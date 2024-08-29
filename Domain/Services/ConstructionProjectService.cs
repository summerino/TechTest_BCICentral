using Microsoft.EntityFrameworkCore;
using NuGet.ProjectModel;
using System;
using TechTest_BCICentral.Data;
using TechTest_BCICentral.Domain.Interfaces;
using TechTest_BCICentral.Models;

namespace TechTest_BCICentral.Domain.Services
{
    public class ConstructionProjectService : IConstructionProjectService
    {
        private readonly TechTest_BCICentralContext _dbContext;

        public ConstructionProjectService(TechTest_BCICentralContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<ConstructionProject>> GetData()
        {
            return await _dbContext.ConstructionProject.ToListAsync();
        }

        public async Task<ConstructionProject> GetDataById(string id)
        {
            return await _dbContext.ConstructionProject.FindAsync(id);
        }

        public async Task<ConstructionProject> InsertData(ConstructionProject constructionProject)
        {
            using var transaction = await _dbContext.Database.BeginTransactionAsync();
            try
            {
                if (constructionProject == null)
                    return null;

                Guid guid = Guid.NewGuid();
                string newGuid = guid.ToString("N")[..6];

                ConstructionProject constProject = new()
                {
                    ProjectId = newGuid,
                    ProjectName = constructionProject.ProjectName,
                    ProjectLocation = constructionProject.ProjectLocation,
                    ProjectStage = constructionProject.ProjectStage,
                    ProjectCategory = constructionProject.ProjectCategory,
                    ProjectConstructionStartDate = constructionProject.ProjectConstructionStartDate,
                    ProjectDetails = constructionProject.ProjectDetails,
                    ProjectCreatorId = constructionProject.ProjectCreatorId
                };

                await _dbContext.ConstructionProject.AddAsync(constProject);
                await _dbContext.SaveChangesAsync();
                await transaction.CommitAsync();

                return constProject;
            }
            catch (Exception)
            {
                await transaction.RollbackAsync();
                throw;
            }
        }

        public async Task<ConstructionProject> UpdateData(ConstructionProject constructionProject)
        {
            using var transaction = await _dbContext.Database.BeginTransactionAsync();
            try
            {
                ConstructionProject constProject = await _dbContext.ConstructionProject.FindAsync(constructionProject.ProjectId);
                if (constructionProject != null)
                {
                    constProject.ProjectName = constructionProject.ProjectName;
                    constProject.ProjectLocation = constructionProject.ProjectLocation;
                    constProject.ProjectStage = constructionProject.ProjectStage;
                    constProject.ProjectCategory = constructionProject.ProjectCategory;
                    constProject.ProjectConstructionStartDate = constructionProject.ProjectConstructionStartDate;
                    constProject.ProjectDetails = constructionProject.ProjectDetails;
                    constProject.ProjectCreatorId = constructionProject.ProjectCreatorId;

                    _dbContext.ConstructionProject.Update(constProject);
                    await _dbContext.SaveChangesAsync();
                    await transaction.CommitAsync();
                }

                return constProject;
            }
            catch (Exception)
            {
                await transaction.RollbackAsync();
                throw;
            }
        }
        public async Task<bool> DeleteData(string id)
        {
            using var transaction = await _dbContext.Database.BeginTransactionAsync();
            try
            {
                ConstructionProject constructionProject = await _dbContext.ConstructionProject.FindAsync(id);
                if (constructionProject != null)
                {
                    _dbContext.ConstructionProject.Remove(constructionProject);
                    await _dbContext.SaveChangesAsync();
                    await transaction.CommitAsync();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                await transaction.RollbackAsync();
                throw;
            }
        }
    }
}

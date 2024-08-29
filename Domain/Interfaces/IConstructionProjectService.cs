using TechTest_BCICentral.Models;

namespace TechTest_BCICentral.Domain.Interfaces
{
    public interface IConstructionProjectService
    {
        Task<IEnumerable<ConstructionProject>> GetData();

        Task<ConstructionProject> GetDataById(string id);

        Task<ConstructionProject> InsertData(ConstructionProject constructionProject);

        Task<ConstructionProject> UpdateData(ConstructionProject constructionProject);

        Task<bool> DeleteData(string id);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TechTest_BCICentral.Data;
using TechTest_BCICentral.Domain.Interfaces;
using TechTest_BCICentral.Models;

namespace TechTest_BCICentral.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConstructionProjectsController : ControllerBase
    {
        private readonly IConstructionProjectService _constructionProject;

        public ConstructionProjectsController(IConstructionProjectService constructionProject)
        {
            _constructionProject = constructionProject;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ConstructionProject>>> GetListConstructionProject()
        {
            return Ok(await _constructionProject.GetData());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ConstructionProject>> GetConstructionProjectById(string id)
        {
            var constructionProject = await _constructionProject.GetDataById(id);

            if (constructionProject == null)
            {
                return NotFound();
            }

            return Ok(constructionProject);
        }

        [HttpPost]
        public async Task<ActionResult<ConstructionProject>> InsertConstructionProject(ConstructionProject constructionProject)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var constructionProjectDt = await _constructionProject.InsertData(constructionProject);

            if (constructionProjectDt == null)
                return NotFound();

            return CreatedAtAction("InsertConstructionProject", constructionProject);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateConstructionProject(ConstructionProject constructionProject)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var constructionProjectDt = await _constructionProject.UpdateData(constructionProject);

            if (constructionProjectDt == null)
                return NotFound();

            return Ok(constructionProject);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteConstructionProject(string id)
        {
            var result = await _constructionProject.DeleteData(id);
            if(result)
                return Ok();
            else
                return NotFound();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ToDoList.Abstractions;
using ToDoList.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ToDoList.Controllers
{
    [Route("api/[controller]")]
    public class AssignmentController : ControllerBase
    {
        private readonly IAssignmentService assignmentService;

        public AssignmentController(IAssignmentService assignmentService)
        {
            this.assignmentService = assignmentService;
        }

        // GET: api/values
        [HttpGet]
        public ActionResult<IEnumerable<Assignment>> Get()
        {
            return Ok(assignmentService.GetAssignments());
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string description)
        {
            assignmentService.CreateAssignment(description);
        }

        // PATCH api/values/5
        [HttpPatch("{id}")]
        public ActionResult PATCH(Guid id)
        {
            var operationResult = assignmentService.CompleteAssignment(id);
            if (operationResult.IsSuccessfull)
            {
                return Ok();
            }
            return NotFound();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public ActionResult Delete(Guid id)
        {
            var operationResult = assignmentService.DeleteAssignment(id); 
            if (operationResult.IsSuccessfull)
            {
                return Ok();
            }
            return NotFound();
        }
    }
}


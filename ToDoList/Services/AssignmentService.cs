using System;
using ToDoList.Abstractions;
using ToDoList.Models;

namespace ToDoList.Services
{
    public class AssignmentService : IAssignmentService
    {
        private readonly IList<Assignment> assignments;

        public AssignmentService()
        {
            this.assignments = new List<Assignment> { new Assignment { Id = Guid.NewGuid(), Description = "Get my hair cut", IsCompleted = false } };
        }

        public IList<Assignment> GetAssignments()
        {
            return this.assignments;
        }

        public void CreateAssignment(string description)
        {
            var newAssignment = new Assignment { Id = Guid.NewGuid(), Description = description, IsCompleted = false };
            assignments.Add(newAssignment);
        }

        public OperationResult CompleteAssignment(Guid id)
        {
            var assignment = assignments.FirstOrDefault(x => x.Id == id);
            if (assignment != null)
            {
                assignment.IsCompleted = true;
                return new OperationResult { IsSuccessfull = true, Message = "OK" };
            }
            return new OperationResult { IsSuccessfull = false, Message = "Assignment not found" };
        }

        public OperationResult DeleteAssignment(Guid id)
        {
            var assignment = assignments.FirstOrDefault(x => x.Id == id);
            if (assignment != null)
            {
                assignments.Remove(assignment);
                return new OperationResult { IsSuccessfull = true, Message = "OK" };
            }
            return new OperationResult { IsSuccessfull = false, Message = "Assignment not found" };
        }
    }
}


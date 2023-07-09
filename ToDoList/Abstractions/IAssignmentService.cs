using ToDoList.Models;

namespace ToDoList.Abstractions
{
    public interface IAssignmentService
    {
        OperationResult CompleteAssignment(Guid id);
        void CreateAssignment(string description);
        OperationResult DeleteAssignment(Guid id);
        IList<Assignment> GetAssignments();
    }
}
using Shared.Commands;

namespace Domain.Commands.Results
{
    public class GenericCommandResult : ICommandResult
    {
        public GenericCommandResult(string message, bool status)
        {
            Message = message;
            Status = status;
        }

        public string Message { get; set; }
        public bool Status { get; set; }
    }
}
namespace RetailInMontionTest.SharedDomain
{
    public class BusinessException : Exception
    {
        public IReadOnlyList<string> Errors { get; } = new List<string>();
        public BusinessException(string? message) : base(message)
        {
        }

        public BusinessException(string message, List<string> errors) : base(message)
        {
            Errors = errors;
        }
    }
}

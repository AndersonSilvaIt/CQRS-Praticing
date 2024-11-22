namespace CleanArch.Domain.Validation
{
    public class DomainValidation : Exception
    {
        public DomainValidation(string message) : base(message) { }

        public static void When(bool hasError, string error)
        {
            if (hasError)
                throw new DomainValidation(error);
        }
    }
}
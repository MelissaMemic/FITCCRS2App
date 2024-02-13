namespace FITCCRS2App.Services;
public class DuplicateEntityException : Exception
{
    public DuplicateEntityException(string message) : base(message) { }
}

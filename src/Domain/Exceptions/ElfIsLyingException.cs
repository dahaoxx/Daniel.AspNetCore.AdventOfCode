namespace One.ElfCalories.Exceptions;

public class ElfIsLyingException : Exception
{
    public ElfIsLyingException() { }

    public ElfIsLyingException(string message) : base(message) { }
}
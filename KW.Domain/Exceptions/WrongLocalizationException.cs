namespace KW.Domain.Exceptions;

public class WrongLocalizationException : Exception
{
    public WrongLocalizationException(string coords)
        : base($"After splitting coords \"{coords}\" cannot found 2 values.")
    {
    }
}
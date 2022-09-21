using KW.Domain.Exceptions;

namespace KW.Domain.ValueObjects;

public class Localization : ValueObject
{
    static Localization()
    {
    }

    private Localization()
    {
    }

    private Localization(double? latitude, double? longtitude)
    {
        Latitude = latitude;
        Longtitude = longtitude;
    }

    public static Localization From(string coords)
    {
        var arr = coords.Split(";");
        if (arr.Length != 2)
            throw new WrongLocalizationException(coords);

        var loc = new Localization(double.Parse(arr[0]), double.Parse(arr[1]));
        return loc;
    }

    public double? Latitude { get; }
    public double? Longtitude { get; }

    public static implicit operator string(Localization localization)
    {
        return localization.ToString();
    }

    public static explicit operator Localization(string code)
    {
        return From(code);
    }

    public override string ToString()
    {
        return $"{Latitude};{Longtitude}";
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return ToString();
    }
}

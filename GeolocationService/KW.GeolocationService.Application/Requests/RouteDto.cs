using System.Text.Json.Serialization;

namespace KW.GeolocationService.Application.Requests;

public class RouteDto
{
    [JsonPropertyName("hints")]
    public Hints Hints { get; set; }

    [JsonPropertyName("info")]
    public Info Info { get; set; }

    [JsonPropertyName("paths")]
    public Paths[] Paths { get; set; }
}

public class Hints
{
    [JsonPropertyName("visited_nodes.sum")]
    public int Sum { get; set; }

    [JsonPropertyName("visited_nodes.average")]
    public float Average { get; set; }
}

public class Info
{
    [JsonPropertyName("copyrights")]
    public string[] Copyrights { get; set; }

    [JsonPropertyName("took")]
    public int Took { get; set; }
}

public class Paths
{
    [JsonPropertyName("distance")]
    public double Distance { get; set; }

    [JsonPropertyName("weight")]
    public double Weight { get; set; }

    [JsonPropertyName("time")]
    public int Time { get; set; }

    [JsonPropertyName("transfer")]
    public int Transfer { get; set; }

    [JsonPropertyName("points_encoded")]
    public bool PointsEncoded { get; set; }

    [JsonPropertyName("bbox")]
    public double[] Bbox { get; set; }

    [JsonPropertyName("points")]
    public Points Points { get; set; }

    [JsonPropertyName("instructions")]
    public Instruction[] Instructions { get; set; }

    [JsonPropertyName("ascend")]
    public double Ascend { get; set; }

    [JsonPropertyName("descend")]
    public double Descend { get; set; }

    [JsonPropertyName("snapped_waypoints")]
    public Points SnappedWaypoints { get; set; }
}

public class Points
{
    [JsonPropertyName("type")]
    public string Type { get; set; }

    [JsonPropertyName("coordinates")]
    public double[][] Coordinates{ get; set; }
}

public class Instruction
{
    [JsonPropertyName("distance")]
    public double Distance { get; set; }

    [JsonPropertyName("heading")]
    public double Heading { get; set; }

    [JsonPropertyName("sign")]
    public int Sign { get; set; }

    [JsonPropertyName("interval")]
    public int[] Interval { get; set; }

    [JsonPropertyName("text")]
    public string Text { get; set; }

    [JsonPropertyName("time")]
    public int Time { get; set; }

    [JsonPropertyName("streetName")]
    public string StreetName { get; set; }

    [JsonPropertyName("exited")]
    public bool Exited { get; set; }

    [JsonPropertyName("turn_angle")]
    public double TurnAngel { get; set; }

    [JsonPropertyName("exit_number")]
    public int ExitNumber { get; set; }
}
namespace KW.Application.Requests.RoadObjectsReports;

public class ReportsByRoadObjectSpec : Specification<RoadObjectReport>
{
    public ReportsByRoadObjectSpec(Guid roadObjectId) =>
        Query.Where(p => p.RoadObjectId == roadObjectId);
}
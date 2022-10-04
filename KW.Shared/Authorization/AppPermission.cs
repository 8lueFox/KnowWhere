using System.Collections.ObjectModel;

namespace KW.Shared.Authorization;

public record AppPermission(string Description, string Action, string Resource, bool IsBasic = false, bool IsRoot = false)
{
    public string Name => NameFor(Action, Resource);

    public static string NameFor(string action, string resource) => $"Permissions.{resource}.{action}";
}

public static class AppPermissions
{
    private static readonly AppPermission[] _all = new AppPermission[]
    {
        new("View Road Objects", AppAction.View, AppResource.RoadObjects, true),
        new("Search Road Objects", AppAction.Search, AppResource.RoadObjects, true),
        new("Create Road Objects", AppAction.Create, AppResource.RoadObjects),
        new("Update Road Objects", AppAction.Update, AppResource.RoadObjects),
        new("Delete Road Objects", AppAction.Delete, AppResource.RoadObjects)
    };

    public static IReadOnlyList<AppPermission> All { get; } = new ReadOnlyCollection<AppPermission>(_all);
    public static IReadOnlyList<AppPermission> Root { get; } = new ReadOnlyCollection<AppPermission>(_all.Where(p => p.IsRoot).ToArray());
    public static IReadOnlyList<AppPermission> Admin { get; } = new ReadOnlyCollection<AppPermission>(_all.Where(p => !p.IsRoot).ToArray());
    public static IReadOnlyList<AppPermission> Basic { get; } = new ReadOnlyCollection<AppPermission>(_all.Where(p => p.IsBasic).ToArray());
}

public static class AppAction
{
    public const string View = nameof(View);
    public const string Search = nameof(Search);
    public const string Create = nameof(Create);
    public const string Update = nameof(Update);
    public const string Delete = nameof(Delete);
    public const string Export = nameof(Export);
    public const string Generate = nameof(Generate);
    public const string Clean = nameof(Clean);
}

public static class AppResource
{
    public const string Dashboard = nameof(Dashboard);
    public const string Hangfire = nameof(Hangfire);
    public const string Users = nameof(Users);
    public const string UserRoles = nameof(UserRoles);
    public const string Roles = nameof(Roles);
    public const string RoleClaims= nameof(RoleClaims);
    public const string RoadObjects= nameof(RoadObjects);
    public const string RoadObjectReports= nameof(RoadObjectReports);
}
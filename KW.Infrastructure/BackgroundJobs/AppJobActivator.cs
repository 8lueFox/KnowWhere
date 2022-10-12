//using Hangfire;
//using Hangfire.Server;
//using KW.Infrastructure.Common;
//using Microsoft.Extensions.DependencyInjection;

//namespace KW.Infrastructure.BackgroundJobs;

//public class AppJobActivator : JobActivator
//{
//    private readonly IServiceScopeFactory _scopeFactory;

//    public AppJobActivator(IServiceScopeFactory scopeFactory) =>
//        _scopeFactory = scopeFactory ?? throw new ArgumentNullException(nameof(scopeFactory));

//    public override JobActivatorScope BeginScope(PerformContext context) =>
//        new Scope(context, _scopeFactory.CreateScope());

//    private class Scope : JobActivatorScope, IServiceProvider
//    {
//        private readonly PerformContext _context;
//        private readonly IServiceScope _scope;

//        public Scope(PerformContext context, IServiceScope scope)
//        {
//            _context = context;
//            _scope = scope;

//            ReceiveParameters();
//        }

//        private void ReceiveParameters()
//        {
//            string userId = _context.GetJobParameter<string>(QueryStringKeys.UserId);
//            if(!string.IsNullOrEmpty(userId))
//                _scope.ServiceProvider.GetRequiredService
//        }

//        public object? GetService(Type serviceType)
//        {
//            throw new NotImplementedException();
//        }

//        public override object Resolve(Type type)
//        {
//            throw new NotImplementedException();
//        }
//    }
//}

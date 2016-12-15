using Ninject.Modules;
using ParrotWingsTransfer.CqsDataModel.CqsCore;
using ParrotWingsTransfer.CqsDataModel.Transfer.Command;
using ParrotWingsTransfer.CqsDataModel.Transfer.Query;
using ParrotWingsTransfer.EFDataAccess;
using ParrotWingsTransfer.EFDataAccess.Transfer.Command;
using ParrotWingsTransfer.EFDataAccess.Transfer.Query;

namespace ParrotWingsTransfer.API.Infrastructure
{
    public class Configuration : NinjectModule
    {
        public override void Load()
        {
            // Infrastructure
            Bind<IQueryFactory>().ToMethod(t => new QueryFactory(x => Container.Current.Resolve(x))).InTransientScope();
            Bind<ICommandsFactory>()
                .ToMethod(t => new CommandFactory(x => (object[])Container.Current.ResolveAll(x)))
                .InTransientScope();

            // DbContext
            Bind<AuthContext>().ToSelf().WithConstructorArgument("connectionString", "name=AngularJSAuth");

            // Queries
            Bind<IGetTemplateMatchNamesQuery>().To<GetTemplateMatchNamesQuery>().InTransientScope();
            Bind<IGetHistoryItemsQuery>().To<GetHistoryItemsQuery>().InTransientScope();

            // Commands
            Bind<ICommandHandler<AddTransactionCommand>>().To<AddTransactionCommandHandler>().InTransientScope();
            
            //Bind<ProcessArchiveService>().ToSelf().InTransientScope();
        }
    }
}


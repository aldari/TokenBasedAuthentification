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
//            Bind<IQueryFactory>().ToMethod(t => new QueryFactory(x => Container.Current.Resolve(x))).InThreadScope();
//            Bind<ICommandsFactory>()
//                .ToMethod(t => new CommandFactory(x => (object[])Container.Current.ResolveAll(x)))
//                .InThreadScope();

            // DbContext
            Bind<AuthContext>().ToSelf().InThreadScope().WithConstructorArgument("connectionString", "name=ParrotWingsTransfer");

            // Queries
            Bind<IGetTemplateMatchNamesQuery>().To<GetTemplateMatchNamesQuery>().InThreadScope();
            Bind<IGetHistoryItemsQuery>().To<GetHistoryItemsQuery>().InThreadScope();

            // Commands
            Bind<ICommandHandler<AddTransactionCommand>>().To<AddTransactionCommandHandler>().InThreadScope();
            
            //Bind<ProcessArchiveService>().ToSelf().InTransientScope();
        }
    }
}


using Autofac;

using BeymenCase.Data.Repositories;
using BeymenCase.Data.UnitOfWork;
using BeymenCase.Service.Services;

using MapsterMapper;

using SahaBT.Retro.Data.UnitOfWork;

namespace BeymenCase.Service.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {

            #region Helper
            #endregion

            builder.RegisterType<Mapper>().As<IMapper>();
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>();

            #region Services

            builder.RegisterType<SettingService>().As<ISettingService>();

            #endregion

            #region Repository
            builder.RegisterType<SettingRepository>().As<ISettingRepository>();

            #endregion

        }
    }
}
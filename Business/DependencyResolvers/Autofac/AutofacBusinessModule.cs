using Autofac;
using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete;

namespace Business.DependencyResolvers.Autofac
{
	public class AutofacBusinessModule : Module
	{
		protected override void Load(ContainerBuilder builder)
		{
			builder.RegisterType<TravelManager>().As<ITravelService>();
			builder.RegisterType<EfTravelDal>().As<ITravelDal>();

			builder.RegisterType<PassengerManager>().As<IPassengerService>();
			builder.RegisterType<EfPassengerDal>().As<IPassengerDal>();
		}
	}
}

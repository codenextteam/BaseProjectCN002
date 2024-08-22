using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstract;
using Business.Concrete;
using Castle.DynamicProxy;
using Core.Helpers.Business.ImageHelper;
using Core.Helpers.Interceptors;
using DataAccess.Abstract;
using DataAccess.Concrete.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ProductManager>().As<IProductService>().SingleInstance();
            builder.RegisterType<EfProductDal>().As<IProductDal>().SingleInstance();
			builder.RegisterType<EfProductImageDal>().As<IProductImageDal>().SingleInstance();
			builder.RegisterType<ProductImageManager>().As<IProductImageService>().SingleInstance();

			builder.RegisterType<CategoryManager>().As<ICategoryService>().SingleInstance();
            builder.RegisterType<EfCategoryDal>().As<ICategoryDal>().SingleInstance();
            builder.RegisterType<OrderManager>().As<IOrderService>().SingleInstance();
            builder.RegisterType<EfOrderDal>().As<IOrderDal>().SingleInstance();
			builder.RegisterType<ServiceHeadManager>().As<IServiceHeadService>().SingleInstance();
			builder.RegisterType<EfServiceHeadDal>().As<IServiceHeadDal>().SingleInstance();
			builder.RegisterType<ServiceItemManager>().As<IServiceItemService>().SingleInstance();
			builder.RegisterType<EfServiceItemDal>().As<IServiceItemDal>().SingleInstance();
			builder.RegisterType<OrderDetailManager>().As<IOrderDetailService>().SingleInstance();
            builder.RegisterType<EfOrderDetailDal>().As<IOrderDetailDal>().SingleInstance();
            builder.RegisterType<EcommerceCN002Context>().As<EcommerceCN002Context>().SingleInstance();
			builder.RegisterType<AddImageHelper>().As<IImageAddHelper>().SingleInstance();

			var assembly = System.Reflection.Assembly.GetExecutingAssembly();
            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();
        }


    }
}

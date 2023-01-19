using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstract;
using Business.CCS;
using Business.Concrete;
using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using Core.Utilities.Security.JWT;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule :Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ProductManager>().As<IProductService>().SingleInstance();
            builder.RegisterType<EfProductDal>().As<IProductDal>().SingleInstance();

            builder.RegisterType<UserManager>().As<IUserService>();
            builder.RegisterType<EfUserDal>().As<IUserDal>();

            builder.RegisterType<AuthManager>().As<IAuthService>();
            builder.RegisterType<JwtHelper>().As<ITokenHelper>();

            builder.RegisterType<OrderManager>().As<IOrderService>().SingleInstance();
            builder.RegisterType<EfOrderDal>().As<IOrderDal>().SingleInstance();

            builder.RegisterType<InvoiceManager>().As<IInvoiceService>();
            builder.RegisterType<EfInvoiceDal>().As<IInvoiceDal>();

            builder.RegisterType<BalanceManager>().As<IBalanceService>().SingleInstance();
            builder.RegisterType<EfBalanceDal>().As<IBalanceDal>().SingleInstance();

           builder.RegisterType<UserCreditManager>().As<IUserCreditService>().SingleInstance();
           builder.RegisterType<EfUserCreditDal>().As<IUserCreditDal>().SingleInstance();

            builder.RegisterType<UserOperationClaimManager>().As<IUserOperationClaimService>().SingleInstance();
            builder.RegisterType<EfUserOperationClaimDal>().As<IUserOperationClaimDal>().SingleInstance();

            builder.RegisterType<UserDiscountGroupManager>().As<IUserDiscountGroupService>().SingleInstance();
            builder.RegisterType<EfUserDiscountGroupDal>().As<IUserDiscountGroupDal>().SingleInstance();

            builder.RegisterType<DiscountGroupManager>().As<IDiscountGroupService>().SingleInstance();
            builder.RegisterType<EfDiscountGroupDal>().As<IDiscountGroupDal>().SingleInstance();


            builder.RegisterType<UseCreditManager>().As<IUseCreditService>().SingleInstance();
            builder.RegisterType<EfUseCreditDal>().As<IUseCreditDal>().SingleInstance();

            // builder.RegisterType<HttpContextAccessor>().As<IHttpContextAccessor>();

            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();
        }
    }
}

using System;
using Autofac;
using BussinessLogic.Abstract;
using BussinessLogic.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.ADONET;
using DataAccess.Concrete.DAPPER;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace BussinessLogic.DependencyResolver
{
    public class AutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CategoryManager>().As<ICategoryService>().InstancePerLifetimeScope();
            builder.RegisterType<DapperCategory>().As<ICategoryDAL>().InstancePerLifetimeScope();
            builder.RegisterType<GameManager>().As<IGameService>().InstancePerLifetimeScope();
            builder.RegisterType<AdoGame>().As<IGameDAL>().InstancePerLifetimeScope();
            builder.RegisterType<CartManager>().As<ICartService>().InstancePerLifetimeScope();
            builder.RegisterType<DapperCart>().As<ICartDAL>().InstancePerLifetimeScope();
            builder.RegisterType<AdoGameCategory>().As<IGameCategoryDAL>().InstancePerLifetimeScope();
            builder.RegisterType<GameCategoryManager>().As<IGameCategoryService>().InstancePerLifetimeScope();
            builder.Register(c =>
            {
                return new GamesectionDbContext();
            }).AsSelf().InstancePerLifetimeScope();
            
    }
    }
}

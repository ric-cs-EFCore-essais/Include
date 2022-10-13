using System.Collections.Generic;

using Domain.Repositories.Interfaces.Ports;
using Domain.Entities.Ports;
using Infra.DataContext.Interfaces.Ports;
using Domain.Repositories.Interfaces;
using Domain.Entities.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Domain.Entities;
using System;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Query;
using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;
//using Infra.DataContext.Interfaces;

namespace Infra.Repositories.Ports
{
    //public interface IXEfQueryable<TEntity>
    //{
    //    IIncludableQueryable<TEntity, TProperty> Includez<TProperty>([NotNullAttribute] Expression<Func<TEntity, TProperty>> navigationPropertyPath);
    //}
    //public partial interface IEnumerableQueryable<TEntity> : IXEfQueryable<TEntity> { }

    //public abstract class AefRepository<TEntity> : ARepository<TEntity, IEnumerableQueryable<TEntity>> //, IRepository<TEntity, IQueryable<TEntity>>
    //    where TEntity : AEntity
    //{
    //    private readonly DbContext dataContext;

    //    protected AefRepository(DbContext dataContext)
    //    {
    //        this.dataContext = dataContext;
    //    }

    //    protected override IEnumerableQueryable<TEntity> GetEntities()
    //    {
    //        IEnumerableQueryable<TEntity> r = dataContext.Set<TEntity>() as IEnumerableQueryable<TEntity>;
    //        r.Includez(x => x.Id);
    //        return r;
    //    }
    //}
}

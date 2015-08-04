using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2
{
    public class Entity<TModel>:NetWorkGroup.Abstraction.AbstractBase<TModel> where TModel:class , new()
    {
        public override IQueryable<TModel> Show(System.Linq.Expressions.Expression<Func<TModel, bool>> KeyValue)
        {
            return this.Show().Where(KeyValue);
        }

        public override IQueryable<TModel> Show()
        {
            return (IQueryable<TModel>)base.DbContext.getTable;
        }
    }
}
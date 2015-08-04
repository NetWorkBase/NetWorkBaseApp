using NetWorkGroup.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Sample.Entity
{
    public class Entity<TModel> : AbstractBase<TModel> where TModel : class,new()
    {

        public override IQueryable<TModel> Show()
        {
            try
            {
                return base.DbContext.getTable;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public override IQueryable<TModel> Show(Expression<Func<TModel, bool>> KeyValue)
        {
            return this.Show().Where(KeyValue);
        }
    }
}

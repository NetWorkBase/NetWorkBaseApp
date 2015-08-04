using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NetWorkGroup.Abstraction;
using System.Linq.Expressions;
using System.Data.SqlClient;
using NetWorkGroup.Data;

namespace NetWorkGroup.Entity
{
    /// <summary>
    /// 默认程序实现，继承自多功能处理基类，用于实现具体功能
    /// </summary>
    /// <typeparam name="TModel">任意模型类</typeparam>
    /// <typeparam name="TType">模型类所实现IModelID中的标识列类型</typeparam>
    public class EntityLogic<TModel, TType> : MultiAbstract<TModel> where TModel : class,IModelID<TType>, new()
    {
        /// <summary>
        /// 默认构造函数
        /// </summary>
        public EntityLogic() { }
        /// <summary>
        /// 构造函数重载
        /// </summary>
        /// <param name="ConnectionString">数据库连接字符串</param>
        public EntityLogic(DbConnectionString ConnectionString) : base(ConnectionString) { }
        /// <summary>
        /// 显示所有数据根据指定条件返回
        /// </summary>
        /// <param name="KeyValue">条件表达式</param>
        /// <returns>IQueryable</returns>
        public override IQueryable<TModel> Show(Expression<Func<TModel, bool>> KeyValue)
        {
            return this.Show().Where(KeyValue);
        }
        /// <summary>
        /// 显示所有数据
        /// </summary>
        /// <returns>IQueryable</returns>
        public override IQueryable<TModel> Show()
        {
            return base.DbContext.getTable.As<IQueryable<TModel>>();
        }
        /// <summary>
        /// 增加新的数据
        /// </summary>
        /// <param name="Msg">可选参数，执行成功之后的返回值</param>
        public override void Append(string Msg = "增加成功")
        {
            try
            {
                base.DbContext.getTable.InsertOnSubmit(base.DbContext.Model);
                base.DbContext.SubmitChanges();
                base.SetReturnValue(Msg);
            }
            catch (SqlException err)
            {
                throw err;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        /// <summary>
        /// 删除信息
        /// </summary>
        /// <param name="Msg">可选参数，执行成功之后的返回值</param>
        public override void Delete(string Msg = "删除成功")
        {
            try
            {
                if (base.DbContext.getTable.Count(p => p.ID.Equals(DbContext.Model.ID)) > 0)
                {
                    TModel tmp = base.DbContext.getTable.As<IEnumerable<TModel>>().Single(p => p.ID.Equals(DbContext.Model.ID));
                    base.DbContext.getTable.DeleteOnSubmit(tmp);
                    base.DbContext.SubmitChanges();
                    base.SetReturnValue(Msg);
                }
                else
                {
                    base.SetReturnValue("执行删除失败，未查找到符合的数据！！");
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        /// <summary>
        /// 执行更新
        /// </summary>
        /// <param name="Msg">可选参数，执行成功之后的返回值</param>
        public override void Update(string Msg = "更新成功")
        {
            try
            {
                if (base.DbContext.getTable.Count(p => p.ID.Equals(DbContext.Model.ID)) > 0)
                {
                    TModel Current = DbContext.Model;
                    TModel tmp = base.DbContext.getTable.As<IEnumerable<TModel>>().Single(p => p.ID.ToString().Trim() == DbContext.Model.ID.ToString().Trim());
                    base.DbContext.Model.CopyObjectProperty(tmp);
                    base.DbContext.SubmitChanges();
                    base.SetReturnValue(Msg);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}

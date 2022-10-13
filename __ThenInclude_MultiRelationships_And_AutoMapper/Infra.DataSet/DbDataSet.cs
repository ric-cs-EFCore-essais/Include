//using System.Collections.Generic;

//using Domain.Entities.Interfaces;
//using Domain.Repositories.Interfaces;
//using Infra.DataSet.Interfaces;

//namespace Infra.DataSet
//{
//    public class DbDataSet<TEntity>: ADataSet<TEntity>, IDataSet<TEntity>
//        where TEntity : IEntity
//    {
//        public DbDataSet(): base()
//        {
//        }

//        public void Save()
//        {
//            throw new System.NotImplementedException();
//        }

//        protected override IEnumerableQueryable<TEntity> Load()
//        {
//            var retour = new List2<TEntity>();
//            return retour;
//        }
//    }
//}

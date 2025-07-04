//using Project.DataAcessLayer.Models.TEntityModels;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Project.DataAcessLayer.Data.Repositories.Interfaces
{
    public interface IGenriceRepo<TEntity> where TEntity : BaseEntity
    {
        int Delete(TEntity Entity);
        IEnumerable<TEntity> GetAll(bool withTracking = false);
        IEnumerable<TEntity> GetAll( Expression<Func<TEntity , bool>> expression );
        TEntity? GetById(int id);
        int Insert(TEntity Entity);
        int Update(TEntity Entity);
    }
}

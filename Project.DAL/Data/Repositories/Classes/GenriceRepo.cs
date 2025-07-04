using Microsoft.EntityFrameworkCore;
//using Project.DataAcessLayer.Models.TEntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Project.DataAcessLayer.Data.Repositories.Classes
{
    public class GenriceRepo<TEntity>(AppDBContext _dbContext) : IGenriceRepo<TEntity> where TEntity : BaseEntity
    {
        public IEnumerable<TEntity> GetAll(bool withTracking = false)
        {
            if (withTracking)
            {
                return _dbContext.Set<TEntity>().Where(Emp => Emp.IsDeleted!= true).ToList();
            }
            else
            {
                return _dbContext.Set<TEntity>().Where(Emp => Emp.IsDeleted != true).AsNoTracking().ToList();
            }
        }

        // Get By Id
        public TEntity? GetById(int id)
        {
            return _dbContext.Set<TEntity>().Find(id);
        }

        // Update
        public int Update(TEntity TEntity)
        {
            if (TEntity == null) return -1;
            _dbContext.Set<TEntity>().Update(TEntity);
            return _dbContext.SaveChanges();

        }

        // delete
        public int Delete(TEntity TEntity)
        {
            if (TEntity == null) return -1;
            _dbContext.Set<TEntity>().Remove(TEntity);
            return _dbContext.SaveChanges();
        }

        // insert
        public int Insert(TEntity TEntity)
        {
            if (TEntity == null) return -1;
            _dbContext.Set<TEntity>().Add(TEntity);
            return _dbContext.SaveChanges();
        }

        public IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> expression)
        {
           return _dbContext.Set<TEntity>().Where(expression).ToList();
        }
    }
}

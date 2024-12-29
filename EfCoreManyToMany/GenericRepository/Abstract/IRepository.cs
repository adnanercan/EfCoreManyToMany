
using EfCoreManyToMany.FluentApiCozumu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EfCoreManyToMany.GenericRepository.Abstract
{

    public interface IRepository<T> where T : class
    {
        public int Insert(T entity);
        public int Update(T entity);
        public int Delete(T entity);
        public T GetById(int id);
        public List<T> GetAll(Expression<Func<T, bool>>? filter = null);
        public IQueryable<T>? GetAllInclude(Expression<Func<T, bool>> filter = null,
            params Expression<Func<T, object>>[] include);
    }

}

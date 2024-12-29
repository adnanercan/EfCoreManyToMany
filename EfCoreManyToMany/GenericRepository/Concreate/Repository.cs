
using EfCoreManyToMany.FluentApiCozumu;
using EfCoreManyToMany.GenericRepository.Abstract;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;


namespace EfCoreManyToMany.GenericRepository.Concreate
{

    public class Repository<T> : IRepository<T> where T : class
    {
        public readonly FluentApiDbContext db;
        public Repository()
        {
            db = new FluentApiDbContext();
        }

        public virtual int Insert(T entity)
        {
            db.Set<T>().AddAsync(entity);
            return db.SaveChanges();
        }

        public virtual int Update(T entity)
        {
            db.Set<T>().Update(entity);
            return db.SaveChanges();
        }
        public virtual int Delete(T entity)
        {
            db.Set<T>().Remove(entity);
            return db.SaveChanges();
        }

        public virtual T? GetById(int id)
        {
            return db.Set<T>().Find(id);

        }
        public virtual ICollection<T>? GetAll(Expression<Func<T, bool>> filter = null)
        {
            if (filter == null)
            {
                return db.Set<T>().ToList();
            }
            return db.Set<T>().Where(filter).ToList();

        }

        public virtual IQueryable<T>? GetAllInclude(Expression<Func<T, bool>> filter = null, params Expression<Func<T, object>>[] include)
        {

            // var result = db.GetAllInclude(p=>p.ProductName=="xyz" ,p=>p.Category,p=>Suplier);
            IQueryable<T> query;
            if (filter == null)
            {
                query = db.Set<T>();
            }
            else
            {
                query = db.Set<T>().Where(filter);
            }

            return include.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
        }

        public virtual T? Get(Expression<Func<T, bool>> filter)
        {
            return db.Set<T>().FirstOrDefault(filter);
        }

        List<T> IRepository<T>.GetAll(Expression<Func<T, bool>>? filter)
        {
            throw new NotImplementedException();
        }
    }
}

using SportsNews.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SportsNews.Service.BaseService.Abstraction
{
    public interface IBaseService<T> where T:BaseEntity
    {
        void Add(T item);
        void Add(List<T> items);

        void Update(T item);

        void Remove(int id);

        T GetById(int id);
        T GetByDefault(Expression<Func<T, bool>> exp);

        List<T> GetDefault(Expression<Func<T, bool>> exp);
        List<T> GetActive();
        List<T> GetAll();

        bool Any(Expression<Func<T, bool>> exp);

        int Save();
    }
}

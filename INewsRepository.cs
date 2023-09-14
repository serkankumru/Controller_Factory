using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface INewsRepository
    {
        List<NewsT> List();
        void Add(NewsT entity);
        void Update(NewsT entity);
        void Remove(int entityId);
        NewsT FindById(int EntityId);
    }
}

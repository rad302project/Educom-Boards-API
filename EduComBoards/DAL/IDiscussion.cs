using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduComBoards.DAL
{
    public interface IDiscussion<T>
    {
        IEnumerable<T> GetAll();
        T GetByID(string id);
        T Put(T item);
    }
}

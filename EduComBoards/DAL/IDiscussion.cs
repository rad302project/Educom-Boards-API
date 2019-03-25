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
        List<T> SearchBoards(string searchTerm);
        T GetByID(int id);
        T Put(T item);
        T Create(T item);
        void Delete(int id);
    }
}

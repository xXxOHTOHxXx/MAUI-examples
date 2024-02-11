using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab3.Entities;

namespace Lab3.Services
{
    public interface IDbService
    {
        public IEnumerable<Author> GetAllAuthors();
        public IEnumerable<Book> GetAuthorsBooks(int id);
        void Init();
    }
}

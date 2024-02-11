using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection.PortableExecutable;
using Lab3.Entities;
using SQLite;


namespace Lab3.Services
{
    public class SQLiteService : IDbService
    {
        SQLiteConnection database;
        public IEnumerable<Author> GetAllAuthors()
        {
            return database.Table<Author>().ToList();
        }
        public IEnumerable<Book> GetAuthorsBooks(int id)
        {
            return database.Table<Book>().Where(x=>x.AuthorID==id).ToList();
        }
        public void Init()
        {
            try
            {
                 database = new SQLiteConnection(Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.Personal),
                "lab3db.db3"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            if(!(File.Exists(Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.Personal),
            "lab3db.db3"))))
            {
                database.CreateTable<Author>();
                database.CreateTable<Book>();



                var author1 = new Author { Name = "Автор 1", Country = "Страна 1", Age = 40 };
                var author2 = new Author { Name = "Автор 2", Country = "Страна 2", Age = 50 };
                database.Insert(author1);
                database.Insert(author2);


                for (int i = 1; i <= 5; i++)
                {
                    var book1 = new Book { Title = $"Книга {i} Автора 1", PagesNumber = $"{100 + i}", Rating = 4.0 + i / 10.0, AuthorID = author1.ID };
                    var book2 = new Book { Title = $"Книга {i} Автора 2", PagesNumber = $"{100 + i}", Rating = 4.0 + i / 10.0, AuthorID = author2.ID };
                    database.Insert(book1);
                    database.Insert(book2);
                }
            }
        }
    }
}

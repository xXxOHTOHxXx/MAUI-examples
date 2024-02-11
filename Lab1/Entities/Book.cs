using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3.Entities
{
    [SQLite.Table("Books")]
    public class Book
    {
        [PrimaryKey, AutoIncrement, Indexed]
        [SQLite.Column("ID")]
        public int BookID { get; set; }
        public string Title { get; set; }
        public string PagesNumber { get; set; }
        public double Rating { get; set; }
        [Indexed]
        public int AuthorID { get; set; }
    }
}

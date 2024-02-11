using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace Lab3.Entities
{
    [SQLite.Table("Authors")]
    public class Author
    {
        [PrimaryKey, AutoIncrement, Indexed]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public int Age { get; set; }
    }
}

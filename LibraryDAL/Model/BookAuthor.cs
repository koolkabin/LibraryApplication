using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryDAL.Model
{

    public class BookAuthor : _AbsEntity
    {
        [MaxLength(255)]
        public string FullName { get; set; }

        public virtual ICollection<Book> Books { get; set; }
        public BookAuthor()
        {
            Books = new HashSet<Book>();
        }
    }

}

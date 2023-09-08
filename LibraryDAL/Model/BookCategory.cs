using System.ComponentModel.DataAnnotations;

namespace LibraryDAL.Model
{
    public class BookCategory : _AbsEntity
    {
        [MaxLength(255)]
        public string CategoryName { get; set; }
        [MaxLength(25)]
        public string Code { get; set; }
        public virtual ICollection<Book> Books { get; set; }
        public BookCategory()
        {
            Books = new HashSet<Book>();
        }

    }
}

using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryDAL.Model
{
    public class Book : _AbsEntity
    {
        public string ISBN { get; set; }
        public string BookTitle { get; set; }
        [ForeignKey("BookCategory")]
        public int BookCategoryId { get; set; }
        [ForeignKey("BookAuthor")]
        public int AuthorId { get; set; }
        public virtual BookAuthor BookAuthor { get; set; }
        public virtual BookCategory BookCategory { get; set; }
        public virtual ICollection<StudentBookRequest> StudentBookRequests { get; set; }
        public Book()
        {
            StudentBookRequests = new HashSet<StudentBookRequest>();
        }

    }
}

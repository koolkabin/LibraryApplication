using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.Design;

namespace LibraryDAL.Model
{
    public class StudentBookRequest : _AbsEntity
    {
        [ForeignKey("Book")]
        public int BookId { get; set; }
        [ForeignKey("Student")]
        public int StudentId { get; set; }
        public DateTime RequestDate { get; set; }
        public string Remarks { get; set; }
        public bool Status { get; set; }
        public virtual Book Book { get; set; }
        public virtual Student Student { get; set; }
    }


}

using System.ComponentModel.DataAnnotations;

namespace LibraryDAL.Model
{
    public class SystemOperator : _AbsEntity
    {
        [MaxLength(255)]
        public string FullName { get; set; }
        [MaxLength(255)]
        public string Code { get; set; }
        [MaxLength(255)]
        public string Address { get; set; }
        [MaxLength(50)]
        public string Mobile { get; set; }
        [MaxLength(255)]
        public string Email { get; set; }
    }
}

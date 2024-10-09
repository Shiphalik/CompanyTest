using System.ComponentModel.DataAnnotations;

namespace CompanyTest.Models
{
    public class TEACHER
    {
        public int TEACHERID { get; set; }
        [Required(ErrorMessage = "Please Enter Your Name")]
        public string NAME { get; set; }
        public string IMAGE { get; set; }
        [Required(ErrorMessage = "Please Enter Your Age")]
        public string AGE { get; set; }
        [Required(ErrorMessage = "Please Enter Your Gender")]
        public string GENDER { get; set; }
        public ICollection<SUBJECTS> SUBJECTS { get; set; }
    }
}

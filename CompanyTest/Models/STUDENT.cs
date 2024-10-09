using System.ComponentModel.DataAnnotations;

namespace CompanyTest.Models
{
    public class STUDENT
    {
        [Key]
       public int ID { get; set; }

        [Required(ErrorMessage = "Please Enter Your Name")]
        public string NAME { get; set; }

        [Required(ErrorMessage = "Please Enter Your Age")]
        public string AGE { get; set; }
        public string IMAGEPATH { get; set; }

        public string CLASS { get; set; }
        [Required(ErrorMessage = "Please Enter Your ROLL NUMBER")]
        public int ROLLNUMBER { get; set; }
    }
}

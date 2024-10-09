using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace CompanyTest.Models
{
    public class SUBJECTS
    {

        public int ID { get; set; }
        [Required(ErrorMessage = "Please Enter Your Name")]
        [Display(Name ="SUBJECT NAME")]
        public string NAME { get; set; }
       
        [Required(ErrorMessage = "Please Enter Your Class")]
        public string CLASS { get; set; }
        public string LANGUAGE { get; set; }
        public int TEACHERID { get;set; }
        public TEACHER TEACHER { get; set; }
    }


}

   
    




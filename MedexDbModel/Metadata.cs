using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedexDbModel
{
    public class PatientMetadata
    {
        public int PatientID { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public System.DateTime BirthDate { get; set; }
        [Required]
        public long IDNP { get; set; }
        [Required]
        public bool Gender { get; set; }
    }

    public class VaccineMetadata
    {
        public int VaccineID { get; set; }
        [Required(ErrorMessage = "Scrie scrie")]
        [MinLength(3, ErrorMessage = "Prea mic!")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Type necesar")]
        public int TypeID { get; set; }
    }

    public class VaccineTypeMetadata
    {
        [Required]
        public int TypeID { get; set; }
        [Required]
        [StringLength(5)]
        public string Description { get; set; }
    }
}

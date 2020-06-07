using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace NeemConsultingTest.Models
{
    public class StudentModel
    {
        ///<summary>
        /// Gets or sets PersonId.
        ///</summary>
        public int PersonId { get; set; }

        ///<summary>
        /// Gets or sets First Name.
        ///</summary>
        ///
        [Display (Name="First Name")]
        [Required(ErrorMessage ="Required")]
        public string FirstName { get; set; }
        ///<summary>
        /// Gets or sets Last Name.
        ///</summary>
        [Display (Name="Last Name")]
        [Required (ErrorMessage ="Required")]
        public string LastName { get; set; }
        ///<summary>
        /// Gets or sets Gender.
        ///</summary>
        [Display(Name = "Gender")]
        [Required (ErrorMessage ="Required")]
        public string Gender { get; set; }

        [Display(Name = "E-Mail")]
        [Required(ErrorMessage = "Required")]
        [EmailAddress]
        public string Email { get; set; }
        ///<summary>
        /// Gets or sets City.
        ///</summary>
        [Display(Name = "City")]
        [Required (ErrorMessage ="Required")]
        public string City { get; set; }
    }
}
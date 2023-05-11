using Microsoft.Build.Framework;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using RequiredAttribute = System.ComponentModel.DataAnnotations.RequiredAttribute;

namespace WebAppMVC.Data.Entities
{
    public class UserProfile
    {
        public int Id { get; set; }

        [Required]
        [StringLength(20, ErrorMessage = "Name length can't be more than 20.")]
        [Display(Name = "First Name")]
        public string? FirstName { get; set; }


        [Required]
        [StringLength(20, ErrorMessage = "Name length can't be more than 20.")]
        [DisplayName("Last Name")]
        public string? LastName { get; set; }

        [Display(Name = "Date Of Birth")]
        [DataType(DataType.DateTime)]
        public DateTime? DateOfBirth { get; set; }

        public string? SlugImage { get; set; }
    }
}

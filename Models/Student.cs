using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Lab4.Models
{
    public class Student
    {
        [Key]
        public int StudentID
        {
            set;
            get;
        }
         
        [Required]
        [StringLength(50)]
        [Display(Name = "Last Name")]
        public string LastName
        {
            set;
            get;
        }

        [Required]
        [StringLength(50)]
        [Display(Name = "First Name")]
        public string FirstName
        {
            set;
            get;
        }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Enrollment Date")]
        public DateTime EnrollmentDate
        {
            set;
            get;
        }

        [Display(Name = "Full Name")]
        public string FullName{
            get
            {
                return LastName + ", " + FirstName;
            }
        }

        public ICollection<CommunityMembership> CommunityMembership
        {
            get;
            set;
        }
    }
}

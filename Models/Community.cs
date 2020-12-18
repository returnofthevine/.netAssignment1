using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Lab4.Models
{
    public class Community
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "Registration Number")]
        [Required]
        public string CommunityID
        {
            get;
            set;
        }

        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Title
        {
            get;
            set;
        }

        [DataType(DataType.Currency)]
        [Column(TypeName = "money")]
        public decimal Budget
        {
            get;
            set;
        }

        public ICollection<CommunityMembership> CommunityMemberships
        {
            get;
            set;
        }
    }
}

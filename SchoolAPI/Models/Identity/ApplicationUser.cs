using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolAPI.Models.Identity
{
    public class ApplicationUser : IdentityUser
    {
        [Column(TypeName = "DATE")] // Store in SQL as a DATE, not DATETIME
        public DateTime? DateOfBirth { get; set; }
    }
}

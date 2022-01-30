using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Finance.Shared;
using System.ComponentModel.DataAnnotations;

namespace Finance.Client.Component
{
    public class EarningModel
    {
        [Required]
        public DateTime Date { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "only 50 characters are allowed")]
        public string Subject { get; set; }

        [Required]
        public EarningCategory Category { get; set; }

        [Required]
        public double Amount { get; set; }
    }
}

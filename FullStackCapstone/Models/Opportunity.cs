using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FullStackCapstone.Models
{
    public class Opportunity
    {
        public int Id  { get; set; }

        [Required]

        public string Title { get; set; }

        [Required]
        [StringLength(300)]
        public string Description { get; set; }

        [Display(Name = "Application Link")]
        public string ApplicationLink { get; set; }

        [DisplayFormat(DataFormatString = "{0:dddd, MMMM dd, yyyy}")]
        [DataType(DataType.Date)]

        public DateTime StartDate { get; set; }

        [DisplayFormat(DataFormatString = "{0:dddd, MMMM dd, yyyy}")]
        [Display(Name = "Program End Date")]
        public DateTime EndDate { get; set; }

        [Display(Name = "Age Group")]
        public string AgeRange { get; set; }

        [Display(Name = "Subject")]
        public int SubjectId { get; set; }

        public Subject Subject  { get; set; }

        [Display(Name = "Program Type")]
        public int ProgramTypeId { get; set; }

        public ProgramType ProgramType { get; set; }

        public bool IsActive { get; set; }

        [DisplayFormat(DataFormatString = "{0:dddd, MMMM dd, yyyy}")]

        [Display(Name = "Application Deadline")]
        public DateTime ApplicationDeadline { get; set; }


    }
}

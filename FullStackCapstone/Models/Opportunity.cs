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
        public string Description { get; set; }

        public string ApplicationLink { get; set; }

        [DisplayFormat(DataFormatString = "{0:dddd, MMMM dd, yyyy}")]
        public DateTime StartDate { get; set; }

        [DisplayFormat(DataFormatString = "{0:dddd, MMMM dd, yyyy}")]
        public DateTime EndDate { get; set; }

        public string AgeRange { get; set; }

        public int SubjectId { get; set; }

        public Subject Subject  { get; set; }

        public int ProgramTypeId { get; set; }

        public ProgramType ProgramType { get; set; }

        public bool IsActive { get; set; }

        [DisplayFormat(DataFormatString = "{0:dddd, MMMM dd, yyyy}")]
        public DateTime ApplicationDeadline { get; set; }


    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FullStackCapstone.Models
{
    public class OppCart
    {
        [Key]
        public int Id { get; set; }

        public int OpportunityId { get; set; }

        public Opportunity Opportunity { get; set; }

        public string UserId { get; set; }

        public ApplicationUser User { get; set; }

        public bool IsComplete { get; set; }
    }
}

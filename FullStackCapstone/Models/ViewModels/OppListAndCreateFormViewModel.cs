﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FullStackCapstone.Models.ViewModels
{
    public class OppListAndCreateFormViewModel
    {
        public List<Opportunity> NewOpportunities { get; set; }
        public List<Opportunity> ActiveOpportunities { get; set; }

        public List<Opportunity> InActiveOpportunities { get; set; }

        public List<Opportunity> Opportunities { get; set; }

        public OppFormViewModel OppForm { get; set; }

        public EditOppViewModel EditOppForm { get; set; }

        public List<OppCart> OppCartItems { get; set; }
    }
}

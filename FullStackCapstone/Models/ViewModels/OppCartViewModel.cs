using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FullStackCapstone.Models.ViewModels
{
    public class OppCartViewModel
    {
        public List<OppCart> OppCarts { get; set; }

        public List<OppCart> OppCartsComplete { get; set; }

        public decimal progressBar { get; set; }
    }
}

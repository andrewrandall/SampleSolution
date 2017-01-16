using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Gadgets
{
    public class GadgetSummary
    {
        public GadgetSummary(string name)
        {
            Name = name;
        }

        public string Name { get; private set; }
    }
}

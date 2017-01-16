using Sample.Gadgets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Widgets
{
    public class WidgetSummary
    {
        public WidgetSummary(int id, string name, IEnumerable<GadgetSummary> gadgets)
        {
            Id = id;
            Name = name;
            Gadgets = gadgets;
        }

        public int Id { get; private set; }
        public string Name { get; private set; }
        public IEnumerable<GadgetSummary> Gadgets { get; private set; }
    }
}

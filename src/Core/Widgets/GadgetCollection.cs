using Sample.Gadgets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Sample.Widgets
{
    public class GadgetCollection : IEnumerable<Gadget>
    {
        HashSet<Gadget> gadgets = new HashSet<Gadget>();

        public GadgetCollection(Widget widget)
        {
            if (widget == null) throw new BrokenBusinessRuleException("Gadgets only exist on Widgets");
        }

        public void AddGadget(string name)
        {
            var gadget = new Gadget(name);
            var added = gadgets.Add(gadget);
            if (!added) throw new BrokenBusinessRuleException("A Widget cannot have two of the same Gadget");
        }

        public IEnumerator<Gadget> GetEnumerator() => gadgets.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}

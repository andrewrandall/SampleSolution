using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Widgets
{
    public class Widget
    {
        public Widget(string name)
        {
            Name = name;
            Gadgets = new GadgetCollection(this);
        }

        string name;
        public string Name
        {
            get { return name; }
            set
            {
                if (string.IsNullOrEmpty(name)) throw new BrokenBusinessRuleException($"{nameof(Name)} is required");
                name = value;
            }
        }

        int? id;
        public int? Id
        {
            get { return id; }
            set
            {
                if (!value.HasValue) throw new BrokenBusinessRuleException($"{nameof(Id)} cannot be set to null");
                if (id.HasValue) throw new BrokenBusinessRuleException($"{nameof(Id)} cannot be changed");
                id = value;
            }
        }

        public GadgetCollection Gadgets { get; private set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Gadgets
{
    public class Gadget
    {
        public Gadget(string name)
        {
            Name = name;
        }

        string name;
        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrEmpty(value)) throw new BrokenBusinessRuleException("Gadgets must have a name");
                name = value;
            }
        }

        public override bool Equals(object obj)
        {
            var other = obj as Gadget;
            return 
                other != null 
                && other.Name.Equals(Name, StringComparison.CurrentCultureIgnoreCase);
        }

        public override int GetHashCode() => Name.GetHashCode();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample
{
    public class BrokenBusinessRuleException : Exception
    {
        public BrokenBusinessRuleException(string explanation)
            : base("That is not allowed")
        {
            Explanation = explanation;
        }

        public string Explanation { get; private set; }
    }
}

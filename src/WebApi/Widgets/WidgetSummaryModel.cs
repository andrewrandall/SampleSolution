using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sample.Widgets
{
    public class WidgetSummaryModel
    {
        public WidgetSummaryModel(WidgetSummary widgetSummary)
        {
            Id = widgetSummary.Id;
            Name = widgetSummary.Name;
            Gadgets = widgetSummary.Gadgets.Select(x => x.Name);
        }

        public int Id { get; private set; }
        public string Name { get; private set; }
        public IEnumerable<string> Gadgets { get; private set; }
    }
}
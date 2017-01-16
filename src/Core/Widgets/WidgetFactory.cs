using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Widgets
{
    public class WidgetFactory
    {
        ISaveWidget saveCmd;

        public WidgetFactory(ISaveWidget saveCmd)
        {
            if (saveCmd == null) throw new ArgumentNullException(nameof(saveCmd));

            this.saveCmd = saveCmd;
        }

        public Widget Create(string name)
        {
            var widget = new Widget(name);
            var id = saveCmd.Save(widget);
            widget.Id = id;
            return widget;
        }
    }
}

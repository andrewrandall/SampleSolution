using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sample.Gadgets;

namespace Sample.Widgets
{
    class WidgetData : ConcurrentDictionary<int, Widget>, IGetPageOfWidgets, ISaveWidget, IReconstituteWidget, ISearchWidgetsByName
    {
        private object saveLock = new object();

        Page<WidgetSummary> IGetPageOfWidgets.GetPageOfWidgets(int number)
        {
            const int pageSize = 20;
            return
                new Page<WidgetSummary>(
                    number,
                    (int)Math.Floor((double)(Count / number)),
                    pageSize,
                    this.OrderBy(x => x.Key)
                        .Skip(pageSize * (number - 1))
                        .Take(pageSize)
                        .Select(x => Summarize(x.Value)));
        }

        int ISaveWidget.Save(Widget widget)
        {
            int? id = widget.Id;

            lock (saveLock)
            {
                if (!widget.Id.HasValue)
                {
                    id =
                        Keys.Any() ?
                            Keys.Max() + 1 :
                            1;
                }

                this[id.Value] = widget;
            }

            return id.Value;
        }

        Widget IReconstituteWidget.IReconstituteWidget(int id)
        {
            Widget widget = null;
            TryGetValue(id, out widget);
            return widget;
        }

        IEnumerable<WidgetSummary> ISearchWidgetsByName.Search(string nameIncludes)
        {
            return this
                .Select(x => x.Value)
                .Where(x => x.Name.IndexOf(nameIncludes, StringComparison.CurrentCultureIgnoreCase) > -1)
                .Select(Summarize);
        }

        private WidgetSummary Summarize(Widget widget) =>
            new WidgetSummary(
                widget.Id.Value,
                widget.Name,
                widget.Gadgets.Select(Summarize));

        private GadgetSummary Summarize(Gadget gadget) =>
            new GadgetSummary(gadget.Name);
    }
}
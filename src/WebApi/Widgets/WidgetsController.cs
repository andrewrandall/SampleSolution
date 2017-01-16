using Sample.Widgets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Sample.Widgets
{
    [RoutePrefix("api/widgets")]
    public class WidgetsController : ApiController
    {
        WidgetFactory factory;
        IGetPageOfWidgets query;

        public WidgetsController(WidgetFactory factory, IGetPageOfWidgets query)
        {
            this.factory = factory;
            this.query = query;
        }
                
        [HttpPost]
        [Route("")]
        public IHttpActionResult AddWidget(AddWidgetModel model)
        {
            return Ok(factory.Create(model.Name));
        }

        [HttpGet]
        [Route("")]
        public IHttpActionResult GetWidgets()
        {
            return
                Ok(
                    new PageModel<WidgetSummaryModel, WidgetSummary>(
                        query.GetPageOfWidgets(),
                        ToModel));
        }

        [HttpGet]
        [Route("")]
        public IHttpActionResult GetWidgets([FromUri] int pageNumber)
        {
            return
                Ok(
                    new PageModel<WidgetSummaryModel, WidgetSummary>(
                        query.GetPageOfWidgets(pageNumber),
                        ToModel));
        }

        private WidgetSummaryModel ToModel(WidgetSummary widget) => new WidgetSummaryModel(widget);
    }
}

using Sample.Widgets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Sample.Widgets
{
    public class GetWidgetsController : ApiController
    {
        IGetPageOfWidgets query;

        public GetWidgetsController(IGetPageOfWidgets query)
        {
            this.query = query;
        }

        [Route("api/Widgets")]
        [HttpGet]
        public IHttpActionResult GetWidgets(int? pageNumber)
        {
            return
                Ok(
                    new PageModel<WidgetSummaryModel, WidgetSummary>(
                        pageNumber.HasValue ?
                            query.GetPageOfWidgets(pageNumber.Value) :
                            query.GetPageOfWidgets(),
                        x => new WidgetSummaryModel(x)));
        }
    }
}
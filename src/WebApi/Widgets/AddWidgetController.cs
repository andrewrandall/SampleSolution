using Sample.Widgets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Sample.Widgets
{
    public class AddWidgetController : ApiController
    {
        WidgetFactory factory;

        public AddWidgetController(WidgetFactory factory)
        {
            this.factory = factory;
        }

        [Route("api/Widgets")]
        [HttpPost]
        public IHttpActionResult AddWidget(AddWidgetModel model)
        {
            return Ok(factory.Create(model.Name));
        }
    }
}

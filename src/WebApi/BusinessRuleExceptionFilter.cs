using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http.Filters;
using System.Web.Http.Results;

namespace Sample
{
    public class BusinessRuleExceptionFilter : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext ctx)
        {
            var ex = ctx.Exception as BrokenBusinessRuleException;
            if (ex != null)
            {
                var response = new HttpResponseMessage(HttpStatusCode.BadRequest);
                response.Content = new StringContent(ex.Explanation);
                ctx.Response = response;
            }
        }
    }
}
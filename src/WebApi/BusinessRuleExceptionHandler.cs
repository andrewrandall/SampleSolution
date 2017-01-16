using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http.Results;

namespace Sample
{
    public class BusinessRuleExceptionHandler : DelegatingHandler
    {
        protected async override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            HttpResponseMessage response;

            try
            {
                response = await base.SendAsync(request, cancellationToken);
            }
            catch (BrokenBusinessRuleException ex)
            {
                response = new HttpResponseMessage(HttpStatusCode.BadRequest);
                response.Content = new StringContent(ex.Explanation);
            }

            return response;
        }
    }
}
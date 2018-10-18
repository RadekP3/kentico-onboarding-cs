using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using TodoList.Api.Controllers;

namespace TodoList.Api.Tests.Extensions
{
    public static class ControllerExtension
    {
        public static async Task<HttpResponseMessage> ExecuteAction(this ItemsController controller, Func<ItemsController, Task<IHttpActionResult>> action)
        {
            var result = await action(controller);
            return await result.ExecuteAsync(CancellationToken.None);
        }
    }
}
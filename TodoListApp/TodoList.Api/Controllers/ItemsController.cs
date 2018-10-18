using System;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.Web.Http;
using TodoList.Api.Models;

namespace TodoList.Api.Controllers
{
    [ApiVersion("1.0")]
    [RoutePrefix("api/v{version:apiVersion}/items")]
    [Route("")]
    public class ItemsController : ApiController
    {
        private static readonly Item[] DefaultItems =
        {
            new Item() {Id = Guid.Empty, Text = "First"},
            new Item() {Id = Guid.Empty, Text = "Second"},
            new Item() {Id = Guid.Empty, Text = "Third"}
        };

        // GET: api/v{version}/items
        [Route("")]
        public async Task<IHttpActionResult> GetAsync() =>
            await Task.FromResult(Ok(DefaultItems));


        // GET: api/v{version}/items/5
        [Route("{id:int}")]
        public async Task<IHttpActionResult> GetAsync(int id) =>
            await Task.FromResult(Ok(DefaultItems[0]));


        // POST: api/v{version}/items
        [Route("")]
        public async Task<IHttpActionResult> PostAsync([FromBody] Item item) =>
            await Task.FromResult(Created($"api/items/{DefaultItems[0].Id}", DefaultItems[0]));


        // PUT: api/v{version}/items/5
        [Route("{id:int}")]
        public async Task<IHttpActionResult> PutAsync(int id, [FromBody] Item item) =>
            await Task.FromResult(Ok(DefaultItems[1]));


        // DELETE: api/v{version}/Items/5
        [Route("{id:int}")]
        public async Task<IHttpActionResult> DeleteAsync(int id) =>
            await Task.FromResult(Ok(DefaultItems[0]));
    }
}
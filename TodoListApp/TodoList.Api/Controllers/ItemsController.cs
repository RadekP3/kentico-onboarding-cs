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
            new Item {Id = new Guid("9cece279-9343-4214-b03f-1062a047727e"), Text = "First"},
            new Item {Id = new Guid("5f24635c-e42f-4c99-8156-a8b94b213d0b"), Text = "Second"},
            new Item {Id = new Guid("779f5f6a-a31d-4956-98bd-3ac7d20993e7"), Text = "Third"}
        };

        // GET: api/v{version}/items
        public async Task<IHttpActionResult> GetAsync() =>
            await Task.FromResult(Ok(DefaultItems));

        // GET: api/v{version}/items/9cece279-9343-4214-b03f-1062a047727e
        [Route("{id:Guid}")]
        public async Task<IHttpActionResult> GetAsync(Guid id) =>
            await Task.FromResult(Ok(DefaultItems[0]));

        // POST: api/v{version}/items
        public async Task<IHttpActionResult> PostAsync([FromBody] Item item) =>
            await Task.FromResult(Created($"api/items/{DefaultItems[0].Id}", DefaultItems[0]));

        // PUT: api/v{version}/items/9cece279-9343-4214-b03f-1062a047727e
        [Route("{id:Guid}")]
        public async Task<IHttpActionResult> PutAsync(Guid id, [FromBody] Item item) =>
            await Task.FromResult(Ok(DefaultItems[1]));

        // DELETE: api/v{version}/items/9cece279-9343-4214-b03f-1062a047727e
        [Route("{id:Guid}")]
        public async Task<IHttpActionResult> DeleteAsync(Guid id) =>
            await Task.FromResult(Ok(DefaultItems[0]));
    }
}
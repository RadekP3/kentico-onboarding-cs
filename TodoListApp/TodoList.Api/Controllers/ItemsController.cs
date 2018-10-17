using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using TodoList.Api.Models;

namespace TodoList.Api.Controllers
{
    [RoutePrefix("api/items")]
    public class ItemsController : ApiController
    {
        private static readonly Item[] DefaultItems =
        {
            new Item() {Id = Guid.Empty, Text = "First"},
            new Item() {Id = Guid.Empty, Text = "Second"},
            new Item() {Id = Guid.Empty, Text = "Third"}
        };

        // GET: api/items
        [Route("")]
        public async Task<IHttpActionResult> GetAsync() =>
            await Task.FromResult(Ok(DefaultItems));


        // GET: api/items/5
        [Route("{id:int}")]
        public async Task<IHttpActionResult> GetAsync(int id) =>
            await Task.FromResult(Ok(DefaultItems[0]));


        // POST: api/items
        [Route("")]
        public async Task<IHttpActionResult> PostAsync([FromBody] Item item) =>
            await Task.FromResult(Created($"api/items/{DefaultItems[0].Id}", DefaultItems[0]));


        // PUT: api/items/5
        [Route("{id:int}")]
        public async Task<IHttpActionResult> PutAsync(int id, [FromBody] Item item) =>
            await Task.FromResult(Ok(DefaultItems[1]));


        // DELETE: api/Items/5
        [Route("{id:int}")]
        public async Task<IHttpActionResult> DeleteAsync(int id) =>
            await Task.FromResult(Ok(DefaultItems[0]));
    }
}
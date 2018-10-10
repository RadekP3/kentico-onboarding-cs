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
            new Item() {Id = 1, Text = "First"},
            new Item() {Id = 2, Text = "Second"},
            new Item() {Id = 3, Text = "Third"}
        };

        // GET: api/items
        [Route("")]
        public async Task<IHttpActionResult> Get() =>
            await Task.FromResult(Ok(DefaultItems));


        // GET: api/items/5
        [Route("{id:int}")]
        public async Task<IHttpActionResult> Get(int id) =>
            await Task.FromResult(Ok(DefaultItems[0]));


        // POST: api/items
        [Route("")]
        public async Task<IHttpActionResult> Post([FromBody] Item item) =>
            await Task.FromResult(Created($"api/items/{DefaultItems[0].Id}", DefaultItems[0]));


        // PUT: api/items/5
        [Route("{id:int}")]
        public async Task<IHttpActionResult> Put(int id, [FromBody] Item item) =>
            await Task.FromResult(Ok(DefaultItems[1]));


        // DELETE: api/Items/5
        [Route("{id:int}")]
        public async Task<IHttpActionResult> Delete(int id) =>
            await Task.FromResult(Ok(DefaultItems[0]));
    }
}
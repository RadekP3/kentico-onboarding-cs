using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using NUnit.Framework;
using TodoList.Api.Controllers;
using TodoList.Api.Models;
using TodoList.Api.Tests.Comparers;
using TodoList.Api.Tests.Extensions;

namespace TodoList.Api.Tests
{
    [TestFixture]
    public class ItemsControllerTests
    {
        readonly Item[] _defaultItems =         
        {
            new Item {Id = new Guid("9cece279-9343-4214-b03f-1062a047727e"), Text = "First"},
            new Item {Id = new Guid("5f24635c-e42f-4c99-8156-a8b94b213d0b"), Text = "Second"},
            new Item {Id = new Guid("779f5f6a-a31d-4956-98bd-3ac7d20993e7"), Text = "Third"}
        };
        readonly ItemComparer _comparer = new ItemComparer();
        readonly Item _mockItem = new Item() { Id = Guid.Empty, Text = "Item" };
        readonly ItemsController _controller = new ItemsController() { Configuration = new HttpConfiguration(), Request = new HttpRequestMessage()};

        [Test]
        public async Task GetAsync_ReturnsDefaultItemsWithOkStatusCode()
        {
            var actionResult = await _controller.ExecuteAction(controller => controller.GetAsync());
            actionResult.TryGetContentValue(out Item[] itemsFromMessage);

            Assert.That(actionResult.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(itemsFromMessage, Is.EqualTo(_defaultItems).Using(_comparer));
        }
        [Test]
        public async Task GetAsync_Id_ReturnsFirstItemWithOkStatusCode()
        {
            var actionResult = await _controller.ExecuteAction(controller => controller.GetAsync(Guid.Empty));
            actionResult.TryGetContentValue(out Item itemFromMessage);

            Assert.That(actionResult.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(itemFromMessage, Is.EqualTo(_defaultItems[0]).Using(_comparer));
        }

        [Test]
        public async Task  PostAsync_Item_ReturnsFirstItemWithCreatedStatusCode()
        {
            var actionResult = await _controller.ExecuteAction(controller => controller.PostAsync(_mockItem));
            actionResult.TryGetContentValue(out Item itemFromMessage);

            Assert.That(actionResult.StatusCode, Is.EqualTo(HttpStatusCode.Created));
            Assert.That(itemFromMessage, Is.EqualTo(_defaultItems[0]).Using(_comparer));
        }
        [Test]
        public async Task PutAsync_Id_Item_ReturnSecondItemWithOkStatusCode()
        {
            var actionResult = await _controller.ExecuteAction(controller => controller.PutAsync(Guid.Empty, _mockItem));
            actionResult.TryGetContentValue(out Item itemFromMessage);

            Assert.That(actionResult.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(itemFromMessage, Is.EqualTo(_defaultItems[1]).Using(_comparer));
        }

        [Test]
        public async Task DeleteAsync_Id_ReturnsFirstItemWithOkStatusCode()
        {
            var actionResult = await _controller.ExecuteAction(controller => controller.DeleteAsync(Guid.Empty));
            actionResult.TryGetContentValue(out Item itemFromMessage);

            Assert.That(actionResult.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(itemFromMessage, Is.EqualTo(_defaultItems[0]).Using(_comparer));
        }
    }
}
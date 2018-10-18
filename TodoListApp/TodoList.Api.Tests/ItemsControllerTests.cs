using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;
using NUnit.Framework;
using NUnit.Framework.Internal;
using TodoList.Api.Comparers;
using TodoList.Api.Controllers;
using TodoList.Api.Models;
using TodoList.Api.Tests.Extensions;

namespace TodoList.Api.Tests
{
    [TestFixture]
    public class ItemsControllerTests
    {
        readonly Item[] _defaultItems =         
        {
            new Item {Id = Guid.Empty, Text = "First"},
            new Item {Id = Guid.Empty, Text = "Second"},
            new Item {Id = Guid.Empty, Text = "Third"}
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
            var actionResult = await _controller.ExecuteAction(controller => controller.GetAsync(2));
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
            var actionResult = await _controller.ExecuteAction(controller => controller.PutAsync(0, _mockItem));
            actionResult.TryGetContentValue(out Item itemFromMessage);

            Assert.That(actionResult.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(itemFromMessage, Is.EqualTo(_defaultItems[1]).Using(_comparer));
        }

        [Test]
        public async Task DeleteAsync_Id_ReturnsFirstItemWithOkStatusCode()
        {
            var actionResult = await _controller.ExecuteAction(controller => controller.DeleteAsync(0));
            actionResult.TryGetContentValue(out Item itemFromMessage);

            Assert.That(actionResult.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(itemFromMessage, Is.EqualTo(_defaultItems[0]).Using(_comparer));
        }
    }
}
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

namespace TodoList.Api.Tests
{
    [TestFixture]
    public class ItemsControllerTests
    {
        readonly Item[] _defaultItems =         
        {
            new Item() {Id = 1, Text = "First"},
            new Item() {Id = 2, Text = "Second"},
            new Item() {Id = 3, Text = "Third"}
        };
        readonly ItemComparer _comparer = new ItemComparer();

        readonly Item _mockItem = new Item() { Id = 9, Text = "Item" };

        [Test]
        public async Task Get_ReturnsDefaultItemsWithOkStatusCode()
        {
            var controller = new ItemsController() {Configuration = new HttpConfiguration(), Request = new HttpRequestMessage()};

            var actionResult = await controller.Get().Result.ExecuteAsync(CancellationToken.None);
            actionResult.TryGetContentValue(out Item[] itemsFromMessage);
            Console.WriteLine("items " + itemsFromMessage.Length);
            Assert.That(actionResult.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(itemsFromMessage, Is.EqualTo(_defaultItems).Using(_comparer));
        }
        [Test]
        public async Task Get_Id_ReturnsFirstItemWithOkStatusCode()
        {
            var controller = new ItemsController() { Configuration = new HttpConfiguration(), Request = new HttpRequestMessage() };

            var actionResult = await controller.Get(2).Result.ExecuteAsync(CancellationToken.None);
            actionResult.TryGetContentValue(out Item itemFromMessage);

            Assert.That(actionResult.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(itemFromMessage, Is.EqualTo(_defaultItems[0]).Using(_comparer));
        }

        [Test]
        public async Task  Post_Item_ReturnsFirstItemWithCreatedStatusCode()
        {
            var controller = new ItemsController() { Configuration = new HttpConfiguration(), Request = new HttpRequestMessage() };

            var actionResult = await controller.Post(_mockItem).Result.ExecuteAsync(CancellationToken.None);
            actionResult.TryGetContentValue(out Item itemFromMessage);

            Assert.That(actionResult.StatusCode, Is.EqualTo(HttpStatusCode.Created));
            Assert.That(itemFromMessage, Is.EqualTo(_defaultItems[0]).Using(_comparer));
        }
        [Test]
        public async Task Put_Id_Item_ReturnSecondItemWithOkStatusCode()
        {
            var controller = new ItemsController() { Configuration = new HttpConfiguration(), Request = new HttpRequestMessage() };

            var actionResult = await controller.Put(0, _mockItem).Result.ExecuteAsync(CancellationToken.None);
            actionResult.TryGetContentValue(out Item itemFromMessage);

            Assert.That(actionResult.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(itemFromMessage, Is.EqualTo(_defaultItems[1]).Using(_comparer));
        }

        [Test]
        public async Task Delete_Id_ReturnsFirstItemWithOkStatusCode()
        {
            var controller = new ItemsController() { Configuration = new HttpConfiguration(), Request = new HttpRequestMessage() };

            var actionResult = await controller.Delete(0).Result.ExecuteAsync(CancellationToken.None);
            actionResult.TryGetContentValue(out Item itemFromMessage);

            Assert.That(actionResult.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(itemFromMessage, Is.EqualTo(_defaultItems[0]).Using(_comparer));
        }

    }
}
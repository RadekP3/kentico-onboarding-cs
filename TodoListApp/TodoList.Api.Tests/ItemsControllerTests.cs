using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using NUnit.Framework;
using TodoList.Api.Controllers;
using TodoList.Api.Models;
using TodoList.Api.Tests.Extensions;

namespace TodoList.Api.Tests
{
    [TestFixture]
    public class ItemsControllerTests
    {
        private ItemsController _controller;

        private readonly Item[] _defaultItems =
        {
            new Item {Id = new Guid("9cece279-9343-4214-b03f-1062a047727e"), Text = "First"},
            new Item {Id = new Guid("5f24635c-e42f-4c99-8156-a8b94b213d0b"), Text = "Second"},
            new Item {Id = new Guid("779f5f6a-a31d-4956-98bd-3ac7d20993e7"), Text = "Third"}
        };

        [SetUp]
        public void Init()
        {
            _controller = new ItemsController
            {
                Configuration = new HttpConfiguration(),
                Request = new HttpRequestMessage()
            };
        }


        [Test]
        public async Task GetAsync_ReturnsDefaultItemsWithOkStatusCode()
        {
            var actionResult = await _controller.ExecuteAction(controller => controller.GetAsync());
            actionResult.TryGetContentValue(out Item[] itemsFromMessage);

            Assert.That(actionResult.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(itemsFromMessage, Is.EqualTo(_defaultItems).UsingItemComparer());
        }

        [Test]
        public async Task GetAsync_Id_ReturnsFirstItemWithOkStatusCode()
        {
            var mockId = new Guid("af825433-d9e4-484f-b6ff-469b5dbb6238");
            var actionResult = await _controller.ExecuteAction(controller => controller.GetAsync(mockId));
            actionResult.TryGetContentValue(out Item itemFromMessage);

            Assert.That(actionResult.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(itemFromMessage, Is.EqualTo(_defaultItems[0]).UsingItemComparer());
        }

        [Test]
        public async Task PostAsync_Item_ReturnsFirstItemWithCreatedStatusCode()
        {
            var mockItem = new Item {Id = new Guid("2daa5641-f500-4021-adc9-47b08806cd6c"), Text = "Item to post"};
            var actionResult = await _controller.ExecuteAction(controller => controller.PostAsync(mockItem));
            actionResult.TryGetContentValue(out Item itemFromMessage);

            Assert.That(actionResult.StatusCode, Is.EqualTo(HttpStatusCode.Created));
            Assert.That(itemFromMessage, Is.EqualTo(_defaultItems[0]).UsingItemComparer());
        }

        [Test]
        public async Task PutAsync_Id_Item_ReturnSecondItemWithOkStatusCode()
        {
            var itemId = new Guid("f4968efb-4f1e-445b-b907-6ba0ac63bc01");
            var mockItem = new Item {Id = itemId, Text = "Item to put"};

            var actionResult = await _controller.ExecuteAction(controller => controller.PutAsync(itemId, mockItem));
            actionResult.TryGetContentValue(out Item itemFromMessage);

            Assert.That(actionResult.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(itemFromMessage, Is.EqualTo(_defaultItems[1]).UsingItemComparer());
        }

        [Test]
        public async Task DeleteAsync_Id_ReturnsFirstItemWithOkStatusCode()
        {
            var mockId = new Guid("26327007-e8e8-4112-984f-a42ce03e99aa");
            var actionResult = await _controller.ExecuteAction(controller => controller.DeleteAsync(mockId));
            actionResult.TryGetContentValue(out Item itemFromMessage);

            Assert.That(actionResult.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(itemFromMessage, Is.EqualTo(_defaultItems[0]).UsingItemComparer());
        }
    }
}
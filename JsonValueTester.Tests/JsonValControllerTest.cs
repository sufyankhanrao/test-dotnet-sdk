// <copyright file="JsonValControllerTest.cs" company="APIMatic">
// Copyright (c) APIMatic. All rights reserved.
// </copyright>
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Threading.Tasks;
using APIMatic.Core.Utilities;
using JsonValueTester.Standard;
using JsonValueTester.Standard.Controllers;
using JsonValueTester.Standard.Exceptions;
using JsonValueTester.Standard.Http.Client;
using JsonValueTester.Standard.Http.Response;
using JsonValueTester.Standard.Utilities;
using Newtonsoft.Json.Converters;
using NUnit.Framework;

namespace JsonValueTester.Tests
{
    /// <summary>
    /// JsonValControllerTest.
    /// </summary>
    [TestFixture]
    public class JsonValControllerTest : ControllerTestBase
    {
        /// <summary>
        /// Controller instance (for all tests).
        /// </summary>
        private IJsonValController controller;

        /// <summary>
        /// Setup test class.
        /// </summary>
        [OneTimeSetUp]
        public void SetUpDerived()
        {
            this.controller = this.Client.JsonValController;
        }

        /// <summary>
        /// Send Value in Model.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [Test]
        public async Task TestSendValueInModel()
        {
            // Parameters for the API call
            Standard.Models.ValueContainer body = ApiHelper.JsonDeserialize<Standard.Models.ValueContainer>("{\"name\":\"a name\",\"id\":\"definition-123\",\"valueMap\":{\"key1\":\"some string\",\"key2\":true,\"key3\":123},\"valueArray\":[\"some string\",true,123],\"value\":\"some string value in model\"}");

            // Perform API call
            Standard.Models.ServerResponse result = null;
            try
            {
                result = await this.controller.SendValueinModelAsync(body);
            }
            catch (ApiException)
            {
            }

            // Test response code
            Assert.AreEqual(200, HttpCallBack.Response.StatusCode, "Status should be 200");

            // Test whether the captured response is as we expected
            Assert.IsNotNull(result, "Result should exist");
            Assert.IsTrue(
                    TestHelper.IsProperSubsetOf(
                    "{\"passed\":true}",
                    TestHelper.ConvertStreamToString(HttpCallBack.Response.RawBody),
                    true,
                    true,
                    false),
                    "Response body should have matching keys");
        }

        /// <summary>
        /// Send Value as Body.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [Test]
        public async Task TestSendValueAsBody()
        {
            // Parameters for the API call
            JsonValue body = ApiHelper.JsonDeserialize<JsonValue>("false");

            // Perform API call
            Standard.Models.ServerResponse result = null;
            try
            {
                result = await this.controller.SendValueasBodyAsync(body);
            }
            catch (ApiException)
            {
            }

            // Test response code
            Assert.AreEqual(200, HttpCallBack.Response.StatusCode, "Status should be 200");

            // Test whether the captured response is as we expected
            Assert.IsNotNull(result, "Result should exist");
            Assert.IsTrue(
                    TestHelper.IsProperSubsetOf(
                    "{\"passed\":true}",
                    TestHelper.ConvertStreamToString(HttpCallBack.Response.RawBody),
                    true,
                    true,
                    false),
                    "Response body should have matching keys");
        }

        /// <summary>
        /// Send Value as Form.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [Test]
        public async Task TestSendValueAsForm()
        {
            // Parameters for the API call
            Standard.Models.ContentType contentType = ApiHelper.JsonDeserialize<Standard.Models.ContentType>("\"application/x-www-form-urlencoded\"");
            int id = 54;
            JsonValue model = ApiHelper.JsonDeserialize<JsonValue>("true");
            List<JsonValue> modelArray = ApiHelper.JsonDeserialize<List<JsonValue>>("[true,\"some string\",123]");
            JsonValue modelMap = ApiHelper.JsonDeserialize<JsonValue>("{\"key1\":true,\"key2\":\"some string\",\"key3\":123}");
            Standard.Models.SendValueasFormInput input = new Standard.Models.SendValueasFormInput(contentType, id, model, modelArray, modelMap);

            // Perform API call
            Standard.Models.ServerResponse result = null;
            try
            {
                result = await this.controller.SendValueasFormAsync(input);
            }
            catch (ApiException)
            {
            }

            // Test response code
            Assert.AreEqual(200, HttpCallBack.Response.StatusCode, "Status should be 200");

            // Test whether the captured response is as we expected
            Assert.IsNotNull(result, "Result should exist");
            Assert.IsTrue(
                    TestHelper.IsProperSubsetOf(
                    "{\"passed\":true}",
                    TestHelper.ConvertStreamToString(HttpCallBack.Response.RawBody),
                    true,
                    true,
                    false),
                    "Response body should have matching keys");
        }

        /// <summary>
        /// Send Value as Query.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [Test]
        public async Task TestSendValueAsQuery()
        {
            // Parameters for the API call
            int id = 54;
            JsonValue model = ApiHelper.JsonDeserialize<JsonValue>("true");
            List<JsonValue> modelArray = ApiHelper.JsonDeserialize<List<JsonValue>>("[true,\"some string\",123]");
            JsonValue modelMap = ApiHelper.JsonDeserialize<JsonValue>("{\"key1\":true,\"key2\":\"some string\",\"key3\":123}");
            Standard.Models.SendValueasQueryInput input = new Standard.Models.SendValueasQueryInput(id, model, modelArray, modelMap);

            // Perform API call
            Standard.Models.ServerResponse result = null;
            try
            {
                result = await this.controller.SendValueasQueryAsync(input);
            }
            catch (ApiException)
            {
            }

            // Test response code
            Assert.AreEqual(200, HttpCallBack.Response.StatusCode, "Status should be 200");

            // Test whether the captured response is as we expected
            Assert.IsNotNull(result, "Result should exist");
            Assert.IsTrue(
                    TestHelper.IsProperSubsetOf(
                    "{\"passed\":true}",
                    TestHelper.ConvertStreamToString(HttpCallBack.Response.RawBody),
                    true,
                    true,
                    false),
                    "Response body should have matching keys");
        }

        /// <summary>
        /// Get Value.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [Test]
        public async Task TestGetValue()
        {
            // Perform API call
            JsonValue result = null;
            try
            {
                result = await this.controller.GetValueAsync();
            }
            catch (ApiException)
            {
            }

            // Test response code
            Assert.AreEqual(200, HttpCallBack.Response.StatusCode, "Status should be 200");

            // Test whether the captured response is as we expected
            Assert.IsNotNull(result, "Result should exist");
            Assert.AreEqual("978", TestHelper.ConvertStreamToString(HttpCallBack.Response.RawBody), "Response body should match exactly (string literal match)");
        }

        /// <summary>
        /// Get Value Array.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [Test]
        public async Task TestGetValueArray()
        {
            // Perform API call
            List<JsonValue> result = null;
            try
            {
                result = await this.controller.GetValueArrayAsync();
            }
            catch (ApiException)
            {
            }

            // Test response code
            Assert.AreEqual(200, HttpCallBack.Response.StatusCode, "Status should be 200");

            // Test whether the captured response is as we expected
            Assert.IsNotNull(result, "Result should exist");
            Assert.AreEqual("[978,\"some string\",false]", TestHelper.ConvertStreamToString(HttpCallBack.Response.RawBody), "Response body should match exactly (string literal match)");
        }

        /// <summary>
        /// Get Value Map.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [Test]
        public async Task TestGetValueMap()
        {
            // Perform API call
            JsonValue result = null;
            try
            {
                result = await this.controller.GetValueMapAsync();
            }
            catch (ApiException)
            {
            }

            // Test response code
            Assert.AreEqual(200, HttpCallBack.Response.StatusCode, "Status should be 200");

            // Test whether the captured response is as we expected
            Assert.IsNotNull(result, "Result should exist");
            Assert.IsTrue(
                    TestHelper.IsProperSubsetOf(
                    "{\"key1\":978,\"key2\":\"some string\",\"key3\":false}",
                    TestHelper.ConvertStreamToString(HttpCallBack.Response.RawBody),
                    true,
                    true,
                    false),
                    "Response body should have matching keys");
        }

        /// <summary>
        /// Get Value in Model.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [Test]
        public async Task TestGetValueInModel()
        {
            // Perform API call
            Standard.Models.ValueContainer result = null;
            try
            {
                result = await this.controller.GetValueinModelAsync();
            }
            catch (ApiException)
            {
            }

            // Test response code
            Assert.AreEqual(200, HttpCallBack.Response.StatusCode, "Status should be 200");

            // Test whether the captured response is as we expected
            Assert.IsNotNull(result, "Result should exist");
            Assert.IsTrue(
                    TestHelper.IsProperSubsetOf(
                    "{\"name\":\"a name\",\"id\":\"definition-123\",\"valueMap\":{\"key1\":\"some string\",\"key2\":true,\"key3\":123},\"valueArray\":[\"some string\",true,123],\"value\":\"some string value in model\"}",
                    TestHelper.ConvertStreamToString(HttpCallBack.Response.RawBody),
                    true,
                    true,
                    false),
                    "Response body should have matching keys");
        }
    }
}
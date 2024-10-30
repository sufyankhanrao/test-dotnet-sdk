// <copyright file="JsonObjControllerTest.cs" company="APIMatic">
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
    /// JsonObjControllerTest.
    /// </summary>
    [TestFixture]
    public class JsonObjControllerTest : ControllerTestBase
    {
        /// <summary>
        /// Controller instance (for all tests).
        /// </summary>
        private IJsonObjController controller;

        /// <summary>
        /// Setup test class.
        /// </summary>
        [OneTimeSetUp]
        public void SetUpDerived()
        {
            this.controller = this.Client.JsonObjController;
        }

        /// <summary>
        /// Send Schema in Model.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [Test]
        public async Task TestSendSchemaInModel()
        {
            // Parameters for the API call
            Standard.Models.SchemaContainer body = ApiHelper.JsonDeserialize<Standard.Models.SchemaContainer>("{\"name\":\"a name\",\"id\":\"definition-123\",\"schemaMap\":{\"key1\":{\"$id\":\"https://example.com/person.schema.json\",\"$schema\":\"https://json-schema.org/draft/2020-12/schema\",\"title\":\"Person\",\"type\":\"object\",\"properties\":{\"firstName\":{\"type\":\"string\",\"description\":\"The person's first name.\"},\"lastName\":{\"type\":\"string\",\"description\":\"The person's last name.\",\"test\":null},\"age\":{\"type\":\"integer\",\"description\":\"Age in years\",\"minimum\":0}}},\"key2\":{\"$id\":\"https://example.com/person.schema.json\",\"$schema\":\"https://json-schema.org/draft/2020-12/schema\",\"title\":\"Person\",\"type\":\"object\",\"properties\":{\"firstName\":{\"type\":\"string\",\"description\":\"The person's first name.\"},\"lastName\":{\"type\":\"string\",\"description\":\"The person's last name.\",\"test\":null},\"age\":{\"type\":\"integer\",\"description\":\"Age in years\",\"minimum\":0}}}},\"schemaArray\":[{\"$id\":\"https://example.com/person.schema.json\",\"$schema\":\"https://json-schema.org/draft/2020-12/schema\",\"title\":\"Person\",\"type\":\"object\",\"properties\":{\"firstName\":{\"type\":\"string\",\"description\":\"The person's first name.\"},\"lastName\":{\"type\":\"string\",\"description\":\"The person's last name.\",\"test\":null},\"age\":{\"type\":\"integer\",\"description\":\"Age in years\",\"minimum\":0}}},{\"$id\":\"https://example.com/person.schema.json\",\"$schema\":\"https://json-schema.org/draft/2020-12/schema\",\"title\":\"Person\",\"type\":\"object\",\"properties\":{\"firstName\":{\"type\":\"string\",\"description\":\"The person's first name.\"},\"lastName\":{\"type\":\"string\",\"description\":\"The person's last name.\",\"test\":null},\"age\":{\"type\":\"integer\",\"description\":\"Age in years\",\"minimum\":0}}}],\"schema\":{\"$id\":\"https://example.com/person.schema.json\",\"$schema\":\"https://json-schema.org/draft/2020-12/schema\",\"title\":\"Person\",\"type\":\"object\",\"properties\":{\"firstName\":{\"type\":\"string\",\"description\":\"The person's first name.\"},\"lastName\":{\"type\":\"string\",\"description\":\"The person's last name.\",\"test\":null},\"age\":{\"type\":\"integer\",\"description\":\"Age in years\",\"minimum\":0}}}}");

            // Perform API call
            Standard.Models.ServerResponse result = null;
            try
            {
                result = await this.controller.SendSchemainModelAsync(body);
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
        /// Send Schema as Body.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [Test]
        public async Task TestSendSchemaAsBody()
        {
            // Parameters for the API call
            JsonObject body = JsonObject.FromJsonString("{\"$id\":\"https://example.com/person.schema.json\",\"$schema\":\"https://json-schema.org/draft/2020-12/schema\",\"title\":\"Person\",\"type\":\"object\",\"properties\":{\"firstName\":{\"type\":\"string\",\"description\":\"The person's first name.\"},\"lastName\":{\"type\":\"string\",\"description\":\"The person's last name.\",\"test\":null},\"age\":{\"type\":\"integer\",\"description\":\"Age in years\",\"minimum\":0}}}");

            // Perform API call
            Standard.Models.ServerResponse result = null;
            try
            {
                result = await this.controller.SendSchemaasBodyAsync(body);
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
                    "{\"passed\":true,\"message\":\"OK\",\"nullableNumberMap\":{\"luckydraw1\":null,\"luckydraw2\":88.1,\"luckydraw3\":89.1,\"luckydraw4\":null,\"luckydraw5\":91.1},\"nullableNumberArray\":[null, 88.1, 89.1, null, 91.1]}",
                    TestHelper.ConvertStreamToString(HttpCallBack.Response.RawBody),
                    true,
                    true,
                    false),
                    "Response body should have matching keys");
        }

        /// <summary>
        /// Send Schema as Form.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [Test]
        public async Task TestSendSchemaAsForm()
        {
            // Parameters for the API call
            Standard.Models.ContentType contentType = ApiHelper.JsonDeserialize<Standard.Models.ContentType>("\"application/x-www-form-urlencoded\"");
            int id = 54;
            JsonObject model = JsonObject.FromJsonString("{\"$id\":\"https://example.com/person.schema.json\",\"$schema\":\"https://json-schema.org/draft/2020-12/schema\",\"title\":\"Person\",\"type\":\"object\",\"properties\":{\"firstName\":{\"type\":\"string\",\"description\":\"The person's first name.\"},\"lastName\":{\"type\":\"string\",\"description\":\"The person's last name.\",\"test\":null},\"age\":{\"type\":\"integer\",\"description\":\"Age in years\",\"minimum\":0}}}");
            List<JsonObject> modelArray = ApiHelper.JsonDeserialize<List<JsonObject>>("[{\"$id\":\"https://example.com/person.schema.json\",\"$schema\":\"https://json-schema.org/draft/2020-12/schema\",\"title\":\"Person\",\"type\":\"object\",\"properties\":{\"firstName\":{\"type\":\"string\",\"description\":\"The person's first name.\"},\"lastName\":{\"type\":\"string\",\"description\":\"The person's last name.\",\"test\":null},\"age\":{\"type\":\"integer\",\"description\":\"Age in years\",\"minimum\":0}}},{\"$id\":\"https://example.com/person.schema.json\",\"$schema\":\"https://json-schema.org/draft/2020-12/schema\",\"title\":\"Person\",\"type\":\"object\",\"properties\":{\"firstName\":{\"type\":\"string\",\"description\":\"The person's first name.\"},\"lastName\":{\"type\":\"string\",\"description\":\"The person's last name.\",\"test\":null},\"age\":{\"type\":\"integer\",\"description\":\"Age in years\",\"minimum\":0}}}]");
            JsonObject modelMap = ApiHelper.JsonDeserialize<JsonObject>("{\"key1\":{\"$id\":\"https://example.com/person.schema.json\",\"$schema\":\"https://json-schema.org/draft/2020-12/schema\",\"title\":\"Person\",\"type\":\"object\",\"properties\":{\"firstName\":{\"type\":\"string\",\"description\":\"The person's first name.\"},\"lastName\":{\"type\":\"string\",\"description\":\"The person's last name.\",\"test\":null},\"age\":{\"type\":\"integer\",\"description\":\"Age in years\",\"minimum\":0}}},\"key2\":{\"$id\":\"https://example.com/person.schema.json\",\"$schema\":\"https://json-schema.org/draft/2020-12/schema\",\"title\":\"Person\",\"type\":\"object\",\"properties\":{\"firstName\":{\"type\":\"string\",\"description\":\"The person's first name.\"},\"lastName\":{\"type\":\"string\",\"description\":\"The person's last name.\",\"test\":null},\"age\":{\"type\":\"integer\",\"description\":\"Age in years\",\"minimum\":0}}}}");
            Standard.Models.SendSchemaasFormInput input = new Standard.Models.SendSchemaasFormInput(contentType, id, model, modelArray, modelMap);

            // Perform API call
            Standard.Models.ServerResponse result = null;
            try
            {
                result = await this.controller.SendSchemaasFormAsync(input);
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
        /// Send Schema as Query.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [Test]
        public async Task TestSendSchemaAsQuery()
        {
            // Parameters for the API call
            int id = 54;
            JsonObject model = JsonObject.FromJsonString("{\"$id\":\"https://example.com/person.schema.json\",\"$schema\":\"https://json-schema.org/draft/2020-12/schema\",\"title\":\"Person\",\"type\":\"object\",\"properties\":{\"firstName\":{\"type\":\"string\",\"description\":\"The person's first name.\"},\"lastName\":{\"type\":\"string\",\"description\":\"The person's last name.\",\"test\":null},\"age\":{\"type\":\"integer\",\"description\":\"Age in years\",\"minimum\":0}}}");
            List<JsonObject> modelArray = ApiHelper.JsonDeserialize<List<JsonObject>>("[{\"$id\":\"https://example.com/person.schema.json\",\"$schema\":\"https://json-schema.org/draft/2020-12/schema\",\"title\":\"Person\",\"type\":\"object\",\"properties\":{\"firstName\":{\"type\":\"string\",\"description\":\"The person's first name.\"},\"lastName\":{\"type\":\"string\",\"description\":\"The person's last name.\",\"test\":null},\"age\":{\"type\":\"integer\",\"description\":\"Age in years\",\"minimum\":0}}},{\"$id\":\"https://example.com/person.schema.json\",\"$schema\":\"https://json-schema.org/draft/2020-12/schema\",\"title\":\"Person\",\"type\":\"object\",\"properties\":{\"firstName\":{\"type\":\"string\",\"description\":\"The person's first name.\"},\"lastName\":{\"type\":\"string\",\"description\":\"The person's last name.\",\"test\":null},\"age\":{\"type\":\"integer\",\"description\":\"Age in years\",\"minimum\":0}}}]");
            JsonObject modelMap = ApiHelper.JsonDeserialize<JsonObject>("{\"key1\":{\"$id\":\"https://example.com/person.schema.json\",\"$schema\":\"https://json-schema.org/draft/2020-12/schema\",\"title\":\"Person\",\"type\":\"object\",\"properties\":{\"firstName\":{\"type\":\"string\",\"description\":\"The person's first name.\"},\"lastName\":{\"type\":\"string\",\"description\":\"The person's last name.\",\"test\":null},\"age\":{\"type\":\"integer\",\"description\":\"Age in years\",\"minimum\":0}}},\"key2\":{\"$id\":\"https://example.com/person.schema.json\",\"$schema\":\"https://json-schema.org/draft/2020-12/schema\",\"title\":\"Person\",\"type\":\"object\",\"properties\":{\"firstName\":{\"type\":\"string\",\"description\":\"The person's first name.\"},\"lastName\":{\"type\":\"string\",\"description\":\"The person's last name.\",\"test\":null},\"age\":{\"type\":\"integer\",\"description\":\"Age in years\",\"minimum\":0}}}}");
            Standard.Models.SendSchemaasQueryInput input = new Standard.Models.SendSchemaasQueryInput(id, model, modelArray, modelMap);

            // Perform API call
            Standard.Models.ServerResponse result = null;
            try
            {
                result = await this.controller.SendSchemaasQueryAsync(input);
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
        /// Get Schema.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [Test]
        public async Task TestGetSchema()
        {
            // Perform API call
            JsonObject result = null;
            try
            {
                result = await this.controller.GetSchemaAsync();
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
                    "{\"$id\":\"https://example.com/person.schema.json\",\"$schema\":\"https://json-schema.org/draft/2020-12/schema\",\"title\":\"Person\",\"type\":\"object\",\"properties\":{\"firstName\":{\"type\":\"string\",\"description\":\"The person's first name.\"},\"lastName\":{\"type\":\"string\",\"description\":\"The person's last name.\",\"test\":null},\"age\":{\"type\":\"integer\",\"description\":\"Age in years\",\"minimum\":0}}}",
                    TestHelper.ConvertStreamToString(HttpCallBack.Response.RawBody),
                    true,
                    true,
                    false),
                    "Response body should have matching keys");
        }

        /// <summary>
        /// Get Schema Array.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [Test]
        public async Task TestGetSchemaArray()
        {
            // Perform API call
            List<JsonObject> result = null;
            try
            {
                result = await this.controller.GetSchemaArrayAsync();
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
                    "[{\"$id\":\"https://example.com/person.schema.json\",\"$schema\":\"https://json-schema.org/draft/2020-12/schema\",\"title\":\"Person\",\"type\":\"object\",\"properties\":{\"firstName\":{\"type\":\"string\",\"description\":\"The person's first name.\"},\"lastName\":{\"type\":\"string\",\"description\":\"The person's last name.\",\"test\":null},\"age\":{\"type\":\"integer\",\"description\":\"Age in years\",\"minimum\":0}}},{\"$id\":\"https://example.com/person.schema.json\",\"$schema\":\"https://json-schema.org/draft/2020-12/schema\",\"title\":\"Person\",\"type\":\"object\",\"properties\":{\"firstName\":{\"type\":\"string\",\"description\":\"The person's first name.\"},\"lastName\":{\"type\":\"string\",\"description\":\"The person's last name.\",\"test\":null},\"age\":{\"type\":\"integer\",\"description\":\"Age in years\",\"minimum\":0}}}]",
                    TestHelper.ConvertStreamToString(HttpCallBack.Response.RawBody),
                    true,
                    true,
                    false),
                    "Response body should have matching keys");
        }

        /// <summary>
        /// Get Schema Map.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [Test]
        public async Task TestGetSchemaMap()
        {
            // Perform API call
            JsonObject result = null;
            try
            {
                result = await this.controller.GetSchemaMapAsync();
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
                    "{\"key1\":{\"$id\":\"https://example.com/person.schema.json\",\"$schema\":\"https://json-schema.org/draft/2020-12/schema\",\"title\":\"Person\",\"type\":\"object\",\"properties\":{\"firstName\":{\"type\":\"string\",\"description\":\"The person's first name.\"},\"lastName\":{\"type\":\"string\",\"description\":\"The person's last name.\",\"test\":null},\"age\":{\"type\":\"integer\",\"description\":\"Age in years\",\"minimum\":0}}},\"key2\":{\"$id\":\"https://example.com/person.schema.json\",\"$schema\":\"https://json-schema.org/draft/2020-12/schema\",\"title\":\"Person\",\"type\":\"object\",\"properties\":{\"firstName\":{\"type\":\"string\",\"description\":\"The person's first name.\"},\"lastName\":{\"type\":\"string\",\"description\":\"The person's last name.\",\"test\":null},\"age\":{\"type\":\"integer\",\"description\":\"Age in years\",\"minimum\":0}}}}",
                    TestHelper.ConvertStreamToString(HttpCallBack.Response.RawBody),
                    true,
                    true,
                    false),
                    "Response body should have matching keys");
        }

        /// <summary>
        /// Get Schema in Model.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [Test]
        public async Task TestGetSchemaInModel()
        {
            // Perform API call
            Standard.Models.SchemaContainer result = null;
            try
            {
                result = await this.controller.GetSchemainModelAsync();
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
                    "{\"name\":\"a name\",\"id\":\"definition-123\",\"schemaMap\":{\"key1\":{\"$id\":\"https://example.com/person.schema.json\",\"$schema\":\"https://json-schema.org/draft/2020-12/schema\",\"title\":\"Person\",\"type\":\"object\",\"properties\":{\"firstName\":{\"type\":\"string\",\"description\":\"The person's first name.\"},\"lastName\":{\"type\":\"string\",\"description\":\"The person's last name.\",\"test\":null},\"age\":{\"type\":\"integer\",\"description\":\"Age in years\",\"minimum\":0}}},\"key2\":{\"$id\":\"https://example.com/person.schema.json\",\"$schema\":\"https://json-schema.org/draft/2020-12/schema\",\"title\":\"Person\",\"type\":\"object\",\"properties\":{\"firstName\":{\"type\":\"string\",\"description\":\"The person's first name.\"},\"lastName\":{\"type\":\"string\",\"description\":\"The person's last name.\",\"test\":null},\"age\":{\"type\":\"integer\",\"description\":\"Age in years\",\"minimum\":0}}}},\"schemaArray\":[{\"$id\":\"https://example.com/person.schema.json\",\"$schema\":\"https://json-schema.org/draft/2020-12/schema\",\"title\":\"Person\",\"type\":\"object\",\"properties\":{\"firstName\":{\"type\":\"string\",\"description\":\"The person's first name.\"},\"lastName\":{\"type\":\"string\",\"description\":\"The person's last name.\",\"test\":null},\"age\":{\"type\":\"integer\",\"description\":\"Age in years\",\"minimum\":0}}},{\"$id\":\"https://example.com/person.schema.json\",\"$schema\":\"https://json-schema.org/draft/2020-12/schema\",\"title\":\"Person\",\"type\":\"object\",\"properties\":{\"firstName\":{\"type\":\"string\",\"description\":\"The person's first name.\"},\"lastName\":{\"type\":\"string\",\"description\":\"The person's last name.\",\"test\":null},\"age\":{\"type\":\"integer\",\"description\":\"Age in years\",\"minimum\":0}}}],\"schema\":{\"$id\":\"https://example.com/person.schema.json\",\"$schema\":\"https://json-schema.org/draft/2020-12/schema\",\"title\":\"Person\",\"type\":\"object\",\"properties\":{\"firstName\":{\"type\":\"string\",\"description\":\"The person's first name.\"},\"lastName\":{\"type\":\"string\",\"description\":\"The person's last name.\",\"test\":null},\"age\":{\"type\":\"integer\",\"description\":\"Age in years\",\"minimum\":0}}}}",
                    TestHelper.ConvertStreamToString(HttpCallBack.Response.RawBody),
                    true,
                    true,
                    false),
                    "Response body should have matching keys");
        }
    }
}
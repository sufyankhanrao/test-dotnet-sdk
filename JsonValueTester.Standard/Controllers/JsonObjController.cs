// <copyright file="JsonObjController.cs" company="APIMatic">
// Copyright (c) APIMatic. All rights reserved.
// </copyright>
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using APIMatic.Core;
using APIMatic.Core.Types;
using APIMatic.Core.Utilities;
using APIMatic.Core.Utilities.Date.Xml;
using JsonValueTester.Standard;
using JsonValueTester.Standard.Http.Client;
using JsonValueTester.Standard.Utilities;
using Newtonsoft.Json.Converters;
using System.Net.Http;

namespace JsonValueTester.Standard.Controllers
{
    /// <summary>
    /// JsonObjController.
    /// </summary>
    internal class JsonObjController : BaseController, IJsonObjController
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="JsonObjController"/> class.
        /// </summary>
        internal JsonObjController(GlobalConfiguration globalConfiguration) : base(globalConfiguration) { }

        /// <summary>
        /// Send Schema in Model.
        /// </summary>
        /// <param name="body">Required parameter: Example: .</param>
        /// <returns>Returns the Models.ServerResponse response from the API call.</returns>
        public Models.ServerResponse SendSchemainModel(
                Models.SchemaContainer body)
            => CoreHelper.RunTask(SendSchemainModelAsync(body));

        /// <summary>
        /// Send Schema in Model.
        /// </summary>
        /// <param name="body">Required parameter: Example: .</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.ServerResponse response from the API call.</returns>
        public async Task<Models.ServerResponse> SendSchemainModelAsync(
                Models.SchemaContainer body,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<Models.ServerResponse>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Post, "/body/sendSchemaInModel")
                  .Parameters(_parameters => _parameters
                      .Body(_bodyParameter => _bodyParameter.Setup(body).Required())
                      .Header(_header => _header.Setup("Content-Type", "application/json"))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .NullOn404())
              .ExecuteAsync(cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Send Schema as Body.
        /// </summary>
        /// <param name="body">Required parameter: Example: .</param>
        /// <returns>Returns the Models.ServerResponse response from the API call.</returns>
        public Models.ServerResponse SendSchemaasBody(
                JsonObject body)
            => CoreHelper.RunTask(SendSchemaasBodyAsync(body));

        /// <summary>
        /// Send Schema as Body.
        /// </summary>
        /// <param name="body">Required parameter: Example: .</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.ServerResponse response from the API call.</returns>
        public async Task<Models.ServerResponse> SendSchemaasBodyAsync(
                JsonObject body,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<Models.ServerResponse>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Post, "/body/sendSchema")
                  .Parameters(_parameters => _parameters
                      .Body(_bodyParameter => _bodyParameter.Setup(body).Required())
                      .Header(_header => _header.Setup("Content-Type", "application/json"))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .NullOn404())
              .ExecuteAsync(cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Send Schema as Form.
        /// </summary>
        /// <param name="input">Object containing request parameters.</param>
        /// <returns>Returns the Models.ServerResponse response from the API call.</returns>
        public Models.ServerResponse SendSchemaasForm(
                Models.SendSchemaasFormInput input)
            => CoreHelper.RunTask(SendSchemaasFormAsync(input));

        /// <summary>
        /// Send Schema as Form.
        /// </summary>
        /// <param name="input">Object containing request parameters.</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.ServerResponse response from the API call.</returns>
        public async Task<Models.ServerResponse> SendSchemaasFormAsync(
                Models.SendSchemaasFormInput input,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<Models.ServerResponse>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Post, "/form/sendSchema")
                  .Parameters(_parameters => _parameters
                      .Header(_header => _header.Setup("Content-Type", ApiHelper.JsonSerialize(input.ContentType).Trim('\"')))
                      .Form(_form => _form.Setup("id", input.Id))
                      .Form(_form => _form.Setup("model", input.Model).Required())
                      .Form(_form => _form.Setup("modelArray", input.ModelArray))
                      .Form(_form => _form.Setup("modelMap", input.ModelMap))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .NullOn404())
              .ExecuteAsync(cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Send Schema as Query.
        /// </summary>
        /// <param name="input">Object containing request parameters.</param>
        /// <returns>Returns the Models.ServerResponse response from the API call.</returns>
        public Models.ServerResponse SendSchemaasQuery(
                Models.SendSchemaasQueryInput input)
            => CoreHelper.RunTask(SendSchemaasQueryAsync(input));

        /// <summary>
        /// Send Schema as Query.
        /// </summary>
        /// <param name="input">Object containing request parameters.</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.ServerResponse response from the API call.</returns>
        public async Task<Models.ServerResponse> SendSchemaasQueryAsync(
                Models.SendSchemaasQueryInput input,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<Models.ServerResponse>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Post, "/query/sendSchema")
                  .Parameters(_parameters => _parameters
                      .Query(_query => _query.Setup("id", input.Id))
                      .Query(_query => _query.Setup("model", input.Model).Required())
                      .Query(_query => _query.Setup("modelArray", input.ModelArray))
                      .Query(_query => _query.Setup("modelMap", input.ModelMap))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .NullOn404())
              .ExecuteAsync(cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Get Schema.
        /// </summary>
        /// <returns>Returns the JsonObject response from the API call.</returns>
        public JsonObject GetSchema()
            => CoreHelper.RunTask(GetSchemaAsync());

        /// <summary>
        /// Get Schema.
        /// </summary>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the JsonObject response from the API call.</returns>
        public async Task<JsonObject> GetSchemaAsync(CancellationToken cancellationToken = default)
            => await CreateApiCall<JsonObject>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Get, "/response/getSchema"))
              .ResponseHandler(_responseHandler => _responseHandler
                  .NullOn404()
                  .Deserializer(_response => JsonObject.FromJsonString(_response)))
              .ExecuteAsync(cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Get Schema Array.
        /// </summary>
        /// <returns>Returns the List of JsonObject response from the API call.</returns>
        public List<JsonObject> GetSchemaArray()
            => CoreHelper.RunTask(GetSchemaArrayAsync());

        /// <summary>
        /// Get Schema Array.
        /// </summary>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the List of JsonObject response from the API call.</returns>
        public async Task<List<JsonObject>> GetSchemaArrayAsync(CancellationToken cancellationToken = default)
            => await CreateApiCall<List<JsonObject>>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Get, "/response/getSchemaArray"))
              .ResponseHandler(_responseHandler => _responseHandler
                  .NullOn404())
              .ExecuteAsync(cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Get Schema Map.
        /// </summary>
        /// <returns>Returns the JsonObject response from the API call.</returns>
        public JsonObject GetSchemaMap()
            => CoreHelper.RunTask(GetSchemaMapAsync());

        /// <summary>
        /// Get Schema Map.
        /// </summary>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the JsonObject response from the API call.</returns>
        public async Task<JsonObject> GetSchemaMapAsync(CancellationToken cancellationToken = default)
            => await CreateApiCall<JsonObject>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Get, "/response/getSchemaMap"))
              .ResponseHandler(_responseHandler => _responseHandler
                  .NullOn404()
                  .Deserializer(_response => JsonObject.FromJsonString(_response)))
              .ExecuteAsync(cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Get Schema in Model.
        /// </summary>
        /// <returns>Returns the Models.SchemaContainer response from the API call.</returns>
        public Models.SchemaContainer GetSchemainModel()
            => CoreHelper.RunTask(GetSchemainModelAsync());

        /// <summary>
        /// Get Schema in Model.
        /// </summary>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.SchemaContainer response from the API call.</returns>
        public async Task<Models.SchemaContainer> GetSchemainModelAsync(CancellationToken cancellationToken = default)
            => await CreateApiCall<Models.SchemaContainer>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Get, "/response/getSchemaInModel"))
              .ResponseHandler(_responseHandler => _responseHandler
                  .NullOn404())
              .ExecuteAsync(cancellationToken).ConfigureAwait(false);
    }
}
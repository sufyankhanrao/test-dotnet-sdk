// <copyright file="JsonValController.cs" company="APIMatic">
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
    /// JsonValController.
    /// </summary>
    internal class JsonValController : BaseController, IJsonValController
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="JsonValController"/> class.
        /// </summary>
        internal JsonValController(GlobalConfiguration globalConfiguration) : base(globalConfiguration) { }

        /// <summary>
        /// Send Value in Model.
        /// </summary>
        /// <param name="body">Required parameter: Example: .</param>
        /// <returns>Returns the Models.ServerResponse response from the API call.</returns>
        public Models.ServerResponse SendValueinModel(
                Models.ValueContainer body)
            => CoreHelper.RunTask(SendValueinModelAsync(body));

        /// <summary>
        /// Send Value in Model.
        /// </summary>
        /// <param name="body">Required parameter: Example: .</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.ServerResponse response from the API call.</returns>
        public async Task<Models.ServerResponse> SendValueinModelAsync(
                Models.ValueContainer body,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<Models.ServerResponse>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Post, "/body/sendValueInModel")
                  .Parameters(_parameters => _parameters
                      .Body(_bodyParameter => _bodyParameter.Setup(body).Required())
                      .Header(_header => _header.Setup("Content-Type", "application/json"))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .NullOn404())
              .ExecuteAsync(cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Send Value as Body.
        /// </summary>
        /// <param name="body">Required parameter: Example: .</param>
        /// <returns>Returns the Models.ServerResponse response from the API call.</returns>
        public Models.ServerResponse SendValueasBody(
                JsonValue body)
            => CoreHelper.RunTask(SendValueasBodyAsync(body));

        /// <summary>
        /// Send Value as Body.
        /// </summary>
        /// <param name="body">Required parameter: Example: .</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.ServerResponse response from the API call.</returns>
        public async Task<Models.ServerResponse> SendValueasBodyAsync(
                JsonValue body,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<Models.ServerResponse>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Post, "/body/sendValue")
                  .Parameters(_parameters => _parameters
                      .Body(_bodyParameter => _bodyParameter.Setup(body).Required())
                      .Header(_header => _header.Setup("Content-Type", "text/plain"))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .NullOn404())
              .ExecuteAsync(cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Send Value as Form.
        /// </summary>
        /// <param name="input">Object containing request parameters.</param>
        /// <returns>Returns the Models.ServerResponse response from the API call.</returns>
        public Models.ServerResponse SendValueasForm(
                Models.SendValueasFormInput input)
            => CoreHelper.RunTask(SendValueasFormAsync(input));

        /// <summary>
        /// Send Value as Form.
        /// </summary>
        /// <param name="input">Object containing request parameters.</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.ServerResponse response from the API call.</returns>
        public async Task<Models.ServerResponse> SendValueasFormAsync(
                Models.SendValueasFormInput input,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<Models.ServerResponse>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Post, "/form/sendValue")
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
        /// Send Value as Query.
        /// </summary>
        /// <param name="input">Object containing request parameters.</param>
        /// <returns>Returns the Models.ServerResponse response from the API call.</returns>
        public Models.ServerResponse SendValueasQuery(
                Models.SendValueasQueryInput input)
            => CoreHelper.RunTask(SendValueasQueryAsync(input));

        /// <summary>
        /// Send Value as Query.
        /// </summary>
        /// <param name="input">Object containing request parameters.</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.ServerResponse response from the API call.</returns>
        public async Task<Models.ServerResponse> SendValueasQueryAsync(
                Models.SendValueasQueryInput input,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<Models.ServerResponse>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Post, "/query/sendValue")
                  .Parameters(_parameters => _parameters
                      .Query(_query => _query.Setup("id", input.Id))
                      .Query(_query => _query.Setup("model", input.Model).Required())
                      .Query(_query => _query.Setup("modelArray", input.ModelArray))
                      .Query(_query => _query.Setup("modelMap", input.ModelMap))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .NullOn404())
              .ExecuteAsync(cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Get Value.
        /// </summary>
        /// <returns>Returns the JsonValue response from the API call.</returns>
        public JsonValue GetValue()
            => CoreHelper.RunTask(GetValueAsync());

        /// <summary>
        /// Get Value.
        /// </summary>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the JsonValue response from the API call.</returns>
        public async Task<JsonValue> GetValueAsync(CancellationToken cancellationToken = default)
            => await CreateApiCall<JsonValue>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Get, "/response/getValue"))
              .ResponseHandler(_responseHandler => _responseHandler
                  .NullOn404())
              .ExecuteAsync(cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Get Value Array.
        /// </summary>
        /// <returns>Returns the List of JsonValue response from the API call.</returns>
        public List<JsonValue> GetValueArray()
            => CoreHelper.RunTask(GetValueArrayAsync());

        /// <summary>
        /// Get Value Array.
        /// </summary>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the List of JsonValue response from the API call.</returns>
        public async Task<List<JsonValue>> GetValueArrayAsync(CancellationToken cancellationToken = default)
            => await CreateApiCall<List<JsonValue>>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Get, "/response/getValueArray"))
              .ResponseHandler(_responseHandler => _responseHandler
                  .NullOn404())
              .ExecuteAsync(cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Get Value Map.
        /// </summary>
        /// <returns>Returns the JsonValue response from the API call.</returns>
        public JsonValue GetValueMap()
            => CoreHelper.RunTask(GetValueMapAsync());

        /// <summary>
        /// Get Value Map.
        /// </summary>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the JsonValue response from the API call.</returns>
        public async Task<JsonValue> GetValueMapAsync(CancellationToken cancellationToken = default)
            => await CreateApiCall<JsonValue>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Get, "/response/getValueMap"))
              .ResponseHandler(_responseHandler => _responseHandler
                  .NullOn404())
              .ExecuteAsync(cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Get Value in Model.
        /// </summary>
        /// <returns>Returns the Models.ValueContainer response from the API call.</returns>
        public Models.ValueContainer GetValueinModel()
            => CoreHelper.RunTask(GetValueinModelAsync());

        /// <summary>
        /// Get Value in Model.
        /// </summary>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.ValueContainer response from the API call.</returns>
        public async Task<Models.ValueContainer> GetValueinModelAsync(CancellationToken cancellationToken = default)
            => await CreateApiCall<Models.ValueContainer>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Get, "/response/getValueInModel"))
              .ResponseHandler(_responseHandler => _responseHandler
                  .NullOn404())
              .ExecuteAsync(cancellationToken).ConfigureAwait(false);
    }
}
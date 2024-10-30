// <copyright file="IJsonValController.cs" company="APIMatic">
// Copyright (c) APIMatic. All rights reserved.
// </copyright>
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using JsonValueTester.Standard;
using JsonValueTester.Standard.Http.Client;
using JsonValueTester.Standard.Http.Request;
using JsonValueTester.Standard.Http.Response;
using JsonValueTester.Standard.Utilities;

namespace JsonValueTester.Standard.Controllers
{
    /// <summary>
    /// IJsonValController.
    /// </summary>
    public interface IJsonValController
    {
        /// <summary>
        /// Send Value in Model.
        /// </summary>
        /// <param name="body">Required parameter: Example: .</param>
        /// <returns>Returns the Models.ServerResponse response from the API call.</returns>
        Models.ServerResponse SendValueinModel(
                Models.ValueContainer body);

        /// <summary>
        /// Send Value in Model.
        /// </summary>
        /// <param name="body">Required parameter: Example: .</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.ServerResponse response from the API call.</returns>
        Task<Models.ServerResponse> SendValueinModelAsync(
                Models.ValueContainer body,
                CancellationToken cancellationToken = default);

        /// <summary>
        /// Send Value as Body.
        /// </summary>
        /// <param name="body">Required parameter: Example: .</param>
        /// <returns>Returns the Models.ServerResponse response from the API call.</returns>
        Models.ServerResponse SendValueasBody(
                JsonValue body);

        /// <summary>
        /// Send Value as Body.
        /// </summary>
        /// <param name="body">Required parameter: Example: .</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.ServerResponse response from the API call.</returns>
        Task<Models.ServerResponse> SendValueasBodyAsync(
                JsonValue body,
                CancellationToken cancellationToken = default);

        /// <summary>
        /// Send Value as Form.
        /// </summary>
        /// <param name="input">Object containing request parameters.</param>
        /// <returns>Returns the Models.ServerResponse response from the API call.</returns>
        Models.ServerResponse SendValueasForm(
                Models.SendValueasFormInput input);

        /// <summary>
        /// Send Value as Form.
        /// </summary>
        /// <param name="input">Object containing request parameters.</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.ServerResponse response from the API call.</returns>
        Task<Models.ServerResponse> SendValueasFormAsync(
                Models.SendValueasFormInput input,
                CancellationToken cancellationToken = default);

        /// <summary>
        /// Send Value as Query.
        /// </summary>
        /// <param name="input">Object containing request parameters.</param>
        /// <returns>Returns the Models.ServerResponse response from the API call.</returns>
        Models.ServerResponse SendValueasQuery(
                Models.SendValueasQueryInput input);

        /// <summary>
        /// Send Value as Query.
        /// </summary>
        /// <param name="input">Object containing request parameters.</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.ServerResponse response from the API call.</returns>
        Task<Models.ServerResponse> SendValueasQueryAsync(
                Models.SendValueasQueryInput input,
                CancellationToken cancellationToken = default);

        /// <summary>
        /// Get Value.
        /// </summary>
        /// <returns>Returns the JsonValue response from the API call.</returns>
        JsonValue GetValue();

        /// <summary>
        /// Get Value.
        /// </summary>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the JsonValue response from the API call.</returns>
        Task<JsonValue> GetValueAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Get Value Array.
        /// </summary>
        /// <returns><![CDATA[Returns the List<JsonValue> response from the API call.]]></returns>
        List<JsonValue> GetValueArray();

        /// <summary>
        /// Get Value Array.
        /// </summary>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns><![CDATA[Returns the List<JsonValue> response from the API call.]]></returns>
        Task<List<JsonValue>> GetValueArrayAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Get Value Map.
        /// </summary>
        /// <returns>Returns the JsonValue response from the API call.</returns>
        JsonValue GetValueMap();

        /// <summary>
        /// Get Value Map.
        /// </summary>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the JsonValue response from the API call.</returns>
        Task<JsonValue> GetValueMapAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Get Value in Model.
        /// </summary>
        /// <returns>Returns the Models.ValueContainer response from the API call.</returns>
        Models.ValueContainer GetValueinModel();

        /// <summary>
        /// Get Value in Model.
        /// </summary>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.ValueContainer response from the API call.</returns>
        Task<Models.ValueContainer> GetValueinModelAsync(CancellationToken cancellationToken = default);
    }
}
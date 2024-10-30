// <copyright file="IJsonObjController.cs" company="APIMatic">
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
    /// IJsonObjController.
    /// </summary>
    public interface IJsonObjController
    {
        /// <summary>
        /// Send Schema in Model.
        /// </summary>
        /// <param name="body">Required parameter: Example: .</param>
        /// <returns>Returns the Models.ServerResponse response from the API call.</returns>
        Models.ServerResponse SendSchemainModel(
                Models.SchemaContainer body);

        /// <summary>
        /// Send Schema in Model.
        /// </summary>
        /// <param name="body">Required parameter: Example: .</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.ServerResponse response from the API call.</returns>
        Task<Models.ServerResponse> SendSchemainModelAsync(
                Models.SchemaContainer body,
                CancellationToken cancellationToken = default);

        /// <summary>
        /// Send Schema as Body.
        /// </summary>
        /// <param name="body">Required parameter: Example: .</param>
        /// <returns>Returns the Models.ServerResponse response from the API call.</returns>
        Models.ServerResponse SendSchemaasBody(
                JsonObject body);

        /// <summary>
        /// Send Schema as Body.
        /// </summary>
        /// <param name="body">Required parameter: Example: .</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.ServerResponse response from the API call.</returns>
        Task<Models.ServerResponse> SendSchemaasBodyAsync(
                JsonObject body,
                CancellationToken cancellationToken = default);

        /// <summary>
        /// Send Schema as Form.
        /// </summary>
        /// <param name="input">Object containing request parameters.</param>
        /// <returns>Returns the Models.ServerResponse response from the API call.</returns>
        Models.ServerResponse SendSchemaasForm(
                Models.SendSchemaasFormInput input);

        /// <summary>
        /// Send Schema as Form.
        /// </summary>
        /// <param name="input">Object containing request parameters.</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.ServerResponse response from the API call.</returns>
        Task<Models.ServerResponse> SendSchemaasFormAsync(
                Models.SendSchemaasFormInput input,
                CancellationToken cancellationToken = default);

        /// <summary>
        /// Send Schema as Query.
        /// </summary>
        /// <param name="input">Object containing request parameters.</param>
        /// <returns>Returns the Models.ServerResponse response from the API call.</returns>
        Models.ServerResponse SendSchemaasQuery(
                Models.SendSchemaasQueryInput input);

        /// <summary>
        /// Send Schema as Query.
        /// </summary>
        /// <param name="input">Object containing request parameters.</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.ServerResponse response from the API call.</returns>
        Task<Models.ServerResponse> SendSchemaasQueryAsync(
                Models.SendSchemaasQueryInput input,
                CancellationToken cancellationToken = default);

        /// <summary>
        /// Get Schema.
        /// </summary>
        /// <returns>Returns the JsonObject response from the API call.</returns>
        JsonObject GetSchema();

        /// <summary>
        /// Get Schema.
        /// </summary>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the JsonObject response from the API call.</returns>
        Task<JsonObject> GetSchemaAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Get Schema Array.
        /// </summary>
        /// <returns><![CDATA[Returns the List<JsonObject> response from the API call.]]></returns>
        List<JsonObject> GetSchemaArray();

        /// <summary>
        /// Get Schema Array.
        /// </summary>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns><![CDATA[Returns the List<JsonObject> response from the API call.]]></returns>
        Task<List<JsonObject>> GetSchemaArrayAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Get Schema Map.
        /// </summary>
        /// <returns>Returns the JsonObject response from the API call.</returns>
        JsonObject GetSchemaMap();

        /// <summary>
        /// Get Schema Map.
        /// </summary>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the JsonObject response from the API call.</returns>
        Task<JsonObject> GetSchemaMapAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Get Schema in Model.
        /// </summary>
        /// <returns>Returns the Models.SchemaContainer response from the API call.</returns>
        Models.SchemaContainer GetSchemainModel();

        /// <summary>
        /// Get Schema in Model.
        /// </summary>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.SchemaContainer response from the API call.</returns>
        Task<Models.SchemaContainer> GetSchemainModelAsync(CancellationToken cancellationToken = default);
    }
}
// <copyright file="JsonValueTesterClient.cs" company="APIMatic">
// Copyright (c) APIMatic. All rights reserved.
// </copyright>
using System;
using System.Collections.Generic;
using System.Linq;
using APIMatic.Core;
using JsonValueTester.Standard.Controllers;
using JsonValueTester.Standard.Http.Client;
using JsonValueTester.Standard.Utilities;

namespace JsonValueTester.Standard
{
    /// <summary>
    /// The gateway for the SDK. This class acts as a factory for Controller and
    /// holds the configuration of the SDK.
    /// </summary>
    public sealed class JsonValueTesterClient : IJsonValueTesterClient
    {
        // A map of environments and their corresponding servers/baseurls
        private static readonly Dictionary<Environment, Dictionary<Enum, string>> EnvironmentsMap =
            new Dictionary<Environment, Dictionary<Enum, string>>
        {
            {
                Environment.Production, new Dictionary<Enum, string>
                {
                    { Server.Default, "http://apimatic.hopto.org" },
                    { Server.AuthServer, "http://apimaticauth.hopto.org:3000" },
                }
            },
            {
                Environment.Testing, new Dictionary<Enum, string>
                {
                    { Server.Default, "http://localhost:3000" },
                    { Server.AuthServer, "http://apimaticauth.xhopto.org:3000" },
                }
            },
        };

        private readonly GlobalConfiguration globalConfiguration;
        private readonly HttpCallback httpCallback;
        private readonly Lazy<IJsonObjController> jsonObj;
        private readonly Lazy<IJsonValController> jsonVal;

        private JsonValueTesterClient(
            Environment environment,
            HttpCallback httpCallback,
            IHttpClientConfiguration httpClientConfiguration)
        {
            this.Environment = environment;
            this.httpCallback = httpCallback;
            this.HttpClientConfiguration = httpClientConfiguration;

            globalConfiguration = new GlobalConfiguration.Builder()
                .ApiCallback(httpCallback)
                .HttpConfiguration(httpClientConfiguration)
                .ServerUrls(EnvironmentsMap[environment], Server.Default)
                .Build();


            this.jsonObj = new Lazy<IJsonObjController>(
                () => new JsonObjController(globalConfiguration));
            this.jsonVal = new Lazy<IJsonValController>(
                () => new JsonValController(globalConfiguration));
        }

        /// <summary>
        /// Gets JsonObjController controller.
        /// </summary>
        public IJsonObjController JsonObjController => this.jsonObj.Value;

        /// <summary>
        /// Gets JsonValController controller.
        /// </summary>
        public IJsonValController JsonValController => this.jsonVal.Value;

        /// <summary>
        /// Gets the configuration of the Http Client associated with this client.
        /// </summary>
        public IHttpClientConfiguration HttpClientConfiguration { get; }

        /// <summary>
        /// Gets Environment.
        /// Current API environment.
        /// </summary>
        public Environment Environment { get; }

        /// <summary>
        /// Gets http callback.
        /// </summary>
        public HttpCallback HttpCallback => this.httpCallback;

        /// <summary>
        /// Gets the URL for a particular alias in the current environment and appends
        /// it with template parameters.
        /// </summary>
        /// <param name="alias">Default value:DEFAULT.</param>
        /// <returns>Returns the baseurl.</returns>
        public string GetBaseUri(Server alias = Server.Default)
        {
            return globalConfiguration.ServerUrl(alias);
        }

        /// <summary>
        /// Creates an object of the JsonValueTesterClient using the values provided for the builder.
        /// </summary>
        /// <returns>Builder.</returns>
        public Builder ToBuilder()
        {
            Builder builder = new Builder()
                .Environment(this.Environment)
                .HttpCallback(httpCallback)
                .HttpClientConfig(config => config.Build());

            return builder;
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return
                $"Environment = {this.Environment}, " +
                $"HttpClientConfiguration = {this.HttpClientConfiguration}, ";
        }

        /// <summary>
        /// Creates the client using builder.
        /// </summary>
        /// <returns> JsonValueTesterClient.</returns>
        internal static JsonValueTesterClient CreateFromEnvironment()
        {
            var builder = new Builder();

            string environment = System.Environment.GetEnvironmentVariable("JSON_VALUE_TESTER_STANDARD_ENVIRONMENT");

            if (environment != null)
            {
                builder.Environment(ApiHelper.JsonDeserialize<Environment>($"\"{environment}\""));
            }

            return builder.Build();
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private Environment environment = JsonValueTester.Standard.Environment.Testing;
            private HttpClientConfiguration.Builder httpClientConfig = new HttpClientConfiguration.Builder();
            private HttpCallback httpCallback;

            /// <summary>
            /// Sets Environment.
            /// </summary>
            /// <param name="environment"> Environment. </param>
            /// <returns> Builder. </returns>
            public Builder Environment(Environment environment)
            {
                this.environment = environment;
                return this;
            }

            /// <summary>
            /// Sets HttpClientConfig.
            /// </summary>
            /// <param name="action"> Action. </param>
            /// <returns>Builder.</returns>
            public Builder HttpClientConfig(Action<HttpClientConfiguration.Builder> action)
            {
                if (action is null)
                {
                    throw new ArgumentNullException(nameof(action));
                }

                action(this.httpClientConfig);
                return this;
            }



            /// <summary>
            /// Sets the HttpCallback for the Builder.
            /// </summary>
            /// <param name="httpCallback"> http callback. </param>
            /// <returns>Builder.</returns>
            public Builder HttpCallback(HttpCallback httpCallback)
            {
                this.httpCallback = httpCallback;
                return this;
            }

            /// <summary>
            /// Creates an object of the JsonValueTesterClient using the values provided for the builder.
            /// </summary>
            /// <returns>JsonValueTesterClient.</returns>
            public JsonValueTesterClient Build()
            {
                return new JsonValueTesterClient(
                    environment,
                    httpCallback,
                    httpClientConfig.Build());
            }
        }
    }
}

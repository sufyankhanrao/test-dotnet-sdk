// <copyright file="IJsonValueTesterClient.cs" company="APIMatic">
// Copyright (c) APIMatic. All rights reserved.
// </copyright>
using System;
using JsonValueTester.Standard.Controllers;

namespace JsonValueTester.Standard
{
    /// <summary>
    /// IJsonValueTesterClient.
    /// </summary>
    public interface IJsonValueTesterClient : IConfiguration
    {
        /// <summary>
        /// Gets instance for IJsonObjController.
        /// </summary>
        IJsonObjController JsonObjController { get; }

        /// <summary>
        /// Gets instance for IJsonValController.
        /// </summary>
        IJsonValController JsonValController { get; }
    }
}
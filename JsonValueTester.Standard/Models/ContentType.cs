// <copyright file="ContentType.cs" company="APIMatic">
// Copyright (c) APIMatic. All rights reserved.
// </copyright>
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using APIMatic.Core.Utilities.Converters;
using JsonValueTester.Standard;
using JsonValueTester.Standard.Utilities;
using Newtonsoft.Json;

namespace JsonValueTester.Standard.Models
{
    /// <summary>
    /// ContentType.
    /// </summary>

    [JsonConverter(typeof(StringEnumConverter))]
    public enum ContentType
    {
        /// <summary>
        /// EnumApplicationxwwwformurlencoded.
        /// </summary>
        [EnumMember(Value = "application/x-www-form-urlencoded")]
        EnumApplicationxwwwformurlencoded
    }
}
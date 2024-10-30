// <copyright file="ServerResponse.cs" company="APIMatic">
// Copyright (c) APIMatic. All rights reserved.
// </copyright>
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APIMatic.Core.Utilities.Converters;
using JsonValueTester.Standard;
using JsonValueTester.Standard.Utilities;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace JsonValueTester.Standard.Models
{
    /// <summary>
    /// ServerResponse.
    /// </summary>
    public class ServerResponse : BaseModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ServerResponse"/> class.
        /// </summary>
        public ServerResponse()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ServerResponse"/> class.
        /// </summary>
        /// <param name="passed">passed.</param>
        /// <param name="message">Message.</param>
        /// <param name="input">input.</param>
        /// <param name="nullableNumberMap">nullableNumberMap.</param>
        /// <param name="nullableNumberArray">nullableNumberArray.</param>
        public ServerResponse(
            bool passed,
            string message = null,
            JsonObject input = null,
            Dictionary<string, double?> nullableNumberMap = null,
            List<double?> nullableNumberArray = null)
        {
            this.Passed = passed;
            this.Message = message;
            this.Input = input;
            this.NullableNumberMap = nullableNumberMap;
            this.NullableNumberArray = nullableNumberArray;
        }

        /// <summary>
        /// Gets or sets Passed.
        /// </summary>
        [JsonProperty("passed")]
        public bool Passed { get; set; }

        /// <summary>
        /// Gets or sets Message.
        /// </summary>
        [JsonProperty("Message", NullValueHandling = NullValueHandling.Ignore)]
        public string Message { get; set; }

        /// <summary>
        /// Gets or sets Input.
        /// </summary>
        [JsonProperty("input", NullValueHandling = NullValueHandling.Ignore)]
        public JsonObject Input { get; set; }

        /// <summary>
        /// Gets or sets NullableNumberMap.
        /// </summary>
        [JsonProperty("nullableNumberMap", NullValueHandling = NullValueHandling.Ignore)]
        public Dictionary<string, double?> NullableNumberMap { get; set; }

        /// <summary>
        /// Gets or sets NullableNumberArray.
        /// </summary>
        [JsonProperty("nullableNumberArray", NullValueHandling = NullValueHandling.Ignore)]
        public List<double?> NullableNumberArray { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"ServerResponse : ({string.Join(", ", toStringOutput)})";
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            if (obj == this)
            {
                return true;
            }
            return obj is ServerResponse other &&                this.Passed.Equals(other.Passed) &&
                ((this.Message == null && other.Message == null) || (this.Message?.Equals(other.Message) == true)) &&
                ((this.Input == null && other.Input == null) || (this.Input?.Equals(other.Input) == true)) &&
                ((this.NullableNumberMap == null && other.NullableNumberMap == null) || (this.NullableNumberMap?.Equals(other.NullableNumberMap) == true)) &&
                ((this.NullableNumberArray == null && other.NullableNumberArray == null) || (this.NullableNumberArray?.Equals(other.NullableNumberArray) == true));
        }
        
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected new void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Passed = {this.Passed}");
            toStringOutput.Add($"this.Message = {(this.Message == null ? "null" : this.Message)}");
            toStringOutput.Add($"Input = {(this.Input == null ? "null" : this.Input.ToString())}");
            toStringOutput.Add($"NullableNumberMap = {(this.NullableNumberMap == null ? "null" : this.NullableNumberMap.ToString())}");
            toStringOutput.Add($"this.NullableNumberArray = {(this.NullableNumberArray == null ? "null" : $"[{string.Join(", ", this.NullableNumberArray)} ]")}");

            base.ToString(toStringOutput);
        }
    }
}
// <copyright file="ValueContainer.cs" company="APIMatic">
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
    /// ValueContainer.
    /// </summary>
    public class ValueContainer : BaseModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ValueContainer"/> class.
        /// </summary>
        public ValueContainer()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ValueContainer"/> class.
        /// </summary>
        /// <param name="name">name.</param>
        /// <param name="id">id.</param>
        /// <param name="mValue">value.</param>
        /// <param name="valueArray">valueArray.</param>
        /// <param name="valueMap">valueMap.</param>
        public ValueContainer(
            string name,
            string id,
            JsonValue mValue,
            List<JsonValue> valueArray = null,
            JsonValue valueMap = null)
        {
            this.Name = name;
            this.Id = id;
            this.MValue = mValue;
            this.ValueArray = valueArray;
            this.ValueMap = valueMap;
        }

        /// <summary>
        /// Gets or sets Name.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets Id.
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets MValue.
        /// </summary>
        [JsonProperty("value")]
        public JsonValue MValue { get; set; }

        /// <summary>
        /// Gets or sets ValueArray.
        /// </summary>
        [JsonProperty("valueArray", NullValueHandling = NullValueHandling.Ignore)]
        public List<JsonValue> ValueArray { get; set; }

        /// <summary>
        /// Gets or sets ValueMap.
        /// </summary>
        [JsonProperty("valueMap", NullValueHandling = NullValueHandling.Ignore)]
        public JsonValue ValueMap { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"ValueContainer : ({string.Join(", ", toStringOutput)})";
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
            return obj is ValueContainer other &&                ((this.Name == null && other.Name == null) || (this.Name?.Equals(other.Name) == true)) &&
                ((this.Id == null && other.Id == null) || (this.Id?.Equals(other.Id) == true)) &&
                ((this.MValue == null && other.MValue == null) || (this.MValue?.Equals(other.MValue) == true)) &&
                ((this.ValueArray == null && other.ValueArray == null) || (this.ValueArray?.Equals(other.ValueArray) == true)) &&
                ((this.ValueMap == null && other.ValueMap == null) || (this.ValueMap?.Equals(other.ValueMap) == true));
        }
        
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected new void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Name = {(this.Name == null ? "null" : this.Name)}");
            toStringOutput.Add($"this.Id = {(this.Id == null ? "null" : this.Id)}");
            toStringOutput.Add($"MValue = {(this.MValue == null ? "null" : this.MValue.ToString())}");
            toStringOutput.Add($"ValueArray = {(this.ValueArray == null ? "null" : this.ValueArray.ToString())}");
            toStringOutput.Add($"ValueMap = {(this.ValueMap == null ? "null" : this.ValueMap.ToString())}");

            base.ToString(toStringOutput);
        }
    }
}
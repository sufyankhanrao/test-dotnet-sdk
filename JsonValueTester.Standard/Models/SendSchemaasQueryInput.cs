// <copyright file="SendSchemaasQueryInput.cs" company="APIMatic">
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
    /// SendSchemaasQueryInput.
    /// </summary>
    public class SendSchemaasQueryInput : BaseModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SendSchemaasQueryInput"/> class.
        /// </summary>
        public SendSchemaasQueryInput()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SendSchemaasQueryInput"/> class.
        /// </summary>
        /// <param name="id">id.</param>
        /// <param name="model">model.</param>
        /// <param name="modelArray">modelArray.</param>
        /// <param name="modelMap">modelMap.</param>
        public SendSchemaasQueryInput(
            int id,
            JsonObject model,
            List<JsonObject> modelArray = null,
            JsonObject modelMap = null)
        {
            this.Id = id;
            this.Model = model;
            this.ModelArray = modelArray;
            this.ModelMap = modelMap;
        }

        /// <summary>
        /// Gets or sets Id.
        /// </summary>
        [JsonProperty("id")]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets Model.
        /// </summary>
        [JsonProperty("model")]
        public JsonObject Model { get; set; }

        /// <summary>
        /// Gets or sets ModelArray.
        /// </summary>
        [JsonProperty("modelArray", NullValueHandling = NullValueHandling.Ignore)]
        public List<JsonObject> ModelArray { get; set; }

        /// <summary>
        /// Gets or sets ModelMap.
        /// </summary>
        [JsonProperty("modelMap", NullValueHandling = NullValueHandling.Ignore)]
        public JsonObject ModelMap { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"SendSchemaasQueryInput : ({string.Join(", ", toStringOutput)})";
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
            return obj is SendSchemaasQueryInput other &&                this.Id.Equals(other.Id) &&
                ((this.Model == null && other.Model == null) || (this.Model?.Equals(other.Model) == true)) &&
                ((this.ModelArray == null && other.ModelArray == null) || (this.ModelArray?.Equals(other.ModelArray) == true)) &&
                ((this.ModelMap == null && other.ModelMap == null) || (this.ModelMap?.Equals(other.ModelMap) == true));
        }
        
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected new void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Id = {this.Id}");
            toStringOutput.Add($"Model = {(this.Model == null ? "null" : this.Model.ToString())}");
            toStringOutput.Add($"ModelArray = {(this.ModelArray == null ? "null" : this.ModelArray.ToString())}");
            toStringOutput.Add($"ModelMap = {(this.ModelMap == null ? "null" : this.ModelMap.ToString())}");

            base.ToString(toStringOutput);
        }
    }
}
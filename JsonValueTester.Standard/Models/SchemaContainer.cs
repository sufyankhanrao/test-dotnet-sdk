// <copyright file="SchemaContainer.cs" company="APIMatic">
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
    /// SchemaContainer.
    /// </summary>
    public class SchemaContainer : BaseModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SchemaContainer"/> class.
        /// </summary>
        public SchemaContainer()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SchemaContainer"/> class.
        /// </summary>
        /// <param name="name">name.</param>
        /// <param name="id">id.</param>
        /// <param name="schema">schema.</param>
        /// <param name="schemaArray">schemaArray.</param>
        /// <param name="schemaMap">schemaMap.</param>
        public SchemaContainer(
            string name,
            string id,
            JsonObject schema,
            List<JsonObject> schemaArray = null,
            JsonObject schemaMap = null)
        {
            this.Name = name;
            this.Id = id;
            this.Schema = schema;
            this.SchemaArray = schemaArray;
            this.SchemaMap = schemaMap;
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
        /// Gets or sets Schema.
        /// </summary>
        [JsonProperty("schema")]
        public JsonObject Schema { get; set; }

        /// <summary>
        /// Gets or sets SchemaArray.
        /// </summary>
        [JsonProperty("schemaArray", NullValueHandling = NullValueHandling.Ignore)]
        public List<JsonObject> SchemaArray { get; set; }

        /// <summary>
        /// Gets or sets SchemaMap.
        /// </summary>
        [JsonProperty("schemaMap", NullValueHandling = NullValueHandling.Ignore)]
        public JsonObject SchemaMap { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"SchemaContainer : ({string.Join(", ", toStringOutput)})";
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
            return obj is SchemaContainer other &&                ((this.Name == null && other.Name == null) || (this.Name?.Equals(other.Name) == true)) &&
                ((this.Id == null && other.Id == null) || (this.Id?.Equals(other.Id) == true)) &&
                ((this.Schema == null && other.Schema == null) || (this.Schema?.Equals(other.Schema) == true)) &&
                ((this.SchemaArray == null && other.SchemaArray == null) || (this.SchemaArray?.Equals(other.SchemaArray) == true)) &&
                ((this.SchemaMap == null && other.SchemaMap == null) || (this.SchemaMap?.Equals(other.SchemaMap) == true));
        }
        
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected new void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Name = {(this.Name == null ? "null" : this.Name)}");
            toStringOutput.Add($"this.Id = {(this.Id == null ? "null" : this.Id)}");
            toStringOutput.Add($"Schema = {(this.Schema == null ? "null" : this.Schema.ToString())}");
            toStringOutput.Add($"SchemaArray = {(this.SchemaArray == null ? "null" : this.SchemaArray.ToString())}");
            toStringOutput.Add($"SchemaMap = {(this.SchemaMap == null ? "null" : this.SchemaMap.ToString())}");

            base.ToString(toStringOutput);
        }
    }
}
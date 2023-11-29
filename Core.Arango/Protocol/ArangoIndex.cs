﻿using System.Collections.Generic;
using System.Text.Json.Serialization;
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Core.Arango.Protocol
{
    /// <summary>
    ///     Arango index
    /// </summary>
    public class ArangoIndex
    {
        /// <summary>
        ///     The identifier of the index
        /// </summary>
        [JsonPropertyName("id")]
        [JsonProperty(PropertyName = "id", NullValueHandling = NullValueHandling.Ignore)]
        [System.Text.Json.Serialization.JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Id { get; set; }

        /// <summary>
        ///     Name of the index or null for auto generation
        /// </summary>
        [JsonPropertyName("name")]
        [JsonProperty(PropertyName = "name", NullValueHandling = NullValueHandling.Ignore)]
        [System.Text.Json.Serialization.JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Name { get; set; }

        /// <summary>
        ///     Type of the index
        /// </summary>
        [JsonPropertyName("type")]
        [JsonProperty(PropertyName = "type")]
        public ArangoIndexType Type { get; set; }

        /// <summary>
        ///     (Persistent | Inverted | MultiDimensional) An array of attribute paths.
        ///     (TTL | Fulltext) An array with exactly one attribute path.
        ///     (Geo) An array with one or two attribute paths.
        ///     If it is an array with one attribute path location, then a geo-spatial index on all documents is created using
        ///     location as path to the coordinates.
        ///     The value of the attribute must be an array with at least two double values.
        ///     The array must contain the latitude (first value) and the longitude (second value).
        ///     All documents, which do not have the attribute path or with value that are not suitable, are ignored.
        ///     If it is an array with two attribute paths latitude and longitude, then a geo-spatial index on all documents is
        ///     created using latitude and longitude as paths the latitude and the longitude.
        ///     The value of the attribute latitude and of the attribute longitude must a double.
        ///     All documents, which do not have the attribute paths or which values are not suitable, are ignored.
        /// </summary>
        [JsonPropertyName("fields")]
        [JsonProperty(PropertyName = "fields", NullValueHandling = NullValueHandling.Ignore)]
        [System.Text.Json.Serialization.JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public List<string> Fields { get; set; }

        /// <summary>
        ///     (Fulltext)  Minimum character length of words to index.
        ///     Will default to a server-defined value if unspecified.
        ///     It is thus recommended to set this value explicitly when creating the index.
        /// </summary>
        [JsonPropertyName("minLength")]
        [JsonProperty(PropertyName = "minLength", NullValueHandling = NullValueHandling.Ignore)]
        [System.Text.Json.Serialization.JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? MinLength { get; set; }

        /// <summary>
        ///     (Geo) If a geo-spatial index on a location is constructed and geoJson is true, then the order within the array is
        ///     longitude followed by latitude.
        ///     This corresponds to the format described in http://geojson.org/geojson-spec.html#positions
        /// </summary>
        [JsonPropertyName("geoJson")]
        [JsonProperty(PropertyName = "geoJson", NullValueHandling = NullValueHandling.Ignore)]
        [System.Text.Json.Serialization.JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? GeoJson { get; set; }

        /// <summary>
        ///     (Persistent)
        /// </summary>
        [JsonPropertyName("sparse")]
        [JsonProperty(PropertyName = "sparse", NullValueHandling = NullValueHandling.Ignore)]
        [System.Text.Json.Serialization.JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Sparse { get; set; }

        /// <summary>
        ///     (Persistent | MultiDimensional) Note: Unique indexes on non-shard keys are not supported in a cluster.
        /// </summary>
        [JsonPropertyName("unique")]
        [JsonProperty(PropertyName = "unique", NullValueHandling = NullValueHandling.Ignore)]
        [System.Text.Json.Serialization.JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Unique { get; set; }

        /// <summary>
        ///     (Persistent) this attribute controls whether an extra in-memory hash cache is created for the index.
        ///     The hash cache can be used to speed up index lookups.
        ///     The cache can only be used for queries that look up all index attributes via an equality lookup (==).
        ///     The hash cache cannot be used for range scans, partial lookups or sorting.
        /// </summary>
        [JsonPropertyName("cacheEnabled")]
        [JsonProperty(PropertyName = "cacheEnabled", NullValueHandling = NullValueHandling.Ignore)]
        [System.Text.Json.Serialization.JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? CacheEnabled { get; set; }

        /// <summary>
        ///     Indexes can also be created in “background”, not using an exclusive lock during the entire index creation.
        ///     Background index creation might be slower than the “foreground” index creation and require more RAM.
        /// </summary>
        [JsonPropertyName("inBackground")]
        [JsonProperty(PropertyName = "inBackground", NullValueHandling = NullValueHandling.Ignore)]
        [System.Text.Json.Serialization.JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? InBackground { get; set; }

        /// <summary>
        ///     (Persistent) Controls whether inserting duplicate index values from the same document into a unique array
        ///     index will lead to a unique constraint error or not.
        ///     The default value is true, so only a single instance of each non-unique index value will be inserted into the index
        ///     per document.
        ///     Trying to insert a value into the index that already exists in the index will always fail, regardless of the value
        ///     of this attribute.
        /// </summary>
        [JsonPropertyName("deduplicate")]
        [JsonProperty(PropertyName = "deduplicate", NullValueHandling = NullValueHandling.Ignore)]
        [System.Text.Json.Serialization.JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Deduplicate { get; set; }

        /// <summary>
        ///     (Persistent) This attribute controls whether index selectivity estimates are maintained for the index.
        ///     Not maintaining index selectivity estimates can have a slightly positive impact on write performance.
        /// </summary>
        [JsonPropertyName("estimates")]
        [JsonProperty(PropertyName = "estimates", NullValueHandling = NullValueHandling.Ignore)]
        [System.Text.Json.Serialization.JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Estimate { get; set; }

        /// <summary>
        ///     (Persistent) The optional storedValues attribute can contain an array of paths to additional attributes to store in the index.
        ///     These additional attributes cannot be used for index lookups or for sorting, but they can be used for projections.
        ///     This allows an index to fully cover more queries and avoid extra document lookups.
        ///     The maximum number of attributes in storedValues is 32.
        /// </summary>
        [JsonPropertyName("storedValues")]
        [JsonProperty(PropertyName = "storedValues", NullValueHandling = NullValueHandling.Ignore)]
        [System.Text.Json.Serialization.JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)] 
        public List<string> StoredValues { get; set; }

        /// <summary>
        ///     (TTL) The time (in seconds) after a document’s creation after which the documents count as “expired”.
        /// </summary>
        [JsonPropertyName("expireAfter")]
        [JsonProperty(PropertyName = "expireAfter", NullValueHandling = NullValueHandling.Ignore)]
        [System.Text.Json.Serialization.JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? ExpireAfter { get; set; }

        /// <summary>
        ///     (MultiDimensional) must be equal to “double”. Currently only doubles are supported as values.
        /// </summary>
        [JsonPropertyName("fieldValueTypes")]
        [JsonProperty(PropertyName = "fieldValueTypes", NullValueHandling = NullValueHandling.Ignore)]
        [System.Text.Json.Serialization.JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string FieldValueTypes { get; set; }
    }
}
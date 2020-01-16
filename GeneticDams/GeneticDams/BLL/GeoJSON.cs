namespace QuickType
{
    using System;
    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    public partial class GeoJson
    {
        [JsonProperty("type")]
        public string Type { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("crs")]
        public Crs Crs { get; set; }
        [JsonProperty("features")]
        public Feature[] Features { get; set; }
    }

    public partial class Crs
    {
        [JsonProperty("type")]
        public string Type { get; set; }
        [JsonProperty("properties")]
        public CrsProperties Properties { get; set; }
    }

    public partial class CrsProperties
    {
        [JsonProperty("name")]
        public string Name { get; set; }
    }

    public partial class Feature
    {
        [JsonProperty("type")]
        public FeatureType Type { get; set; }

        [JsonProperty("properties")]
        public FeatureProperties Properties { get; set; }

        [JsonProperty("geometry")]
        public Geometry Geometry { get; set; }
    }

    public partial class Geometry
    {
        [JsonProperty("type")]
        public GeometryType Type { get; set; }

        [JsonProperty("coordinates")]
        public double[][][][] Coordinates { get; set; }
    }

    public partial class FeatureProperties
    {
        [JsonProperty("Name")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long Name { get; set; }

        [JsonProperty("description")]
        public object Description { get; set; }

        [JsonProperty("elevation")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long Elevation { get; set; }

        [JsonProperty("stroke")]
        public string Stroke { get; set; }

        [JsonProperty("fill")]
        public Fill Fill { get; set; }

        [JsonProperty("fill_opacity")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long FillOpacity { get; set; }
    }

    public enum GeometryType { MultiPolygon };

    public enum Fill { The000000 };

    public enum FeatureType { Feature };

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                GeometryTypeConverter.Singleton,
                FillConverter.Singleton,
                FeatureTypeConverter.Singleton,
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }

    internal class GeometryTypeConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(GeometryType) || t == typeof(GeometryType?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            if (value == "MultiPolygon")
            {
                return GeometryType.MultiPolygon;
            }
            throw new Exception("Cannot unmarshal type GeometryType");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (GeometryType)untypedValue;
            if (value == GeometryType.MultiPolygon)
            {
                serializer.Serialize(writer, "MultiPolygon");
                return;
            }
            throw new Exception("Cannot marshal type GeometryType");
        }

        public static readonly GeometryTypeConverter Singleton = new GeometryTypeConverter();
    }

    internal class ParseStringConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(long) || t == typeof(long?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            long l;
            if (Int64.TryParse(value, out l))
            {
                return l;
            }
            throw new Exception("Cannot unmarshal type long");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (long)untypedValue;
            serializer.Serialize(writer, value.ToString());
            return;
        }

        public static readonly ParseStringConverter Singleton = new ParseStringConverter();
    }

    internal class FillConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(Fill) || t == typeof(Fill?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            if (value == "#000000")
            {
                return Fill.The000000;
            }
            throw new Exception("Cannot unmarshal type Fill");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (Fill)untypedValue;
            if (value == Fill.The000000)
            {
                serializer.Serialize(writer, "#000000");
                return;
            }
            throw new Exception("Cannot marshal type Fill");
        }

        public static readonly FillConverter Singleton = new FillConverter();
    }

    internal class FeatureTypeConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(FeatureType) || t == typeof(FeatureType?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            if (value == "Feature")
            {
                return FeatureType.Feature;
            }
            throw new Exception("Cannot unmarshal type FeatureType");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (FeatureType)untypedValue;
            if (value == FeatureType.Feature)
            {
                serializer.Serialize(writer, "Feature");
                return;
            }
            throw new Exception("Cannot marshal type FeatureType");
        }

        public static readonly FeatureTypeConverter Singleton = new FeatureTypeConverter();
    }
}

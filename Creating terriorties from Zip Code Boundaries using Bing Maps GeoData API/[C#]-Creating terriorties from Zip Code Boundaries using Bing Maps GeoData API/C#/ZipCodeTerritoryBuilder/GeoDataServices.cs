using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ZipCodeTerritoryBuilder
{
    [DataContract]
    public class Response
    {
        [DataMember(Name = "d", EmitDefaultValue = false)]
        public ResultSet ResultSet { get; set; }
    }

    [DataContract]
    public class ResultSet
    {
        [DataMember(Name = "__copyright", EmitDefaultValue = false)]
        public string Copyright { get; set; }

        [DataMember(Name = "results", EmitDefaultValue = false)]
        public Result[] Results { get; set; }
    }

    [DataContract]
    public class Result
    {
        [DataMember(Name = "EntityID", EmitDefaultValue = false)]
        public string EntityID { get; set; }

        [DataMember(Name = "EntityMetadata", EmitDefaultValue = false)]
        public Metadata EntityMetadata { get; set; }

        [DataMember(Name = "Name", EmitDefaultValue = false)]
        public Name Name { get; set; }

        [DataMember(Name = "Primitives", EmitDefaultValue = false)]
        public Primitive[] Primitives { get; set; }

        [DataMember(Name = "Copyright", EmitDefaultValue = false)]
        public Copyright Copyright { get; set; }
    }

    [DataContract]
    public class Metadata
    {
        [DataMember(Name = "AreaSqKm", EmitDefaultValue = false)]
        public string AreaSqKm { get; set; }

        [DataMember(Name = "BestMapViewBox", EmitDefaultValue = false)]
        public string BestMapViewBox { get; set; }

        [DataMember(Name = "OfficialCulture", EmitDefaultValue = false)]
        public string OfficialCulture { get; set; }

        [DataMember(Name = "RegionalCulture", EmitDefaultValue = false)]
        public string RegionalCulture { get; set; }

        [DataMember(Name = "PopulationClass", EmitDefaultValue = false)]
        public string PopulationClass { get; set; }
    }

    [DataContract]
    public class Name
    {
        [DataMember(Name = "EntityName", EmitDefaultValue = false)]
        public string EntityName { get; set; }

        [DataMember(Name = "Culture", EmitDefaultValue = false)]
        public string Culture { get; set; }

        [DataMember(Name = "SourceID", EmitDefaultValue = false)]
        public string SourceID { get; set; }
    }

    [DataContract]
    public class Primitive
    {
        [DataMember(Name = "PrimitiveID", EmitDefaultValue = false)]
        public string PrimitiveID { get; set; }

        [DataMember(Name = "Shape", EmitDefaultValue = false)]
        public string Shape { get; set; }

        [DataMember(Name = "NumPoints", EmitDefaultValue = false)]
        public string NumPoints { get; set; }

        [DataMember(Name = "SourceID", EmitDefaultValue = false)]
        public string SourceID { get; set; }
    }

    [DataContract]
    public class Copyright
    {
        [DataMember(Name = "CopyrightURL", EmitDefaultValue = false)]
        public string CopyrightURL { get; set; }

        [DataMember(Name = "Sources", EmitDefaultValue = false)]
        public CopyrightSource[] Sources { get; set; }
    }

    [DataContract]
    public class CopyrightSource
    {
        [DataMember(Name = "SourceID", EmitDefaultValue = false)]
        public string SourceID { get; set; }

        [DataMember(Name = "SourceName", EmitDefaultValue = false)]
        public string SourceName { get; set; }

        [DataMember(Name = "Copyright", EmitDefaultValue = false)]
        public string Copyright { get; set; }
    }
}
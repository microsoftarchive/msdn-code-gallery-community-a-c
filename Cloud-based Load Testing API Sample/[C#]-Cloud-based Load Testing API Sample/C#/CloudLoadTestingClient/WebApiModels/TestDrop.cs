using System;
using System.Runtime.Serialization;

namespace CloudLoadTestingClient
{
    public class TestDrop
    {
        /// <summary>
        /// Drop Id
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string Id { get; set; }

        /// <summary>
        /// Test Run Id
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string TestRunId { get; set; }

        /// <summary>
        /// Identifies the type of drop
        /// </summary>
        [DataMember(EmitDefaultValue = false, IsRequired = true)]
        public string DropType { get; set; }

        /// <summary>
        /// Data for accessing the drop and not persisted in storage
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public DropAccessData AccessData { get; set; }

        /// <summary>
        /// Time at which the drop is created
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public DateTime CreatedDate { get; set; }

        /// <summary>
        /// LoadTest defintion of the run for which testdrop is created
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public LoadTestDefinition LoadTestDefinition { get; set; }

    }

    public class DropAccessData
    {

        /// <summary>
        /// The SaSkey to use for the drop.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string SasKey { get; set; }

        /// <summary>
        /// The drop container Url for the drop.
        /// this would be in format <Blob_Storage_Url>/<ContainerName>/<DropId>
        /// sample: http://127.0.0.1:10000/devstoreaccount1/ets-containerfor-0af79c97-9801-4e94-803a-07199f101f0c/f6173e25-942f-4e8b-aff0-723d4c54180a
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string DropContainerUrl { get; set; }
    }
}

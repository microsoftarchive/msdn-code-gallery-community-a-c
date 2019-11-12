using System.Reflection;
using System.Runtime.Serialization;

namespace CloudLoadTestingClient
{
    [DataContract]
    public class TestSettings
    {
        /// <summary>
        /// Cleanup command
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string CleanupCommand = string.Empty;

        /// <summary>
        /// Processor Architecture chosen
        /// </summary>
        public ProcessorArchitecture HostProcessPlatform = ProcessorArchitecture.X86;

        /// <summary>
        /// Setup command
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string SetupCommand = string.Empty;
    }


    // Same as System.Reflection.ProcessorArchitecture
    [DataContract]
    public enum ProcessorArchitecture
    {

        // Summary:
        //     An unknown or unspecified combination of processor and bits-per-word.
        [EnumMember]
        None = 0,

        //
        // Summary:
        //     Neutral with respect to processor and bits-per-word.
        [EnumMember]
        Msil = 1,

        //
        // Summary:
        //     A 32-bit Intel processor, either native or in the Windows on Windows environment
        //     on a 64-bit platform (WOW64).
        [EnumMember]
        X86 = 2,

        //
        // Summary:
        //     A 64-bit Intel processor only.
        [EnumMember]
        Ia64 = 3,

        //
        // Summary:
        //     A 64-bit AMD processor only.
        [EnumMember]
        Amd64 = 4,

        //
        // Summary:
        //     An ARM processor.
        [EnumMember]
        Arm = 5,

    }
}

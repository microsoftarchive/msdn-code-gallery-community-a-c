namespace SimpleCopy
{
    using CmdLine;

    /// <summary>
    /// Command Arguments for the Copy Command
    /// </summary>
    /// <remarks>
    /// The real copy command supports more complex token structures so this is a simplified version
    /// 
    /// COPY [/D] [/V] [/N] [/Y | /-Y] [/Z] [/L] [/A | /B ] source [/A | /B] [destination [/A | /B]]
    ///
    ///  source       Specifies the file or files to be copied.
    ///  /A           Indicates an ASCII text file.
    ///  /B           Indicates a binary file.
    ///  /D           Allow the destination file to be created decrypted
    ///  destination  Specifies the directory and/or filename for the new file(s).
    ///  /V           Verifies that new files are written correctly.
    ///  /N           Uses short filename, if available, when copying a file with a non-8dot3 name.
    ///  /Y           Causes or Suppresses prompting to confirm you want to overwrite an existing destination file.
    ///  /Z           Copies networked files in restartable mode.
    ///  /L           If the source is a symbolic link, copy the link to the target instead of the actual file the source link points to.
    /// </remarks>    
    //TODO: Do something with CommandLineArguments
    [CommandLineArguments(Program = "SimpleCopy", Title = "Simple Copy Title", Description="Sample copy command")]
    public class SimpleCopyArguments
    {
        [CommandLineParameter(Name = "source", ParameterIndex = 1, Required=true, Description = "Specifies the file or files to be copied.")]
        public string Source { get; set; }

        [CommandLineParameter(Name = "destination", ParameterIndex = 2, Description = "Specifies the directory and/or filename for the new file(s).")]
        public string Destination { get; set; }

        [CommandLineParameter(Command = "A", Required = true, Description = "Indicates an ASCII text file")]
        public bool ASCIITextFile { get; set; }

        [CommandLineParameter(Command = "B", Description = "Indicates a binary file.")]
        public bool BinaryFile { get; set; }

        [CommandLineParameter(Command = "D", Description = "Allow the destination file to be created decrypted")]
        public bool AllowDestinationDecrypted { get; set; }

        [CommandLineParameter(Command = "V", Description = "Verifies that new files are written correctly.")]
        public bool Verify { get; set; }

        [CommandLineParameter(Command = "N", Description = "Uses short filename, if available, when copying a file with a non-8dot3 name.")]
        public bool UseShortFileName { get; set; }

        [CommandLineParameter(Command = "Y", Description = "Causes or Suppresses prompting to confirm you want to overwrite an existing destination file.", ValueExample = "/Y (prompt) /Y- (suppress prompt)")]
        public bool ConfirmPrompt { get; set; }

        [CommandLineParameter(Command = "Z", Description = "Copies networked files in restartable mode.")]
        public bool Restartable { get; set; }

        [CommandLineParameter(Command = "L", Description = "If the source is a symbolic link, copy the link to the target instead of the actual file the source link points to.")]
        public bool CopyLink { get; set; }

        [CommandLineParameter(Command = "?", Default = false, Description = "Show Help", Name = "Help", IsHelp = true)]
        public bool Help { get; set; }
    }
}

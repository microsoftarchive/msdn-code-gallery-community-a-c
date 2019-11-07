namespace ConcreteLibrary 
{
    public class ExcelLast
    {
        /// <summary>
        /// Last used row in specific sheet
        /// </summary>
        public int Row { get; set; }
        /// <summary>
        /// Last used column in specific sheet
        /// </summary>
        public int Column { get; set; }

        public override string ToString()
        {
            return $"Row: {Row} Col: {Column}";
        }
    }
}

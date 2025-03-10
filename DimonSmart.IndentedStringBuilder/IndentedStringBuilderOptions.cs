namespace DimonSmart.IndentedStringBuilder
{
    public class IndentedStringBuilderOptions
    {
        public int Capacity { get; }
        public int InitialIndent { get; }
        public int IndentSize { get; }
        public string OpeningBracket { get; }
        public string ClosingBracket { get; }
        public bool IndentMultiline { get; }

        public IndentedStringBuilderOptions(
            int capacity = 16,
            int initialIndent = 0,
            int indentSize = 4,
            string openingBracket = "{",
            string closingBracket = "}",
            bool indentMultiline = true)
        {
            Capacity = capacity;
            InitialIndent = initialIndent;
            IndentSize = indentSize;
            OpeningBracket = openingBracket;
            ClosingBracket = closingBracket;
            IndentMultiline = indentMultiline;
        }
    }
}
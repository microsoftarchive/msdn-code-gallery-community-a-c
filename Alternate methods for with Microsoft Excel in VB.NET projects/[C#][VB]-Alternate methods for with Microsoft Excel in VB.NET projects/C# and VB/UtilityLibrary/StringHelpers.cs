using System.Text;

namespace UtilityLibrary
{
    public class StringHelpers
    {
        public string AddSpacesToSentence(string text, bool preserveAcronyms)
        {
            if (string.IsNullOrWhiteSpace(text))
                return string.Empty;

            StringBuilder sb = new StringBuilder(text.Length * 2);
            sb.Append(text[0]);

            for (int i = 1; i < text.Length; i++)
            {
                if (char.IsUpper(text[i]))
                    if ((text[i - 1] != ' ' && !char.IsUpper(text[i - 1])) || (preserveAcronyms && char.IsUpper(text[i - 1]) &&  i < text.Length - 1 && !char.IsUpper(text[i + 1])))
                        sb.Append(' ');

                sb.Append(text[i]);

            }

            return sb.ToString();
        }
    }
}

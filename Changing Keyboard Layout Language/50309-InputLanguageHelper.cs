using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace InputLanguageDemo
{
    class InputLanguageHelper
    {
        InputLanguage _arabicInput;
        InputLanguage _englishInput;


        public InputLanguageHelper()
        {
            _arabicInput = GetInputLanguageByName("arabic");
            _englishInput = GetInputLanguageByName("english");
        }

        public void SetKeyboardLayout(InputLanguage layout)
        {
            InputLanguage.CurrentInputLanguage = layout;
        }


        public static InputLanguage GetInputLanguageByName(string inputName)
        {
            foreach (InputLanguage lang in InputLanguage.InstalledInputLanguages)
            {
                if (lang.Culture.EnglishName.ToLower().StartsWith(inputName))
                    return lang;
            }
            return null;
        }

        public void LoadArabicKeyboardLayout()
        {
            if (_arabicInput != null)
                InputLanguage.CurrentInputLanguage = _arabicInput;
            else
                InputLanguage.CurrentInputLanguage = InputLanguage.DefaultInputLanguage;
        }

        public void LoadEnglishKeyboardLayout()
        {
            if (_englishInput != null)
                InputLanguage.CurrentInputLanguage = _englishInput;
            else
                InputLanguage.CurrentInputLanguage = InputLanguage.DefaultInputLanguage;
        }

    }
}

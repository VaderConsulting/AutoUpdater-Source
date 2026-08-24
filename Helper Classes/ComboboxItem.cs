using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Browser
{
    public class ComboBoxItem
    {
        private string _Text = "";
        private string _EnglishText = "";

        public string Text
        {
            get
            {
                return _Text;
            }
            set
            {
                _Text = value;
            }
        }

        public string EnglishText
        {
            get
            {
                return _EnglishText;
            }
            set
            {
                _EnglishText = value;
            }
        }

        public override string ToString()
        {
            return _Text;
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace Osumen_TheVirtualFriend
{
    class TextBoxWithPlaceHolder : TextBox
    {
        private String _PlaceHolderText = "PlaceHolder";

        public String PlaceHolderText 
        {
            get
            {
                return _PlaceHolderText;
            }
            set
            {
                _PlaceHolderText = value;
                ApplyPlaceholder();
            }
        }



        public SolidColorBrush TextColor { get; set; } = new SolidColorBrush(Color.FromRgb(0, 0, 0));
        public SolidColorBrush PlaceHolderColor { get; set; } = new SolidColorBrush(Color.FromArgb((byte)255, (byte)64, (byte)64, (byte)64));
        public TextBoxWithPlaceHolder()
        {
            this.GotFocus += TextBoxWithPlaceHolder_GotFocus;
            this.LostFocus += TextBoxWithPlaceHolder_LostFocus;
        }

        private void TextBoxWithPlaceHolder_LostFocus(object sender, System.Windows.RoutedEventArgs e)
        {
            if (this.Text == "")
            {
                ApplyPlaceholder();
            }
        }

        private void TextBoxWithPlaceHolder_GotFocus(object sender, System.Windows.RoutedEventArgs e)
        {
            RemovePlaceholder();
        }

        public TextBoxWithPlaceHolder(String placeholderText)
        {
            PlaceHolderText = placeholderText;
        }

        private void RemovePlaceholder()
        {
            if(this.Text == PlaceHolderText)
            {
                this.Text = "";
                this.Foreground = TextColor;

            }
        }

        private void ApplyPlaceholder()
        {
            this.Text = PlaceHolderText;
            this.Foreground = PlaceHolderColor;
            
        }

    }
}

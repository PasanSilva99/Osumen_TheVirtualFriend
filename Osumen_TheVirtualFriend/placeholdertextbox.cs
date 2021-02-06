using System.Windows.Controls;
using System.Windows.Media;

namespace Osumen_TheVirtualFriend
{
    class placeholdertextbox : TextBox
    {
        private string _placeholdertext = "Placeholder";

        public string placeholdertext
        {
            get
            {
                return _placeholdertext;
            }
            set
            {
                _placeholdertext = value;
                Applyplaceholder();
            }
        }
        public SolidColorBrush TextColor { get; set; } = new SolidColorBrush(Color.FromArgb(0, 0, 0, 0));
        public SolidColorBrush placeholdercolor { get; set; } = new SolidColorBrush(Color.FromArgb((byte)255, (byte)64, (byte)64, (byte)64));
        public placeholdertextbox()
        {

            this.GotFocus += Placeholdertextbox_GotFocus;
            this.LostFocus += Placeholdertextbox_LostFocus;

        }

        private void Placeholdertextbox_LostFocus(object sender, System.Windows.RoutedEventArgs e)
        {
            if (this.Text == "")
            {
                Applyplaceholder();
            }
        }

        private void Placeholdertextbox_GotFocus(object sender, System.Windows.RoutedEventArgs e)
        {
            removeplaceholder();
        }

        public placeholdertextbox(string placeholderText)
        {
            placeholdertext = placeholdertext;
        }

        private void removeplaceholder()
        {
            if (this.Text == placeholdertext)
            {
                this.Text = "";
                this.Foreground = TextColor;

            }
        }

        private void Applyplaceholder()
        {
            this.Text = placeholdertext;

            this.Foreground = placeholdercolor;

        }


    }
}

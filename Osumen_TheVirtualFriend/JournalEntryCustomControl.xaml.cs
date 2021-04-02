using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace Osumen_TheVirtualFriend
{
    public sealed partial class JournalEntryCustomControl : UserControl
    {
        private String _Title = "No Title";
        private DateTime _DateNTime = DateTime.Now;
        private String _Content = "No Content";

        public String Title
        {
            get
            {
                return _Title;
            }
            set
            {
                _Title = value;
                lbl_title.Text = _Title;
            }
        }

        public DateTime DateNTime
        {
            get
            {
                return _DateNTime;
            }
            set
            {
                _DateNTime = value;
                lbl_datentime.Text = _DateNTime.ToString("dd/MM/yyyy  hh:mm tt");
            }
        }

        public String ContentL
        {
            get
            {
                return _Content;
            }
            set
            {
                _Content = value;
                lbl_content.Text = _Content;
            }
        }

        public JournalEntryCustomControl()
        {
            this.InitializeComponent();
            lbl_title.Text = _Title;
            lbl_datentime.Text = _DateNTime.ToString("dd/MM/yyyy  hh:mm tt");
            lbl_content.Text = _Content;
        }

        private void entry_PointEntered(object sender, PointerRoutedEventArgs e)
        {
            DAnimationTo1.Begin();
        }

        private void entry_PointExisted(object sender, PointerRoutedEventArgs e)
        {
            //entry_Transform.SkewX = 0;
            //entry_Transform.SkewY = 0;
            //entry_Transform.TranslateX = 0;
            DAnimationTo1.Stop();
        }

        private void entry_GettingFocus(UIElement sender, GettingFocusEventArgs args)
        {
            DAnimationTo1.Begin();
        }

        private void entry_LostFocus(object sender, RoutedEventArgs e)
        {
            DAnimationTo1.Stop();
        }
    }
}

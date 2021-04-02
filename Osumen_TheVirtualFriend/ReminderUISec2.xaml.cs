using System;
using System.Collections.Generic;
using System.Globalization;
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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Osumen_TheVirtualFriend
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public partial class ReminderUISec2 : Page
    {
        public ReminderUISec2()
        {
            this.InitializeComponent();
            UpperText.IsReadOnly = true;    
        }
        public void getText(String value)
        {
            UpperText.Text = value;
        }

        public void prioritybox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            String drpValue = prioritybox.Text.ToString();
        }

        //Done button
        public void Button_Click(object sender, RoutedEventArgs e)
        {
            String RemName = UpperText.Text;
            var date = this.dpicker.Date.ToString();
            var val = tpicker.Time.ToString();
            ComboBoxItem cbi = (ComboBoxItem)prioritybox.SelectedItem;
            string str1 = cbi.Content.ToString();
            NewDB.addRecord(RemName, date, val, str1);
            ReminderUiMain reminderUiMain = new ReminderUiMain();
            reminderUiMain.getcontent(RemName);
         
           
        }

    }
}

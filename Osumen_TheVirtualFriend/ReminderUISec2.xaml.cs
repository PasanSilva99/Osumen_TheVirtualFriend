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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Osumen_TheVirtualFriend
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ReminderUISec2 : Page
    {
        public ReminderUISec2()
        {
            this.InitializeComponent();
            ReminderDatePicker reminderDatePicker = new ReminderDatePicker();
            datepicker.Children.Add(reminderDatePicker);
            TimePicker timePicker = new TimePicker();
            timepicker1.Children.Add(timePicker);
            ReminderDropdwn reminderDropdwn = new ReminderDropdwn();
            dropdwn.Children.Add(reminderDropdwn);
            ReminderSec2Textbox reminderSec2Textbox = new ReminderSec2Textbox();
            sectxt.Children.Add(reminderSec2Textbox);
      }
    }
}

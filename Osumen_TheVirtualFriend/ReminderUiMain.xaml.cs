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
    public sealed partial class ReminderUiMain : Page
    {
        public ReminderUiMain()
        {
            this.InitializeComponent();
            ReminderSec1 reminderSec1 = new ReminderSec1();
            Section1.Children.Add(reminderSec1);
            ReminderUISec2 reminderUISec2 = new ReminderUISec2();
            Sec2.Children.Add(reminderUISec2);
        }
    }
}

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
    public sealed partial class ReminderSec1 : UserControl
    {
        public ReminderSec1()
        {
            this.InitializeComponent();
            ReminderSec1Usercntrl reminderSec1Usercntrl = new ReminderSec1Usercntrl();
            ReminderSec1Usercntrl reminderSec1Usercntr2 = new ReminderSec1Usercntrl();
            ReminderSec1Usercntrl reminderSec1Usercntr3 = new ReminderSec1Usercntrl();
            txtbx1.Children.Add(reminderSec1Usercntrl);
            txtbx2.Children.Add(reminderSec1Usercntr2);
            txtbx3.Children.Add(reminderSec1Usercntr3);
        }
    }
}

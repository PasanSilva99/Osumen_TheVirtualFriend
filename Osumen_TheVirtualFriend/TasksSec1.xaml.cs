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
    public sealed partial class TasksSec1 : UserControl
    {
        public TasksSec1()
        {
            this.InitializeComponent();
            TasksSec1UserCntrl TasksSec1UserCntrl1 = new TasksSec1UserCntrl();
            TasksSec1UserCntrl TasksSec1UserCntrl2 = new TasksSec1UserCntrl();
            TasksSec1UserCntrl TasksSec1UserCntrl3 = new TasksSec1UserCntrl();
            Taskstxtbx1.Children.Add(TasksSec1UserCntrl1);
            Taskstxtbx2.Children.Add(TasksSec1UserCntrl2);
            Taskstxtbx3.Children.Add(TasksSec1UserCntrl3);
        }
    }
}

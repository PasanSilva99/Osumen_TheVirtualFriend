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
    public sealed partial class TasksSec2 : Page
    {
        public TasksSec2()
        {
            this.InitializeComponent();
            TasksSec2TextBox TasksS2textbx = new TasksSec2TextBox();
            TasksSec2txtbx.Children.Add(TasksS2textbx);
            TasksDatePicker TasksS2DatePicker = new TasksDatePicker();
            TasksSec2DatePicker.Children.Add(TasksS2DatePicker);
            TasksTimePicker TasksS2TimePicker = new TasksTimePicker();
            TasksSec2TimePicker.Children.Add(TasksS2TimePicker);
        }
    }
}

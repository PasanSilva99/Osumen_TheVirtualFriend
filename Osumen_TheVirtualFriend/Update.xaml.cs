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
    public sealed partial class Update : Page
    {
        public Update()
        {
            this.InitializeComponent();
        }
        //update
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            String RemName = UpperText.Text;
            var date = this.dpicker.Date.ToString();
            var val = tpicker.Time.ToString();
            ComboBoxItem cbi = (ComboBoxItem)prioritybox.SelectedItem;
            string str1 = cbi.Content.ToString();

            checkdetails checkdetails = new checkdetails();
            checkdetails.setName(RemName);
            checkdetails.setDate(date);
            checkdetails.setTime(val);
            checkdetails.setPriority(str1);
            NewDB.updateRecord(checkdetails);

        }



        private void Button_cancel(object sender, RoutedEventArgs e)
        {

        }
        public void addedData(String name, String date, String time, String priority)
        {
            UpperText.Text = name;
            dpicker.SelectedDate = DateTime.Parse(date);
            /*prioritybox.Text = priority;*/
            TimeSpan tsp = TimeSpan.Parse(time);
            tpicker.SelectedTime = tsp;
            //int value = priority.Equals("Low") ? 1 : 0;
            //prioritybox.SelectedIndex = prioritybox.Items.IndexOf(value);
            //prioritybox.SelectedItem = priority;
            //prioritybox.SelectedIndex = prioritybox.Items.IndexOf(priority);
            prioritybox.Items.Add(priority);
            prioritybox.SelectedItem = 

        }


    }
    public class checkdetails
    {
        private string name, date, time, priority;
        public  void setName(string name)
        {
            this.name = name;
        }
        public  string getName()
        {
            return name;
        }
        public void setDate(string date)
        {
            this.date = date;
        }
        public string getDate()
        {
            return date;
        }
        public void setTime(string time)
        {
            this.time = time;
        }
        public string getTime()
        {
            return time;
        }
        public void setPriority(string priority)
        {
            this.priority = priority;
        }
        public string getPriority()
        {
            return priority;
        }
    }
}



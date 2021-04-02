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
            
            
        }
        public void getcontent(String value)
        {
            if (Task1.Content.ToString() == "null")
            {
                Task1.Content= value;
            }
            else
            {
               
            }
        }

        private void Task1_Click(object sender, RoutedEventArgs e)
        {
            

            Update update = new Update();
            Sec2.Children.Add(update);
            String value = Task1.Content.ToString();
            List<TaskData> list = NewDB.sendData1(value);
            
            foreach(TaskData td in list) {
                string name = td.getName();
                string date = td.getDate();
                string time = td.getTime();
                string priority = td.getPriority();
               
                update.addedData(name, date,time,priority);

                checkdetails checkdetails = new checkdetails();
                checkdetails.setName(name);
                checkdetails.setDate(date);
                checkdetails.setTime(time);
                checkdetails.setPriority(priority);
            }
        }

        private void Task2_Click(object sender, RoutedEventArgs e)
        {
            Update update = new Update();
            Sec2.Children.Add(update);
            String value = Task2.Content.ToString();
            List<TaskData> list = NewDB.sendData1(value);

            foreach (TaskData td in list)
            {
                string name = td.getName();
                string date = td.getDate();
                string time = td.getTime();
                string priority = td.getPriority();

                update.addedData(name, date, time, priority);
            }
        }

        private void Task3_Click(object sender, RoutedEventArgs e)
        {
            Update update = new Update();
            Sec2.Children.Add(update);
            String value = Task3.Content.ToString();
            List<TaskData> list = NewDB.sendData1(value);

            foreach (TaskData td in list)
            {
                string name = td.getName();
                string date = td.getDate();
                string time = td.getTime();
                string priority = td.getPriority();

                update.addedData(name, date, time, priority);
                checkdetails checkdetails = new checkdetails();
            }
        }

        //Plus Button

        private void Button_Click(object sender, RoutedEventArgs e)
        { 
                if(Bottumtxt != null)
                {
                ReminderUISec2 reminderUISec2 = new ReminderUISec2();
                Sec2.Children.Add(reminderUISec2);
                string Psstext;
                Psstext = Bottumtxt.Text;
                reminderUISec2.getText(Psstext);
                }
               
             
           
                
        }
      
    }
}

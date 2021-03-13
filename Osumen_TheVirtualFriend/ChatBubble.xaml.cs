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

namespace StandeedAIBot
{
    public sealed partial class ChatBubble : UserControl
    {
        String _Message;
        bool _IsUser = false;

        public bool IsUser 
        {
            get
            {
                return _IsUser;
            }
            set
            {
                _IsUser = value;
                GenerateUserUI();
            }
        }

        public String Message
        {
            get
            {
                return _Message;
            }
            set
            {
                _Message = value;
                tb_Message.Text = _Message;
                ResizeBubble();
            }
        }

        public ChatBubble()
        {
            this.InitializeComponent();
            this.Height = tb_Message.Height + 10.0;
            this.HorizontalAlignment = HorizontalAlignment.Left;
            this.tb_Message.HorizontalAlignment = HorizontalAlignment.Left;
            this.Width = tb_Message.Width + 20.0;


            if (_IsUser)
            {
                GenerateUserUI();
            }
        }

        private void ResizeBubble()
        {
            this.Height = tb_Message.Height + 10.0;
            this.Width = tb_Message.Width + 20.0;
        }

        private void GenerateUserUI()
        {
            Grid_base.RowDefinitions.Clear();
            Grid_base.ColumnDefinitions.Clear();

            ColumnDefinition messgaecolumn = new ColumnDefinition();
            ColumnDefinition filler = new ColumnDefinition();
            ColumnDefinition profilePic = new ColumnDefinition();

            messgaecolumn.Width = new GridLength(1, GridUnitType.Star);
            filler.Width = new GridLength(10, GridUnitType.Pixel);
            profilePic.Width = new GridLength(60, GridUnitType.Pixel);

            Grid_base.ColumnDefinitions.Add(messgaecolumn);
            Grid_base.ColumnDefinitions.Add(filler);
            Grid_base.ColumnDefinitions.Add(profilePic);

            PointCollection poly_user = new PointCollection();
            //0,0,0,10,10,0
            poly_filler.Points.Add(new Point(0, 0));
            poly_filler.Points.Add(new Point(0, 10));
            poly_filler.Points.Add(new Point(10, 0));


            poly_filler.Points.Clear();
            poly_filler.Points.Add(new Point(0, 0));
            poly_filler.Points.Add(new Point(0, 10));
            poly_filler.Points.Add(new Point(10, 0));
            poly_filler.VerticalAlignment = VerticalAlignment.Top;
            poly_filler.HorizontalAlignment = HorizontalAlignment.Right;
            //poly_filler.Stretch = Stretch.Uniform;

            border_message.CornerRadius = new CornerRadius(10, 0, 10, 10);

            img_profile.SetValue(Grid.ColumnProperty, 2);
            border_filler.SetValue(Grid.ColumnProperty, 1);
            border_message.SetValue(Grid.ColumnProperty, 0);


            this.HorizontalAlignment = HorizontalAlignment.Right;
            tb_Message.HorizontalAlignment = HorizontalAlignment.Right;
            this.Width = tb_Message.Width + 20.0;

            border_message.Background = (RevealBackgroundBrush)Resources["SystemControlHighlightAccent2RevealBackgroundBrush"];
            poly_filler.Fill = (RevealBackgroundBrush)Resources["SystemControlHighlightAccent2RevealBackgroundBrush"]; 
            img_profile.Background = (RevealBackgroundBrush)Resources["SystemControlHighlightAccent2RevealBackgroundBrush"];

        }
    }
}

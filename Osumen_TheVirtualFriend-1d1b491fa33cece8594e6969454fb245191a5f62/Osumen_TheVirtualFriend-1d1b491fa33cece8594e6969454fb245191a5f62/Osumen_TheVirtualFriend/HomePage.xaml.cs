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
    public sealed partial class HomePage : Page
    {
        public HomePage()
        {
            this.InitializeComponent();
        }

        private void LoadSearch(object sender, RoutedEventArgs e)
        {
            grid_tip.Visibility = Visibility.Collapsed;
            grid_search.Visibility = Visibility.Visible;
            SearchFunc(text_Search.Text.Equals("")?"Remedies for common ailments":text_Search.Text);
           
            
        }

        public void SearchFunc(String SearchString)
        {
            
            webView1.Navigate(new Uri("https://www.google.com?q=" + SearchString));

            
        }

        private void scrl_search_ViewChanged(object sender, ScrollViewerViewChangedEventArgs e)
        {

        }

        private void WebView_NavigationStarting(WebView sender, WebViewNavigationStartingEventArgs args)
        {
            
        }

        private void WebView_NavigationFailed(object sender, WebViewNavigationFailedEventArgs e)
        {
            
        }

        private void WebView_NavigationCompleted(WebView sender, WebViewNavigationCompletedEventArgs args)
        {
           
        }
    }
}

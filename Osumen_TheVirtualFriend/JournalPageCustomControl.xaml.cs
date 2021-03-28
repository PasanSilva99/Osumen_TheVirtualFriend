using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.Storage.Streams;
using Windows.UI.Text;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;



// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace Osumen_TheVirtualFriend
{
    public sealed partial class JournalPageCustomControl : UserControl
    {
        

        public JournalPageCustomControl()
        {
            this.InitializeComponent();
        }

        private void BoldButton_Click(object sender, RoutedEventArgs e)
        {
            editor.Document.Selection.CharacterFormat.Bold = FormatEffect.Toggle;

        }

        private void ItalicButton_Click(object sender, RoutedEventArgs e)
        {
            editor.Document.Selection.CharacterFormat.Italic = FormatEffect.Toggle;

        }

        private void AlignRightButton_Click(object sender, RoutedEventArgs e)
        {
            editor.Document.Selection.ParagraphFormat.Alignment = ParagraphAlignment.Right;
        }

        private void AlignLeftButton_Click(object sender, RoutedEventArgs e)
        {
            editor.Document.Selection.ParagraphFormat.Alignment = ParagraphAlignment.Left;
        }
        private void AlignCenterButton_Click(object sender, RoutedEventArgs e)
        {
            editor.Document.Selection.ParagraphFormat.Alignment = ParagraphAlignment.Center;
        }

        private async void Picture_Loader(object sender, RoutedEventArgs e)
        {
            FileOpenPicker openPicker = new FileOpenPicker();
            openPicker.ViewMode = PickerViewMode.Thumbnail;
            openPicker.SuggestedStartLocation = PickerLocationId.PicturesLibrary;
            openPicker.FileTypeFilter.Add(".jpg");
            openPicker.FileTypeFilter.Add(".png");

            StorageFile file = await openPicker.PickSingleFileAsync();

            if (file != null)
            {
                using (IRandomAccessStream fileStream = await file.OpenAsync(Windows.Storage.FileAccessMode.Read))

                {

                    editor.Document.Selection.InsertImage(250, 250, 0, VerticalCharacterAlignment.Baseline, "img", fileStream);

                }

            }
            else
            {
                //  
            }


        }


        private async void Video_Loader(object sender, RoutedEventArgs e)
        {
            FileOpenPicker openPicker = new FileOpenPicker();
            openPicker.ViewMode = PickerViewMode.Thumbnail;
            openPicker.SuggestedStartLocation = PickerLocationId.PicturesLibrary;
            openPicker.FileTypeFilter.Add(".mp4");
            openPicker.FileTypeFilter.Add(".wvw");

            StorageFile vidfile = await openPicker.PickSingleFileAsync();

            if (vidfile != null)
            {
                using (IRandomAccessStream fileStream = await vidfile.OpenAsync(Windows.Storage.FileAccessMode.Read))

                {

                    editor.Document.Selection.InsertImage(250, 250, 0, VerticalCharacterAlignment.Baseline, "img", fileStream);

                }

            }
            else
            {
                //  
            }
        }

        private async void VoiceRecord_Loader(object sender, RoutedEventArgs e)
        {
            // Open a mp3 file.
            Windows.Storage.Pickers.FileOpenPicker open =
                new Windows.Storage.Pickers.FileOpenPicker();
            open.SuggestedStartLocation =
                Windows.Storage.Pickers.PickerLocationId.DocumentsLibrary;
            open.FileTypeFilter.Add(".mp3");

            Windows.Storage.StorageFile file = await open.PickSingleFileAsync();

            if (file != null)
            {
                using (Windows.Storage.Streams.IRandomAccessStream randAccStream =
                    await file.OpenAsync(Windows.Storage.FileAccessMode.Read))
                {
                    // Load the file into the Document property of the RichEditBox.
                    editor.Document.LoadFromStream(Windows.UI.Text.TextSetOptions.FormatRtf, randAccStream);
                }
            }
        }

       

    }
}

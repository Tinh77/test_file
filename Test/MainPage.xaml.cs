using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Test.Entity;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage.Pickers;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Test
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private Member member;
        public MainPage()
        {
            this.member = new Member();
            this.InitializeComponent();
        }

        private async void Write_File(object sender, RoutedEventArgs e)
        {
            this.member.name = Name.Text;
            this.member.email = Email.Text;
            this.member.phone = Phone.Text;

            string jsonMember = JsonConvert.SerializeObject(this.member);
            FileSavePicker savePicker = new FileSavePicker();
            savePicker.SuggestedStartLocation = PickerLocationId.DocumentsLibrary;
            savePicker.FileTypeChoices.Add("Plain Text", new List<string>() { ".txt" });
            Windows.Storage.StorageFile file = await savePicker.PickSaveFileAsync();

            await Windows.Storage.FileIO.WriteTextAsync(file, jsonMember);
        }

        private async void Read_File(object sender, RoutedEventArgs e)
        {

            FileOpenPicker openPicker = new FileOpenPicker();
            openPicker.ViewMode = PickerViewMode.Thumbnail;
            openPicker.SuggestedStartLocation = PickerLocationId.DocumentsLibrary;
            openPicker.FileTypeFilter.Add(".txt");
            Windows.Storage.StorageFile file = await openPicker.PickSingleFileAsync();
            string content = await Windows.Storage.FileIO.ReadTextAsync(file);
            Member member = JsonConvert.DeserializeObject<Member>(content);
            Email.Text = member.email;
            Name.Text = member.name;
            Phone.Text = member.phone;
        }
    }
}

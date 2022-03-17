using Avalonia.Controls;
using Avalonia.Interactivity;
using Lab_5.ViewModels;
using System.IO;
using Lab_5.Models;

namespace Lab_5.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            this.FindControl<Button>("SaveFile_bt").Click += async delegate
            {
                var taskGetPath = new OpenFileDialog().ShowAsync((Window)this.VisualRoot);


                string[]? pathToFile = await taskGetPath;
                var contex = this.DataContext as MainWindowViewModel;
                if (pathToFile != null)
                {
                    using (StreamWriter writer = new StreamWriter(string.Join(@"\", pathToFile), false))
                    {
                        await writer.WriteLineAsync(contex.FinalText);
                    }

                }
            };
            this.FindControl<Button>("OpenFile_bt").Click += async delegate
            {
                var taskGetPath = new OpenFileDialog().ShowAsync((Window)this.VisualRoot);
                string[]? pathToFile = await taskGetPath;
                var contex = this.DataContext as MainWindowViewModel;
                if (pathToFile != null)
                {
                    StreamReader reader = new StreamReader(string.Join(@"\", pathToFile));
                    contex.StartText = reader.ReadToEnd();
                }
            };

            this.FindControl<TextBox>("textBoxIn").AddHandler(KeyUpEvent, TextBoxChange, RoutingStrategies.Tunnel); 
        }
        private void OpenRegexWindow(object sender, RoutedEventArgs e)
        {
            var Window = new RegexView();
            Window.OkNotify += delegate (string str)
            {
                var contex = this.DataContext as MainWindowViewModel;
                contex.Reg = str;
                contex.FinalText = contex.FindRegular();

            };
            Window.Show((Window)this.VisualRoot);
        }
        private async void TextBoxChange(object sender, RoutedEventArgs e)
        {
            var contex = this.DataContext as MainWindowViewModel;
            contex.FinalText = RegexFunction.FindRegexInText(this.FindControl<TextBox>("textBoxIn").Text, contex.Reg);

    }
}
}


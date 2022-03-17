using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.Interactivity;

namespace Lab_5.Views
{
    public partial class RegexView : Window
    {
        public delegate void OkHandler(string message);
        public event OkHandler? OkNotify;
        
        public RegexView()
        {
            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }

        private void IventCloseRegexWindow(object sender, RoutedEventArgs e)
        {   
            Close();
        }

        private void IventOkPushed(object sender, RoutedEventArgs e)
        {
            OkNotify(this.Find<TextBox>("textBoxInRegex").Text);
            Close();
        }

    }
}

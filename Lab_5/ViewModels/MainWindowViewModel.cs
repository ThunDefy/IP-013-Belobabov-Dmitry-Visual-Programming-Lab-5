using ReactiveUI;
using Lab_5.Models;


namespace Lab_5.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {

        string startText="", reg="", finalText="";

        public string StartText
        {
            get => startText;

            set => this.RaiseAndSetIfChanged(ref startText, value);
        }

        

        public string Reg
        {

            get => reg;

            set => this.RaiseAndSetIfChanged(ref reg, value);
        }


        
        public string FinalText
        {
            get => finalText;
            set => this.RaiseAndSetIfChanged(ref finalText, value);
        }

        public string? FindRegular() => RegexFunction.FindRegexInText(startText, reg);

    }

}

using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using EncuestApp.Models;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace EncuestApp.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {

        private string jsonData =
            "{\n\"id\" : 1,\n\"numberOfStudents\":4,\n\"numberOfFields\": 3,\n\"fields\" : [\n{\n\"fieldName\" : \"Name\",\n\"fieldType\" : \"entry\",\n\"value\": null,\n},\n{\n\"fieldName\" :\"Course\",\n\"fieldType\" : \"entry\",\n\"value\": null,\n},\n{\n\"fieldName\" : \"DOB\",\n\"fieldType\" : \"DatePicker\",\n\"value\": null,\n}\n]\n}";

        public MainPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            Title = "Main Page";
        }

        private ICommand _goCommand;

        public ICommand GoCommand
        {
            get
            {
                return _goCommand ?? (_goCommand = new Command(async (value) =>
                           {
                               NavigationParameters par = new NavigationParameters();

                               Encuesta enc = JsonConvert.DeserializeObject<Encuesta>(jsonData);

                               par.Add("Enc",enc);

                               await NavigationService.NavigateAsync("CapturaPage", par);


                           }
                       ));
            }
        }
    }
}

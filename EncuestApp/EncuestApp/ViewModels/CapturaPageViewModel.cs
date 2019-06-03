using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using EncuestApp.Models;
using Newtonsoft.Json;
using Prism.Navigation;
using Xamarin.Forms;

namespace EncuestApp.ViewModels
{
	public class CapturaPageViewModel : ViewModelBase
	{
	    private ObservableCollection<Datos> _documentDetail;
	    public ObservableCollection<Datos> DocumentDetail
	    {
	        get => _documentDetail;
	        set => SetProperty(ref _documentDetail, value);
	    }

	    
	    private string _BtnText;
	    public string BtnText
        {
	        get => _BtnText;
	        set => SetProperty(ref _BtnText, value);
	    }

        private Encuesta _document;
	    public Encuesta Document
	    {
	        get => _document;
	        set => SetProperty(ref _document, value);
	    }

	    private int _id;
	    public int Id
	    {
	        get => _id;
	        set => SetProperty(ref _id, value);
	    }

        public CapturaPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            
        }

	    private ICommand _goCommand;

	    public ICommand GoCommand
	    {
	        get
	        {
	            return _goCommand ?? (_goCommand = new Command(async (value) =>
	                       {

	                           if (Id < Document.numberOfStudents)
	                           {
	                               NavigationParameters par = new NavigationParameters();

	                               Document.id = Id + 1;

	                               par.Add("Enc", Document);

	                               await NavigationService.NavigateAsync("CapturaPage", par);
	                           }
	                           else
	                           {
	                               if (await Confirm("Desea Finalizar la Captura?"))
	                               {
	                                   await NavigationService.GoBackToRootAsync();
	                               }
	                           }

	                       }
	                   ));
	        }
	    }

        public override async void OnNavigatedTo(INavigationParameters parameters)
	    {
	        var doc = parameters["Enc"];
	        
	        if (doc != null)
	        {
	            Document = (Encuesta)doc;
	            Id = Document.id;
	            DocumentDetail = new ObservableCollection<Datos>();
	            Title = Id.ToString();
	            BtnText = (Document.id == Document.numberOfStudents) ? "Finalizar" : "Siguiente";

                foreach (var item in Document.fields)
	            {
	               item.value = null;
                   item.valueDate =DateTime.Now;
                   DocumentDetail.Add(item);
	            }

	           
	        }
	    }
    }
}

using System.Threading.Tasks;
using Acr.UserDialogs;
using Prism.Mvvm;
using Prism.Navigation;

namespace EncuestApp.ViewModels
{
    public class ViewModelBase : BindableBase, INavigationAware, IDestructible
    {
        protected INavigationService NavigationService { get; private set; }

        private string _title;
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public ViewModelBase(INavigationService navigationService)
        {
            NavigationService = navigationService;
        }

        public async Task<bool> Confirm(string msg)
        {
            var c = new ConfirmConfig
            {
                Title = Title,
                Message = msg,
                OkText = "Aceptar",
                CancelText = "Cancelar"
            };
            return await UserDialogs.Instance.ConfirmAsync(c);
        }

        public virtual void OnNavigatedFrom(INavigationParameters parameters)
        {

        }

        public virtual void OnNavigatedTo(INavigationParameters parameters)
        {

        }

        public virtual void OnNavigatingTo(INavigationParameters parameters)
        {

        }

        public virtual void Destroy()
        {

        }
    }
}

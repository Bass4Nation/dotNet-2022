using System;
using System.Threading.Tasks;

using Microsoft.UI.Xaml;

using RF2022.Contracts.Services;
using RF2022.ViewModels;

namespace RF2022.Activation
{
    public class DefaultActivationHandler : ActivationHandler<LaunchActivatedEventArgs>
    {
        private readonly INavigationService _navigationService;

        public DefaultActivationHandler(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        protected override async Task HandleInternalAsync(LaunchActivatedEventArgs args)
        {
            _navigationService.NavigateTo(typeof(AllDocumentsViewModel).FullName, args.Arguments);
            await Task.CompletedTask;
        }

        protected override bool CanHandleInternal(LaunchActivatedEventArgs args)
        {
            // None of the ActivationHandlers has handled the app activation
            return _navigationService.Frame.Content == null;
        }
    }
}

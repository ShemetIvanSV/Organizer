using GalaSoft.MvvmLight.Views;

namespace Organizer.Infrastracture
{
    public interface IFrameNavigationService : INavigationService
    {
        object Parameter { get; }
    }
}

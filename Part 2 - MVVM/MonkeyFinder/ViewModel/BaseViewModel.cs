namespace MonkeyFinder.ViewModel;

// [INotifyPropertyChanged]
public partial class BaseViewModel : ObservableObject
{
    [ObservableProperty]
    // [AlsoNotifyChangeFor(nameof(IsNotBusy))] zmienili z tego na: NotifyPropertyChangedFor
    [NotifyPropertyChangedFor(nameof(IsNotBusy))]
    bool isBusy;
    
    [ObservableProperty]
    string title;

    public BaseViewModel()
    {
        // SetProperty(ref isBusy, true);
        
    }

    public bool IsNotBusy => !IsBusy;
}

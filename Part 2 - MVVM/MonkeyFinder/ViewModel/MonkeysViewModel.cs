using MonkeyFinder.Services;

namespace MonkeyFinder.ViewModel;

public partial class MonkeysViewModel : BaseViewModel
{
    MonkeyService _monkeyService;
    public ObservableCollection<Monkey> Monkeys { get; } = new ();
    // public Command GetMonkeysCommand { get; }
    public MonkeysViewModel(MonkeyService monkeyService)
    {
        Title = "Monkeys";
        _monkeyService = monkeyService;
        // GetMonkeysCommand = new Command(async () => await GetMonkeysAsync());
        // GetMonkeysCommand.
    }

    // [ICommand] was relaced to RelayCommand
    [RelayCommand]
    async Task GetMonkeysAsync()
    {
        if (IsBusy)
            return;

        try
        {
            IsBusy = true;
            var monkeys = await _monkeyService.GetMonkeys();

            if (Monkeys.Count != 0)
                Monkeys.Clear();

            foreach (var monkey in monkeys)
                Monkeys.Add(monkey);
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
            await Shell.Current.DisplayAlert("Error", $"Unable to load monkeys. Error: {ex.Message}", "OK");
        }
        finally
        {
            IsBusy = false;
        }
    }
}

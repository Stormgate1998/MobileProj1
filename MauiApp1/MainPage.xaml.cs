//using Android.Hardware.Camera2;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.ComponentModel;
using System.Windows.Input;

namespace MauiApp1;

public partial class MainPage : ContentPage
{
    int count = 0;

    public MainPage(MainPageViewModel2 vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}

public class MainPageViewModel : INotifyPropertyChanged
{
    private int counterValue;

    public MainPageViewModel()
    {
        CounterValue = 0;
        IncrementCounter = new IncrementCounterCommand(this);
    }

    public int CounterValue 
    { 
        get => counterValue;
        set
        {
            counterValue = value;
            ButtonText = $"Clicked {counterValue} times";

            PropertyChanged?.Invoke(this, 
                new PropertyChangedEventArgs(nameof(CounterValue)));
            PropertyChanged?.Invoke(this, 
                new PropertyChangedEventArgs(nameof(ButtonText)));
        }
    }

    public string ButtonText { get; set; }
    public ICommand IncrementCounter { get; set; }

    public event PropertyChangedEventHandler PropertyChanged;
}

public class IncrementCounterCommand : ICommand
{
    private readonly MainPageViewModel vm;

    public IncrementCounterCommand(MainPageViewModel vm)
    {
        this.vm = vm;
    }

    public event EventHandler CanExecuteChanged;

    public bool CanExecute(object parameter)
    {
        return true;
    }

    public void Execute(object parameter)
    {
        vm.CounterValue++;
    }
}

public partial class MainPageViewModel2 : ObservableObject
{
    public string ButtonText => $"Clicked {counterValue} times";

    [ObservableProperty, NotifyPropertyChangedFor(nameof(TankPrice))]
    private double gallonCount;

    [ObservableProperty, NotifyPropertyChangedFor(nameof(TankPrice))]
    private double gasPrice;

    public double TankPrice{
        get {return GallonCount* GasPrice; }
    }

    [ObservableProperty]
    private DateTime now;

    [ObservableProperty, NotifyPropertyChangedFor(nameof(ButtonText))]
    private int counterValue;

    [RelayCommand]
    public void IncrementCounter()
    {
        CounterValue++;
        Now = DateTime.Now;
    }



}
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using WpfLibraryImport.ViewModels;

namespace WpfLibraryImport.Views;

public partial class MainPage : UserControl
{
    public static readonly DependencyProperty CustomDialogMessageProperty = DependencyProperty.Register("CustomDialogMessage", typeof(string),
        typeof(MainPage), new PropertyMetadata("NULL", OnSetCustomDialogMessage));

    public string CustomDialogMessage
    {
        set => SetValue(CustomDialogMessageProperty, value);
        get => (string)GetValue(CustomDialogMessageProperty);
    }

    private static void OnSetCustomDialogMessage(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {        
        string customDialogMessage = (string)e.NewValue;
        if (e.NewValue != null)
        {
            if (string.IsNullOrEmpty(customDialogMessage))
            {
                return;
            }
            CustomMessageBox messageBox = new(customDialogMessage);
            messageBox.ShowDialog();
        }
    }

    private bool _viewLoaded = false;

    public MainPage()
    {
        InitializeComponent();
        Loaded += OnLoaded;
    }

    private void OnLoaded(object sender, RoutedEventArgs e)
    {
        if (_viewLoaded)
        {
            return;
        }
        var viewModel = this.DataContext as MainViewModel;
        var customDialogMessageBinding = new Binding
        {
            Source = viewModel,
            Path = new PropertyPath("CustomDialogMessage"),
            Mode = BindingMode.OneWay,
            UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged
        };
        BindingOperations.SetBinding(this, CustomDialogMessageProperty, customDialogMessageBinding);
        _viewLoaded = true;
    }
}

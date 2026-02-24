using Prism.Mvvm;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;
using WpfLibraryImport.Models;
using WpfLibraryImport.Models.Marshaling.Legacy;
using WpfLibraryImport.Models.Marshaling.Modern;
using WpfLibraryImport.PInvoke;
using WpfLibraryImport.PInvokeCallback;

namespace WpfLibraryImport.ViewModels;

public class MainViewModel : BindableBase
{
    private readonly LegacyPInvokeMainWindowCallback _legacyPInvokeMainWindowCallback;
    private readonly ModernPInvokeMainWindowCallback _modernPInvokeMainWindowCallback;
    private readonly LegacyPInvokeSample _legacyPInvokeSample;
    private readonly ModernPInvokeSample _modernPInvokeSample;
    private string _customDialogMessage = "";

    private int _boolReturnInputValue = 0;
    private bool _inputBoolValue = false;
    private string _inputStringValue = "";
    private readonly SampleStructModel _sampleStruct = new();
    private readonly SampleArrayStructModel _sampleArrayStruct = new();
    
    public ICommand ButtonCommand { get; set; }

    public string CustomDialogMessage
    {
        get => _customDialogMessage;
        set => SetProperty(ref _customDialogMessage, value);
    }

    public int BoolReturnInputValue
    {
        get => _boolReturnInputValue;
        set => SetProperty(ref _boolReturnInputValue, value);
    }

    public bool InputBoolValue
    {
        get => _inputBoolValue;
        set => SetProperty(ref _inputBoolValue, value);
    }

    public string InputStringValue
    {
        get => _inputStringValue;
        set => SetProperty(ref _inputStringValue, value);
    }

    public SampleStructModel SampleStruct
    {
        get => _sampleStruct;        
    }

    public SampleArrayStructModel SampleArrayStruct
    {
        get => _sampleArrayStruct;
    }


    public MainViewModel(LegacyPInvokeSample legacyPInvokeSample, ModernPInvokeSample modernPInvokeSample)
    {
        _legacyPInvokeMainWindowCallback = new(this);
        _modernPInvokeMainWindowCallback = new(this);
        _legacyPInvokeSample = legacyPInvokeSample;
        _modernPInvokeSample = modernPInvokeSample;
        ButtonCommand = new DelegateCommand<string>(OnButtonCommand);
    }

    private void OnButtonCommand(string param)
    {
        switch (param)
        {
            case "PInvoke_ReturnBoolValue_Legacy":
                {
                    var dialogMessage = $"Bool Return: {_legacyPInvokeSample.ReturnBoolValue(BoolReturnInputValue)}";
                    var dialogContent = new LegacyDialogContent { text = dialogMessage };
                    OnShowDialogLegacy(ref dialogContent);
                }
                break;

            case "PInvoke_ReturnBoolValue_Modern":
                {
                    var dialogMessage = $"Bool Return: {_modernPInvokeSample.ReturnBoolValue(BoolReturnInputValue)}";
                    var dialogContent = new ModernDialogContent { Text = dialogMessage };
                    OnShowDialogModern(ref dialogContent);
                }
                break;

            case "PInvoke_InputBoolValue_Legacy":
                _legacyPInvokeSample.InputBoolValue(InputBoolValue);
                break;

            case "PInvoke_InputBoolValue_Modern":
                _modernPInvokeSample.InputBoolValue(InputBoolValue);
                break;

            case "PInvoke_InputStringValue_Legacy":
                _legacyPInvokeSample.InputStringValue(InputStringValue);
                break;

            case "PInvoke_InputStringValue_Modern":
                _modernPInvokeSample.InputStringValue(InputStringValue);
                break;

            case "PInvoke_InputStructValue_Legacy":
                _legacyPInvokeSample.InputStructValue(SampleStruct.GetLegacyMarshalValue());
                break;

            case "PInvoke_OutputStructValue_Legacy":
                {
                    var returnStruct = _legacyPInvokeSample.OutputStructValue();
                    SampleStruct.SetLegacyMarshalValue(returnStruct);
                }
                break;

            case "PInvoke_InputStructValue_Modern":
                _modernPInvokeSample.InputStructValue(SampleStruct.GetModernMarshalValue());
                break;

            case "PInvoke_OutputStructValue_Modern":
                {
                    var returnStruct = _modernPInvokeSample.OutputStructValue();
                    SampleStruct.SetModernMarshalValue(returnStruct);
                }
                break;

            case "PInvoke_InputStructWithArrayValue_Legacy":
                _legacyPInvokeSample.InputStructWithArrayValue(SampleArrayStruct.GetLegacyMarshalValue());
                break;

            case "PInvoke_OutputStructWithArrayValue_Legacy":
                {
                    var returnStruct = _legacyPInvokeSample.OutputStructWithArrayValue();
                    SampleArrayStruct.SetLegacyMarshalValue(returnStruct);
                }
                break;

            case "PInvoke_InputStructWithArrayValue_Modern":
                _modernPInvokeSample.InputStructWithArrayValue(SampleArrayStruct.GetModernMarshalValue());
                break;

            case "PInvoke_OutputStructWithArrayValue_Modern":
                {
                    var returnStruct = _modernPInvokeSample.OutputStructWithArrayValue();
                    SampleArrayStruct.SetModernMarshalValue(returnStruct);
                }
                break;

            default:
                break;
        }
    }

    public void OnShowDialogLegacy(ref LegacyDialogContent dialogContent)
    {
        string messageText = dialogContent.text;
        Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Background, () =>
        {
            CustomDialogMessage = "";
            CustomDialogMessage = messageText;
        });
    }

    public void OnShowDialogModern(ref ModernDialogContent dialogContent)
    {
        string messageText = dialogContent.Text;
        Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Background, () =>
        {
            CustomDialogMessage = "";
            CustomDialogMessage = messageText;
        });
    }

    public void OnSetCoreValue(bool boolValue, int intValue, float floatValue, double doubleValue)
    {

    }
}

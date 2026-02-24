using System.Runtime.InteropServices;
using WpfLibraryImport.Models.Marshaling.Legacy;
using WpfLibraryImport.ViewModels;

namespace WpfLibraryImport.PInvokeCallback;

public class LegacyPInvokeMainWindowCallback
{
    public delegate void OnShowDialog(ref LegacyDialogContent dialogContent);
    public delegate void OnSetCoreValue(bool boolValue, int intValue, float floatValue, double doubleValue);

    private static OnShowDialog _onShowDialog;
    private static OnSetCoreValue _onSetCoreValue;

    [DllImport("WpfLibraryImport.Core")]
    internal static extern void PInvoke_MainWindowCallback_AssignCallbackFunction(OnShowDialog onShowDialog, OnSetCoreValue onSetCoreValue);

    public LegacyPInvokeMainWindowCallback(MainViewModel mainViewModel)
    {
        _onShowDialog = mainViewModel.OnShowDialogLegacy;
        _onSetCoreValue = mainViewModel.OnSetCoreValue;
        PInvoke_MainWindowCallback_AssignCallbackFunction(_onShowDialog, _onSetCoreValue);
    }
}

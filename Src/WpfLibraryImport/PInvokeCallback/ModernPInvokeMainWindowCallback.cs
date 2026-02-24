using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using WpfLibraryImport.Models.Marshaling.Modern;
using WpfLibraryImport.ViewModels;

using unsafe OnShowDialogPtr =  delegate* unmanaged[Cdecl]<WpfLibraryImport.Models.Marshaling.Modern.ModernDialogContent*, void>;
using unsafe OnSetCoreValuePtr = delegate* unmanaged[Cdecl]<byte, int, float, double, void>;

namespace WpfLibraryImport.PInvokeCallback;

public unsafe partial class ModernPInvokeMainWindowCallback
{
    [UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvCdecl) })]
    private static void OnShowDialog(ModernDialogContent* dialogContent)
    {
        ref ModernDialogContent content = ref Unsafe.AsRef<ModernDialogContent>(dialogContent);
        _viewModel.OnShowDialogModern(ref content);
    }

    [UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvCdecl) })]
    private static void OnSetCoreValue(byte boolValue, int intValue, float floatValue, double doubleValue)
    {
        bool value = boolValue != 0;
        _viewModel.OnSetCoreValue(value, intValue, floatValue, doubleValue);
    }

    private static MainViewModel _viewModel;    

    [LibraryImport("WpfLibraryImport.Core")]
    internal static partial void PInvoke_MainWindowCallback_AssignCallbackFunction(OnShowDialogPtr onShowDialog, OnSetCoreValuePtr onSetCoreValue);

    public ModernPInvokeMainWindowCallback(MainViewModel viewModel)
    {
        _viewModel = viewModel;
        PInvoke_MainWindowCallback_AssignCallbackFunction(&OnShowDialog, &OnSetCoreValue);
    }
}

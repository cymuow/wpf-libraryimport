using System.Runtime.InteropServices;
using WpfLibraryImport.Models.Marshaling.Legacy;

namespace WpfLibraryImport.PInvoke;

public class LegacyPInvokeSample
{
    private LegacySampleStruct _sampleStruct = new();
    private LegacySampleStructWithArray _sampleStructWithArray = new();

    public LegacyPInvokeSample()
    {
    }

    [DllImport("WpfLibraryImport.Core", CallingConvention = CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.I1)]
    internal static extern bool PInvoke_ReturnBoolValue(int inputValue);
    public bool ReturnBoolValue(int inputValue)
    {
        return PInvoke_ReturnBoolValue(inputValue);
    }

    [DllImport("WpfLibraryImport.Core")]
    internal static extern void PInvoke_InputBoolValue([MarshalAs(UnmanagedType.I1)] bool inputValue);
    public void InputBoolValue(bool inputValue)
    {
        PInvoke_InputBoolValue(inputValue);
    }

    [DllImport("WpfLibraryImport.Core", CharSet = CharSet.Unicode)]
    internal static extern void PInvoke_InputStringValue(string inputValue);
    public void InputStringValue(string inputValue)
    {
        PInvoke_InputStringValue(inputValue);
    }

    [DllImport("WpfLibraryImport.Core")]
    internal static extern void PInvoke_InputStructValue(ref LegacySampleStruct inValue);
    public void InputStructValue(LegacySampleStruct inValue)
    {
        PInvoke_InputStructValue(ref inValue);
    }

    [DllImport("WpfLibraryImport.Core")]
    internal static extern void PInvoke_OutputStructValue(ref LegacySampleStruct outValue);
    public LegacySampleStruct OutputStructValue()
    {
        PInvoke_OutputStructValue(ref _sampleStruct);
        return _sampleStruct;
    }

    [DllImport("WpfLibraryImport.Core")]
    internal static extern void PInvoke_InputStructWithArrayValue(ref LegacySampleStructWithArray inValue);
    public void InputStructWithArrayValue(LegacySampleStructWithArray inValue)
    {
        PInvoke_InputStructWithArrayValue(ref inValue);
    }

    [DllImport("WpfLibraryImport.Core")]
    internal static extern void PInvoke_OutputStructWithArrayValue(ref LegacySampleStructWithArray outValue);
    public LegacySampleStructWithArray OutputStructWithArrayValue()
    {
        PInvoke_OutputStructWithArrayValue(ref _sampleStructWithArray);
        return _sampleStructWithArray;
    }
}

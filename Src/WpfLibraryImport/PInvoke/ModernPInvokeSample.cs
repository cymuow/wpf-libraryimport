using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using WpfLibraryImport.Models.Marshaling.Modern;

namespace WpfLibraryImport.PInvoke;

//CS0227을 막기 위해서는 프로젝트 파일을 편집하여 PropertyGroup에 <AllowUnsafeBlocks>true</AllowUnsafeBlocks> 을 넣어 준다.
public partial class ModernPInvokeSample
{
    private ModernSampleStruct _sampleStruct = new();
    private ModernSampleStructWithArray _sampleStructWithArray = new();

    public ModernPInvokeSample()
    {
    }

    [LibraryImport("WpfLibraryImport.Core")]
    [UnmanagedCallConv(CallConvs = new Type[] { typeof(CallConvCdecl) })]
    [return: MarshalAs(UnmanagedType.I1)]
    internal static partial bool PInvoke_ReturnBoolValue(int inputValue);
    public bool ReturnBoolValue(int inputValue)
    {
        return PInvoke_ReturnBoolValue(inputValue);
    }

    [LibraryImport("WpfLibraryImport.Core")]
    internal static partial void PInvoke_InputBoolValue([MarshalAs(UnmanagedType.I1)] bool inputValue);
    public void InputBoolValue(bool inputValue)
    {
        PInvoke_InputBoolValue(inputValue);
    }

    [LibraryImport("WpfLibraryImport.Core", StringMarshalling = StringMarshalling.Utf8)]
    internal static partial void PInvoke_InputStringValue(string inputValue);
    public void InputStringValue(string inputValue)
    {
        PInvoke_InputStringValue(inputValue);
    }

    [LibraryImport("WpfLibraryImport.Core")]
    internal static partial void PInvoke_InputStructValue(ref ModernSampleStruct inValue);
    public void InputStructValue(ModernSampleStruct inValue)
    {
        PInvoke_InputStructValue(ref inValue);
    }

    [LibraryImport("WpfLibraryImport.Core")]
    internal static partial void PInvoke_OutputStructValue(ref ModernSampleStruct outValue);
    public ModernSampleStruct OutputStructValue()
    {
        PInvoke_OutputStructValue(ref _sampleStruct);
        return _sampleStruct;
    }

    [LibraryImport("WpfLibraryImport.Core")]
    internal static partial void PInvoke_InputStructWithArrayValue(ref ModernSampleStructWithArray inValue);
    public void InputStructWithArrayValue(ModernSampleStructWithArray inValue)
    {
        PInvoke_InputStructWithArrayValue(ref inValue);
    }

    [LibraryImport("WpfLibraryImport.Core")]
    internal static partial void PInvoke_OutputStructWithArrayValue(ref ModernSampleStructWithArray outValue);
    public ModernSampleStructWithArray OutputStructWithArrayValue()
    {
        PInvoke_OutputStructWithArrayValue(ref _sampleStructWithArray);
        return _sampleStructWithArray;
    }
}

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace WpfLibraryImport.Models.Marshaling.Modern;

/*
InlineArray는 기본적으로 구조체(struct)이므로 PascalCase를 사용하며, 해당 타입의 역할과 크기를 명시하는 것이 관례입니다. 1.5.1 
추천 형식: Char{Size}Buffer 또는 {Purpose}Buffer, {Type}{Size}Buffer
예시:
Char10Buffer: 크기가 10인 범용 char 배열
Char128Buffer: 크기가 128인 범용 char 배열
NameBuffer: 이름 저장용으로 크기가 고정된 배열
*/

[InlineArray(50)]
public struct Char50Buffer
{
    //C++의 char는 C#의 byte, C++의 wchar_t는 C#의 char
    private byte _element0;
}

[StructLayout(LayoutKind.Sequential)]
public struct ModernSampleStruct
{
    //[MarshalAs(UnmanagedType.I1)] 를 쓰면 SYSLIB1051 에러가 발생하므로 Blittable 유지를 위하여 직접 byte로 마샬링 한다.
    public byte boolValue = 0;
    public byte byteValue = 0;
    public int intValue = 0;
    public float floatValue = 0;
    public double doubleValue = 0;
    public long longValue = 0;
    public Char50Buffer stringValue;

    public string StringValue
    {
        readonly get => StringMarshaller.GetString(stringValue);
        set => StringMarshaller.SetString(value, stringValue);
    }

    public ModernSampleStruct()
    {
    }
}

[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct ModernSampleStructWithPack
{
    //[MarshalAs(UnmanagedType.I1)] 를 쓰면 SYSLIB1051 에러가 발생하므로 Blittable 유지를 위하여 직접 byte로 마샬링 한다.
    public byte boolValue = 0;

    public byte byteValue = 0;
    public int intValue = 0;
    public float floatValue = 0;
    public double doubleValue = 0;
    public long longValue = 0;
    public Char50Buffer stringValue;

    public string StringValue
    {
        readonly get => StringMarshaller.GetString(stringValue);
        set => StringMarshaller.SetString(value, stringValue);
    }

    public ModernSampleStructWithPack()
    {
    }
}

[InlineArray(3)]
public struct SampleStruct3Buffer
{
    private ModernSampleStruct _element0;
}

[InlineArray(3)]
public struct Int3Buffer
{
    private int _element0;
}

[InlineArray(3)]
public struct Float3Buffer
{
    private float _element0;
}

[InlineArray(400)]
public struct Char400Buffer
{
    private byte _element0;
}

[StructLayout(LayoutKind.Sequential)]
public struct ModernSampleStructWithArray
{
    public Int3Buffer intArray;
    public Float3Buffer floatArray;
    public SampleStruct3Buffer structArray;

    public ModernSampleStructWithArray()
    {
    }
}

[StructLayout(LayoutKind.Sequential)]
public struct ModernDialogContent
{
    public Char400Buffer text;

    public string Text
    {
        readonly get => StringMarshaller.GetString(text);
        set => StringMarshaller.SetString(value, text);
    }

    public ModernDialogContent()
    {
    }
}
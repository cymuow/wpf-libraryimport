using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace WpfLibraryImport.Models.Marshaling.Legacy;

[StructLayout(LayoutKind.Sequential)]
public struct LegacySampleStruct
{
    [MarshalAs(UnmanagedType.I1)]
    public bool boolValue = false;

    public byte byteValue = 0;
    public int intValue = 0;
    public float floatValue = 0;
    public double doubleValue = 0;
    public long longValue = 0;

    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 50)]
    public string stringValue = "";

    public LegacySampleStruct()
    {
    }
}

[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct LegacySampleStructWithPack
{
    [MarshalAs(UnmanagedType.I1)]
    public bool boolValue = false;

    public byte byteValue = 0;
    public int intValue = 0;
    public float floatValue = 0;
    public double doubleValue = 0;
    public long longValue = 0;

    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 50)]
    public string stringValue = "";

    public LegacySampleStructWithPack()
    {
    }
}

[StructLayout(LayoutKind.Sequential)]
public struct LegacySampleStructWithArray
{
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
    public int[] intArray = new int[3];

    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
    public float[] floatArray = new float[3];

    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3, ArraySubType = UnmanagedType.LPStruct)]
    public LegacySampleStruct[] structArray = new LegacySampleStruct[3];

    public LegacySampleStructWithArray()
    {
    }
}

[StructLayout(LayoutKind.Sequential)]
public struct LegacyDialogContent
{
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 400)]
    public string text = "";

    public LegacyDialogContent()
    {
    }
}
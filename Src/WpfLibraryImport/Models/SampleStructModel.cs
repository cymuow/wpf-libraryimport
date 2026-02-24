using WpfLibraryImport.Models.Marshaling.Legacy;
using WpfLibraryImport.Models.Marshaling.Modern;

namespace WpfLibraryImport.Models;

public  class SampleStructModel : BindableBase
{
    private bool _boolValue = false;
    private byte _byteValue = 0;
    private int _intValue = 0;
    private float _floatValue = 0;
    private double _doubleValue = 0;
    private long _longValue = 0;
    private string _stringValue = "";

    public bool BoolValue
    {
        get => _boolValue;
        set => SetProperty(ref _boolValue, value);
    }

    public byte ByteValue
    {
        get => _byteValue;
        set => SetProperty(ref _byteValue, value);
    }

    public int IntValue
    {
        get => _intValue;
        set => SetProperty(ref _intValue, value);
    }

    public float FloatValue
    {
        get => _floatValue;
        set => SetProperty(ref _floatValue, value);
    }

    public double DoubleValue
    {
        get => _doubleValue;
        set => SetProperty(ref _doubleValue, value);
    }

    public long LongValue
    {
        get => _longValue;
        set => SetProperty(ref _longValue, value);
    }

    public string StringValue
    {
        get => _stringValue;
        set => SetProperty(ref _stringValue, value);
    }

    public void SetLegacyMarshalValue(in LegacySampleStruct sampleStruct)
    {
        BoolValue = sampleStruct.boolValue;
        ByteValue = sampleStruct.byteValue;
        IntValue = sampleStruct.intValue;
        FloatValue = sampleStruct.floatValue;
        DoubleValue = sampleStruct.doubleValue;
        LongValue = sampleStruct.longValue;
        StringValue = sampleStruct.stringValue;
    }

    public void SetModernMarshalValue(in ModernSampleStruct sampleStruct)
    {
        BoolValue = sampleStruct.boolValue != 0;
        ByteValue = sampleStruct.byteValue;
        IntValue = sampleStruct.intValue;
        FloatValue = sampleStruct.floatValue;
        DoubleValue = sampleStruct.doubleValue;
        LongValue = sampleStruct.longValue;
        StringValue = sampleStruct.StringValue;
    }

    public LegacySampleStruct GetLegacyMarshalValue()
    {
        return new LegacySampleStruct
        {
            boolValue = BoolValue,
            byteValue = ByteValue,
            intValue = IntValue,
            floatValue = FloatValue,
            doubleValue = DoubleValue,
            longValue = LongValue,
            stringValue = StringValue
        };
    }

    public ModernSampleStruct GetModernMarshalValue()
    {
        return new ModernSampleStruct
        {
            boolValue = (byte)(BoolValue ? 1 : 0),
            byteValue = ByteValue,
            intValue = IntValue,
            floatValue = FloatValue,
            doubleValue = DoubleValue,
            longValue = LongValue,
            StringValue = StringValue
        };
    }
}

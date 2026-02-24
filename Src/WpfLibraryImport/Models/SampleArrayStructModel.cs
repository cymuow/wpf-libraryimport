using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using WpfLibraryImport.Models.Marshaling.Legacy;
using WpfLibraryImport.Models.Marshaling.Modern;

namespace WpfLibraryImport.Models;

public class SampleArrayStructModel : BindableBase
{
    private ObservableCollection<int> _intArray = [0, 0, 0];
    private ObservableCollection<float> _floatArray = [0, 0, 0];
    private ObservableCollection<SampleStructModel> _structArray = [new(), new(), new()];

    public ObservableCollection<int> IntArray
    {
        get => _intArray;
        set => SetProperty(ref _intArray, value);
    }
    public ObservableCollection<float> FloatArray
    {
        get => _floatArray;
        set => SetProperty(ref _floatArray, value);
    }

    public ObservableCollection<SampleStructModel> StructArray
    {
        get => _structArray;
        set => SetProperty(ref _structArray, value);
    }

    public void SetLegacyMarshalValue(in LegacySampleStructWithArray sampleStruct)
    {
        for (int i = 0; i < 3; i++)
        {
            IntArray[i] = sampleStruct.intArray[i];
            FloatArray[i] = sampleStruct.floatArray[i];
            StructArray[i].SetLegacyMarshalValue(sampleStruct.structArray[i]);
        }
    }

    public void SetModernMarshalValue(in ModernSampleStructWithArray sampleStruct)
    {
        for (int i = 0; i < 3; i++)
        {
            IntArray[i] = sampleStruct.intArray[i];
            FloatArray[i] = sampleStruct.floatArray[i];
            StructArray[i].SetModernMarshalValue(sampleStruct.structArray[i]);
        }
    }

    public LegacySampleStructWithArray GetLegacyMarshalValue()
    {
        var result = new LegacySampleStructWithArray();
        for (int i = 0; i < 3; i++)
        {
            result.intArray[i] = IntArray[i];
            result.floatArray[i] = FloatArray[i];
            result.structArray[i] = StructArray[i].GetLegacyMarshalValue();
        }
        return result;
    }

    public ModernSampleStructWithArray GetModernMarshalValue()
    {
        var result = new ModernSampleStructWithArray();
        for (int i = 0; i < 3; i++)
        {
            result.intArray[i] = IntArray[i];
            result.floatArray[i] = FloatArray[i];
            result.structArray[i] = StructArray[i].GetModernMarshalValue();
        }
        return result;
    }
}

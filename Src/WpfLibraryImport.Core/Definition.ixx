module;

export module definition;

import <cstdint>;

export namespace def
{
	struct SampleStruct
	{
		bool boolValue = false;
		uint8_t byteValue = 0;
		int intValue = 0;
		float floatValue = 0;
		double doubleValue = 0;
		int64_t longValue = 0;
		char stringValue[50] = { 0, };
	};

#pragma pack(push, 1)
	struct SampleStructWithPack
	{
		bool boolValue = false;
		uint8_t byteValue = 0;
		int intValue = 0;
		float floatValue = 0;
		double doubleValue = 0;
		int64_t longValue = 0;
		char stringValue[50] = { 0, };
	};
#pragma pack(pop)

	struct SampleStructWithArray
	{
		int intArray[3] = { 0, };
		float floatArray[3] = { 0, };
		SampleStruct structArray[3] = {};
	};

	struct DialogContent
	{
		char text[400] = { 0, };
	};
}
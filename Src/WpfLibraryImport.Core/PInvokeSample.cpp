import std;
import definition;
import pinvoke.callback.mainwindow;

extern "C"
{
	_declspec(dllexport) bool PInvoke_ReturnBoolValue(int inputValue)
	{
		return inputValue != 0;
	}

	_declspec(dllexport) void PInvoke_InputBoolValue(bool inputValue)
	{
		//C# 콜백으로 대화 상자 띄움.
		auto text = std::format("Bool Input: {}", inputValue);
		def::DialogContent dialogContent = {};
		std::copy(text.begin(), text.end(), dialogContent.text);
		pinvoke::MainWindowCallback::ShowDialog(&dialogContent);
	}

	_declspec(dllexport) void PInvoke_InputStringValue(const char* inputValue)
	{
		//C# 콜백으로 대화 상자 띄움.		
		auto text = std::format("String Input: {}", inputValue);
		def::DialogContent dialogContent = {};
		std::copy(text.begin(), text.end(), dialogContent.text);
		pinvoke::MainWindowCallback::ShowDialog(&dialogContent);
	}

	_declspec(dllexport) void PInvoke_InputStructValue(def::SampleStruct* inValue)
	{
		auto text = std::format("Bool: {}, Byte: {}, Int: {}\nFloat: {:.3f}, Double: {:.6f}, Long: {}\nString: {}", 
			inValue->boolValue, inValue->byteValue, inValue->intValue, inValue->floatValue, inValue->doubleValue, inValue->longValue, inValue->stringValue);
		def::DialogContent dialogContent = {};
		std::copy(text.begin(), text.end(), dialogContent.text);
		pinvoke::MainWindowCallback::ShowDialog(&dialogContent);
	}	

	_declspec(dllexport) void PInvoke_OutputStructValue(def::SampleStruct* outValue)
	{
		auto& out = *outValue;
		out.boolValue = true;
		out.byteValue = 1;
		out.intValue = 2;
		out.floatValue = 3.4f;
		out.doubleValue = 5.6;
		out.longValue = 7;
		std::string text = "From C++ Function";
		std::copy(text.begin(), text.end(), out.stringValue);
	}

	_declspec(dllexport) void PInvoke_InputStructWithArrayValue(def::SampleStructWithArray* inValue)
	{
		auto text = std::format("intArray[0]: {}, intArray[1]: {}, intArray[2]: {}\nfloatArray[0]: {:.3f}, floatArray[1]: {:.3f}, floatArray[2]: {:.3f}",
			inValue->intArray[0], inValue->intArray[1], inValue->intArray[2], inValue->floatArray[0], inValue->floatArray[1], inValue->floatArray[2]);
		def::DialogContent dialogContent = {};
		std::copy(text.begin(), text.end(), dialogContent.text);
		pinvoke::MainWindowCallback::ShowDialog(&dialogContent);
	}

	_declspec(dllexport) void PInvoke_OutputStructWithArrayValue(def::SampleStructWithArray* outValue)
	{
		auto& out = *outValue;
		auto intValue = { 1, 2, 3 };
		auto floatValue = { 4.5f, 6.7f, 8.9f };
		std::copy(intValue.begin(), intValue.end(), out.intArray);
		std::copy(floatValue.begin(), floatValue.end(), out.floatArray);
	}
}
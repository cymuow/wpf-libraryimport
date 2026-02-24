module;

export module pinvoke.callback.mainwindow;

import definition;

export namespace pinvoke
{
	class MainWindowCallback
	{
	public:
		__declspec(dllexport) MainWindowCallback() = default;
		__declspec(dllexport) virtual ~MainWindowCallback() = default;
		MainWindowCallback(const MainWindowCallback& src) = delete;
		MainWindowCallback(const MainWindowCallback&& src) = delete;
		MainWindowCallback& operator= (const MainWindowCallback& src) = delete;
		MainWindowCallback& operator= (const MainWindowCallback&& src) = delete;

		using OnShowDialog = void(*)(def::DialogContent*);
		using OnSetCoreValue = void(*)(bool, int, float, double);

		__declspec(dllexport) static void AssignCallbackFunction(OnShowDialog onShowDialog, OnSetCoreValue onSetCoreValue);
		__declspec(dllexport) static void ShowDialog(def::DialogContent* dialogContent);
		__declspec(dllexport) static void SetCoreValue(bool boolValue, int intValue, float floatValue, double doubleValue);

	private:
		static inline OnShowDialog sOnShowDialog = nullptr;
		static inline OnSetCoreValue sOnSetCoreValue = nullptr;
	};
}
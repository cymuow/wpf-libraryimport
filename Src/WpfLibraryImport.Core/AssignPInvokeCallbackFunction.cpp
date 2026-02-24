import pinvoke.callback.mainwindow;

extern "C"
{
	__declspec(dllexport) void PInvoke_MainWindowCallback_AssignCallbackFunction(pinvoke::MainWindowCallback::OnShowDialog onShowDialog,
		pinvoke::MainWindowCallback::OnSetCoreValue onSetCoreValue)
	{
		pinvoke::MainWindowCallback::AssignCallbackFunction(onShowDialog, onSetCoreValue);
	}
}
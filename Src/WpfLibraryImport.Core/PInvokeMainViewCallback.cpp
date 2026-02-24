module;

module pinvoke.callback.mainwindow;

namespace pinvoke
{
	void MainWindowCallback::AssignCallbackFunction(OnShowDialog onShowDialog, OnSetCoreValue onSetCoreValue)
	{
		sOnShowDialog = onShowDialog;
		sOnSetCoreValue = onSetCoreValue;
	}

	void MainWindowCallback::ShowDialog(def::DialogContent* dialogContent)
	{
		if (sOnShowDialog)
		{
			sOnShowDialog(dialogContent);
		}
	}

	void MainWindowCallback::SetCoreValue(bool boolValue, int intValue, float floatValue, double doubleValue)
	{
		if (sOnSetCoreValue)
		{
			sOnSetCoreValue(boolValue, intValue, floatValue, doubleValue);
		}
	}
}
using Android.App;
using Android.Runtime;

namespace MauiForCars;

[Application]
[MetaData(name: "com.google.android.gms.car.application", Resource = "@xml/automotive_app_desc")]
[MetaData(name: "androidx.car.app.minCarApiLevel", Value = "2")]
public class MainApplication : MauiApplication
{
	public MainApplication(IntPtr handle, JniHandleOwnership ownership)
		: base(handle, ownership)
	{
	}

	protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();
}

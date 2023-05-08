using Android.App;
using AndroidX.Car.App;
using AndroidX.Car.App.Validation;
using MauiForCars.Platforms.Android.AndroidAuto.Sessions;

namespace MauiForCars.Platforms.Android.AndroidAuto.Services
{
    [Service(Exported = true)]
    [IntentFilter(new string[] { "androidx.car.app.CarAppService" }, Categories = new[] { "androidx.car.app.category.POI" })]
    public class AACarAppService : CarAppService
    {
        public override HostValidator CreateHostValidator()
        {
            return HostValidator.AllowAllHostsValidator;
        }

        public override Session OnCreateSession()
        {
            return new AASession();
        }
    }
}

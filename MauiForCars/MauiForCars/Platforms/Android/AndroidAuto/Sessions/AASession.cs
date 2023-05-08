using Android.Content;
using AndroidX.Car.App;
using MauiForCars.Platforms.Android.AndroidAuto.Screens;

namespace MauiForCars.Platforms.Android.AndroidAuto.Sessions
{
    public class AASession : Session
    {
        public override Screen OnCreateScreen(Intent intent)
        {
            return new AAScreenMenu(CarContext);
        }
    }
}

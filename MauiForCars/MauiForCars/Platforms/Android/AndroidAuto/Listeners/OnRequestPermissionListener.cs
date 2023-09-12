using AndroidX.Car.App;
using MauiForCars.Platforms.Android.AndroidAuto.Screens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiForCars.Platforms.Android.AndroidAuto.Listeners
{
    public class OnRequestPermissionListener : Java.Lang.Object, IOnRequestPermissionsListener
    {
        private readonly CarContext _carContext;
        private readonly ScreenManager _screenManager;

        public OnRequestPermissionListener(CarContext carContext, ScreenManager screenManager)
        {
            _carContext = carContext;
            _screenManager = screenManager;
        }

        public void OnRequestPermissionsResult(IList<string> grandtedPermissions, IList<string> rejectedPermissions)
        {
            if (rejectedPermissions.Count > 0)
            {
                /* Permissions were rejected */
                CarToast.MakeText(_carContext, "Permissions were denied", CarToast.LengthShort).Show();
                return;
            }

            CarToast.MakeText(_carContext, "All permissions has been accepted", CarToast.LengthShort).Show();
        }

    }
}

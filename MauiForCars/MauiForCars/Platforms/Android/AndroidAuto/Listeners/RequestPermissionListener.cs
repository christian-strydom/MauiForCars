using Android;
using Android.Content.PM;
using AndroidX.Car.App;
using AndroidX.Car.App.Model;
using MauiForCars.Platforms.Android.AndroidAuto.Screens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiForCars.Platforms.Android.AndroidAuto.Listeners
{
    public class RequestPermissionListener : Java.Lang.Object, IOnClickListener
    {
        private readonly CarContext _carContext;
        private readonly ScreenManager _screenManager;

        public RequestPermissionListener(CarContext carContext, ScreenManager screenManager)
        {
            _carContext = carContext;
            _screenManager = screenManager;
        }

        public void OnClick()
        {
            var permissionsToRequest = new List<string>();

            if (_carContext.CheckSelfPermission(Manifest.Permission.AccessCoarseLocation) != Permission.Granted)
            {
                permissionsToRequest.Add(Manifest.Permission.AccessCoarseLocation);
            }

            if (_carContext.CheckSelfPermission(Manifest.Permission.AccessFineLocation) != Permission.Granted)
            {
                permissionsToRequest.Add(Manifest.Permission.AccessFineLocation);
            }

            if (permissionsToRequest.Count != 0)
            {
                _carContext.RequestPermissions(permissionsToRequest, new OnRequestPermissionListener(_carContext, _screenManager));
                return;
            }

            Device.BeginInvokeOnMainThread(() => { CarToast.MakeText(_carContext, "All permissions has been accepted", CarToast.LengthShort).Show(); });
        }
    }
}

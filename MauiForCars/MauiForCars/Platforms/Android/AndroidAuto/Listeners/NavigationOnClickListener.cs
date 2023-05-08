using AndroidX.Car.App;
using AndroidX.Car.App.Model;
using MauiForCars.Platforms.Android.AndroidAuto.Enums;
using MauiForCars.Platforms.Android.AndroidAuto.Screens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiForCars.Platforms.Android.AndroidAuto.Listeners
{
    public class NavigationOnClickListener : Java.Lang.Object, IOnClickListener
    {
        private CarContext _carContext;
        private ScreenManager _screenManager;
        private AAScreen _screenToNavigateTo;

        public NavigationOnClickListener(CarContext carContext, ScreenManager screenManager, AAScreen screenToNavigateTo)
        {
            _carContext = carContext;
            _screenManager = screenManager;
            _screenToNavigateTo = screenToNavigateTo;
        }

        public void OnClick()
        {
            switch (_screenToNavigateTo)
            {
                case AAScreen.None:
                    return;
                case AAScreen.Menu:
                    _screenManager.Push(new AAScreenMenu(_carContext));
                    break;
                case AAScreen.MessageTemplate:
                    _screenManager.Push(new AAScreenMessageTemplate(_carContext));
                    break;
                case AAScreen.PaneTemplate:
                    _screenManager.Push(new AAScreenPaneTemplate(_carContext));
                    break;
                case AAScreen.GridTemplate:
                    _screenManager.Push(new AAScreenGridTemplate(_carContext));
                    break;
                case AAScreen.Pop:
                    _screenManager.Pop();
                    break;
                default:
                    return;

            }


        }
    }
}

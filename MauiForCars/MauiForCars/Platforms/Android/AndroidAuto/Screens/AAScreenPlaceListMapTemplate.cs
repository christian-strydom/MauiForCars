using AndroidX.Car.App;
using AndroidX.Car.App.Model;
using AndroidX.Core.Graphics.Drawable;
using MauiForCars.Platforms.Android.AndroidAuto.Listeners;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Action = AndroidX.Car.App.Model.Action;

namespace MauiForCars.Platforms.Android.AndroidAuto.Screens
{
    public class AAScreenPlaceListMapTemplate : Screen
    {
        public AAScreenPlaceListMapTemplate(CarContext carContext) : base(carContext)
        {
        }

        public override ITemplate OnGetTemplate()
        {
            var dotnetBotIconCompat = IconCompat.CreateWithResource(CarContext, Resource.Drawable.dotnet_bot);
            var dotnetBotCarIcon = new CarIcon.Builder(dotnetBotIconCompat).Build();

            var actionOne = new Action.Builder()
                .SetIcon(dotnetBotCarIcon)
                 .SetOnClickListener(new ActionOnClickListener(CarContext, $"Action strip item 1 was tapped"))
                .Build();

            var actionTwo = new Action.Builder()
                .SetIcon(dotnetBotCarIcon)
                 .SetOnClickListener(new ActionOnClickListener(CarContext, $"Action strip item 2 was tapped"))
                .Build();

            var actionStrip = new ActionStrip.Builder()
                .AddAction(actionOne)
                .AddAction(actionTwo)
                .Build();

            var placeMarker = new PlaceMarker.Builder()
                .SetIcon(dotnetBotCarIcon,1)
                .Build();

            var place = new Place
                .Builder(CarLocation.Create(-26.04407123041681, 28.018462664396115))
                .SetMarker(placeMarker)
                .Build();

            var row = new Row.Builder()
                .SetTitle("Microsoft Bryanston Office")
                .AddText("Welcome")
                .SetBrowsable(true)
                .SetImage(dotnetBotCarIcon)
                .SetOnClickListener(new ActionOnClickListener(CarContext, "POI Tapped"))
                .Build();

            var placeList = new ItemList.Builder().AddItem(row).Build();

            return new PlaceListMapTemplate.Builder()
                .SetTitle("MAUI Android Auto - Place List Map Template")
                .SetActionStrip(actionStrip)
                .SetHeaderAction(Action.Back)
                .SetAnchor(place)
                .SetLoading(false)
                .SetItemList(placeList)
                .Build();
        }
    }
}

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
    public class AAScreenMenu : Screen
    {
        public AAScreenMenu(CarContext carContext) : base(carContext)
        {
        }

        public override ITemplate OnGetTemplate()
        {
            try
            {
                var dotnetBotIconCompat = IconCompat.CreateWithResource(CarContext, Resource.Drawable.dotnet_bot);
                var dotnetBotCarIcon = new CarIcon.Builder(dotnetBotIconCompat).Build();

                var messageTemplateScreen = new Row.Builder()
                    .SetTitle("Message Template")
                    .SetOnClickListener(new NavigationOnClickListener(CarContext, ScreenManager, Enums.AAScreen.MessageTemplate))
                    .SetImage(dotnetBotCarIcon)
                    .SetBrowsable(true)
                    .Build();

                var paneTemplateScreen = new Row.Builder()
                    .SetTitle("Pane Template")
                    .SetOnClickListener(new NavigationOnClickListener(CarContext, ScreenManager, Enums.AAScreen.PaneTemplate))
                    .SetImage(dotnetBotCarIcon)
                    .SetBrowsable(true)
                    .Build();

                var gridTemplateScreen = new Row.Builder()
                    .SetTitle("Grid Template")
                    .SetOnClickListener(new NavigationOnClickListener(CarContext, ScreenManager, Enums.AAScreen.GridTemplate))
                    .SetImage(dotnetBotCarIcon)
                    .SetBrowsable(true)
                    .Build();

                var itemLsit = new ItemList.Builder()
                    .SetNoItemsMessage("Our MAUI app is running on Android Auto!")
                    .AddItem(messageTemplateScreen)
                    .AddItem(paneTemplateScreen)
                    .AddItem(gridTemplateScreen)
                    .Build();

                return new ListTemplate.Builder()
                    .SetHeaderAction(Action.AppIcon)
                    .SetTitle("MAUI Android Auto - Menu")
                    .SetSingleList(itemLsit)
                    .Build();
            }
            catch (Exception ex)
            {
                throw;
            }

        }
    }
}

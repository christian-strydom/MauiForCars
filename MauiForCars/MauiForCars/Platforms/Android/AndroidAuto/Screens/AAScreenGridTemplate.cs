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
    public class AAScreenGridTemplate : Screen
    {
        public AAScreenGridTemplate(CarContext carContext) : base(carContext)
        {
        }

        public override ITemplate OnGetTemplate()
        {
            try
            {
                var homeGridItemsListBuilder = new ItemList.Builder().SetNoItemsMessage("This is a MAUI app running on Android Auto!");

                var dotnetBotIconCompat = IconCompat.CreateWithResource(CarContext, Resource.Drawable.dotnet_bot);
                var dotnetBotCarIcon = new CarIcon.Builder(dotnetBotIconCompat).Build();

                for (int i = 1; i <= 9; i++)
                {
                    var gridItem = new GridItem.Builder()
                    .SetTitle($"Item {i} Title")
                    .SetText($"Item {i} Text")
                    .SetImage(dotnetBotCarIcon)
                    .SetOnClickListener(new ActionOnClickListener(CarContext, $"Grid item {i} was tapped"))
                    .Build();

                    homeGridItemsListBuilder.AddItem(gridItem);
                }

                var homeGridItems = homeGridItemsListBuilder.Build();

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

                return new GridTemplate.Builder()
                    .SetHeaderAction(Action.Back)
                    .SetTitle("MAUI Android Auto - Grid Template")
                    .SetSingleList(homeGridItems)
                    .SetActionStrip(actionStrip)
                    .Build();
            }
            catch (Exception e)
            {

                throw;
            }
           
        }
    }
}

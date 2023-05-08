using AndroidX.Car.App;
using AndroidX.Car.App.Model;
using AndroidX.Core.Graphics.Drawable;
using MauiForCars.Platforms.Android.AndroidAuto.Listeners;
using Action = AndroidX.Car.App.Model.Action;

namespace MauiForCars.Platforms.Android.AndroidAuto.Screens
{
    public class AAScreenPaneTemplate : Screen
    {
        public AAScreenPaneTemplate(CarContext carContext) : base(carContext)
        {
        }

        public override ITemplate OnGetTemplate()
        {
            try
            {
                var dotnetBotIconCompat = IconCompat.CreateWithResource(CarContext, Resource.Drawable.dotnet_bot);
                var dotnetBotCarIcon = new CarIcon.Builder(dotnetBotIconCompat).Build();

                var paneAction = new Action.Builder()
                    .SetIcon(dotnetBotCarIcon)
                    .SetBackgroundColor(CarColor.Blue)
                    .SetTitle("< Go back")
                    .SetOnClickListener(new NavigationOnClickListener(CarContext, ScreenManager, Enums.AAScreen.Pop))
                    .Build();


                var paneBuilder = new Pane.Builder()
                    .SetImage(dotnetBotCarIcon)
                    .AddAction(paneAction);

                for (var i = 1; i <= 10; i++)
                {
                    var row = new Row.Builder()
                        .SetTitle($"Row {i} title")
                        .SetImage(dotnetBotCarIcon)
                        .AddText($"Row {i} text")
                        .Build();

                    paneBuilder.AddRow(row);
                }

                var pane = paneBuilder.Build();

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

                return new PaneTemplate.Builder(pane)
                    .SetTitle("MAUI Android Auto - Pane Template")
                    .SetActionStrip(actionStrip)
                    .SetHeaderAction(Action.Back)
                    .Build();
            }
            catch (Exception)
            {

                throw;
            }
         
        }
    }
}

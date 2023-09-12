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
    public class AAScreenMessageTemplate : Screen
    {
        public AAScreenMessageTemplate(CarContext carContext) : base(carContext)
        {
        }

        public override ITemplate OnGetTemplate()
        {
            var dotnetBotIconCompat = IconCompat.CreateWithResource(CarContext, Resource.Drawable.dotnet_bot);
            var dotnetBotCarIcon = new CarIcon.Builder(dotnetBotIconCompat).Build();

            var actionOne = new Action.Builder()
                .SetIcon(dotnetBotCarIcon)
                .SetOnClickListener(new ActionOnClickListener(CarContext, "Cancel was tapped"))
                .SetTitle("Cancel")
                .SetBackgroundColor(CarColor.Red)
                .Build();

            var actionTwo = new Action.Builder()
                .SetIcon(dotnetBotCarIcon)
                .SetOnClickListener(ParkedOnlyOnClickListener.Create(new RequestPermissionListener(CarContext, ScreenManager)))
                .SetTitle("Accept")
                .SetBackgroundColor(CarColor.Green)
                .Build();

            return new MessageTemplate.Builder("Please park your vehicle and accept the permissions on your phone to be able to use location services in the app")
                .SetHeaderAction(Action.Back)
                .SetTitle("MAUI Android Auto - Message Template")
                .SetIcon(dotnetBotCarIcon)
                .AddAction(actionOne)
                .AddAction(actionTwo)
                .Build();
        }
    
    }
}

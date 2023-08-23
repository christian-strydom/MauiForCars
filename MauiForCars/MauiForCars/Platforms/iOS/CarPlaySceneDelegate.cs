using System;
using CarPlay;
using Foundation;
using System.Runtime.Versioning;

namespace MauiCarAppDemo2.Platforms.iOS
{
    [SupportedOSPlatform("ios16.0")]
    [UnsupportedOSPlatform("macos")]
    [UnsupportedOSPlatform("maccatalyst")]
    [Register("CarPlaySceneDelegate")]
    public class CarPlaySceneDelegate : CPTemplateApplicationSceneDelegate
    {
        private CPInterfaceController _interfaceController;
        private CPTabBarTemplate _tabBarTemplate;
        private CPListTemplate _listTemplate;
        private CPGridTemplate _gridTemplate;
        private CPPointOfInterestTemplate _poiTemplate;
        private CPInformationTemplate _infoTemplate;
        private nint _selectedPoi;


        public CarPlaySceneDelegate()
        {
            _gridTemplate = BuildGridTemplate();
            _listTemplate = BuildListTemplate();
            _poiTemplate = BuildPoiTemplate();
            _infoTemplate = BuildInfoTemplate();
            _tabBarTemplate = new CPTabBarTemplate(new CPTemplate[] { _gridTemplate, _listTemplate, _poiTemplate, _infoTemplate });
        }

        private CPGridTemplate BuildGridTemplate()
        {
            List<CPGridButton> gridButtons = new List<CPGridButton>();

            for (var i = 0; i < 8; i++)
            {
                gridButtons.Add(
                    new CPGridButton(titleVariants: new string[] { $"Grid item: {i + 1}" },
                    UIKit.UIImage.FromBundle("dotnet_bot"),
                    (action) => { _interfaceController.PresentTemplate(BuildAlertTemplate("Grid item was tapped"), true); })
                    );
            }


            var gridTemplate = new CPGridTemplate("Grid Template", gridButtons.ToArray())
            {
                TabImage = UIKit.UIImage.GetSystemImage("circle.grid.3x3.fill"),
            };

            return gridTemplate;
        }

        private CPListTemplate BuildListTemplate()
        {
            List<ICPListTemplateItem> sectionListItems1 = new List<ICPListTemplateItem>();
            List<ICPListTemplateItem> sectionListItems2 = new List<ICPListTemplateItem>();

            for (var i = 0; i < 4; i++)
            {
                var listButton = new CPListItem(text: $"List item: {i + 1}", detailText: "Section 1 list item", UIKit.UIImage.FromBundle("dotnet_bot"))
                {
                    Handler = (item, block) =>
                    {
                        block.Invoke();
                        _interfaceController.PresentTemplate(BuildAlertTemplate("Section 1 list item was tapped"), true);
                    }
                };
            }

            for (var i = 0; i < 4; i++)
            {
                var listButton = new CPListItem(text: $"List item: {i + 1}", detailText: "Section 2 list item", UIKit.UIImage.FromBundle("dotnet_bot"))
                {
                    Handler = (item, block) =>
                    {
                        block.Invoke();
                        _interfaceController.PresentTemplate(BuildAlertTemplate("Section 2 list item was tapped"), true);
                    }
                };
                sectionListItems2.Add(listButton);
            }

            var listSections = new CPListSection[]
            {
                new CPListSection(sectionListItems1.ToArray(),"Section 1", "Section 1 Index Title"),
                new CPListSection(sectionListItems2.ToArray(),"Section 2", "Section 2 Index Title"),
            };

            var listTemplate = new CPListTemplate("List Template", listSections)
            {
                TabImage = UIKit.UIImage.GetSystemImage("list.dash")
            };

            return listTemplate;
        }

        private CPPointOfInterestTemplate BuildPoiTemplate()
        {
            var pointsOfInterest = new CPPointOfInterest[]
            {
                new CPPointOfInterest(new MapKit.MKMapItem(new MapKit.MKPlacemark(new CoreLocation.CLLocationCoordinate2D(6.640736232446453, 3.332384122105398))),
                "Subcribe Now",
                "For more great tutorials",
                "Hit the like if useful",
                "Thank you!",
                "I hope you find the videos helpful",
                "Many more tutorials coming!",
                UIKit.UIImage.GetSystemImage("video")),

                new CPPointOfInterest(new MapKit.MKMapItem(new MapKit.MKPlacemark(new CoreLocation.CLLocationCoordinate2D(6.645878547828399, 3.325916039566034))),
                "School",
                "For more great tutorials",
                "Hit the like if useful",
                "Thank you!",
                "I hope you find the videos helpful",
                "Many more tutorials coming!",
                UIKit.UIImage.GetSystemImage("book")),

                new CPPointOfInterest(new MapKit.MKMapItem(new MapKit.MKPlacemark(new CoreLocation.CLLocationCoordinate2D(6.6406485855942865, 3.33157652029374))),
                "Shop",
                "For more great tutorials",
                "Hit the like if useful",
                "Thank you!",
                "I hope you find the videos helpful",
                "Many more tutorials coming!",
                UIKit.UIImage.GetSystemImage("cart")),
            };

            var poiTemplate = new CPPointOfInterestTemplate("POI Template", pointsOfInterest, _selectedPoi)
            {
                TabImage = UIKit.UIImage.GetSystemImage("pin"),
            };
            return poiTemplate;
        }

        private CPInformationTemplate BuildInfoTemplate()
        {
            var infoItems = new CPInformationItem[]
            {
                new CPInformationItem("Hi there","Here is your detail message"),
                new CPInformationItem("Groceries","Milk"),
                new CPInformationItem("Groceries","Bread"),
                new CPInformationItem("Groceries","Sugar"),
            };

            var textButtons = new CPTextButton[]
            {
                new CPTextButton("Accept",CPTextButtonStyle.Confirm,(action) => _interfaceController.PresentTemplate(BuildAlertTemplate("Accept was tapped"),true)),
                new CPTextButton("Cancel",CPTextButtonStyle.Cancel,(action) => _interfaceController.PresentTemplate(BuildAlertTemplate("Cancel was tapped"),true)),
            };

            var infoTemplate = new CPInformationTemplate("Info Template", CPInformationTemplateLayout.TwoColumn, infoItems, textButtons)
            {
                TabImage = UIKit.UIImage.GetSystemImage("info.circle.fill"),
            };

            return infoTemplate;
        }

        private CPAlertTemplate BuildAlertTemplate(string message)
        {
            return new CPAlertTemplate(titleVariants: new[] { message },
                new[]
                {
                    new CPAlertAction("Dismiss",CPAlertActionStyle.Default,(action) => _interfaceController.DismissTemplate(true))
                });
        }

        public override void DidConnect(CPTemplateApplicationScene templateApplicationScene, CPInterfaceController interfaceController)
        {
            _interfaceController = interfaceController;
            _interfaceController.SetRootTemplate(_tabBarTemplate, true);
        }

        public override void DidDisconnect(CPTemplateApplicationScene templateApplicationScene, CPInterfaceController interfaceController)
        {
            _interfaceController.Dispose();
        }
    }
}


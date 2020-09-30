using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using ModuleTest.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;

namespace ModuleTest
{
    public class ModuleTestModule : IModule
    {
        private readonly IRegionManager _regionManager;

        public ModuleTestModule(IRegionManager regionManager)
        {
            _regionManager = regionManager;
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            
        }

        public void OnInitialized(IContainerProvider containerProvider)
        {
            _regionManager.RegisterViewWithRegion("ContentRegion", typeof(TestView));
            
            IRegion region = _regionManager.Regions["SecondRegion"];
            var secondView = containerProvider.Resolve<SecondView>();
            region.Add(secondView);

            var thirdView = containerProvider.Resolve<TestView>();
            thirdView.Content = new TextBlock()
            {
                Text = "Hello from ThirdView",
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center
            };

            region.Add(thirdView);
            region.Activate(thirdView);

            region.Activate(secondView);
            region.Deactivate(secondView);
        }
    }
}

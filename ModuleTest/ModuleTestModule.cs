using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using ModuleTest.Controls;
using ModuleTest.ViewModels;
using ModuleTest.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Mvvm;
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
            ViewModelLocationProvider.Register<SecondView, SecondViewModel>();
            //ViewModelLocationProvider.Register<SecondView>(() => new SecondViewModel() {Text = "Hello from SecondFactory"});
        }

        public void OnInitialized(IContainerProvider containerProvider)
        {
            _regionManager.RegisterViewWithRegion("ContentRegion", typeof(TestView));
            
            IRegion region = _regionManager.Regions["SecondRegion"];

            var tabOne = containerProvider.Resolve<SecondView>();
            ((SecondViewModel) tabOne.DataContext).Title = "Tab 1.";
            region.Add(tabOne);

            var tabTwo = containerProvider.Resolve<SecondView>();
            ((SecondViewModel) tabTwo.DataContext).Title = "Tab 2.";
            region.Add(tabTwo);

            var tabThree = containerProvider.Resolve<SecondView>();
            ((SecondViewModel) tabThree.DataContext).Title = "Tab 3.";
            region.Add(tabThree);

            //var thirdView = containerProvider.Resolve<TestView>();
            //thirdView.Content = new TextBlock()
            //{
            //    Text = "Hello from ThirdView",
            //    HorizontalAlignment = HorizontalAlignment.Center,
            //    VerticalAlignment = VerticalAlignment.Center
            //};

            //region.Add(thirdView);
            //region.Activate(thirdView);

            //region.Activate(secondView);
            //region.Deactivate(secondView);
        }
    }
}

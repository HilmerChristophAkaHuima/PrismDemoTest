using System;
using System.Collections.Generic;
using System.Text;
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
        }
    }
}

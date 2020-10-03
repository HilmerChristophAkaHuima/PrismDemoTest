using System;
using System.Collections.Generic;
using System.Text;
using ModuleSendInput.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;

namespace ModuleSendInput
{
    public class ModuleSendInput : IModule
    {
        private readonly IRegionManager _regionManager;

        public ModuleSendInput(IRegionManager regionManager)
        {
            _regionManager = regionManager;
        }
        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            
        }

        public void OnInitialized(IContainerProvider containerProvider)
        {
            _regionManager.RegisterViewWithRegion("SendInputRegion", typeof(SendInputView));
        }
    }
}

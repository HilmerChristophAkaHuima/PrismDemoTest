using ModuleReceiveOutput.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;

namespace ModuleReceiveOutput
{
    public class ModuleReceiveOutput : IModule
    {
        private readonly IRegionManager _regionManager;

        public ModuleReceiveOutput(IRegionManager regionManager)
        {
            _regionManager = regionManager;
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            
        }

        public void OnInitialized(IContainerProvider containerProvider)
        {
            _regionManager.RegisterViewWithRegion("ReceivedOutputRegion", typeof(ReceivedOutputList));
        }
    }
}

using Prism.Ioc;
using PrismUi.Views;
using System.Windows;
using System.Windows.Controls;
using Prism.Modularity;
using Prism.Regions;
using PrismUi.Core.Region;
using ModuleTest;
using PrismUI.Core.Commands;

namespace PrismUi
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IApplicationCommands, ApplicationCommands>();
        }

        protected override void ConfigureRegionAdapterMappings(RegionAdapterMappings regionAdapterMappings)
        {
            base.ConfigureRegionAdapterMappings(regionAdapterMappings);
            regionAdapterMappings.RegisterMapping(typeof(StackPanel), Container.Resolve<StackPanelRegionAdapter>());
        }

        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            base.ConfigureModuleCatalog(moduleCatalog);
            moduleCatalog.AddModule<ModuleTestModule>();
            moduleCatalog.AddModule<ModuleReceiveOutput.ModuleReceiveOutput>();
            moduleCatalog.AddModule<ModuleSendInput.ModuleSendInput>();
        }
    }
}

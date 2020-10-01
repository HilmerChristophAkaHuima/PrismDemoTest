using System;
using System.Collections.Generic;
using System.Text;
using Prism.Commands;

namespace PrismUI.Core.Commands
{
    public interface IApplicationCommands
    {
        CompositeCommand SaveAllCommand { get; }
    }
    public class ApplicationCommands : IApplicationCommands
    {
        public CompositeCommand SaveAllCommand { get; } = new CompositeCommand();
    }
}

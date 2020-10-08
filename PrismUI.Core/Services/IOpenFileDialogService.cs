using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Win32;
using Prism.Services.Dialogs;

namespace PrismUI.Core.Services
{
    public interface IOpenFileDialogService
    {
        public OpenFileDialog OpenFileDialog { get; }
        public bool? ShowDialog();
    }
}

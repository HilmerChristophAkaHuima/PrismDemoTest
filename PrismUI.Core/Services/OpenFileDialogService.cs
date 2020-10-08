using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Win32;

namespace PrismUI.Core.Services
{
    public class OpenFileDialogService : IOpenFileDialogService
    {
        public OpenFileDialog OpenFileDialog { get; private set; } = new OpenFileDialog();
        public bool? ShowDialog()
        {
            return OpenFileDialog.ShowDialog();
        }
    }
}

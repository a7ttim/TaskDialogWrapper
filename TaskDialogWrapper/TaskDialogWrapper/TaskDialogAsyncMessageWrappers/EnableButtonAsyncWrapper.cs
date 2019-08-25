using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskDialogWrapper
{
    /// <summary>
    /// Specifies the wrapper of the button enable message.
    /// </summary>
    class EnableButtonAsyncWrapper : IAsyncMessage
    {
        private int buttonId;
        private bool enableButton;

        public EnableButtonAsyncWrapper(in int buttonId, in bool enableButton)
        {
            this.enableButton = enableButton;
            this.buttonId = buttonId;
        }

        public int Execute(IntPtr handle)
        {
            TaskDialogAsyncMessages.EnableButtonAsync(handle, buttonId, enableButton);
            return 0;
        }
    }
}

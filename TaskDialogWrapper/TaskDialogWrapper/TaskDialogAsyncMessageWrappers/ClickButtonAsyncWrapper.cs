using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskDialogWrapper
{
    class ClickButtonAsyncWrapper : IAsyncMessage
    {
        private int buttonId = 0;

        public ClickButtonAsyncWrapper(in int buttonId)
        {
            this.buttonId = buttonId;
        }

        public int Execute(IntPtr handle)
        {
            return TaskDialogAsyncMessages.ClickButtonAsync(handle, buttonId) ? 0 : 1;
        }
    }
}

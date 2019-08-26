using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskDialogWrapper
{
    /// <summary>
    /// Specifies the wrapper of the user rights elevation required message.
    /// </summary>
    class SetButtonElevationRequiredStateAsyncWrapper : IAsyncMessage
    {
        private int buttonId;
        private bool elevationRequired;

        public SetButtonElevationRequiredStateAsyncWrapper(in int buttonId, in bool elevationRequired)
        {
            this.buttonId = buttonId;
            this.elevationRequired = elevationRequired;
        }

        public int Execute(IntPtr handle)
        {
            TaskDialogAsyncMessages.SetButtonElevationRequiredStateAsync(handle, buttonId, elevationRequired);
            return 0;
        }
    }
}

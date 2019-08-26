using System;

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
            TaskDialogAsyncMessagesWrapper.SetButtonElevationRequiredStateAsync(handle, buttonId, elevationRequired);
            return 0;
        }
    }
}

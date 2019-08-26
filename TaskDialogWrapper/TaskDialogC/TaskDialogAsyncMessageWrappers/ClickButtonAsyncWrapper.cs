using System;

namespace TaskDialogWrapper
{    
    /// <summary>
    /// Specifies the wrapper of the click button message.
    /// </summary>
    class ClickButtonAsyncWrapper : IAsyncMessage
    {
        private int buttonId = 0;

        public ClickButtonAsyncWrapper(in int buttonId)
        {
            this.buttonId = buttonId;
        }

        public int Execute(IntPtr handle)
        {
            return TaskDialogAsyncMessagesWrapper.ClickButtonAsync(handle, buttonId) ? 0 : 1;
        }
    }
}

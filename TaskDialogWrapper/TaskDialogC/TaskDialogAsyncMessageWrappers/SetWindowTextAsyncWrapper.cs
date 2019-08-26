using System;

namespace TaskDialogWrapper
{
    /// <summary>
    /// Specifies the wrapper of the setting window title message.
    /// </summary>
    class SetWindowTextAsyncWrapper : IAsyncMessage
    {
        private string text;

        public SetWindowTextAsyncWrapper(in string text)
        {
            this.text = text;
        }

        public int Execute(IntPtr handle)
        {
            return TaskDialogAsyncMessagesWrapper.SetWindowTextAsync(handle, text) ? 0 : 1;
        }
    }
}

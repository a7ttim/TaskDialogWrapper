using System;

namespace TaskDialogWrapper
{
    /// <summary>
    /// Specifies the wrapper of the setting content message.
    /// </summary>
    class SetContentAsyncWrapper : IAsyncMessage
    {
        private string text;

        public SetContentAsyncWrapper(in string text)
        {
            this.text = text;
        }

        public int Execute(IntPtr handle)
        {
            return TaskDialogAsyncMessagesWrapper.SetContentAsync(handle, text) ? 0 : 1;
        }
    }
}

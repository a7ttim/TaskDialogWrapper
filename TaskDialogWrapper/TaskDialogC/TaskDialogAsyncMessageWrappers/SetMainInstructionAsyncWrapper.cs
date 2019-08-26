using System;

namespace TaskDialogWrapper
{
    /// <summary>
    /// Specifies the wrapper of the setting main instruction message.
    /// </summary>
    class SetMainInstructionAsyncWrapper : IAsyncMessage
    {
        private string text;

        public SetMainInstructionAsyncWrapper(in string text)
        {
            this.text = text;
        }

        public int Execute(IntPtr handle)
        {
            return TaskDialogAsyncMessagesWrapper.SetMainInstructionAsync(handle, text) ? 0 : 1;
        }
    }
}

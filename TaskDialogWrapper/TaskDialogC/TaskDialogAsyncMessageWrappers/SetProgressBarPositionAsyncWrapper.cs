using System;

namespace TaskDialogWrapper
{
    /// <summary>
    /// Specifies the wrapper of the progress bar current position setting message.
    /// </summary>
    class SetProgressBarPositionAsyncWrapper : IAsyncMessage
    {
        private int position;

        public SetProgressBarPositionAsyncWrapper(in int position)
        {
            this.position = position;
        }

        public int Execute(IntPtr handle)
        {
            return TaskDialogAsyncMessagesWrapper.SetProgressBarPositionAsync(handle, position) == 0 ? 1 : 0;
        }
    }
}

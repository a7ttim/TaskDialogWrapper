using System;

namespace TaskDialogWrapper
{
    /// <summary>
    /// Specifies the wrapper of the progress bar range setting message.
    /// </summary>
    class SetProgressBarRangeAsyncWrapper : IAsyncMessage
    {
        private short minRange;
        private short maxRange;

        public SetProgressBarRangeAsyncWrapper(in short minRange, in short maxRange)
        {
            this.minRange = minRange;
            this.maxRange = maxRange;
        }

        public int Execute(IntPtr handle)
        {
            return TaskDialogAsyncMessagesWrapper.SetProgressBarRangeAsync(handle, minRange, maxRange) ? 0 : 1;
        }
    }
}

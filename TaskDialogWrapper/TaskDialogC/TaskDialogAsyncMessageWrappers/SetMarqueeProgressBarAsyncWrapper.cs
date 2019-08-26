using System;

namespace TaskDialogWrapper
{
    /// <summary>
    /// Specifies the wrapper of the progress bar marque mode enabling message.
    /// </summary>
    class SetMarqueeProgressBarAsyncWrapper : IAsyncMessage
    {
        private bool marqueMode;

        public SetMarqueeProgressBarAsyncWrapper(in bool marqueMode)
        {
            this.marqueMode = marqueMode;
        }

        public int Execute(IntPtr handle)
        {
            return TaskDialogAsyncMessagesWrapper.SetMarqueeProgressBarAsync(handle, marqueMode) ? 0 : 1;
        }
    }
}

using System;

namespace TaskDialogWrapper
{
    /// <summary>
    /// Specifies the wrapper of the progress bar marque animation speed setting message.
    /// </summary>
    class SetProgressBarMarqueeAsyncWrapper : IAsyncMessage
    {
        private bool marqueMode;
        private uint animationSpeed;

        public SetProgressBarMarqueeAsyncWrapper(in bool marqueMode, in uint animationSpeed)
        {
            this.marqueMode = marqueMode;
            this.animationSpeed = animationSpeed;
        }

        public int Execute(IntPtr handle)
        {
            TaskDialogAsyncMessagesWrapper.SetProgressBarMarqueeAsync(handle, marqueMode, animationSpeed);
            return 0;
        }
    }
}

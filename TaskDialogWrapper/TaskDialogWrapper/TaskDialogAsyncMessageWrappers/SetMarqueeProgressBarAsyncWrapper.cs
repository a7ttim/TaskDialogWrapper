using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            return TaskDialogAsyncMessages.SetMarqueeProgressBarAsync(handle, marqueMode) ? 0 : 1;
        }
    }
}

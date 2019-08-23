using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskDialogWrapper
{
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

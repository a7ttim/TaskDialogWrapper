using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskDialogWrapper
{
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
            TaskDialogAsyncMessages.SetProgressBarMarqueeAsync(handle, marqueMode, animationSpeed);
            return 0;
        }
    }
}

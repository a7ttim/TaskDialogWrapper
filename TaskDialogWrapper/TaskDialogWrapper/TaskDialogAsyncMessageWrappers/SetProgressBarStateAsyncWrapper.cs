using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskDialogWrapper
{
    /// <summary>
    /// Specifies the wrapper of the progress bar state setting message.
    /// </summary>
    class SetProgressBarStateAsyncWrapper : IAsyncMessage
    {
        private TaskDialogProgressBarState state;

        public SetProgressBarStateAsyncWrapper(in TaskDialogProgressBarState state)
        {
            this.state = state;
        }

        public int Execute(IntPtr handle)
        {
            return TaskDialogAsyncMessages.SetProgressBarStateAsync(handle, state) ? 0 : 1;
        }
    }
}

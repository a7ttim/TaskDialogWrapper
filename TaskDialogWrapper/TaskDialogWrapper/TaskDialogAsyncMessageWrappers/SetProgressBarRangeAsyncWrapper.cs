using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskDialogWrapper
{
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
            return TaskDialogAsyncMessages.SetProgressBarRangeAsync(handle, minRange, maxRange) ? 0 : 1;
        }
    }
}

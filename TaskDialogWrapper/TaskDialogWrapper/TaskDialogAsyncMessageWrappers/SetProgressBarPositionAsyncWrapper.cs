﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskDialogWrapper
{
    class SetProgressBarPositionAsyncWrapper : IAsyncMessage
    {
        private int position;

        public SetProgressBarPositionAsyncWrapper(in int position)
        {
            this.position = position;
        }

        public int Execute(IntPtr handle)
        {
            return TaskDialogAsyncMessages.SetProgressBarPositionAsync(handle, position) == 0 ? 1 : 0;
        }
    }
}

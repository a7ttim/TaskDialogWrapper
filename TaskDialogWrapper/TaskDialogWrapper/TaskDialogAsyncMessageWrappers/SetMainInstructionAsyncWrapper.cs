﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskDialogWrapper
{
    class SetMainInstructionAsyncWrapper : IAsyncMessage
    {
        private string text;

        public SetMainInstructionAsyncWrapper(in string text)
        {
            this.text = text;
        }

        public int Execute(IntPtr handle)
        {
            return TaskDialogAsyncMessages.SetMainInstructionAsync(handle, text) ? 0 : 1;
        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskDialogWrapper
{
    class SetContentAsyncWrapper : IAsyncMessage
    {
        private string text;

        public SetContentAsyncWrapper(in string text)
        {
            this.text = text;
        }

        public int Execute(IntPtr handle)
        {
            return TaskDialogAsyncMessages.SetContentAsync(handle, text) ? 0 : 1;
        }
    }
}

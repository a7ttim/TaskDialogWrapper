﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskDialogWrapper
{
    class SetWindowTextAsyncWrapper : IAsyncMessage
    {
        private string text;

        public SetWindowTextAsyncWrapper(in string text)
        {
            this.text = text;
        }

        public int Execute(IntPtr handle)
        {
            return TaskDialogAsyncMessages.SetWindowTextAsync(handle, text) ? 0 : 1;
        }
    }
}
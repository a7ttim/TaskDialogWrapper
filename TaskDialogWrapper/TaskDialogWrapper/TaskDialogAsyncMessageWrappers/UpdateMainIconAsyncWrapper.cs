﻿using System;
using System.Drawing;

namespace TaskDialogWrapper
{
    class UpdateMainIconAsyncWrapper : IAsyncMessage
    {
        private TaskDialogMainIcon icon;
        private Icon customIcon;

        public UpdateMainIconAsyncWrapper(in TaskDialogMainIcon icon)
        {
            this.icon = icon;
        }

        public UpdateMainIconAsyncWrapper(in Icon customIcon)
        {
            this.customIcon = customIcon;
        }

        public int Execute(IntPtr handle)
        {
            if(customIcon != null)
            {
                TaskDialogAsyncMessages.UpdateMainIconAsync(handle, customIcon);
            }
            else
            {
                TaskDialogAsyncMessages.UpdateMainIconAsync(handle, icon);
            }

            return 0;
        }
    }
}

using System;
using System.Drawing;

namespace TaskDialogWrapper
{
    /// <summary>
    /// Specifies the wrapper of the main icon setting message.
    /// </summary>
    class UpdateMainIconAsyncWrapper : IAsyncMessage
    {
        private TaskDialogIcon icon;
        private Icon customIcon;

        public UpdateMainIconAsyncWrapper(in TaskDialogIcon icon)
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
                TaskDialogAsyncMessagesWrapper.UpdateMainIconAsync(handle, customIcon);
            }
            else
            {
                TaskDialogAsyncMessagesWrapper.UpdateMainIconAsync(handle, icon);
            }

            return 0;
        }
    }
}

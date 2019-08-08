using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskDialogWrapperNamespace;
using Microsoft.WindowsAPICodePack.Dialogs;

namespace Task_dialog
{
    class Program
    {
        static void Main()
        {
            TaskDialogWrapper dialog = new TaskDialogWrapper();

            dialog.WindowTitle = "TaskDialogWrapperExample";
            dialog.MainInstruction = "Click on the \"Add\" or on the \"Decrease\" button";
            dialog.MainIcon = TaskDialogStandardIcon.Information;

            dialog.ProgressBar.Value = 0;
            dialog.ProgressBar.State = TaskDialogProgressBarState.Normal;
            dialog.SetProgressBarEnabled(true);

            var addButton = new TaskDialogButton("addButton", "Add");
            addButton.Click += delegate (object sender, EventArgs args)
            {
                if (dialog.ProgressBar.Value < dialog.ProgressBar.Maximum)
                    dialog.ProgressBar.Value += 10;
            };

            var decreaseButton = new TaskDialogButton("decreaseButton", "Decrease");
            decreaseButton.Click += delegate (object sender, EventArgs args)
            {
                if(dialog.ProgressBar.Value > dialog.ProgressBar.Minimum)
                    dialog.ProgressBar.Value -= 10;
            };

            var closeButton = new TaskDialogButton("closeButton", "Close");
            closeButton.Click += delegate (object sender, EventArgs args)
            {
                dialog.Close();
            };

            dialog.AddCustomButton(addButton);
            dialog.AddCustomButton(decreaseButton);
            dialog.AddCustomButton(closeButton);

            dialog.Show();
        }
    }
}

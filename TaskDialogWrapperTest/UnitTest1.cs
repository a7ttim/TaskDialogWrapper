using System;
using System.Threading.Tasks;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.WindowsAPICodePack.Dialogs;
using TaskDialogWrapperNamespace;

namespace TaskDialogWrapperTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestDialog()
        {
            // Init
            TaskDialogWrapper dialog = new TaskDialogWrapper();

            // Fill
            dialog.WindowTitle = "Title";
            dialog.Content = "Lorem Ipsum";
            dialog.MainIcon = TaskDialogStandardIcon.Information;

            // Close with result
            Task.Delay(200).ContinueWith(t => dialog.Close());
            var res = dialog.Show();
            Assert.AreEqual(TaskDialogResult.Cancel, res);
        }

        [TestMethod]
        public void TestProgressBar()
        {
            // Init
            TaskDialogWrapper dialog = new TaskDialogWrapper();

            // Fill
            dialog.WindowTitle = "Title";
            dialog.Content = "Lorem Ipsum";
            dialog.MainIcon = TaskDialogStandardIcon.Information;
            dialog.Cancelable = true;

            // Must enabled before dialog showing
            dialog.SetProgressBarEnabled(true);

            Assert.AreEqual(0, dialog.ProgressBar.Value);
            dialog.ProgressBar.Value = 50;
            dialog.ProgressBar.State = TaskDialogProgressBarState.Normal;

            dialog.ProgressBar.Value += 10;
            dialog.ProgressBar.Value += 10;
            Assert.AreEqual(70, dialog.ProgressBar.Value);
            dialog.ProgressBar.Value += 10;
            dialog.ProgressBar.Value += 10;
            dialog.ProgressBar.Value += 10;
            Assert.AreEqual(100, dialog.ProgressBar.Value);

            Task.Delay(300).ContinueWith(t =>
            {
                try
                {
                    dialog.ProgressBar.Value += 10;
                }
                catch (ArgumentException)
                {
                    dialog.Close();
                }
            });

            dialog.Show();
        }

        [TestMethod]
        public void TestControls()
        {
            const int numOfButtons = 3;

            // Init
            TaskDialogWrapper dialog = new TaskDialogWrapper();

            // Test controls
            {
                var saveButton = new TaskDialogButton("saveButton", "Save");
                var addButton = new TaskDialogButton("addButton", "Add");
                var closeButton = new TaskDialogButton("closeButton", "Close");

                dialog.AddCustomButton(addButton);
                dialog.AddCustomButton(saveButton);
                dialog.AddCustomButton(closeButton);
            }

            Assert.AreEqual(numOfButtons, dialog.CustomButtons.Count);

            Task.Delay(200).ContinueWith(t =>
            {
                dialog.Close();
            });
            dialog.Show();

            dialog.CommonButton = TaskDialogStandardButtons.Ok;

            Task.Delay(200).ContinueWith(t =>
            {
                dialog.Close();
            });
            dialog.Show();

            Assert.AreEqual(0, dialog.CustomButtons.Count);

            {
                var saveButton = new TaskDialogButton("saveButton", "Save");
                var addButton = new TaskDialogButton("addButton", "Add");
                var closeButton = new TaskDialogButton("closeButton", "Close");

                dialog.AddCustomButton(addButton);
                dialog.AddCustomButton(saveButton);
                dialog.AddCustomButton(closeButton);
            }

            Task.Delay(200).ContinueWith(t =>
            {
                dialog.Close();
            });
            dialog.Show();

            Assert.AreEqual(numOfButtons, dialog.CustomButtons.Count);
        }
    }
}

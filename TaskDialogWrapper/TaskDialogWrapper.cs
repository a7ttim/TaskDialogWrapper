using Microsoft.WindowsAPICodePack.Dialogs;
using System;

namespace TaskDialogWrapperNamespace
{
    /// <summary>
    /// Wrapping TaskDialog from WindowsAPICodePack
    /// </summary>
    public class TaskDialogWrapper
    {
        private TaskDialog __dialog;
        private TaskDialogProgressBar __progressBar;

        public TaskDialogWrapper()
        {
            __dialog = new TaskDialog();
            __progressBar = new TaskDialogProgressBar();
        }

        ~TaskDialogWrapper()
        {
            __dialog.Dispose();
        }

        /// <summary>
        /// Shows TaskDialog with result.
        /// </summary>
        /// <param name="title">Dialog title</param>
        /// <param name="content">Dialog content</param>
        /// <param name="instruction">Dialog instruction</param>
        /// <returns>Dialog result</returns>
        public TaskDialogResult Show(in string title = null, in string content = null, in string instruction = null)
        {
            if (title != null)
            {
                WindowTitle = title;
            }
            if (instruction != null)
            {
                MainInstruction = instruction;
            }
            if (content != null)
            {
                Content = content;
            }
            return __dialog.Show();
        }

        public void Close()
        {
            __dialog.Close();
        }

        /// <summary>
        /// Gets or sets a value that contains the WindowTitle.
        /// </summary>
        public string WindowTitle
        {
            get
            {
                return __dialog.Caption;
            }
            set
            {
                __dialog.Caption = value;
            }
        }

        /// <summary>
        /// Gets or sets a value that contains the MainInstruction.
        /// </summary>
        public string MainInstruction
        {
            get
            {
                return __dialog.InstructionText;
            }
            set
            {
                __dialog.InstructionText = value;
            }
        }

        /// <summary>
        /// Gets or sets a value that contains the Content.
        /// </summary>
        public string Content
        {
            get
            {
                return __dialog.Text;
            }
            set
            {
                __dialog.Text = value;
            }
        }

        /// <summary>
        /// Gets or sets a value that contains the MainIcon.
        /// </summary>
        public TaskDialogStandardIcon MainIcon
        {
            get
            {
                return __dialog.Icon;
            }
            set
            {
                __dialog.Icon = value;
            }
        }

        /// <summary>
        /// Gets the ProgressBar.
        /// </summary>
        public TaskDialogProgressBar ProgressBar
        {
            get
            {
                return __progressBar;
            }
        }

        /// <summary>
        /// Set the ProgressBar enabled.
        /// </summary>
        /// <param name="enable"></param>
        public void SetProgressBarEnabled(in bool enable = true)
        {
            if (enable)
            {
                if (__dialog.ProgressBar == __progressBar)
                {
                    return;
                }
                __dialog.ProgressBar = __progressBar;
                __progressBar.HostingDialog = __dialog;
            }
            else
            {
                if (__dialog.ProgressBar != null)
                {
                    __dialog.ProgressBar = null;
                    __progressBar.HostingDialog = null;
                }
            }
        }

        /// <summary>
        /// Gets the CustomButtons.
        /// </summary>
        public DialogControlCollection<TaskDialogControl> CustomButtons
        {
            get
            {
                return __dialog.Controls;
            }
        }

        /// <summary>
        /// Adds TaskDialogButton to a Dialog
        /// </summary>
        /// <param name="button">Button that can be hosted in a dialog</param>
        public void AddCustomButton(in TaskDialogButton button)
        {
            __dialog.StandardButtons = TaskDialogStandardButtons.None;
            __dialog.Controls.Add(button);
        }

        /// <summary>
        /// Clears TaskDialogButtons from a Dialog
        /// </summary>
        public void ClearCustomButtons()
        {
            __dialog.Controls.Clear();
        }

        /// <summary>
        /// Gets or sets a value that contains the CommonButton.
        /// </summary>
        public TaskDialogStandardButtons CommonButton
        {
            get
            {
                return __dialog.StandardButtons;
            }
            set
            {
                __dialog.Controls.Clear();
                __dialog.StandardButtons = value;
            }
        }

        /// <summary>
        /// Gets or sets a value that contains the Cancelable.
        /// </summary>
        public bool Cancelable
        {
            get
            {
                return __dialog.Cancelable;
            }
            set
            {
                __dialog.Cancelable = value;
            }
        }

        /// <summary>
        /// Not implemented.
        /// </summary>
        public TaskDialogStartupLocation StartupLocation
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        /// <summary>
        /// Not implemented.
        /// </summary>
        public string FooterText
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        /// <summary>
        /// Not implemented.
        /// </summary>
        public string FooterCheckBoxText
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        /// <summary>
        /// Not implemented.
        /// </summary>
        public TaskDialogStandardIcon FooterIcon
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }
        
        /// <summary>
        /// Not implemented.
        /// </summary>
        public string DetailsExpandedLabel
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }
        
        /// <summary>
        /// Not implemented.
        /// </summary>
        public string DetailsCollapsedLabel
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        /// <summary>
        /// Not implemented.
        /// </summary>
        public bool DetailsExpanded
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }
    }
}
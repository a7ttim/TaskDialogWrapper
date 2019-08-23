using System;
using System.Windows.Forms;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace TaskDialogWrapper
{
    public class TaskDialog
    {
        public delegate int TaskDialogMessagesCallbackDelegate(in IntPtr handle);
        public delegate int TaskDialogButtonClickedCallbackDelegate(in int buttonId);
        public delegate int TaskDialogHyperLinkClickedCallbackDelegate(in string hyperLink);
        public delegate int TaskDialogTimerTickCallbackDelegate(in uint timer);

        private IntPtr hwndParent;

        private string windowTitle;

        private string mainInstruction;

        private string content;

        private TaskDialogMainIcon mainIcon;

        private Icon customMainIcon;

        private TaskDialogProgressBar progressBar;

        /// <summary>
        /// The flags passed to TaskDialogIndirect.
        /// </summary>
        private TaskDialogFlags flags;

        private TaskDialogCommonButtons commonButtons;

        private TaskDialogButton[] customButtons;
                       
        private TaskDialogMessagesCallbackDelegate messagesCallbackDelegate;
        private TaskDialogButtonClickedCallbackDelegate buttonClickedCallbackDelegate;
        private TaskDialogHyperLinkClickedCallbackDelegate hyperLinkClickedCallbackDelegate;
        private TaskDialogTimerTickCallbackDelegate timerTickCallbackDelegate;
        private Queue<IAsyncMessage> messageQueue;

        /// <summary>
        /// Specifies the width of the Task Dialog’s client area in DLU’s. If 0, Task Dialog will calculate the ideal width.
        /// </summary>
        private uint width;

        /// <summary>
        /// The window title in header of the dialog.
        /// </summary>
        public string WindowTitle
        {
            get => windowTitle;
            set => windowTitle = value;
        }

        public void SetWindowTitleInstructionAsync(in string windowTitle)
        {
            this.windowTitle = windowTitle;
            messageQueue.Enqueue(new SetWindowTextAsyncWrapper(windowTitle));
        }

        /// <summary>
        /// The main instruction displayed in the dialog box.
        /// </summary>
        public string MainInstruction
        {
            get => mainInstruction;
            set => mainInstruction = value;
        }

        public void SetMainInstructionAsync(in string mainInstruction)
        {
            this.mainInstruction = mainInstruction;
            messageQueue.Enqueue(new SetMainInstructionAsyncWrapper(mainInstruction));
        }

        /// <summary>
        /// The content displayed in the dialog box.
        /// </summary>
        public string Content
        {
            get => content;
            set => content = value;
        }

        public void SetContentAsync(in string content)
        {
            this.content = content;
            messageQueue.Enqueue(new SetContentAsyncWrapper(content));
        }

        /// <summary>
        /// The main icon displayed in the dialog box.
        /// </summary>
        public TaskDialogMainIcon MainIcon
        {
            get => mainIcon;
            set => mainIcon = value;
        }

        public void SetMainIconAsync(in TaskDialogMainIcon mainIcon)
        {
            this.mainIcon = mainIcon;
            messageQueue.Enqueue(new UpdateMainIconAsyncWrapper(mainIcon));
        }

        public Icon CustomMainIcon
        {
            get => customMainIcon;
            set => customMainIcon = value;
        }

        public void SetMainIconAsync(in Icon customMainIcon)
        {
            this.customMainIcon = customMainIcon;
            messageQueue.Enqueue(new UpdateMainIconAsyncWrapper(customMainIcon));
        }


        /// <summary>
        /// Specifies the push buttons displayed in the dialog box.
        /// </summary>
        public TaskDialogCommonButtons CommonButtons
        {
            get => commonButtons;
            set => commonButtons = value;
        }

        /// <summary>
        /// Specifies the custom push buttons to display in the dialog.
        /// </summary>
        [SuppressMessage("Microsoft.Performance", "CA1819:PropertiesShouldNotReturnArrays")] // Returns a reference, not a copy.
        public TaskDialogButton[] CustomButtons
        {
            get => this.customButtons;
            set => this.customButtons = value;
        }

        public void EnableButtonAsync(int buttonId, bool enabled)
        {
            messageQueue.Enqueue(new EnableButtonAsyncWrapper(buttonId, !enabled));
        }

        public void SetButtonElevationRequiredStateAsync(int buttonId, bool elevationRequired)
        {
            messageQueue.Enqueue(new SetButtonElevationRequiredStateAsyncWrapper(buttonId, elevationRequired));
        }

        /// <summary>
        /// The progress bar displayed in the dialog box.
        /// </summary>
        public ITaskDialogProgressBar ProgressBar
        {
            get
            {
                if (progressBar == null)
                {
                    progressBar = new TaskDialogProgressBar(messageQueue);
                }
                return progressBar;
            }
        }

        /// <summary>
        /// ***
        /// </summary>
        public bool ProgressBarEnabled
        {
            get
            {
                return flags.HasFlag(TaskDialogFlags.ShowProgressBar);
            }
            set
            {
                if (value)
                {
                    flags |= TaskDialogFlags.ShowProgressBar;
                }
                else
                {
                    flags &= ~TaskDialogFlags.ShowProgressBar;
                }
            }
        }

        /// <summary>
        /// ***
        /// </summary>
        public bool HyperlinksBarEnabled
        {
            get
            {
                return flags.HasFlag(TaskDialogFlags.EnableHyperLinks);
            }
            set
            {
                if (value)
                {
                    flags |= TaskDialogFlags.EnableHyperLinks;
                }
                else
                {
                    flags &= ~TaskDialogFlags.EnableHyperLinks;
                }
            }
        }

        /// <summary>
        /// ***
        /// </summary>
        public bool Cancellable
        {
            get
            {
                return this.flags.HasFlag(TaskDialogFlags.AllowDialogCancellation);
            }
            set
            {
                if (value)
                {
                    this.flags |= TaskDialogFlags.AllowDialogCancellation;
                }
                else
                {
                    CanBeMinimized = false;
                    this.flags &= ~TaskDialogFlags.AllowDialogCancellation;
                }
            }
        }

        /// <summary>
        /// ***
        /// </summary>
        public bool CanBeMinimized
        {
            get
            {
                return this.flags.HasFlag(TaskDialogFlags.CanBeMinimized);
            }
            set
            {
                if (value)
                {
                    Cancellable = true;
                    this.flags |= TaskDialogFlags.CanBeMinimized;
                }
                else
                {
                    this.flags &= ~TaskDialogFlags.CanBeMinimized;
                }
            }
        }

        /// <summary>
        /// ***
        /// </summary>
        public bool ExpandedByDefault
        {
            get
            {
                return this.flags.HasFlag(TaskDialogFlags.ExpandedByDefault);
            }
            set
            {
                if (value)
                {
                    this.flags |= TaskDialogFlags.ExpandedByDefault;
                }
                else
                {
                    this.flags &= ~TaskDialogFlags.ExpandedByDefault;
                }
            }
        }
        
        public uint Width
        {
            get => width;
            set => width = value;
        }
        public TaskDialogButtonClickedCallbackDelegate ButtonClickedCallbackDelegate
        {
            get => buttonClickedCallbackDelegate;
            set => buttonClickedCallbackDelegate = value;
        }

        public TaskDialogHyperLinkClickedCallbackDelegate HyperLinkClickedCallbackDelegate
        {
            get => hyperLinkClickedCallbackDelegate;
            set => hyperLinkClickedCallbackDelegate = value;
        }

        public TaskDialogTimerTickCallbackDelegate TimerTickCallbackDelegate
        {
            get => timerTickCallbackDelegate;
            set => timerTickCallbackDelegate = value;
        }

        public void ClickButton(in int buttonId)
        {
            messageQueue.Enqueue(new ClickButtonAsyncWrapper(buttonId));
        }

        public TaskDialog()
        {
            hwndParent = IntPtr.Zero;
            windowTitle = null;
            mainInstruction = null;
            content = null;
            commonButtons = 0;
            mainIcon = TaskDialogMainIcon.None;
            customMainIcon = null;
            customButtons = new TaskDialogButton[0];
            flags = TaskDialogFlags.CallbackTimer;
            messagesCallbackDelegate = TaskCircle;
            progressBar = null;
            width = 0;
            messageQueue = new Queue<IAsyncMessage>();
        }

        public int Show()
        {
            TaskDialogConfig dialogConfig = new TaskDialogConfig();
            int result = 0;

            try
            {
                dialogConfig.cbSize = (uint)Marshal.SizeOf(typeof(TaskDialogConfig));
                dialogConfig.hwndParent = hwndParent;
                dialogConfig.hInstance = IntPtr.Zero;
                dialogConfig.cxWidth = width;
                dialogConfig.dwCommonButtons = commonButtons;
                dialogConfig.dwFlags = flags;
                dialogConfig.pszWindowTitle = windowTitle;
                dialogConfig.pszMainInstruction = mainInstruction;
                dialogConfig.pszContent = content;

                if (this.customMainIcon != null)
                {
                    dialogConfig.dwFlags |= TaskDialogFlags.UseHIconMain;
                    dialogConfig.MainIcon = this.customMainIcon.Handle;
                }
                else
                {
                    dialogConfig.MainIcon = (IntPtr)this.mainIcon;
                }
                
                if (customButtons.Length > 0)
                {
                    int size = Marshal.SizeOf(typeof(TaskDialogButton));
                    dialogConfig.pButtons = Marshal.AllocHGlobal(size * (int)customButtons.Length);
                    foreach (TaskDialogButton button in customButtons)
                    {
                        unsafe
                        {
                            // Warning! Manual pointer operations.
                            byte* pointer = (byte*)dialogConfig.pButtons;
                            Marshal.StructureToPtr(button, (IntPtr)(pointer + (size * dialogConfig.cButtons++)), false);
                        }
                    }
                }

                dialogConfig.pfCallback = new TaskDialogCallbackC(this.TaskDialogCallback);

                TaskDialogC.TaskDialogIndirect(ref dialogConfig, out _, out result, out _);
            }
            /*
            catch(Exception exception)
            {
                throw exception;
            }*/
            finally
            {
                if (dialogConfig.pButtons != IntPtr.Zero)
                {
                    int size = Marshal.SizeOf(typeof(TaskDialogButton));
                    int i = 0;
                    foreach (TaskDialogButton button in customButtons)
                    {
                        unsafe
                        {
                            // Warning! Manual pointer operations.
                            byte* pointer = (byte*)dialogConfig.pButtons;
                            Marshal.DestroyStructure((IntPtr)(pointer + (size * i++)), typeof(TaskDialogButton));
                        }
                    }

                    Marshal.FreeHGlobal(dialogConfig.pButtons);
                }
            }

            return result;
        }

        private int TaskCircle(in IntPtr handle)
        {
            while(messageQueue.Count > 0)
            {
                messageQueue.Dequeue().Execute(handle);
            }
            return 0;
        }

        /// <summary>
        /// The callback for async messages to the Task Dialog and notifications from that.
        /// </summary>
        private int TaskDialogCallback([In] IntPtr hwnd, [In] uint msg, [In] UIntPtr wparam, [In] IntPtr lparam, [In] IntPtr refData)
        {
            TaskDialogNotifications notification = (TaskDialogNotifications)msg;
            switch (notification)
            {
                case TaskDialogNotifications.ButtonClicked:
                    {
                        if (buttonClickedCallbackDelegate != null)
                        {
                            return buttonClickedCallbackDelegate((int)wparam);
                        }
                        break;
                    }
                case TaskDialogNotifications.HyperLinkClicked:
                    {
                        if (hyperLinkClickedCallbackDelegate != null)
                        {
                            return hyperLinkClickedCallbackDelegate(Marshal.PtrToStringUni(lparam));
                        }
                        break;
                    }
                case TaskDialogNotifications.Timer:
                    {
                        if (timerTickCallbackDelegate != null)
                        {
                            return timerTickCallbackDelegate((uint)wparam);
                        }
                        break;
                    }
            }

            TaskDialogMessagesCallbackDelegate messagesCallbackDelegate = this.messagesCallbackDelegate;
            if (messagesCallbackDelegate != null)
            {
                return messagesCallbackDelegate(hwnd);
            }
            return 0;
        }
    }
}

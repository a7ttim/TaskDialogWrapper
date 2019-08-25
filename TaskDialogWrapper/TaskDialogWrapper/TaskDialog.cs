using System;
using System.Windows.Forms;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace TaskDialogWrapper
{
    /// <summary>
    /// Delegate for messages to the Task Dialog.
    /// </summary>
    public class TaskDialog
    {        
        /// <summary>
        /// Declaration of a delegate for messages to the Task Dialog.
        /// </summary>
        public delegate int TaskDialogMessagesCallbackDelegate(in IntPtr handle);
        
        /// <summary>
        /// Declaration of a delegate for buttons notifications from the Task Dialog.
        /// </summary>
        public delegate int TaskDialogButtonClickedCallbackDelegate(in int buttonId);   
        
        /// <summary>
        /// Declaration of a delegate for hyperlinks notifications from the Task Dialog.
        /// </summary>
        public delegate int TaskDialogHyperLinkClickedCallbackDelegate(in string hyperLink);
        
        /// <summary>
        /// Declaration of a delegate for timer tick notifications from the Task Dialog.
        /// </summary>
        public delegate int TaskDialogTimerTickCallbackDelegate(in uint timer);
        
        /// <summary>
        /// Specifies the parent window handler for the Task Dialog.
        /// </summary>
        private IntPtr hwndParent;

        /// <summary>
        /// Specifies the window title of the Task Dialog.
        /// </summary>
        private string windowTitle;

        /// <summary>
        /// Specifies the window main instruction of the Task Dialog.
        /// </summary>
        private string mainInstruction;

        /// <summary>
        /// The content of the Task Dialog.
        /// </summary>
        private string content;

        /// <summary>
        /// Specifies the window main icon of the Task Dialog.
        /// </summary>
        private TaskDialogMainIcon mainIcon;

        /// <summary>
        /// Specifies the window custom main icon of the Task Dialog.
        /// </summary>
        private Icon customMainIcon;

        /// <summary>
        /// Specifies the progress bar of the Task Dialog.
        /// </summary>
        private TaskDialogProgressBar progressBar;

        /// <summary>
        /// Specifies flags which will be passed to TaskDialogIndirect.
        /// </summary>
        private TaskDialogFlags flags;

        /// <summary>
        /// Specifies the common buttons flag of the Task Dialog.
        /// </summary>
        private TaskDialogCommonButtons commonButtons;

        /// <summary>
        /// Specifies custom buttons of the Task Dialog.
        /// </summary>
        private TaskDialogButton[] customButtons;
                
        /// <summary>
        /// Specifies the delegate for messages to the Task Dialog.
        /// </summary>
        private TaskDialogMessagesCallbackDelegate messagesCallbackDelegate;        
        
        /// <summary>
        /// Specifies the delegate for buttons notifications from the Task Dialog.
        /// </summary>
        private TaskDialogButtonClickedCallbackDelegate buttonClickedCallbackDelegate;
        
        /// <summary>
        /// Specifies the delegate for hyperlinks notifications from the Task Dialog.
        /// </summary>
        private TaskDialogHyperLinkClickedCallbackDelegate hyperLinkClickedCallbackDelegate;
        
        /// <summary>
        /// Specifies the delegate for timer tick notifications from the Task Dialog.
        /// </summary>
        private TaskDialogTimerTickCallbackDelegate timerTickCallbackDelegate;
        
        /// <summary>
        /// Specifies the message queue for async messages to the Task Dialog in loop.
        /// </summary>
        private Queue<IAsyncMessage> messageQueue;

        /// <summary>
        /// Specifies the width of the Task Dialog.
        /// </summary>
        private uint width;

        /// <summary>
        /// Specifies the window title displayed in header of the Task Dialog.
        /// </summary>
        public string WindowTitle
        {
            get => windowTitle;
            set => windowTitle = value;
        }

        /// <summary>
        /// Sets the window title in header of the Task Dialog asynchronously.
        /// </summary>
        public void SetWindowTitleInstructionAsync(in string windowTitle)
        {
            this.windowTitle = windowTitle;
            messageQueue.Enqueue(new SetWindowTextAsyncWrapper(windowTitle));
        }

        /// <summary>
        /// Specifies the main instruction displayed in the Task Dialog box.
        /// </summary>
        public string MainInstruction
        {
            get => mainInstruction;
            set => mainInstruction = value;
        }

        /// <summary>
        /// Sets the main instruction in the Task Dialog box asynchronously.
        /// </summary>
        public void SetMainInstructionAsync(in string mainInstruction)
        {
            this.mainInstruction = mainInstruction;
            messageQueue.Enqueue(new SetMainInstructionAsyncWrapper(mainInstruction));
        }

        /// <summary>
        /// Specifies the content displayed in the Task Dialog box.
        /// </summary>
        public string Content
        {
            get => content;
            set => content = value;
        }

        /// <summary>
        /// Sets the content in the Task Dialog box asynchronously.
        /// </summary>
        public void SetContentAsync(in string content)
        {
            this.content = content;
            messageQueue.Enqueue(new SetContentAsyncWrapper(content));
        }

        /// <summary>
        /// Specifies the main icon displayed in the Task Dialog box.
        /// </summary>
        public TaskDialogMainIcon MainIcon
        {
            get => mainIcon;
            set => mainIcon = value;
        }

        /// <summary>
        /// Sets the main icon in the dialog box asynchronously.
        /// </summary>
        public void SetMainIconAsync(in TaskDialogMainIcon mainIcon)
        {
            this.mainIcon = mainIcon;
            messageQueue.Enqueue(new UpdateMainIconAsyncWrapper(mainIcon));
        }

        /// <summary>
        /// Specifies the custom main icon displayed in the Task Dialog box.
        /// </summary>
        public Icon CustomMainIcon
        {
            get => customMainIcon;
            set => customMainIcon = value;
        }

        /// <summary>
        /// Sets the main icon in the Task Dialog box asynchronously.
        /// </summary>
        public void SetMainIconAsync(in Icon customMainIcon)
        {
            this.customMainIcon = customMainIcon;
            messageQueue.Enqueue(new UpdateMainIconAsyncWrapper(customMainIcon));
        }


        /// <summary>
        /// Specifies the push buttons displayed in the Task Dialog box.
        /// </summary>
        public TaskDialogCommonButtons CommonButtons
        {
            get => commonButtons;
            set => commonButtons = value;
        }

        /// <summary>
        /// Specifies the custom push buttons to display in the Task Dialog.
        /// </summary>
        [SuppressMessage("Microsoft.Performance", "CA1819:PropertiesShouldNotReturnArrays")] // Returns a reference, not a copy.
        public TaskDialogButton[] CustomButtons
        {
            get => this.customButtons;
            set => this.customButtons = value;
        }

        /// <summary>
        /// Enables the custom push buttons in the Task Dialog asynchronously.
        /// </summary>
        public void EnableButtonAsync(int buttonId, bool enabled)
        {
            messageQueue.Enqueue(new EnableButtonAsyncWrapper(buttonId, !enabled));
        }

        /// <summary>
        /// Requires elevated user rights for the button by id.
        /// </summary>
        public void SetButtonElevationRequiredStateAsync(int buttonId, bool elevationRequired)
        {
            messageQueue.Enqueue(new SetButtonElevationRequiredStateAsyncWrapper(buttonId, elevationRequired));
        }

        /// <summary>
        /// Specifies the progress bar displayed in the Task Dialog box.
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
        /// Enables the progress bar in the Task Dialog box.
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
        /// Enables hyperlinks in the content in the Task Dialog box.
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
        /// Sets the Task Dialog cancellable. 
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
        /// Sets the Task Dialog minimizable. 
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
        /// Sets the Task Dialog expanded by default. 
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
        
        /// <summary>
        /// Specifies the width of the Task Dialog.
        /// </summary>
        public uint Width
        {
            get => width;
            set => width = value;
        }
        
        /// <summary>
        /// Specifies the delegate for buttons notifications from the Task Dialog.
        /// </summary>
        public TaskDialogButtonClickedCallbackDelegate ButtonClickedCallbackDelegate
        {
            get => buttonClickedCallbackDelegate;
            set => buttonClickedCallbackDelegate = value;
        }

        /// <summary>
        /// Specifies the delegate for hyperlinks notifications from the Task Dialog.
        /// </summary>
        public TaskDialogHyperLinkClickedCallbackDelegate HyperLinkClickedCallbackDelegate
        {
            get => hyperLinkClickedCallbackDelegate;
            set => hyperLinkClickedCallbackDelegate = value;
        }

        /// <summary>
        /// Specifies the delegate for timer tick notifications from the Task Dialog.
        /// </summary>
        public TaskDialogTimerTickCallbackDelegate TimerTickCallbackDelegate
        {
            get => timerTickCallbackDelegate;
            set => timerTickCallbackDelegate = value;
        }

        /// <summary>
        /// Clicks the button in the Task Dialog asynchronously.
        /// </summary>
        public void ClickButton(in int buttonId)
        {
            messageQueue.Enqueue(new ClickButtonAsyncWrapper(buttonId));
        }

        /// <summary>
        /// The Task Dialog constructor.
        /// </summary>
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

        /// <summary>
        /// Assembles the Task Dialog Config then displays the Task Dialog using the Task Dialog Indirect function.
        /// </summary>
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
            catch(Exception exception)
            {
                throw exception;
            }
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

        /// <summary>
        /// The callback for the messages queue to the Task Dialog.
        /// </summary>
        private int TaskCircle(in IntPtr handle)
        {
            while(messageQueue.Count > 0)
            {
                messageQueue.Dequeue().Execute(handle);
            }
            return 0;
        }

        /// <summary>
        /// The callback for async messages to the Task Dialog and notifications from the above.
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

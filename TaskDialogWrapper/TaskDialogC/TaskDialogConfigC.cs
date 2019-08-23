using System;
using System.Runtime.InteropServices;
using System.Diagnostics.CodeAnalysis;

namespace TaskDialogWrapper
{
    /// <summary>
    /// TaskDialogConfig taken from commctl.h.
    /// https://docs.microsoft.com/ru-ru/windows/win32/api/commctrl/ns-commctrl-taskdialogconfig
    /// </summary>
    [SuppressMessage("Microsoft.Design", "CA1049:TypesThatOwnNativeResourcesShouldBeDisposable", 
        Justification = "Native resources are all owned by managed code and should not be disposed here.")]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode, Pack = 1)]
    internal struct TaskDialogConfig
    {
        /// <summary>
        /// Size of the structure in bytes.
        /// </summary>
        public uint cbSize;

        /// <summary>
        /// Parent window handle.
        /// </summary>
        // Managed code owns actual resource. Passed to native in syncronous call. No lifetime issues.
        [SuppressMessage("Microsoft.Reliability", "CA2006:UseSafeHandleToEncapsulateNativeResources")] 
        public IntPtr hwndParent;

        /// <summary>
        /// Module instance handle for resources.
        /// </summary>
        // Managed code owns actual resource. Passed to native in syncronous call. No lifetime issues.
        [SuppressMessage("Microsoft.Reliability", "CA2006:UseSafeHandleToEncapsulateNativeResources")]
        public IntPtr hInstance;

        /// <summary>
        /// Flags.
        /// </summary>
        // TASKDIALOG_FLAGS (TDF_XXX) flags
        public TaskDialogFlags dwFlags;

        /// <summary>
        /// Bit flags for commonly used buttons.
        /// </summary>
        // TASKDIALOG_COMMON_BUTTON (TDCBF_XXX) flags
        public TaskDialogCommonButtons dwCommonButtons;

        /// <summary>
        /// Window title.
        /// </summary>
        [MarshalAs(UnmanagedType.LPWStr)]
        // string or MAKEINTRESOURCE()
        public string pszWindowTitle;

        /// <summary>
        /// The Main icon. Overloaded member. Can be string, a handle, a special value or a resource ID.
        /// </summary>
        // Managed code owns actual resource. Passed to native in syncronous call. No lifetime issues.
        [SuppressMessage("Microsoft.Reliability", "CA2006:UseSafeHandleToEncapsulateNativeResources")]
        public IntPtr MainIcon;

        /// <summary>
        /// Main Instruction.
        /// </summary>
        [MarshalAs(UnmanagedType.LPWStr)]
        public string pszMainInstruction;

        /// <summary>
        /// Content.
        /// </summary>
        [MarshalAs(UnmanagedType.LPWStr)]
        public string pszContent;

        /// <summary>
        /// Count of custom Buttons.
        /// </summary>
        public uint cButtons;

        /// <summary>
        /// Array of custom buttons.
        /// </summary>
        // Managed code owns actual resource. Passed to native in syncronous call. No lifetime issues.
        [SuppressMessage("Microsoft.Reliability", "CA2006:UseSafeHandleToEncapsulateNativeResources")]
        public IntPtr pButtons;

        /// <summary>
        /// ID of default button.
        /// </summary>
        public int nDefaultButton;

        /// <summary>
        /// Count of radio Buttons.
        /// </summary>
        public uint cRadioButtons;

        /// <summary>
        /// Array of radio buttons.
        /// </summary>
        // Managed code owns actual resource. Passed to native in syncronous call. No lifetime issues.
        [SuppressMessage("Microsoft.Reliability", "CA2006:UseSafeHandleToEncapsulateNativeResources")]
        public IntPtr pRadioButtons;

        /// <summary>
        /// ID of default radio button.
        /// </summary>
        public int nDefaultRadioButton;

        /// <summary>
        /// Text for verification check box. often "Don't ask be again".
        /// </summary>
        [MarshalAs(UnmanagedType.LPWStr)]
        public string pszVerificationText;

        /// <summary>
        /// Expanded TDI_INFORMATION.
        /// </summary>
        [MarshalAs(UnmanagedType.LPWStr)]
        public string pszExpandedInformation;

        /// <summary>
        /// Text for expanded control.
        /// </summary>
        [MarshalAs(UnmanagedType.LPWStr)]
        public string pszExpandedControlText;

        /// <summary>
        /// Text for expanded control.
        /// </summary>
        [MarshalAs(UnmanagedType.LPWStr)]
        public string pszCollapsedControlText;

        /// <summary>
        /// Icon for the footer. An overloaded member link MainIcon.
        /// </summary>
        // Managed code owns actual resource. Passed to native in syncronous call. No lifetime issues.
        [SuppressMessage("Microsoft.Reliability", "CA2006:UseSafeHandleToEncapsulateNativeResources")]
        public IntPtr FooterIcon;

        /// <summary>
        /// Footer Text.
        /// </summary>
        [MarshalAs(UnmanagedType.LPWStr)]
        public string pszFooter;

        /// <summary>
        /// Function pointer for callback.
        /// </summary>
        public TaskDialogCallbackC pfCallback;

        /// <summary>
        /// Data that will be passed to the call back.
        /// </summary>
        // Managed code owns actual resource. Passed to native in syncronous call. No lifetime issues.
        [SuppressMessage("Microsoft.Reliability", "CA2006:UseSafeHandleToEncapsulateNativeResources")]
        public IntPtr lpCallbackData;

        /// <summary>
        /// Width of the Task Dialog's area in DLU's.
        /// </summary>
        public uint cxWidth;
    }
}

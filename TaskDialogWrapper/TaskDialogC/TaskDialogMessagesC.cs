using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Diagnostics.CodeAnalysis;

namespace TaskDialogWrapper
{
    /// <summary>
    /// Functions for TaskDialogMessages.
    /// https://docs.microsoft.com/en-us/windows/win32/controls/bumper-task-dialogs-reference-messages
    /// </summary>
    internal static class TaskDialogMessageFunctions
    {
        /// <summary>
        /// WM_USER taken from WinUser.h.
        /// https://docs.microsoft.com/en-us/windows/win32/winmsg/wm-user
        /// </summary>
        public const uint WM_USER = 0x0400;

        /// <summary>
        /// Win32 SendMessage.
        /// </summary>
        /// <param name="hWnd">Window handle to send to.</param>
        /// <param name="Msg">The windows message to send.</param>
        /// <param name="wParam">Specifies additional message-specific information.</param>
        /// <param name="lParam">Specifies additional message-specific information.</param>
        /// <returns>The return value specifies the result of the message processing; it depends on the message sent.</returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Interoperability", "CA1400:PInvokeEntryPointsShouldExist")]
        [DllImport("user32.dll")]
        public static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);

        /// <summary>
        /// Win32 SendMessage taken from WinUser.h.
        /// https://docs.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-sendmessage
        /// </summary>
        /// <param name="hWnd">Window handle to send to.</param>
        /// <param name="Msg">The windows message to send.</param>
        /// <param name="wParam">Specifies additional message-specific information.</param>
        /// <param name="lParam">Specifies additional message-specific information as a string.</param>
        /// <returns>The return value specifies the result of the message processing; it depends on the message sent.</returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Interoperability", "CA1400:PInvokeEntryPointsShouldExist")]
        [DllImport("user32.dll", EntryPoint = "SendMessage")]
        public static extern IntPtr SendMessageWithString(IntPtr hWnd, uint Msg, IntPtr wParam, [MarshalAs(UnmanagedType.LPWStr)] string lParam);
    }

    /// <summary>
    /// TaskDialogMessages taken from CommCtrl.h.
    /// https://docs.microsoft.com/en-us/windows/win32/controls/bumper-task-dialogs-reference-messages
    /// </summary>
    internal enum TaskDialogMessages : uint
    {
        /// <summary>
        /// Navigate page.
        /// </summary>
        NavigatePage = TaskDialogMessageFunctions.WM_USER + 101,

        /// <summary>
        /// Click button.
        /// </summary>
        // wParam = Button ID
        ClickButton = TaskDialogMessageFunctions.WM_USER + 102,

        /// <summary>
        /// Set Progress bar to be marquee mode.
        /// </summary>
        // wParam = 0 (nonMarque) wParam != 0 (Marquee)
        SetMarqueeProgressBar = TaskDialogMessageFunctions.WM_USER + 103,

        /// <summary>
        /// Set Progress bar state.
        /// </summary>
        // wParam = new progress state
        SetProgressBarState = TaskDialogMessageFunctions.WM_USER + 104,

        /// <summary>
        /// Set progress bar range.
        /// </summary>
        // lParam = MAKELPARAM(nMinRange, nMaxRange)
        SetProgressBarRange = TaskDialogMessageFunctions.WM_USER + 105,

        /// <summary>
        /// Set progress bar position.
        /// </summary>
        // wParam = new position
        SetProgressBarPosition = TaskDialogMessageFunctions.WM_USER + 106,

        /// <summary>
        /// Set progress bar marquee (animation).
        /// </summary>
        // wParam = 0 (stop marquee), wParam != 0 (start marquee), lparam = speed (milliseconds between repaints)
        SetProgressBarMarquee = TaskDialogMessageFunctions.WM_USER + 107,

        /// <summary>
        /// Set a text element of the Task Dialog.
        /// </summary>
        // wParam = element (TASKDIALOG_ELEMENTS), lParam = new element text (LPCWSTR)
        SetElementText = TaskDialogMessageFunctions.WM_USER + 108,

        /// <summary>
        /// Click a radio button.
        /// </summary>
        // wParam = Radio Button ID
        ClickRadioButton = TaskDialogMessageFunctions.WM_USER + 110,

        /// <summary>
        /// Enable or disable a button.
        /// </summary>
        // lParam = 0 (disable), lParam != 0 (enable), wParam = Button ID
        EnableButton = TaskDialogMessageFunctions.WM_USER + 111,

        /// <summary>
        /// Enable or disable a radio button.
        /// </summary>
        // lParam = 0 (disable), lParam != 0 (enable), wParam = Radio Button ID
        EnableRadioButton = TaskDialogMessageFunctions.WM_USER + 112,

        /// <summary>
        /// Check or uncheck the verfication checkbox.
        /// </summary>
        // wParam = 0 (unchecked), 1 (checked), lParam = 1 (set key focus)
        ClickVerification = TaskDialogMessageFunctions.WM_USER + 113,

        /// <summary>
        /// Update the text of an element (no effect if origially set as null).
        /// </summary>
        // wParam = element (TASKDIALOG_ELEMENTS), lParam = new element text (LPCWSTR)
        UpdateElementText = TaskDialogMessageFunctions.WM_USER + 114,

        /// <summary>
        /// Designate whether a given Task Dialog button or command link should have a User Account Control (UAC) shield icon.
        /// </summary>
        // wParam = Button ID, lParam = 0 (elevation not required), lParam != 0 (elevation required)
        SetButtonElevationRequiredState = TaskDialogMessageFunctions.WM_USER + 115,

        /// <summary>
        /// Refreshes the icon of the task dialog.
        /// </summary>
        // wParam = icon element (TASKDIALOG_ICON_ELEMENTS), lParam = new icon (hIcon if TDF_USE_HICON_* was set, PCWSTR otherwise)
        UpdateIcon = TaskDialogMessageFunctions.WM_USER + 116 
    }
}

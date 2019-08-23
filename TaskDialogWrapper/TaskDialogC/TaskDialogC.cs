using System;
using System.Runtime.InteropServices;

namespace TaskDialogWrapper
{
    internal static class TaskDialogC
    {
        /// <summary>
        /// TaskDialogIndirect taken from commctl.h
        /// https://docs.microsoft.com/ru-ru/windows/win32/api/commctrl/nf-commctrl-taskdialogindirect
        /// </summary>
        /// <param name="pTaskConfig">All the parameters about the Task Dialog to Show.</param>
        /// <param name="pnButton">The push button pressed.</param>
        /// <param name="pnRadioButton">The radio button that was selected.</param>
        /// <param name="pfVerificationFlagChecked">The state of the verification checkbox on dismiss of the Task Dialog.</param>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Interoperability", "CA1400:PInvokeEntryPointsShouldExist", Justification = "Declaration is valid and works fine.")]
        [DllImport("ComCtl32", CharSet = CharSet.Unicode, EntryPoint = "TaskDialogIndirect", ExactSpelling = true, PreserveSig = false)]
        internal static extern void TaskDialogIndirect(
            [In] ref TaskDialogConfig pTaskConfig,
            [Out] out int pnButton,
            [Out] out int pnRadioButton,
            [Out] out bool pfVerificationFlagChecked);

        /// <summary>
        /// Changes the text of the specified window's title bar (if it has one).
        /// </summary>
        /// <param name="hwnd">A handle to the window or control whose text is to be changed.</param>
        /// <param name="lpString">The new title or control text. </param>
        /// <returns>
        /// If the function succeeds, the return value is nonzero.
        /// If the function fails, the return value is zero.
        /// To get extended error information, call GetLastError. 
        /// </returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Interoperability", "CA1400:PInvokeEntryPointsShouldExist")]
        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        internal static extern bool SetWindowText(IntPtr hwnd, String lpString);
    }
}

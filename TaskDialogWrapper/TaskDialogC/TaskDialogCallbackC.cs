using System;
using System.Runtime.InteropServices;

namespace TaskDialogWrapper
{
    /// <summary>
    /// The signature of the callback that receives messages from the Task Dialog when various events occur.
    /// https://docs.microsoft.com/en-us/windows/win32/api/commctrl/nc-commctrl-pftaskdialogcallback
    /// </summary>
    /// <param name="hwnd">The window handle of the </param>
    /// <param name="msg">The message being passed.</param>
    /// <param name="wParam">wParam which is interpreted differently depending on the message.</param>
    /// <param name="lParam">wParam which is interpreted differently depending on the message.</param>
    /// <param name="refData">The refrence data that was set to TaskDialog.CallbackData.</param>
    /// <returns>A HRESULT value. The return value is specific to the message being processed. </returns>
    internal delegate int TaskDialogCallbackC([In] IntPtr hwnd, [In] uint msg, [In] UIntPtr wParam, [In] IntPtr lParam, [In] IntPtr refData);
}

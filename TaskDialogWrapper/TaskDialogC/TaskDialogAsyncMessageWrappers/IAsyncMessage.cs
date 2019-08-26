using System;

namespace TaskDialogWrapper
{
    /// <summary>
    /// A interface for messages to the Task Dialog.
    /// </summary>
    internal interface IAsyncMessage
    {
        /// <summary>
        /// Specifies the operation signature that will be called and executed in the Task Dialog callback.
        /// </summary>
        int Execute(IntPtr handle);
    }
}

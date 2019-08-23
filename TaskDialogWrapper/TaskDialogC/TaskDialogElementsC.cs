namespace TaskDialogWrapper
{
    /// <summary>
    /// TASKDIALOG_ELEMENTS taken from CommCtrl.h
    /// https://docs.microsoft.com/en-us/windows/win32/controls/tdm-update-element-text
    /// </summary>
    internal enum TaskDialogElements
    {
        /// <summary>
        /// The content element.
        /// </summary>
        Content = 0x0,

        /// <summary>
        /// Expanded TDI_INFORMATION.
        /// </summary>
        ExpandedInformation = 0x1,

        /// <summary>
        /// Footer.
        /// </summary>
        Footer = 0x2,

        /// <summary>
        /// Main Instructions
        /// </summary>
        MainInstruction = 0x3
    }
}

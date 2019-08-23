namespace TaskDialogWrapper
{
    /// <summary>
    /// TaskDialogNotifications taken from commctrl.h.
    /// https://docs.microsoft.com/en-us/windows/win32/controls/bumper-task-dialogs-reference-notifications
    /// </summary>
    internal enum TaskDialogNotifications : uint
    {
        /// <summary>
        /// Indicates that the Task Dialog has been created.
        /// </summary>
        Created = 0,

        /// <summary>
        /// Indicates that navigation has occurred.
        /// </summary>
        Navigated = 1,

        /// <summary>
        /// Indicates that a button has been selected. The command ID of
        /// the button is specified by wParam.
        /// </summary>
        // wParam = Button ID
        ButtonClicked = 2,

        /// <summary>
        /// Indicates that a hyperlink has been selected. A pointer to the
        /// link text is specified by lParam.
        /// </summary>
        // lParam = (LPCWSTR)pszHREF
        HyperLinkClicked = 3,

        /// <summary>
        /// Indicates that the Task Dialog timer has fired. The total
        /// elapsed time is specified by wParam. You can update the
        /// progress bar by sending a TDM_SET_PROGRESS_BAR_POS message to
        /// the window specified by the hwnd parameter.
        /// </summary>
        // wParam = Milliseconds since dialog created or timer reset
        Timer = 4,

        /// <summary>
        /// Indicates that the Task Dialog has been destroyed.
        /// </summary>
        Destroyed = 5,

        /// <summary>
        /// Indicates that a radio button has been selected. The command
        /// ID of the radio button is specified by wParam.
        /// </summary>
        // wParam = Radio Button ID
        RadioButtonClicked = 6,

        /// <summary>
        /// Indicates that the Task Dialog has been created but has not
        /// been displayed yet.
        /// </summary>
        DialogConstructed = 7,

        /// <summary>
        /// Indicates that the Task Dialog verification check box has been
        /// selected.
        /// </summary>
        // wParam = 1 if checkbox checked, 0 if not, lParam is unused and always 0
        VerificationClicked = 8,

        /// <summary>
        /// Indicates that the F1 key has been pressed while the Task
        /// Dialog has focus.
        /// </summary>
        Help = 9,

        /// <summary>
        /// Indicates that the exando button has been selected.
        /// </summary>
        // wParam = 0 (dialog is now collapsed), wParam != 0 (dialog is now expanded)
        ExpandButtonClicked = 10
    }
}

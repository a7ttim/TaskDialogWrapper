using System;

namespace TaskDialogWrapper
{
    /// <summary>
    /// TaskDialogFlags taken from CommCtrl.h.
    /// https://docs.microsoft.com/en-us/windows/win32/api/commctrl/ns-commctrl-taskdialogconfig
    /// </summary>
    [Flags]
    internal enum TaskDialogFlags
    {
        /// <summary>
        /// Enable hyperlinks.
        /// </summary>
        EnableHyperLinks = 0x0001,

        /// <summary>
        /// Use icon handle for main icon.
        /// </summary>
        UseHIconMain = 0x0002,

        /// <summary>
        /// Use icon handle for footer icon.
        /// </summary>
        UseHIconFooter = 0x0004,

        /// <summary>
        /// Allow dialog to be cancelled, even if there is no cancel button.
        /// </summary>
        AllowDialogCancellation = 0x0008,

        /// <summary>
        /// Use command links rather than buttons.
        /// </summary>
        UseCommandLinks = 0x0010,

        /// <summary>
        /// Use command links with no icons rather than buttons.
        /// </summary>
        UseCommandLinksNoIcon = 0x0020,

        /// <summary>
        /// Show expanded info in the footer area.
        /// </summary>
        ExpandFooterArea = 0x0040,

        /// <summary>
        /// Expand by default.
        /// </summary>
        ExpandedByDefault = 0x0080,

        /// <summary>
        /// Start with verification flag already checked.
        /// </summary>
        VerificationFlagChecked = 0x0100,

        /// <summary>
        /// Show a progress bar.
        /// </summary>
        ShowProgressBar = 0x0200,

        /// <summary>
        /// Show a marquee progress bar.
        /// </summary>
        ShowMarqueeProgressBar = 0x0400,

        /// <summary>
        /// Callback every 200 milliseconds.
        /// </summary>
        CallbackTimer = 0x0800,

        /// <summary>
        /// Center the dialog on the owner window rather than the monitor.
        /// </summary>
        PositionRelativeToWindow = 0x1000,

        /// <summary>
        /// Right to Left Layout.
        /// </summary>
        RightToLeftLayout = 0x2000,

        /// <summary>
        /// No default radio button.
        /// </summary>
        NoDefaultRadionButton = 0x4000,

        /// <summary>
        /// Task Dialog can be minimized.
        /// </summary>
        CanBeMinimized = 0x8000
    }
}

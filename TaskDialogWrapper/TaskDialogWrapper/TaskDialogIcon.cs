using System.Diagnostics.CodeAnalysis;

namespace TaskDialogWrapper
{
    /// <summary>
    /// The System icons taken from CommCtrl.h.
    /// https://docs.microsoft.com/en-us/windows/win32/api/commctrl/nf-commctrl-taskdialog
    /// </summary>
    [SuppressMessage("Microsoft.Design", "CA1028:EnumStorageShouldBeInt32")]
    public enum TaskDialogIcon : uint
    {
        /// <summary>
        /// No Icon.
        /// </summary>
        None = 0,

        /// <summary>
        /// System warning icon.
        /// </summary>
        Warning = 0xFFFF,

        /// <summary>
        /// System error icon.
        /// </summary>
        Error = 0xFFFE,

        /// <summary>
        /// System information icon.
        /// </summary>
        Information = 0xFFFD,

        /// <summary>
        /// System shield icon.
        /// </summary>
        Shield = 0xFFFC,
    }

    /// <summary>
    /// TaskDialogIconElements taken from CommCtrl.h
    /// https://docs.microsoft.com/en-us/windows/win32/controls/tdm-update-icon
    /// </summary>
    [SuppressMessage("Microsoft.Design", "CA1028:EnumStorageShouldBeInt32")]
    internal enum TaskDialogIconElements
    {
        /// <summary>
        /// Main instruction icon.
        /// </summary>
        IconMain = 0,

        /// <summary>
        /// Footer icon.
        /// </summary>
        IconFooter = 1
    }
}

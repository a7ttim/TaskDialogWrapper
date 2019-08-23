using System.Diagnostics.CodeAnalysis;

namespace TaskDialogWrapper
{
    /// <summary>
    /// Progress bar state.
    /// </summary>
    // Comes from CommCtrl.h PBST_* values which don't have a zero.
    [SuppressMessage("Microsoft.Design", "CA1008:EnumsShouldHaveZeroValue")]
    public enum TaskDialogProgressBarState
    {
        /// <summary>
        /// Normal.
        /// </summary>
        Normal = 1,

        /// <summary>
        /// Error state.
        /// </summary>
        Error = 2,

        /// <summary>
        /// Paused state.
        /// </summary>
        Paused = 3
    }
}

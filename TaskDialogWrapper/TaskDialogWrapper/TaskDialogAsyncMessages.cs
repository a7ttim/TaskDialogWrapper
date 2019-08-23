using System;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Windows.Forms;

namespace TaskDialogWrapper
{

    /// <summary>
    /// Async messages to Task Dialog window. Provides several methods for acting on the active TaskDialog.
    /// </summary>
    internal static class TaskDialogAsyncMessages
    {
        /// <summary>
        /// Simulate the action of a button click in the TaskDialog. This can be a DialogResult value 
        /// or the ButtonID set on a TasDialogButton set on TaskDialog.Buttons.
        /// </summary>
        /// <param name="buttonId">Indicates the button ID to be selected.</param>
        /// <returns>If the function succeeds the return value is true.</returns>
        public static bool ClickButtonAsync(IntPtr handle, int buttonId)
        {
            // TDM_CLICK_BUTTON                    = WM_USER+102, // wParam = Button ID
            return TaskDialogMessageFunctions.SendMessage(
                handle,
                (uint)TaskDialogMessages.ClickButton,
                (IntPtr)buttonId,
                IntPtr.Zero) != IntPtr.Zero;
        }

        public static bool SetWindowTextAsync(IntPtr handle, string text)
        {
            return TaskDialogC.SetWindowText(
                handle,
                text
                );
        }

        /// <summary>
        /// Used to indicate whether the hosted progress bar should be displayed in marquee mode or not.
        /// </summary>
        /// <param name="marquee">
        /// Specifies whether the progress bar sbould be shown in Marquee mode.
        /// A value of true turns on Marquee mode.
        /// </param>
        /// <returns>If the function succeeds the return value is true.</returns>
        public static bool SetMarqueeProgressBarAsync(IntPtr handle, bool marquee)
        {
            // TDM_SET_MARQUEE_PROGRESS_BAR        = WM_USER+103, // wParam = 0 (nonMarque) wParam != 0 (Marquee)
            return TaskDialogMessageFunctions.SendMessage(
                handle,
                (uint)TaskDialogMessages.SetMarqueeProgressBar,
                (marquee ? (IntPtr)1 : IntPtr.Zero),
                IntPtr.Zero) != IntPtr.Zero;

            // Future: get more detailed error from and throw.
        }

        /// <summary>
        /// Sets the state of the progress bar.
        /// </summary>
        /// <param name="newState">The state to set the progress bar.</param>
        /// <returns>If the function succeeds the return value is true.</returns>
        public static bool SetProgressBarStateAsync(IntPtr handle, TaskDialogProgressBarState newState)
        {
            // TDM_SET_PROGRESS_BAR_STATE          = WM_USER+104, // wParam = new progress state
            return TaskDialogMessageFunctions.SendMessage(
                handle,
                (uint)TaskDialogMessages.SetProgressBarState,
                (IntPtr)newState,
                IntPtr.Zero) != IntPtr.Zero;

            // Future: get more detailed error from and throw.
        }

        /// <summary>
        /// Set the minimum and maximum values for the hosted progress bar.
        /// </summary>
        /// <param name="minRange">Minimum range value. By default, the minimum value is zero.</param>
        /// <param name="maxRange">Maximum range value.  By default, the maximum value is 100.</param>
        /// <returns>If the function succeeds the return value is true.</returns>
        public static bool SetProgressBarRangeAsync(IntPtr handle, Int16 minRange, Int16 maxRange)
        {
            IntPtr lparam = (IntPtr)((((Int32)minRange) & 0xffff) | ((((Int32)maxRange) & 0xffff) << 16));
            return TaskDialogMessageFunctions.SendMessage(
                handle,
                (uint)TaskDialogMessages.SetProgressBarRange,
                IntPtr.Zero,
                lparam) != IntPtr.Zero;

            // Return value is actually prior range.
        }

        /// <summary>
        /// Set the current position for a progress bar.
        /// </summary>
        /// <param name="newPosition">The new position.</param>
        /// <returns>Returns the previous value if successful, or zero otherwise.</returns>
        public static int SetProgressBarPositionAsync(IntPtr handle, int newPosition)
        {
            // TDM_SET_PROGRESS_BAR_POS            = WM_USER+106, // wParam = new position
            return (int)TaskDialogMessageFunctions.SendMessage(
                handle,
                (uint)TaskDialogMessages.SetProgressBarPosition,
                (IntPtr)newPosition,
                IntPtr.Zero);
        }

        /// <summary>
        /// Sets the animation state of the Marquee Progress Bar.
        /// </summary>
        /// <param name="startMarquee">true starts the marquee animation and false stops it.</param>
        /// <param name="speed">The time in milliseconds between refreshes.</param>
        public static void SetProgressBarMarqueeAsync(IntPtr handle, bool startMarquee, uint speed)
        {
            // TDM_SET_PROGRESS_BAR_MARQUEE        = WM_USER+107, // wParam = 0 (stop marquee), wParam != 0 (start marquee), lparam = speed (milliseconds between repaints)
            TaskDialogMessageFunctions.SendMessage(
                handle,
                (uint)TaskDialogMessages.SetProgressBarMarquee,
                (startMarquee ? new IntPtr(1) : IntPtr.Zero),
                (IntPtr)speed);
        }

        /// <summary>
        /// Updates the content text.
        /// </summary>
        /// <param name="content">The new value.</param>
        /// <returns>If the function succeeds the return value is true.</returns>
        public static bool SetContentAsync(IntPtr handle, string content)
        {
            // TDE_CONTENT,
            // TDM_SET_ELEMENT_TEXT                = WM_USER+108  // wParam = element (TASKDIALOG_ELEMENTS), lParam = new element text (LPCWSTR)
            return TaskDialogMessageFunctions.SendMessageWithString(
                handle,
                (uint)TaskDialogMessages.SetElementText,
                (IntPtr)TaskDialogElements.Content,
                content) != IntPtr.Zero;
        }


        /// <summary>
        /// Updates the Main Instruction.
        /// </summary>
        /// <param name="mainInstruction">The new value.</param>
        /// <returns>If the function succeeds the return value is true.</returns>
        public static bool SetMainInstructionAsync(IntPtr handle, string mainInstruction)
        {
            // TDE_MAIN_INSTRUCTION
            // TDM_SET_ELEMENT_TEXT                = WM_USER+108  // wParam = element (TASKDIALOG_ELEMENTS), lParam = new element text (LPCWSTR)
            return TaskDialogMessageFunctions.SendMessageWithString(
                handle,
                (uint)TaskDialogMessages.SetElementText,
                (IntPtr)TaskDialogElements.MainInstruction,
                mainInstruction) != IntPtr.Zero;
        }

        /// <summary>
        /// Enable or disable a button in the TaskDialog. 
        /// The passed buttonID is the ButtonID set on a TaskDialogButton set on TaskDialog.Buttons
        /// or a common button ID.
        /// </summary>
        /// <param name="buttonId">Indicates the button ID to be enabled or diabled.</param>
        /// <param name="enable">Enambe the button if true. Disable the button if false.</param>
        public static void EnableButtonAsync(IntPtr handle, int buttonId, bool enable)
        {
            // TDM_ENABLE_BUTTON = WM_USER+111, // lParam = 0 (disable), lParam != 0 (enable), wParam = Button ID
            TaskDialogMessageFunctions.SendMessage(
                handle,
                (uint)TaskDialogMessages.EnableButton,
                (IntPtr)buttonId,
                (IntPtr)(enable ? 0 : 1));
        }

        /// <summary>
        /// Updates the content text.
        /// </summary>
        /// <param name="content">The new value.</param>
        public static void UpdateContentAsync(IntPtr handle, string content)
        {
            // TDE_CONTENT,
            // TDM_UPDATE_ELEMENT_TEXT             = WM_USER+114, // wParam = element (TASKDIALOG_ELEMENTS), lParam = new element text (LPCWSTR)
            TaskDialogMessageFunctions.SendMessageWithString(
                handle,
                (uint)TaskDialogMessages.UpdateElementText,
                (IntPtr)TaskDialogElements.Content,
                content);
        }

        /// <summary>
        /// Updates the Main Instruction.
        /// </summary>
        /// <param name="mainInstruction">The new value.</param>
        public static void UpdateMainInstructionAsync(IntPtr handle, string mainInstruction)
        {
            // TDE_MAIN_INSTRUCTION
            // TDM_UPDATE_ELEMENT_TEXT             = WM_USER+114, // wParam = element (TASKDIALOG_ELEMENTS), lParam = new element text (LPCWSTR)
            TaskDialogMessageFunctions.SendMessageWithString(
                handle,
                (uint)TaskDialogMessages.UpdateElementText,
                (IntPtr)TaskDialogElements.MainInstruction,
                mainInstruction);
        }

        /// <summary>
        /// Designate whether a given Task Dialog button or command link should have a User Account Control (UAC) shield icon.
        /// </summary>
        /// <param name="buttonId">ID of the push button or command link to be updated.</param>
        /// <param name="elevationRequired">False to designate that the action invoked by the button does not require elevation;
        /// true to designate that the action does require elevation.</param>
        public static void SetButtonElevationRequiredStateAsync(IntPtr handle, int buttonId, bool elevationRequired)
        {
            // TDM_SET_BUTTON_ELEVATION_REQUIRED_STATE = WM_USER+115, // wParam = Button ID, lParam = 0 (elevation not required), lParam != 0 (elevation required)
            TaskDialogMessageFunctions.SendMessage(
                handle,
                (uint)TaskDialogMessages.SetButtonElevationRequiredState,
                (IntPtr)buttonId,
                (IntPtr)(elevationRequired ? new IntPtr(1) : IntPtr.Zero));
        }

        /// <summary>
        /// Updates the main instruction icon. Note the type (standard via enum or
        /// custom via Icon type) must be used when upating the icon.
        /// </summary>
        /// <param name="icon">Task Dialog standard icon.</param>
        public static void UpdateMainIconAsync(IntPtr handle, TaskDialogMainIcon icon)
        {
            // TDM_UPDATE_ICON = WM_USER+116  // wParam = icon element (TASKDIALOG_ICON_ELEMENTS), lParam = new icon (hIcon if TDF_USE_HICON_* was set, PCWSTR otherwise)
            TaskDialogMessageFunctions.SendMessage(
                handle,
                (uint)TaskDialogMessages.UpdateIcon,
                (IntPtr)TaskDialogIconElements.IconMain,
                (IntPtr)icon);
        }

        /// <summary>
        /// Updates the main instruction icon. Note the type (standard via enum or
        /// custom via Icon type) must be used when updating the icon.
        /// </summary>
        /// <param name="icon">The icon to set.</param>
        public static void UpdateMainIconAsync(IntPtr handle, Icon icon)
        {
            // TDM_UPDATE_ICON = WM_USER+116  // wParam = icon element (TASKDIALOG_ICON_ELEMENTS), lParam = new icon (hIcon if TDF_USE_HICON_* was set, PCWSTR otherwise)
            TaskDialogMessageFunctions.SendMessage(
                handle,
                (uint)TaskDialogMessages.UpdateIcon,
                (IntPtr)TaskDialogIconElements.IconMain,
                (icon == null ? IntPtr.Zero : icon.Handle));
        }
    }
}

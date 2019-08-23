using System.Runtime.InteropServices;
using System.Diagnostics.CodeAnalysis;

namespace TaskDialogWrapper
{
    /// <summary>
    /// A custom button for the TaskDialog.
    /// </summary>
    [SuppressMessage("Microsoft.Performance", "CA1815:OverrideEqualsAndOperatorEqualsOnValueTypes")] 
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode, Pack = 1)]
    public struct TaskDialogButton
    {
        /// <summary>
        /// The ID of the button. This value is returned by TaskDialog.Show when the button is clicked.
        /// </summary>
        private int buttonId;

        /// <summary>
        /// The string that appears on the button.
        /// </summary>
        [MarshalAs(UnmanagedType.LPWStr)]
        private string buttonText;

        /// <summary>
        /// Initialize the custom button.
        /// </summary>
        /// <param name="id">The ID of the button. This value is returned by TaskDialog.Show when
        /// the button is clicked. Typically this will be a value in the DialogResult enum.</param>
        /// <param name="text">The string that appears on the button.</param>
        public TaskDialogButton(int id, string text)
        {
            this.buttonId = id;
            this.buttonText = text;
        }

        /// <summary>
        /// The ID of the button. This value is returned by TaskDialog.Show when the button is clicked.
        /// </summary>
        public int ButtonId
        {
            get
            {
                return this.buttonId;
            }
            set
            {
                this.buttonId = value;
            }
        }

        /// <summary>
        /// The string that appears on the button.
        /// </summary>
        public string ButtonText
        {
            get
            {
                return this.buttonText;
            }
            set
            {
                this.buttonText = value;
            }
        }
    }
}

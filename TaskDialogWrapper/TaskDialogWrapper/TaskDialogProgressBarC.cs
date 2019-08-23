using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskDialogWrapper
{
    /// <summary>
    /// A custom progress bar for the TaskDialog.
    /// </summary>
    class TaskDialogProgressBar : ITaskDialogProgressBar
    {
        /// <summary>
        /// ***
        /// </summary>
        private TaskDialogProgressBarState state;

        /// <summary>
        /// Minimal position.
        /// </summary>
        private int position;

        /// <summary>
        /// Minimal value.
        /// </summary>
        private short minRange;

        /// <summary>
        /// Maximal position.
        /// </summary>
        private short maxRange;

        /// <summary>
        /// Marquee mode.
        /// </summary>
        private bool marqueMode;

        /// <summary>
        /// Speed of the animation.
        /// </summary>
        private uint animationSpeed;

        /// <summary>
        /// ***
        /// </summary>
        private Queue<IAsyncMessage> queue;

        public TaskDialogProgressBar(
            in Queue<IAsyncMessage> queue,
            in short minRange = 0,
            in short maxRange = 100, 
            in TaskDialogProgressBarState state = TaskDialogProgressBarState.Normal,
            in bool marqueMode = false)
        {
            this.queue = queue;
            this.minRange = minRange;
            this.maxRange = maxRange;
            this.position = 0;
            this.state = state;
            this.marqueMode = marqueMode;
            this.animationSpeed = 20;
        }

        public TaskDialogProgressBarState StateAsync
        {
            get => state;
            set
            {
                state = value;
                queue.Enqueue(new SetProgressBarStateAsyncWrapper(state));
            }
        }

        public int PositionAsync
        {
            get => position;
            set
            {
                position = value;
                queue.Enqueue(new SetProgressBarPositionAsyncWrapper(position));
            }
        }
        public short MinRangeAsync
        {
            get => minRange;
            set
            {
                minRange = value;
                queue.Enqueue(new SetProgressBarRangeAsyncWrapper(minRange, maxRange));
            }
        }

        public short MaxRangeAsync
        {
            get => maxRange;
            set
            {
                maxRange = value;
                queue.Enqueue(new SetProgressBarRangeAsyncWrapper(minRange, maxRange));
            }
        }

        public bool MarqueModeAsync
        {
            get => marqueMode;
            set
            {
                marqueMode = value;
                queue.Enqueue(new SetMarqueeProgressBarAsyncWrapper(marqueMode));
            }
        }

        public uint AnimationSpeedAsync
        {
            get => animationSpeed;
            set
            {
                animationSpeed = value;
                queue.Enqueue(new SetProgressBarMarqueeAsyncWrapper(marqueMode, animationSpeed));
            }
        }
    }
}

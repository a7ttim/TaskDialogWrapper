using System.Collections.Generic;

namespace TaskDialogWrapper
{
    /// <summary>
    /// A custom progress bar for the Task Dialog.
    /// </summary>
    class TaskDialogProgressBar : ITaskDialogProgressBar
    {
        /// <summary>
        /// Specifies the state of the Task Dialog Progress Bar.
        /// </summary>
        private TaskDialogProgressBarState state;

        /// <summary>
        /// Specifies the current position of the Task Dialog Progress Bar.
        /// </summary>
        private int position;

        /// <summary
        /// Specifies the minimal position of the Task Dialog Progress Bar.
        /// </summary>
        private short minRange;

        /// <summary>
        /// Specifies the maximal position of the Task Dialog Progress Bar.
        /// </summary>
        private short maxRange;

        /// <summary>
        /// Enables the marquee mode of the Task Dialog Progress Bar.
        /// </summary>
        private bool marqueMode;

        /// <summary>
        /// Specifies the animation speed of the Task Dialog Progress Bar.
        /// </summary>
        private uint animationSpeed;

        /// <summary>
        /// Specifies the messages queue of the Task Dialog.
        /// </summary>
        private Queue<IAsyncMessage> queue;

        /// <summary>
        /// The Task Dialog Progress Bar constructor.
        /// </summary>
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

        /// <summary>
        /// Specifies the state of the Task Dialog Progress Bar and sets it asynchronously.
        /// </summary>
        public TaskDialogProgressBarState StateAsync
        {
            get => state;
            set
            {
                state = value;
                queue.Enqueue(new SetProgressBarStateAsyncWrapper(state));
            }
        }

        /// <summary>
        /// Specifies the current position of the Task Dialog Progress Bar and sets it asynchronously.
        /// </summary>
        public int PositionAsync
        {
            get => position;
            set
            {
                position = value;
                queue.Enqueue(new SetProgressBarPositionAsyncWrapper(position));
            }
        }
        
        /// <summary>
        /// Specifies the minimal position of the Task Dialog Progress Bar and sets it asynchronously.
        /// </summary>
        public short MinRangeAsync
        {
            get => minRange;
            set
            {
                minRange = value;
                queue.Enqueue(new SetProgressBarRangeAsyncWrapper(minRange, maxRange));
            }
        }

        /// <summary>
        /// Specifies the maximal position of the Task Dialog Progress Bar and sets it asynchronously.
        /// </summary>
        public short MaxRangeAsync
        {
            get => maxRange;
            set
            {
                maxRange = value;
                queue.Enqueue(new SetProgressBarRangeAsyncWrapper(minRange, maxRange));
            }
        }

        /// <summary>
        /// Enables the marquee mode of the Task Dialog Progress Bar and sets it asynchronously.
        /// </summary>
        public bool MarqueModeAsync
        {
            get => marqueMode;
            set
            {
                marqueMode = value;
                queue.Enqueue(new SetMarqueeProgressBarAsyncWrapper(marqueMode));
            }
        }

        /// <summary>
        /// Specifies the animation speed of the Task Dialog Progress Bar and sets it asynchronously.
        /// </summary>
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

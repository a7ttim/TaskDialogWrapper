namespace TaskDialogWrapper
{
    public interface ITaskDialogProgressBar
    {
        TaskDialogProgressBarState StateAsync
        {
            get;
            set;
        }

        int PositionAsync
        {
            get;
            set;
        }
        short MinRangeAsync
        {
            get;
            set;
        }

        short MaxRangeAsync
        {
            get;
            set;
        }

        bool MarqueModeAsync
        {
            get;
            set;
        }

        uint AnimationSpeedAsync
        {
            get;
            set;
        }
    }
}

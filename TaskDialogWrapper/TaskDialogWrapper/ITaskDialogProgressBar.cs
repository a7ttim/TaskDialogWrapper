using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

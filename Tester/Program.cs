using System;
using System.Threading.Tasks;
using TaskDialogWrapper;

namespace TaskDialogTester
{
    class Program
    {
        static void Main()
        {
            TaskDialog taskDialogWrapper = new TaskDialog();
            taskDialogWrapper.WindowTitle = "Кириллица в заголовке";
            taskDialogWrapper.Content = "Контент с гиперссылкой <a href=\"https://github.com/a7ttim\">https://github.com/a7ttim</a>";
            taskDialogWrapper.HyperlinksBarEnabled = true;
            taskDialogWrapper.MainIcon = TaskDialogMainIcon.Information;
            taskDialogWrapper.MainInstruction = "Главная инструкция";
            taskDialogWrapper.CustomButtons = new TaskDialogButton[3]
            {
                new TaskDialogButton(1, "Принять"),
                new TaskDialogButton(3, "Отменить"),
                new TaskDialogButton(4, "Убить"),
            };
            taskDialogWrapper.HyperLinkClickedCallbackDelegate += HyperLinkClicked;
            taskDialogWrapper.ButtonClickedCallbackDelegate += ButtonClicked;
            taskDialogWrapper.Width = 600;
            taskDialogWrapper.Cancellable = false;
            taskDialogWrapper.CanBeMinimized = true;
            taskDialogWrapper.ExpandedByDefault = true;
            taskDialogWrapper.ProgressBarEnabled = true;
            taskDialogWrapper.ProgressBar.PositionAsync = 10;
            Task.Delay(3000).ContinueWith(t =>
            {
                try
                {
                    taskDialogWrapper.EnableButtonAsync(1, false);
                    taskDialogWrapper.EnableButtonAsync(3, false);
                    taskDialogWrapper.ProgressBar.PositionAsync = 50;
                }
                catch (ArgumentException)
                {
                }
            });
            Task.Delay(5000).ContinueWith(t =>
            {
                try
                {
                    taskDialogWrapper.ProgressBar.PositionAsync = 90;
                    taskDialogWrapper.EnableButtonAsync(1, true);
                }
                catch (ArgumentException)
                {
                }
            });
            Task.Delay(6000).ContinueWith(t =>
            {
                try
                {
                    taskDialogWrapper.ProgressBar.StateAsync = TaskDialogProgressBarState.Paused;
                }
                catch (ArgumentException)
                {
                }
            });
            Task.Delay(8000).ContinueWith(t =>
            {
                try
                {
                    taskDialogWrapper.ProgressBar.StateAsync = TaskDialogProgressBarState.Error;
                }
                catch (ArgumentException)
                {
                }
            });
            Task.Delay(10000).ContinueWith(t =>
            {
                try
                {
                    taskDialogWrapper.ProgressBar.StateAsync = TaskDialogProgressBarState.Normal;
                    taskDialogWrapper.ProgressBar.MarqueModeAsync = true;
                    taskDialogWrapper.ProgressBar.AnimationSpeedAsync = 20;
                }
                catch (ArgumentException)
                {
                }
            });
            Task.Delay(11000).ContinueWith(t =>
            {
                try
                {
                    taskDialogWrapper.ProgressBar.StateAsync = TaskDialogProgressBarState.Paused;
                }
                catch (ArgumentException)
                {
                }
            });
            Task.Delay(13000).ContinueWith(t =>
            {
                try
                {
                    taskDialogWrapper.ProgressBar.MarqueModeAsync = false;
                    taskDialogWrapper.ProgressBar.AnimationSpeedAsync = 0;
                    taskDialogWrapper.ProgressBar.StateAsync = TaskDialogProgressBarState.Normal;
                    taskDialogWrapper.ProgressBar.PositionAsync = 50;
                }
                catch (ArgumentException)
                {
                }
            });
            Task.Delay(14000).ContinueWith(t =>
            {
                try
                {
                    taskDialogWrapper.SetContentAsync("Content 2");
                    taskDialogWrapper.EnableButtonAsync(1, false);
                }
                catch (ArgumentException)
                {
                }
            });
            Task.Delay(20000).ContinueWith(t =>
            {
                try
                {
                    taskDialogWrapper.ClickButton(1);
                }
                catch (ArgumentException)
                {
                }
            });
            taskDialogWrapper.Show();
        }

        private static int HyperLinkClicked(in string hyperLink)
        {
            Console.WriteLine(hyperLink);
            return 0;
        }

        private static int ButtonClicked(in int buttonId)
        {
            Console.WriteLine(buttonId);
            if(buttonId == 2)
            {
                return 0;
            }
            return 1;
        }
    }
}

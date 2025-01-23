namespace MyBlazorAnimation
{
    public class AnimateSettingsBase
    {        
        public double DurationInSeconds { get; set; } = 1;
        public double DelayInSeconds { get; set; } = 0;
        public int IterationCount { get; set; } = 1;        
    }

    public class AnimateSettings : AnimateSettingsBase
    {
        public string Animation { get; set; } = "";
        public Func<Task>? OnAnimationTriggered { get; set; }
    }
}

namespace ThreeBytes.Core.Quartz.Abstract
{
    public interface IQuartzServer
    {
        void Start();
        void Stop();
        void Pause();
        void Resume();
    }
}

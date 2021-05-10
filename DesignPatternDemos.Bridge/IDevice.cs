namespace DesignPatternDemos.Bridge
{
    /// <summary>
    /// Интерфейс, который не должен изменяться
    /// (такой набор методов будет у всех устройств всегда)
    /// </summary>
    public interface IDevice
    {
        bool IsEnabled();
        
        void Enable();
        
        void Disable();
        
        int GetVolume();
        
        void SetVolume(int percent);
        
        int GetChannel();
        
        void SetChannel(int channel);
    }
}
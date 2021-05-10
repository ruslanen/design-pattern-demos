namespace DesignPatternDemos.Bridge
{
    public class Tv : IDevice
    {
        private bool _isEnabled = false;
        private int _volume = 0;
        private int _channel = 1;
        
        public bool IsEnabled()
        {
            return _isEnabled;
        }

        public void Enable()
        {
            // Логика включения телевизора
        }

        public void Disable()
        {
            // Логика выключения телевизора
        }

        public int GetVolume()
        {
            // Логика получения значения громкости телевизора
            return _volume;
        }

        public void SetVolume(int percent)
        {
            // Логика установки значения громкости телевизора
            _volume = percent;
        }

        public int GetChannel()
        {
            // Логика получения номера текущего канала телевизора
            return _channel;
        }

        public void SetChannel(int channel)
        {
            // Логика установки значения номера текущего канала телевизора
            _channel = channel;
        }
    }
}
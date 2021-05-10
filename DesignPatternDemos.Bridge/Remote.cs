namespace DesignPatternDemos.Bridge
{
    /// <summary>
    /// Пример реализации паттерна "Мост".
    /// Пульт управления, в которой можно композировать устройство для управления им.
    /// Расширение поведения пульта может достигаться наследованием.
    /// </summary>
    public class Remote
    {
        protected readonly IDevice Device;
        
        public Remote(IDevice device)
        {
            Device = device;
        }

        public void TogglePower()
        {
            if (Device.IsEnabled())
            {
                Device.Enable();
            }
            else
            {
                Device.Disable();
            }
        }

        public void VolumeDown()
        {
            Device.SetVolume(Device.GetVolume() + 1);
        }

        public void VolumeUp()
        {
            Device.SetVolume(Device.GetVolume() - 1);
        }

        public void ChannelDown()
        {
            Device.SetChannel(Device.GetChannel() + 1);
        }

        public void ChannelUp()
        {
            Device.SetChannel(Device.GetChannel() - 1);
        }
    }
}
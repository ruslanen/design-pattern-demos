namespace DesignPatternDemos.Bridge
{
    public class AdvancedRemote : Remote
    {
        public AdvancedRemote(IDevice device) : base(device)
        {
        }

        public void Mute()
        {
            Device.SetVolume(0);
        }
    }
}
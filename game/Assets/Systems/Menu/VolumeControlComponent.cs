using SystemBase.Core;
using Systems.Menu.Events;
using UniRx;

namespace Systems.Menu
{
    public class VolumeControlComponent : GameComponent
    {
        public float adjustInterval = 0.1f;
        
        public void VolumeUp()
        {
            MessageBroker.Default.Publish(new VolumeUpMessage());
        }
        
        public void VolumeDown()
        {
            MessageBroker.Default.Publish(new VolumeDownMessage());
        }
    }
}
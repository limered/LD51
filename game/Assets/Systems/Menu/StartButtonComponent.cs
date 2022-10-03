using SystemBase.Core;
using SystemBase.GameState.Messages;
using UniRx;
using UnityEngine;

namespace Systems.Menu
{
    public class StartButtonComponent : GameComponent
    {
        public GameObject hideOnStart;
        public GameObject particles;
        public void StartGame()
        {
            MessageBroker.Default.Publish(new GameMsgStart());
            hideOnStart.SetActive(false);

            if (particles)
            {
                var clone = GameObject.Instantiate(particles, hideOnStart.transform.parent, true);
                clone.GetComponent<ParticleSystem>().Emit(100);
            }
        }
    }
}
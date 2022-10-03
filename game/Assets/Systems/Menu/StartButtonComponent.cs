using SystemBase.Core;
using SystemBase.GameState.Messages;
using UniRx;
using UnityEngine;

namespace Systems.Menu
{
    public class StartButtonComponent : GameComponent
    {
        public GameObject hideOnStart;
        public void StartGame()
        {
            MessageBroker.Default.Publish(new GameMsgStart());
            hideOnStart.SetActive(false);
        }
    }
}
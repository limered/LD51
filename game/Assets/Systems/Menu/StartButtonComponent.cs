using SystemBase.Core;
using UniRx;
using UnityEngine;

namespace Systems.Menu
{
    public class StartButtonComponent : GameComponent
    {
        public GameObject hideOnStart;
        public GameObject particles;
        public readonly ReactiveCommand StartCommand = new ReactiveCommand();

        public void StartGame()
        {
            StartCommand.Execute();
        }
    }
}
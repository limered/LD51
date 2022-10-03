using SystemBase.Core;
using UniRx;
using UnityEngine;

namespace Systems.Menu
{
    public class RestartGameComponent : GameComponent
    {
        public GameObject showOnGameOver;
        public readonly ReactiveCommand RestartCommand = new ReactiveCommand();

        public void RestartGame()
        {
            RestartCommand.Execute();
        }
    }
}
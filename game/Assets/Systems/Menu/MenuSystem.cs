using System;
using SystemBase.Core;
using SystemBase.GameState.Messages;
using SystemBase.Utils;
using UniRx;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Systems.Menu
{
    [GameSystem]
    public class MenuSystem : GameSystem<StartButtonComponent, RestartGameComponent>
    {
        public override void Register(StartButtonComponent component)
        {
            component.hideOnStart.SetActive(true);

            component.StartCommand.Subscribe(_ =>
            {
                MessageBroker.Default.Publish(new GameMsgStart());

                if (component.particles)
                {
                    var clone = GameObject.Instantiate(component.particles, component.hideOnStart.transform.parent,
                        true);
                    clone.GetComponent<ParticleSystem>().Emit(100);
                }

                component.hideOnStart.SetActive(false);
            }).AddTo(component);
        }

        public override void Register(RestartGameComponent component)
        {
            component.showOnGameOver.SetActive(false);

            MessageBroker.Default.Receive<GameMsgEnd>()
                .Subscribe((_) =>
                {
                    Debug.Log("Game Over");
                    component.showOnGameOver.SetActive(true);
                })
                .AddTo(component);

            component.RestartCommand.Subscribe((_) =>
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex, LoadSceneMode.Single);
            });
        }
    }
}
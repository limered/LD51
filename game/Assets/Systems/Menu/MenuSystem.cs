using System;
using SystemBase.Core;
using SystemBase.GameState.Messages;
using SystemBase.Utils;
using Systems.Menu.Events;
using Systems.Music;
using UniRx;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Systems.Menu
{
    [GameSystem]
    public class MenuSystem : GameSystem<StartButtonComponent, RestartGameComponent, VolumeControlComponent>
    {
        private float2 _musicVolumeRange;
        private float2 _rainVolumeRange;
        
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

        public override void Register(VolumeControlComponent component)
        {
            var audio = IoC.Game.GetComponent<MusicComponent>();
            _musicVolumeRange = audio.musicVolumeMinMax;
            _rainVolumeRange = audio.rainVolumeMinMax;
            

            MessageBroker.Default.Receive<VolumeDownMessage>()
                .Subscribe(_ =>
                {
                    var audio = IoC.Game.GetComponent<MusicComponent>();
                    audio.musicVolumeMinMax.y = Mathf.Clamp(audio.musicVolumeMinMax.y - component.adjustInterval, 0, _musicVolumeRange.y);
                    audio.rainVolumeMinMax.y = Mathf.Clamp(audio.rainVolumeMinMax.y - component.adjustInterval, 0, _rainVolumeRange.y);
                    audio.musicVolumeMinMax.x = Mathf.Clamp(audio.musicVolumeMinMax.x - component.adjustInterval, 0, _musicVolumeRange.x);
                    audio.rainVolumeMinMax.x = Mathf.Clamp(audio.rainVolumeMinMax.x - component.adjustInterval, 0, _rainVolumeRange.x);
                    audio.music.volume = Mathf.Clamp(audio.music.volume - component.adjustInterval, 0f, _musicVolumeRange.y);
                    audio.rain.volume = Mathf.Clamp(audio.rain.volume - component.adjustInterval, 0f, _rainVolumeRange.y);
                })
                .AddTo(component);

            MessageBroker.Default.Receive<VolumeUpMessage>()
                .Subscribe(_ =>
                {
                    var audio = IoC.Game.GetComponent<MusicComponent>();
                    audio.musicVolumeMinMax.y = Mathf.Clamp(audio.musicVolumeMinMax.y + component.adjustInterval, 0f, _musicVolumeRange.y);
                    audio.rainVolumeMinMax.y = Mathf.Clamp(audio.rainVolumeMinMax.y + component.adjustInterval, 0f, _rainVolumeRange.y);
                    audio.musicVolumeMinMax.x = Mathf.Clamp(audio.musicVolumeMinMax.x + component.adjustInterval, 0, _musicVolumeRange.x);
                    audio.rainVolumeMinMax.x = Mathf.Clamp(audio.rainVolumeMinMax.x + component.adjustInterval, 0, _rainVolumeRange.x);
                    audio.music.volume = Mathf.Clamp(audio.music.volume + component.adjustInterval, 0f, _musicVolumeRange.y);
                    audio.rain.volume = Mathf.Clamp(audio.rain.volume + component.adjustInterval, 0f, _rainVolumeRange.y);
                })
                .AddTo(component);
        }
    }
}
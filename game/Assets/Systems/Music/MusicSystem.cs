using System.Collections;
using SystemBase.Core;
using SystemBase.GameState.Messages;
using UniRx;
using Unity.Mathematics;
using UnityEngine;

namespace Systems.Music
{
    [GameSystem]
    public class MusicSystem : GameSystem<MusicComponent>
    {
        public override void Register(MusicComponent component)
        {
            MessageBroker.Default.Receive<GameMsgStart>()
                .Subscribe(_ => FadeInMusic(component))
                .AddTo(component);
        }

        private void FadeInMusic(MusicComponent music)
        {
            music.music.Play();
            
            Observable.FromCoroutine(_ => CrossFade(music))
                .Subscribe()
                .AddTo(music);
        }

        private IEnumerator CrossFade(MusicComponent music)
        {
            for (var i = 0; i < music.crossFadeFrames; i++)
            {
                var t = i * 1.0f / music.crossFadeFrames;
                var rainVolume = math.lerp(music.rainVolumeMinMax.x, music.rainVolumeMinMax.y, t);
                var musicVolume = math.lerp(music.musicVolumeMinMax.x, music.musicVolumeMinMax.y, t);
                
                music.rain.volume = rainVolume;
                music.music.volume = musicVolume;
                
                yield return new WaitForSeconds(0.1f);
            }
        }
    }
}
using SystemBase.Core;
using Unity.Mathematics;
using UnityEngine;

namespace Systems.Music
{
    public class MusicComponent : GameComponent
    {
        public AudioSource rain;
        public AudioSource music;

        public int crossFadeFrames;
        public float2 rainVolumeMinMax;
        public float2 musicVolumeMinMax;
    }
}
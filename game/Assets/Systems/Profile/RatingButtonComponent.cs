using SystemBase.Core;
using UniRx;
using UnityEngine;

namespace Systems.Profile
{
    public class RatingButtonComponent : GameComponent
    {
        public Rating rating;
        public ReactiveCommand<RatingButtonComponent> Command = new();

        public GameObject likeStamp;
        public GameObject nopeStamp;

        public void PressButton()
        {
            Command.Execute(this);
        }
    }
}
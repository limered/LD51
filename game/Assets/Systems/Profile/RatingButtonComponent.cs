using SystemBase.Core;
using UniRx;
using UnityEngine;

namespace Assets.Systems.Profile
{
    public class RatingButtonComponent : GameComponent
    {
        public Rating rating;
        public ReactiveCommand<Rating> Command = new ReactiveCommand<Rating>();

        public void PressButton()
        {
            Command.Execute(rating);
        }
    }
}
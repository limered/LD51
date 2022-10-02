using SystemBase.Core;
using UniRx;

namespace Systems.Profile
{
    public class RatingButtonComponent : GameComponent
    {
        public Rating rating;
        public ReactiveCommand<Rating> Command = new();

        public void PressButton()
        {
            Command.Execute(rating);
        }
    }
}
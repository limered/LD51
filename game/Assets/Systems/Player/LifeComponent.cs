using SystemBase.Core;
using UniRx;

namespace Systems.Player
{
    public class LifeComponent : GameComponent
    {
        public int initialLives = 3;
        public IntReactiveProperty livesLeft = new();
    }
}
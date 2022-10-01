using SystemBase.Core;
using UnityEngine;

namespace Systems.ClockFace
{
    public class ClockFaceSystem : GameSystem<ClockFaceComponent>
    {
        public override void Register(ClockFaceComponent component)
        {
            
        }
    }

    public class ClockFaceComponent : GameComponent
    {
        public GameObject MainHand;
        public GameObject SecondHand;
    }
}
using SystemBase.Core;
using UniRx;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Systems.Test
{
    [GameSystem]
    public class TestSystem : GameSystem<TestComponent>
    {
        public override void Register(TestComponent component)
        {
            SystemUpdate(component).Subscribe(Animate).AddTo(component);
        }

        private void Animate(TestComponent test)
        {
            var nextPosition = test.transform.position +
                               (Vector3) (math.float3(test.direction) *
                                          math.float3(test.speed));

            if (!test.bounds.Contains(nextPosition))
                test.direction = Vector3.Normalize(test.bounds.center - nextPosition + Random.insideUnitSphere);

            test.transform.position = nextPosition;
        }
    }
}
using SystemBase.Core;
using UnityEngine;

namespace Systems.Test
{
    public class TestComponent : GameComponent
    {
        [SerializeField] public Vector3 speed;
        [SerializeField] public Bounds bounds;

        public Vector3 direction = Vector3.forward;
    }
}
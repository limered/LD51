using SystemBase.Core;
using UnityEngine;

namespace Systems.Test
{
    public class TestComponent : GameComponent
    {
        [SerializeField] public Vector3 speed;
        [SerializeField] public Bounds bounds;

        [HideInInspector] public Vector3 direction;
    }
}
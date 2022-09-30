using System;
using SystemBase.Core;
using UnityEngine;

namespace Systems.Test
{
    [GameSystem]
    public class TestSystem : GameSystem<TestComponent>
    {
        public override void Register(TestComponent component)
        {
            Debug.Log("Component Registered " + component.name);
        }
    }
}

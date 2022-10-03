using System;
using SystemBase.Core;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace Systems.Player
{
    public class LifeUiComponent : GameComponent
    {
        public GameObject heartsContainer;
        
        public GameObject messageContainer;
        public Text messageText;

        [NonSerialized] public readonly ReactiveProperty<LifeComponent> lifeComponent = new();
    }
}
using System;
using SystemBase.Core;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace Systems.Player
{
    public class LifeUiComponent : GameComponent
    {
        public GameObject heartsContainer;
        
        public GameObject messageContainer;
        public TextMeshProUGUI messageText;

        [NonSerialized] public readonly ReactiveProperty<LifeComponent> lifeComponent = new();
    }
}
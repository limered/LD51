using SystemBase.Core;
using UnityEngine;

namespace Systems.Notes
{
    public class NotesConfigComponent : GameComponent
    {
        public GameObject textPrefab;
        public RectTransform likeList;
        public RectTransform dislikeList;
    }
}
using SystemBase.Core;
using Systems.Player;
using Systems.Profile.Events;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace Systems.Notes
{
    [GameSystem]
    public class NotesDisplaySystem : GameSystem<NotesConfigComponent, WishlistComponent>
    {
        private NotesConfigComponent _uiConfig;
        private WishlistComponent _config;
        private bool _listInitialized = false;

        public override void Register(NotesConfigComponent component)
        {
            _uiConfig = component;
            CreateList();
        }

        public override void Register(WishlistComponent component)
        {
            _config = component;
            component.listsChanged.Take(1).Subscribe((_) => CreateList()).AddTo(component);
            component.listsChanged.Subscribe((_) => UpdateList()).AddTo(component);
        }

        private void CreateList()
        {
            if (_listInitialized) return;

            if (_config != null && _uiConfig != null)
            {
                for (var i = 0; i < _config.wantPositives.Count; i++)
                {
                    var like = _config.wantPositives[i];
                    var text = GameObject.Instantiate(_uiConfig.textPrefab, _uiConfig.likeList);
                    text.GetComponent<TextMeshProUGUI>().text = like.trait.text;
                    text.GetComponent<TextMeshProUGUI>().fontStyle = FontStyles.Bold;
                }

                for (var i = 0; i < _config.wantNegatives.Count; i++)
                {
                    var dislike = _config.wantNegatives[i];
                    var text = GameObject.Instantiate(_uiConfig.textPrefab, _uiConfig.dislikeList);
                    text.GetComponent<TextMeshProUGUI>().text = dislike.trait.text;
                    text.GetComponent<TextMeshProUGUI>().fontStyle = FontStyles.Bold;
                }

                if (_config.wantNegatives.Count + _config.wantNegatives.Count > 0)
                {
                    _listInitialized = true;
                }
            }
            else
            {
                Debug.Log("oh no");
            }
        }

        private void UpdateList()
        {
            if (_config != null && _uiConfig != null)
            {
                for (var i = 0; i < _config.wantPositives.Count; i++)
                {
                    var like = _config.wantPositives[i];
                    var text = _uiConfig.likeList.GetChild(i);
                    text.GetComponent<TextMeshProUGUI>().fontStyle = like.state == PersonalityCheckState.Checked
                        ? FontStyles.Strikethrough | FontStyles.Italic
                        : FontStyles.Bold;
                }

                for (var i = 0; i < _config.wantNegatives.Count; i++)
                {
                    var dislike = _config.wantNegatives[i];
                    var text = _uiConfig.dislikeList.GetChild(i);
                    text.GetComponent<TextMeshProUGUI>().fontStyle = dislike.state == PersonalityCheckState.Checked
                        ? FontStyles.Strikethrough | FontStyles.Italic
                        : FontStyles.Bold;
                }
            }
        }
    }
}
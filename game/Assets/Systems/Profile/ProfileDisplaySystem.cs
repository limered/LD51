using SystemBase.Core;
using SystemBase.Utils;
using UniRx;
using UnityEngine;

namespace Systems.Profile
{
    [GameSystem(typeof(ProfileSystem))]
    public class ProfileDisplaySystem : GameSystem<ProfileUIConfigComponent, ProfileConfigComponent>
    {
        private readonly ReactiveProperty<ProfileConfigComponent> _configComponent = new();

        public override void Register(ProfileUIConfigComponent component)
        {
            _configComponent.WhereNotNull()
                .Subscribe(configComponent =>
                {
                    configComponent.activeProfile
                        .Subscribe(newProfile => UpdateProfile(component, newProfile))
                        .AddTo(component);
                })
                .AddTo(component);
        }

        private static void UpdateProfile(
            ProfileUIConfigComponent profileUIConfigDisplaySystem,
            DisplayProfile newProfile)
        {
            profileUIConfigDisplaySystem.imageElement.sprite = newProfile.Profile.profileImage.avatar;
            profileUIConfigDisplaySystem.nameTextElement.text = newProfile.Profile.name;
            profileUIConfigDisplaySystem.ageTextElement.text = $"{newProfile.Profile.age} years";
            profileUIConfigDisplaySystem.distanceTextElement.text = $"{newProfile.Profile.distance:N0} miles away";
            profileUIConfigDisplaySystem.bioTextElement.text = newProfile.Profile.text;
            ResetScrollPosition(profileUIConfigDisplaySystem);
        }

        private static void ResetScrollPosition(ProfileUIConfigComponent component)
        {
            var rectTransform = component.bioTextElement.GetComponent<RectTransform>();
            var position = rectTransform.position;
            rectTransform.position = new Vector3(position.x, 0, position.z);
        }

        public override void Register(ProfileConfigComponent component)
        {
            _configComponent.Value = component;
        }
    }
}
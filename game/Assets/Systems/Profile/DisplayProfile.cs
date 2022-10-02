using System.Collections.Generic;
using System.Linq;
using Systems.Profile.ScriptableObjects;

namespace Systems.Profile
{
    public class DisplayProfile
    {
        public ProfileSo Profile { get; set; }
        public Rating? Rating { get; set; }

        public IEnumerable<PersonalityTrait> AllTraits()
        {
            var imageTraits = Profile.profileImage.traits;
            var textTraits = Profile.traits;
            return imageTraits.Concat(textTraits);
        }
    }
}
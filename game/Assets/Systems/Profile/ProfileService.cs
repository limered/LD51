using System.Collections.Generic;
using Assets.Utils;
using UniRx;

namespace Assets.Systems.Profile
{
    public static class ProfileService
    {
        public static ReactiveProperty<Profile> activeProfile = new();
        private static Stack<Profile> _unseenProfiles;
        private static Stack<Profile> _likedProfiles;
        private static Stack<Profile> _dislikedProfiles;

        public static void Init()
        {
            _unseenProfiles = new Stack<Profile>(ScriptableObjectSearcher.GetAllInstances<Profile>());
        }

        public static void ToNextProfile()
        {
            activeProfile.Value = _unseenProfiles.Pop();
        }
    }
}

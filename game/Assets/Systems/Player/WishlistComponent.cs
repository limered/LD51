using System;
using System.Collections.Generic;
using SystemBase.Core;
using Systems.Profile;
using Systems.Profile.ScriptableObjects;
using UnityEngine;

namespace Systems.Player
{
    public class WishlistComponent : GameComponent
    {
        public Vector2Int wantPositivesMinMax;
        public Vector2Int wantNegativeMinMax;
        
        public List<CheckedTrait> wantPositives;
        public List<CheckedTrait> wantNegatives;
        public List<DisplayProfile> likedProfiles;
    }

    public enum PersonalityCheckState
    {
        Unchecked,
        Checked
    }
    
    [Serializable]
    public class CheckedTrait
    {
        public PersonalityTrait trait;
        public PersonalityCheckState state;
    }
}
﻿using UnityEngine;

namespace Systems.Profile.ScriptableObjects
{
    [CreateAssetMenu(menuName = "LD51/Profile", fileName = "Profile", order = 0)]
    public class ProfileSo : ScriptableObject
    {
        public ProfileImage profileImage;
        public Sprite avatar;
        public new string name;
        public string text;
        public int age;
        public float distance;
        public PersonalityTrait[] traits;
    }
}

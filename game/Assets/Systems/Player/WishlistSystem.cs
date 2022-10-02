using System.Collections.Generic;
using System.Linq;
using SystemBase.Core;
using SystemBase.Utils;
using Systems.Profile;
using Systems.Profile.Events;
using UniRx;
using UnityEngine;

namespace Systems.Player
{
    [GameSystem]
    public class WishlistSystem : GameSystem<WishlistComponent>
    {
        public override void Register(WishlistComponent wishList)
        {
            wishList.likedProfiles = new List<DisplayProfile>();

            MessageBroker.Default.Receive<ActiveProfileChangedEvent>()
                .Subscribe(msg => SaveLikedProfiles(msg, wishList))
                .AddTo(wishList);

            MessageBroker.Default.Receive<ProfileQueueFilledEvent>()
                .Subscribe(msg => FillWishes(msg, wishList))
                .AddTo(wishList);
        }

        private void FillWishes(ProfileQueueFilledEvent msg, WishlistComponent wishList)
        {
            var allTraits = msg.UsedTraits().Randomize();
            var positivesCount = Random.Range(wishList.wantPositivesMinMax.x, wishList.wantPositivesMinMax.y);
            var negativesCount = Random.Range(wishList.wantNegativeMinMax.x, wishList.wantNegativeMinMax.y);

            wishList.wantPositives = allTraits.GetRange(0, positivesCount)
                .Select(trait => new CheckedTrait {trait = trait, state = PersonalityCheckState.Unchecked})
                .ToList();
            wishList.wantNegatives = allTraits.GetRange(positivesCount + 1, negativesCount)
                .Select(trait => new CheckedTrait {trait = trait, state = PersonalityCheckState.Unchecked})
                .ToList();
        }

        private void SaveLikedProfiles(ActiveProfileChangedEvent msg, WishlistComponent wishList)
        {
            if (msg.lastProfile.Rating == Rating.Dislike) return;
            wishList.likedProfiles.Add(msg.lastProfile);

            var profileTraits = msg.lastProfile.AllTraits();
            var foundPositive = wishList.wantPositives.FindAll(trait => profileTraits.Contains(trait.trait));
            var foundNegatives = wishList.wantNegatives.FindAll(trait => profileTraits.Contains(trait.trait));
            foreach (var checkedTrait in foundPositive) checkedTrait.state = PersonalityCheckState.Checked;
            // Check for Win

            foreach (var checkedTrait in foundNegatives) checkedTrait.state = PersonalityCheckState.Checked;
            // Check for Loss
        }
    }
}
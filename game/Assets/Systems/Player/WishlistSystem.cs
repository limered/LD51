using System.Collections.Generic;
using System.Linq;
using SystemBase.Core;
using SystemBase.Utils;
using Systems.Player.Events;
using Systems.Profile;
using Systems.Profile.Events;
using Systems.Profile.ScriptableObjects;
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

        public class TraitOccurence
        {
            public PersonalityTrait trait;
            public int occurence;
        }

        private void FillWishes(ProfileQueueFilledEvent msg, WishlistComponent wishList)
        {
            var positivesCount = Random.Range(wishList.wantPositivesMinMax.x, wishList.wantPositivesMinMax.y);
            var negativesCount = Random.Range(wishList.wantNegativeMinMax.x, wishList.wantNegativeMinMax.y);

            var allTraits = msg.UsedTraits();

            var orderedTraitOccurences = allTraits
                .GroupBy(trait => trait.text)
                .Select(traitGroup => new TraitOccurence {trait = traitGroup.First(), occurence = traitGroup.Count()})
                .OrderBy(occurence => occurence.occurence)
                .ToList();

            var traitOccurenceDictionary = orderedTraitOccurences
                .ToDictionary(occurence => occurence.trait.text, occurence => occurence.occurence);

            Debug.Log("People Count: " + msg.queue.Count);
            Debug.Log("Distinct Trait Count: " + orderedTraitOccurences.Count);

            // Negative Traits
            wishList.wantNegatives = orderedTraitOccurences
                .Skip((int) (orderedTraitOccurences.Count * 0.90))
                .Take(negativesCount)
                .Select(
                    occurence => new CheckedTrait {trait = occurence.trait, state = PersonalityCheckState.Unchecked})
                .ToList();

            // Positive Traits
            var positives = new List<CheckedTrait>();

            var peopleWithNegatives = msg.queue.Where(profile =>
                profile.AllTraits()
                    .Any(trait => wishList.wantNegatives.Any(checkedTrait => checkedTrait.trait == trait)));

            var traitsOfPeopleWithNegatives = peopleWithNegatives
                .Aggregate(Enumerable.Empty<PersonalityTrait>(),
                    (traits, profile) => traits.Concat(profile.AllTraits().Distinct()))
                .ToList();

            var orderedNoneNegativeTraitsOfPersonsWithNegatives = traitsOfPeopleWithNegatives
                .Where(trait => wishList.wantNegatives.All(checkedTrait => checkedTrait.trait != trait))
                .OrderBy(trait => traitOccurenceDictionary[trait.text])
                .ToList();

            // A Positive Trait that only 1 Person has, that has also a negative trait
            positives.Add(new CheckedTrait
            {
                trait = orderedNoneNegativeTraitsOfPersonsWithNegatives.First(), state = PersonalityCheckState.Unchecked
            });

            // A Positive Trait that more than 1 person has, but some of them have negatives
            var occurenceOfTraitsInNegativePeople = traitsOfPeopleWithNegatives.GroupBy(trait => trait.text)
                .Select(traitGroup => new TraitOccurence {trait = traitGroup.First(), occurence = traitGroup.Count()})
                .OrderBy(occurence => occurence.occurence)
                .ToList();

            var searchedTrait = occurenceOfTraitsInNegativePeople
                .Last(occurence => traitOccurenceDictionary[occurence.trait.text] > occurence.occurence);

            positives.Add(new CheckedTrait
            {
                trait = searchedTrait.trait, state = PersonalityCheckState.Unchecked
            });

            // A Positive Trait that only 2 persons have that have no negatives
            var twiceExitingPositiveTraits = orderedTraitOccurences
                .Where(occurence => occurence.occurence == 2)
                .Where(occurence => wishList.wantNegatives.All(trait => trait.trait.text != occurence.trait.text))
                .Where(occurence =>
                    orderedNoneNegativeTraitsOfPersonsWithNegatives.All(trait => trait.text != occurence.trait.text))
                .ToList();

            searchedTrait = twiceExitingPositiveTraits.Skip(twiceExitingPositiveTraits.Count / 2).Take(1).First();

            positives.Add(new CheckedTrait
            {
                trait = searchedTrait.trait, state = PersonalityCheckState.Unchecked
            });

            positives.Print(trait =>
                trait.trait.text + " Full Occurence: " + traitOccurenceDictionary[trait.trait.text] +
                " Occurence in Negatives: " +
                occurenceOfTraitsInNegativePeople.Find(occurence => occurence.trait.text == trait.trait.text)?
                    .occurence);

            wishList.wantPositives = positives;

            wishList.listsChanged.Execute();
        }

        private void SaveLikedProfiles(ActiveProfileChangedEvent msg, WishlistComponent wishList)
        {
            if (msg.lastProfile.Rating == Rating.Dislike) return;
            wishList.likedProfiles.Add(msg.lastProfile);

            var profileTraits = msg.lastProfile.AllTraits();
            var foundPositive = wishList.wantPositives.FindAll(trait => profileTraits.Contains(trait.trait));
            var foundNegatives = wishList.wantNegatives.FindAll(trait => profileTraits.Contains(trait.trait));

            if (foundNegatives.Any())
                MessageBroker.Default.Publish(
                    new LoseLifeMessage
                    {
                        profile = msg.lastProfile,
                        badTraits = foundNegatives.Select(trait => trait.trait).ToArray()
                    });

            foreach (var checkedTrait in foundPositive) checkedTrait.state = PersonalityCheckState.Checked;

            wishList.listsChanged.Execute();
            if (wishList.wantPositives.All(trait => trait.state == PersonalityCheckState.Checked))
                MessageBroker.Default.Publish(new WinMessage {profiles = wishList.likedProfiles});
        }
    }
}
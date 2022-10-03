using System.Collections.Generic;
using System.Linq;
using Systems.Profile.ScriptableObjects;

namespace Systems.Profile.Events
{
    public class ProfileQueueFilledEvent
    {
        public Queue<DisplayProfile> queue;
        
        public List<PersonalityTrait> UsedTraits()
        {
            return queue.Aggregate(Enumerable.Empty<PersonalityTrait>(), 
                (list, profile) => list.Concat(profile.AllTraits().Distinct()))
                .ToList();
        }
    }
}
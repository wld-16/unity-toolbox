using UnityEngine;

namespace Enemies.Combat
{
    
    [CreateAssetMenu(fileName = "AnimationReaction", menuName = "AnimationReaction", order = 0)]
    public class AnimationReaction : Reaction
    {

        [SerializeField] private AnimationClip clip;
        [ReadOnlyAttribute] new readonly float duration;
        
        public AnimationReaction(string triggerName, float duration) : base(triggerName, duration)
        {
            duration = clip.length;
        }
    }
}
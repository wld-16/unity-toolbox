using UnityEngine;

namespace Enemies.Combat
{
    [CreateAssetMenu(fileName = "AnimationAction", menuName = "AnimationAction", order = 0)]
    public class AnimationAction : IAction
    {
        [SerializeField] private string triggerName;
        [SerializeField] private AnimationClip clip;
        [SerializeField] private float probability;
        [ReadOnlyAttribute] private float duration;
        
        public AnimationAction(string triggerName, float probability, AnimationClip clip) 
        {
            this.triggerName = triggerName;
            this.probability = probability;
            this.clip = clip;
            duration = clip.length;
        }

        public override string getTriggerName()
        {
            return triggerName;
        }

        public override float getDuration()
        {
            return duration;
        }
    }
}
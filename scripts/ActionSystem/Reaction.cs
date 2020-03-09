using UnityEngine;

namespace Enemies.Combat
{
    [CreateAssetMenu(fileName = "Reaction", menuName = "Reaction", order = 0)]
    public class Reaction: IAction
    {
        public int prio;
        public Condition condition;
        
        public override string getTriggerName()
        {
            return triggerName;
        }

        public override float getDuration()
        {
            return duration;
        }

        public Reaction(string triggerName, float duration) : base(triggerName, duration)
        {
        }
    }
}
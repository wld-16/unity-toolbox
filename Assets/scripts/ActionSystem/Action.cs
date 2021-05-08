using UnityEngine;
using UnityEngine.Serialization;

namespace Enemies.Combat
{
    public abstract class IAction : ScriptableObject
    {
        [SerializeField] protected string triggerName;
        [SerializeField] protected float duration;

        protected IAction()
        {
            triggerName = "";
            duration = 0;
        }
        
        protected IAction(string triggerName, float duration)
        {
            this.triggerName = triggerName;
            this.duration = duration;
        }
        
        public virtual string getTriggerName()
        {
            return triggerName;
        }
        public virtual float getDuration()
        {
            return duration;
        }
    }

    [CreateAssetMenu(fileName = "Action", menuName = "Action", order = 0)]
    public class Action : IAction 
    {
        public float probability;


        public Action() : base()
        {
            probability = 0;
        }
        
        public Action(string triggerName, float duration, float probability) : base(triggerName, duration)
        {
            this.duration = duration;
            this.triggerName = triggerName;
            this.probability = probability;
        }

        public override string  getTriggerName()
        {
            return triggerName;
        }

        public override float getDuration()
        {
            return duration;
        }
    }
}
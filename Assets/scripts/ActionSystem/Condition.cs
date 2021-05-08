using UnityEngine;

namespace Enemies.Combat
{
    public abstract class Condition : ScriptableObject
    {
        public virtual bool applyCondition(ConditionVars conditionVars)
        {
            return false;
        }
    }
}
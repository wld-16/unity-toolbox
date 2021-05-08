using UnityEngine;

namespace Enemies.Combat
{
    [CreateAssetMenu(fileName = "ConditionKeyPressed", menuName = "ConditionKeyPressed", order = 0)]
    public class ConditionKeyPressed :  Condition
    {
        public KeyCode keyCode;

        public override bool applyCondition(ConditionVars conditionVars) =>
            Input.GetKey(keyCode);
    }
}
using System.Collections;
using System.Collections.Generic;
using Enemies.Combat;
using UnityEngine;

[CreateAssetMenu(fileName = "ConditionBoolCheck", menuName = "ConditionBoolCheck", order = 0)]
public class ConditionBoolCheck : Condition
{
    public string boolName;

    public override bool applyCondition(ConditionVars conditionVars)
    {
        return conditionVars.boolsMap[boolName];
    }
}

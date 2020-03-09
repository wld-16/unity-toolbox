using System;
using System.Collections.Generic;
using System.Linq;
using Enemies.Combat;
using UnityEngine;

namespace Enemies
{
    [CreateAssetMenu(fileName = "AIBlueprint", menuName = "AIBlueprint", order = 0)]
    public class AIBlueprint : ScriptableObject
    {
        [SerializeField] private string strategyName;
        [SerializeField] private List<Mode> mode;

        public List<Mode> Mode => mode;

        public Mode GetCurrentCombatMode(ConditionVars conditionVars)
        {
            List<Mode> modesApplyable = mode.Where(mode =>
            {
                if (mode.optionalCondition != null)
                {
                    return mode.condition.applyCondition(conditionVars) &&
                           mode.optionalCondition.applyCondition(conditionVars);
                }

                return mode.condition.applyCondition(conditionVars);
            }).ToList();
            if (modesApplyable.Count > 1)
            {
                modesApplyable.Sort((mode1, mode2) => mode1.prio.CompareTo(mode2.prio));
            }

            return modesApplyable.First();
        }
    }

    [Serializable]
    public struct Mode
    {
        public string modeName;
        public Condition condition;
        public Condition optionalCondition;
        public int prio;
        public List<Combat.Action> actions;
        public GenerateActionMode generateActionMode;
    }

    public enum GenerateActionMode
    {
        ByPropability,
        InSequence,
        FullRandom
    }
}
﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Enemies;
using Enemies.Combat;
using UnityEngine;
using Action = Enemies.Combat.Action;
 
public class AIBehaviour : MonoBehaviour
{
    #region Data

        public AIBlueprint aiBlueprint;
        public Reactions reactions;
        public CombatSequencer combatSequencer;
        [SerializeField] private ConditionVars conditionVars;
        public Animator animator;
        private float _count;
        public Mode currentMode;
        [SerializeField] private List<Action> actions;
        [SerializeField] private IAction currentAction;
        [SerializeField] private int sequencesCount = 1;
        
    #endregion
    
    
    // Start is called before the first frame update
    void Start()
    {
        conditionVars = new ConditionVars();
        animator = GetComponent<Animator>();
        currentMode = aiBlueprint.GetCurrentCombatMode(conditionVars);
        combatSequencer = new CombatSequencer(currentMode, sequencesCount);
        currentAction = combatSequencer.NextAction(currentMode.generateActionMode);
        animator.SetTrigger(currentAction.getTriggerName());
    }
    
    void Update()
    {
        UpdateConditionVars();
        List<Reaction> possibleReactions = reactions.reactions
            .Where(reaction => reaction.condition.applyCondition(conditionVars)).ToList();
        if (possibleReactions.Count > 0)
        {
            currentAction = possibleReactions.First();
            animator.SetTrigger(currentAction.getTriggerName());
            _count = 0;
        }
        else
        {
            currentMode = aiBlueprint.GetCurrentCombatMode(conditionVars);
            combatSequencer.Mode = currentMode;
            actions = combatSequencer.actions.ToList();

            if (_count > currentAction.getDuration())
            {
                animator.ResetTrigger(currentAction.getTriggerName());
                currentAction = combatSequencer.NextAction(currentMode.generateActionMode);
                animator.SetTrigger(currentAction.getTriggerName());
                _count = 0;
            }
        }
        _count += Time.deltaTime;
    }

    void UpdateConditionVars()
    {
        
    }
}

/**
 * Here ConditionVars are defined, that will be checked by the conditions to determine a mode
 */
[Serializable]
public class ConditionVars
{
    public Dictionary<string, bool> boolsMap = new Dictionary<string, bool>();

    public ConditionVars()
    {
        
    }
}
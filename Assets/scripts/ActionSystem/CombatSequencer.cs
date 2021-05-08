
using System.Collections.Generic;
using Enemies;
using Action = Enemies.Combat.Action;
using Random = UnityEngine.Random;

public class CombatSequencer
{
    public Queue<Action> actions;
    private int _actionIndex = 0;

    public Mode Mode { get; set; }

    public CombatSequencer(Mode mode, int sequenceLength)
    {
        this.Mode = mode;
        actions = new Queue<Action>();
        for (int i = 0; i < sequenceLength; i++)
        {
            switch (mode.generateActionMode)
            {
                case GenerateActionMode.InSequence:
                    actions.Enqueue(GenerateNextSequentialAction());
                    break;
                case GenerateActionMode.ByPropability:
                    actions.Enqueue(GenerateNextAction());
                    break;
                case GenerateActionMode.FullRandom:
                    actions.Enqueue(GenerateRandomNextAction());
                    break;
            }
        }
    }

    public Action NextAction(GenerateActionMode mode)
    {
        switch (mode)
        {
            case GenerateActionMode.FullRandom:
                actions.Enqueue(GenerateRandomNextAction());
                return actions.Dequeue();
            case GenerateActionMode.InSequence:
                actions.Enqueue(GenerateNextSequentialAction());
                return actions.Dequeue();
            default:
                actions.Enqueue(GenerateNextAction());
                return actions.Dequeue();
        }
    }

    private Action GenerateNextSequentialAction()
    {
        Action generateNextSequentialAction = Mode.actions[_actionIndex];
        _actionIndex += 1;
        _actionIndex %= Mode.actions.Count;
        return generateNextSequentialAction;
    }

    private Action GenerateNextAction()
    {
        float sum = 0;
        Mode.actions.ForEach(action => sum += action.probability);
        float random = Random.Range(0, sum);
        Action returnAction = Mode.actions[0];
        for (int i = 0; i < Mode.actions.Count; i++)
        {
            random -= Mode.actions[i].probability;
            if (random <= 0) return Mode.actions[i];
        }
        return returnAction;
    }

    private Action GenerateRandomNextAction()
    {
        return Mode.actions[Random.Range(0, Mode.actions.Count)];
    }

};
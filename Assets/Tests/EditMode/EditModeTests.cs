using System;
using System.Collections;
using System.Collections.Generic;
using Enemies;
using NUnit.Framework;
using UnityEngine.TestTools;
using Action = Enemies.Combat.Action;

namespace Tests
{
    public class EditModeTests
    {
        private CombatSequencer com;

            [Test]
        public void TestTheTruth()
        {
          // Then
          Assert.True(true);
        }

        [Test]
        public void should_ReturnActionAlways100_When_GenerateNextActionByPropability()
        {
            // Given
            Mode mode = new Mode();
            mode.actions = new List<Action>();
            mode.actions.Add(new Action("never",10,0));
            mode.actions.Add(new Action("always",10,100));
            com = new CombatSequencer(mode,1);
            
            // When
            Action result = com.NextAction(GenerateActionMode.ByPropability);
            
            // Then
            Assert.True(result.getTriggerName().Equals("always"));
            Assert.True(Math.Abs(result.getDuration() - 10) < 0.01f);
        }
        
        // A Test behaves as an ordinary method
        [Test]
        public void should_ReturnActionsByInsertionOrder_When_GenerateActionsBySequence()
        {
            
            // Given
            Mode mode = new Mode();
            mode.generateActionMode = GenerateActionMode.InSequence;
            mode.actions = new List<Action>();
            mode.actions.Add(new Action("first",10,0));
            mode.actions.Add(new Action("second",10,100));
            mode.actions.Add(new Action("third",10,50));
            com = new CombatSequencer(mode,3);
            
            // When
            List<Action> result = new List<Action>();
            result.Add(com.NextAction(GenerateActionMode.InSequence));
            result.Add(com.NextAction(GenerateActionMode.InSequence));
            result.Add(com.NextAction(GenerateActionMode.InSequence));
            
            // Then
            Assert.AreSame(result[0].getTriggerName(), "first");
            Assert.AreSame(result[1].getTriggerName(), "second");
            Assert.AreSame(result[2].getTriggerName(), "third");
        }

        // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
        // `yield return null;` to skip a frame.
        [UnityTest]
        public IEnumerator CombatSequencerTestsWithEnumeratorPasses()
        {
            // Use the Assert class to test conditions.
            // Use yield to skip a frame.
            yield return null;
        }
    }
}

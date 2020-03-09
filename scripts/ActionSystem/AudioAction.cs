using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UIElements;

namespace Enemies.Combat
{
    [CreateAssetMenu(fileName = "AudioAction", menuName = "AudioAction", order = 0)]
    public class AudioAction : Action
    {
        [SerializeField] private AudioClip clip;
        [SerializeField] private AudioMixer mixer;
        [ReadOnlyAttribute] new readonly float duration;
        
        public AudioAction(string triggerName, float probability, AudioClip clip) 
        {
            this.triggerName = triggerName;
            this.probability = probability;
            duration = clip.length;
        }

        public override string getTriggerName()
        {
            return triggerName;
        }

        public override float getDuration()
        {
            float pitch = 1;
            mixer.GetFloat("pitch", out pitch);
            return clip.length / pitch;
        }
    }
}
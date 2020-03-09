using Enemies.Combat;
using UnityEngine;
using UnityEngine.Audio;

namespace DefaultNamespace
{
    [CreateAssetMenu(fileName = "AudioReaction", menuName = "AudioReaction", order = 0)]
    public class AudioReaction : Reaction
    {

        [SerializeField] private AudioClip clip;
        [SerializeField] private AudioMixer mixer;
        [ReadOnlyAttribute] new readonly float duration;
        
        public AudioReaction(string triggerName, float duration) : base(triggerName, duration)
        {
            duration = clip.length;
        }
        
        public override float getDuration()
        {
            float pitch = 1;
            mixer.GetFloat("pitch", out pitch);
            return clip.length / pitch;
        }
    }
}
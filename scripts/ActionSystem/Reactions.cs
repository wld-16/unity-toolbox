using System.Collections.Generic;
using UnityEngine;

namespace Enemies.Combat
{
    [CreateAssetMenu(fileName = "Reactions", menuName = "Reactions", order = 0)]
    public class Reactions:ScriptableObject
    {
        public List<Reaction> reactions;
    }
}
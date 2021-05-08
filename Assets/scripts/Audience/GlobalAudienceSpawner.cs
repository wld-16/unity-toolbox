using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace DefaultNamespace
{
    public class GlobalAudienceSpawner : MonoBehaviour
    {
        public List<AudienceSlotSpawner> audienceSlotSpawners = new List<AudienceSlotSpawner>();
        public string globalAudiencePath;

        public void GenerateAudience()
        {
            audienceSlotSpawners.ForEach(spawner => spawner.SpawnAtSlots());
        }

        public void ClearAudience()
        {
            audienceSlotSpawners.ForEach(spawner => spawner.DestroySlotsSpawns());
        }

        public void FetchSlotsSpawners()
        {
            audienceSlotSpawners.AddRange(transform.GetComponentsInChildren<AudienceSlotSpawner>());
        }

        public void ReloadSlotSpawners()
        {
            audienceSlotSpawners.ForEach(spawner =>
            {
                spawner.ClearSlots();
                spawner.ClearCharacters();
                spawner.FetchSlots();
                spawner.LoadCharacters();
            });
        }

        public void SetCharacterPaths()
        {
            audienceSlotSpawners.ForEach(spawner => spawner.pathToCharacters = globalAudiencePath);
        }
    }
}
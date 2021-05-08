using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

public class AudienceSlotSpawner : MonoBehaviour
{
    public string pathToCharacters;
    public List<GameObject> characterPool;
    public List<GameObject> slots;

    [SerializeField] private bool randomPitch = false;
    [SerializeField] private float pitchMin = 0.2f;
    [SerializeField] private float pitchMax = 1.5f;

    [SerializeField] [ReadOnly] private List<GameObject> audienceRow = new List<GameObject>();

    void Start()
    {
        if (audienceRow.Count == 0)
        {
            SpawnAtSlots();
        }
    }

    public void SpawnAtSlots()
    {
        slots.ForEach(slot =>
        {
            GameObject gameObject = Instantiate(characterPool[Random.Range(0, characterPool.Count)], slot.transform);
            if (randomPitch)
                ((AudioSource) Util.CheckForNull(gameObject.GetComponent<AudioSource>(), typeof(AudioSource),
                    gameObject)).pitch = Random.Range(pitchMin, pitchMax);
            audienceRow.Add(gameObject);
        });
    }

    public void DestroySlotsSpawns()
    {
        audienceRow.ForEach(DestroyImmediate);
        audienceRow.Clear();
    }

    public void ClearCharacters()
    {
        characterPool.Clear();
    }

    public void LoadCharacters()
    {
        List<string> assets = AssetDatabase.FindAssets("t:GameObject", new[] {pathToCharacters}).ToList();
        List<GameObject> gameObjects = assets
            .Select(guid => AssetDatabase.LoadAssetAtPath<GameObject>(AssetDatabase.GUIDToAssetPath(guid))).ToList();
        characterPool.AddRange(gameObjects);
    }

    public void ClearSlots()
    {
        slots.Clear();
    }

    public void FetchSlots()
    {
        List<GameObject> firstBornChildren =
            transform.GetComponentsInChildren<Transform>().ToList()
                .Where(child => child.parent.GetComponent<AudienceSlotSpawner>() != null)
                .Select(child => child.gameObject).ToList();

        slots.AddRange(firstBornChildren.ToList());
    }
}
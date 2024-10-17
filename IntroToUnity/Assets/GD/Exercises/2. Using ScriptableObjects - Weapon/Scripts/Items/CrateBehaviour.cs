using GD.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrateBehaviour : MonoBehaviour
{
    [SerializeField]
    [Tooltip("The transform where the item will be spawned")]
    private Transform spawnTransform;

    //[SerializeField]
    //[Tooltip("A list of ScriptableObjects that implement IInstantiatePrefab")]
    //[RequireInterface(typeof(IInstantiatePrefab))]
    //private List<ScriptableObject> items;

    [SerializeField]
    private SO_GameObjectList archetypes;

    private void Awake()
    {
        //check if the spawnTransform is set
        if (spawnTransform == null)
            throw new System.Exception("The spawnTransform is not set");
    }

    [ContextMenu("Generate Crate Item")]
    public void GenerateCrateItem()
    {
        //count how many archetypes are in the list
        int countItems = archetypes.Count();

        //get index of random game object
        var index = Random.Range(0, countItems);

        //get an archetype at the index
        var gameObject = archetypes[index];

        //add to the game by instantiating the prefab
        Instantiate(gameObject, spawnTransform);
    }
}
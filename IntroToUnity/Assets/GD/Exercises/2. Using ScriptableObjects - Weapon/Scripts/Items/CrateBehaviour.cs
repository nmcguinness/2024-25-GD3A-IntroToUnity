using System.Collections.Generic;
using UnityEngine;

public class CrateBehaviour : MonoBehaviour
{
    [SerializeField]
    [Tooltip("The transform where the item will be spawned")]
    private Transform spawnTransform;

    [SerializeField]
    [Tooltip("A list of ScriptableObjects that implement IInstantiatePrefab")]
    [RequireInterface(typeof(IInstantiatePrefab))]
    private List<ScriptableObject> items;

    private void Awake()
    {
        //check if the spawnTransform is set
        if (spawnTransform == null)
            throw new System.Exception("The spawnTransform is not set");
    }

    [ContextMenu("Generate Crate Item")]
    public void GenerateCrateItem()
    {
        //generate a random item from the items
        var index = Random.Range(0, items.Count);

        //obtain a reference to the generator
        var generator = items[index] as IInstantiatePrefab;

        var newItem = generator.Instantiate(spawnTransform);

        //apply impulse to the item

        //instanciate and output to the ground
    }
}
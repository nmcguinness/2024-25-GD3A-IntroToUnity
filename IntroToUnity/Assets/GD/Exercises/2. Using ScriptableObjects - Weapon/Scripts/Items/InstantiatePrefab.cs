using UnityEngine;

[CreateAssetMenu(fileName = "InstantiatePrefab",
    menuName = "SO/Instantiate/Item")]
public class InstantiatePrefab : ScriptableObject, IInstantiatePrefab
{
    [SerializeField]
    [Tooltip("The name of the item")]
    private string description;

    [SerializeField]
    [Tooltip("The prefab of the item")]
    private GameObject prefab;

    [SerializeField]
    [Tooltip("The item is active when generated")]
    private bool isGeneratedActive = true;

    public GameObject Instantiate(Transform transform)
    {
        //make an instance appear at the transform
        var item = Instantiate(prefab, transform);
        //set the item to active
        item.SetActive(isGeneratedActive);
        //return the item
        return item;
    }
}
using Sirenix.OdinInspector;
using UnityEngine;

public class Player : MonoBehaviour
{
    #region Fields

    public int health = 100;
    public int rank = 50;
    public bool hasHeroObject = false;

    [FoldoutGroup("Update Settings")]
    public float updateInterval = 1f;

    [FoldoutGroup("Update Settings")]
    public int updateRankBy = 20;

    [FoldoutGroup("Update Settings", expanded: false)]
    [ReadOnly]
    public float timeSinceUpdate = 0f;

    #endregion Fields

    private void Update()
    {
        timeSinceUpdate += Time.deltaTime;

        if (timeSinceUpdate >= updateInterval)
        {
            timeSinceUpdate = 0f;
            rank += updateRankBy;
        }
    }
}
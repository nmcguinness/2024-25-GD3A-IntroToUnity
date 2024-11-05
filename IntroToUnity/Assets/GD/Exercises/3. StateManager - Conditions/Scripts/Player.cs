using UnityEngine;

public class Player : MonoBehaviour
{
    public int health = 100;
    public int rank = 50;
    public bool hasHeroObject = false;

    public float timeSinceUpdate = 0f;
    public float updateInterval = 1f;
    public int updateRankBy = 20;

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
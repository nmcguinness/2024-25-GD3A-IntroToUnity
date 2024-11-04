using GD.State;
using UnityEngine;

[CreateAssetMenu(menuName = "GD/Conditions/Game/Player Rank")]
public class PlayerRankCondition : ConditionBase
{
    [SerializeField]
    private int rankThreshold = 1000;

    private Player player;

    private void Awake()
    {
        player = FindFirstObjectByType<Player>();

        if (player == null)
            throw new System.Exception("Player object not found in the scene.");
    }

    protected override bool EvaluateCondition()
    {
        return player.rank >= rankThreshold;
    }
}
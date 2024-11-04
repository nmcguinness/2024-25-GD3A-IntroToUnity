using GD.State;
using UnityEngine;

[CreateAssetMenu(menuName = "GD/Conditions/Game/Player Health")]
public class PlayerHealthCondition : ConditionBase
{
    [SerializeField]
    private int healthThreshold = 0;

    private Player player;

    private void Awake()
    {
        player = FindFirstObjectByType<Player>();

        if (player == null)
            throw new System.Exception("Player object not found in the scene.");
    }

    protected override bool EvaluateCondition()
    {
        return player.health < healthThreshold;
    }
}
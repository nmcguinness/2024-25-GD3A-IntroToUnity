using GD.Items;
using Sirenix.OdinInspector;
using System.Collections.Generic;
using UnityEngine;

namespace GD.State
{
    /// <summary>
    /// Manages the game state by evaluating win and loss conditions.
    /// </summary>
    public class StateManager : MonoBehaviour
    {
        [FoldoutGroup("Context", expanded: true)]
        [SerializeField]
        [Tooltip("Player reference to evaluate conditions required by the context")]
        private Player player;

        [FoldoutGroup("Context")]
        [SerializeField]
        [Tooltip("Player inventory collection to evaluate conditions required by the context")]
        private InventoryCollection inventoryCollection;

        [FoldoutGroup("Conditions", expanded: true)]
        [SerializeField]
        [Tooltip("Reset conditions on start")]
        private bool resetConditionsOnStart = true;

        /// <summary>
        /// The condition that determines if the player wins.
        /// </summary>
        [FoldoutGroup("Conditions")]
        [SerializeField]
        [Tooltip("The condition that determines if the player wins")]
        private ConditionBase winCondition;

        /// <summary>
        /// The condition that determines if the player loses.
        /// </summary>
        [FoldoutGroup("Conditions")]
        [SerializeField]
        [Tooltip("The condition that determines if the player loses")]
        private ConditionBase loseCondition;

        [SerializeField]
        [Tooltip("Set of optional conditions related to awards/quests")]
        private List<ConditionBase> awardConditions;

        /// <summary>
        /// Indicates whether the game has ended.
        /// </summary>
        private bool gameEnded = false;

        private ConditionContext conditionContext;

        private void Awake()
        {
            // Wrap the two objects inside the context envelope
            conditionContext = new ConditionContext(player, inventoryCollection);
        }

        private void Start()
        {
            if (resetConditionsOnStart)
                ResetConditions();
        }

        /// <summary>
        /// Evaluates conditions each frame and handles game state transitions.
        /// </summary>
        private void Update()  //TODO - NMCG : Slow down the update rate to once every 0.5 seconds
        {
            // If the game has already ended, no need to evaluate further
            if (gameEnded)
                return;

            // Evaluate the win condition
            if (winCondition != null && winCondition.Evaluate(conditionContext))
            {
                HandleWin();
                // Set gameEnded to true to prevent further updates
                gameEnded = true;
                // Optionally, disable this component
                // enabled = false;
            }
            // Evaluate the lose condition only if the win condition is not met
            else if (loseCondition != null && loseCondition.Evaluate(conditionContext))
            {
                HandleLoss();
                // Set gameEnded to true to prevent further updates
                gameEnded = true;
                // Optionally, disable this component
                // enabled = false;
            }

            foreach (var awardCondition in awardConditions)
            {
                if (awardCondition != null && awardCondition.Evaluate(conditionContext))
                {
                    //do something
                }
            }
        }

        /// <summary>
        /// Handles the logic when the player wins.
        /// </summary>
        protected virtual void HandleWin()
        {
            Debug.Log($"Player Wins! Win condition met at {winCondition.TimeMet} seconds.");

            // Implement win logic here, such as:
            // - Displaying a victory screen
            // - Transitioning to the next level
            // - Awarding points or achievements
            // - Playing a victory sound or animation

            // Example:
            // UIManager.Instance.ShowVictoryScreen();
            // SceneManager.LoadScene("NextLevel");
        }

        /// <summary>
        /// Handles the logic when the player loses.
        /// </summary>
        protected virtual void HandleLoss()
        {
            Debug.Log($"Player Loses! Lose condition met at {loseCondition.TimeMet} seconds.");

            // Implement loss logic here, such as:
            // - Displaying a game over screen
            // - Offering a restart option
            // - Reducing player lives
            // - Playing a defeat sound or animation

            // Example:
            // UIManager.Instance.ShowGameOverScreen();
            // GameManager.Instance.RestartLevel();
        }

        /// <summary>
        /// Resets the win and loss conditions.
        /// Call this method when restarting the game or level.
        /// </summary>
        public void ResetConditions()
        {
            // Reset the gameEnded flag
            gameEnded = false;

            // Reset the win condition
            if (winCondition != null)
                winCondition.ResetCondition();

            // Reset the lose condition
            if (loseCondition != null)
                loseCondition.ResetCondition();
        }
    }
}
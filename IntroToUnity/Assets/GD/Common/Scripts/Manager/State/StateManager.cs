using UnityEngine;

namespace GD.State
{
    /// <summary>
    /// Manages the game state by evaluating win and loss conditions.
    /// </summary>
    public class StateManager : MonoBehaviour
    {
        /// <summary>
        /// The condition that determines if the player wins.
        /// </summary>
        public ConditionBase winCondition;

        /// <summary>
        /// The condition that determines if the player loses.
        /// </summary>
        public ConditionBase loseCondition;

        /// <summary>
        /// Indicates whether the game has ended.
        /// </summary>
        private bool gameEnded = false;

        /// <summary>
        /// Evaluates conditions each frame and handles game state transitions.
        /// </summary>
        private void Update()
        {
            // If the game has already ended, no need to evaluate further
            if (gameEnded)
                return;

            // Evaluate the win condition
            if (winCondition != null && winCondition.Evaluate())
            {
                HandleWin();
                // Set gameEnded to true to prevent further updates
                gameEnded = true;
                // Optionally, disable this component
                // enabled = false;
            }
            // Evaluate the lose condition only if the win condition is not met
            else if (loseCondition != null && loseCondition.Evaluate())
            {
                HandleLoss();
                // Set gameEnded to true to prevent further updates
                gameEnded = true;
                // Optionally, disable this component
                // enabled = false;
            }
        }

        /// <summary>
        /// Handles the logic when the player wins.
        /// </summary>
        private void HandleWin()
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
        private void HandleLoss()
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
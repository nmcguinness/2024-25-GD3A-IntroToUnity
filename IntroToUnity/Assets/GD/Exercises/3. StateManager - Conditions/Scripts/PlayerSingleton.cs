namespace GD.Exercises
{
    /// <summary>
    /// A bad idea to use Singleton pattern in Unity.
    /// These variables are visible through the whole project.
    /// </summary>
    /// <example>
    ///
    /// PlayerSingleton.health = 100;
    /// var rank = PlayerSingleton.rank;
    ///
    /// </example>
    public static class PlayerSingleton
    {
        public static int health = 100;
        public static int rank = 1;
    }
}
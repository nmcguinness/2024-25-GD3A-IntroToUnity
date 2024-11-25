
using UnityEngine;

namespace GD.Toast
{
    /// <summary>
    /// Interface for creating toast objects.
    /// </summary>
    public interface IToastFactory
    {
        GameObject CreateToast(string message);
    }
}

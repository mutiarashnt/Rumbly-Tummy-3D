using UnityEngine;

public class PlayerSafeZone : MonoBehaviour
{
    public bool IsSafe { get; private set; }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("SafeZone"))
        {
            IsSafe = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("SafeZone"))
        {
            IsSafe = false;
        }
    }
}
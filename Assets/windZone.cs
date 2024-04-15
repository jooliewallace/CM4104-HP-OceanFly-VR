using UnityEngine;

public class WindZone : MonoBehaviour
{
    public float windStrength = 10f; // Adjust the strength of the wind
    public UnityEngine.Vector3 windDirection = UnityEngine.Vector3.right; // Adjust the direction of the wind

    private void OnTriggerStay(Collider other)
    {
        Rigidbody rb = other.GetComponent<Rigidbody>();
        if (rb != null)
        {
            // Calculate the force to apply based on wind strength and direction
            UnityEngine.Vector3 force = windStrength * windDirection.normalized;
            rb.AddForce(force, ForceMode.Force);
        }
    }
}

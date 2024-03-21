using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletSpeed = 10f;
    public float bulletLifetime = 3f;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.velocity = transform.forward * bulletSpeed;
        }
        else
        {
            Debug.LogWarning("Bullet prefab does not contain a Rigidbody component!");
        }

        Destroy(gameObject, bulletLifetime);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Zombie"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
            // Assuming there is a Gun script attached to the player or another GameObject,
            // you can access it to increment the kill count
            Gun gun = FindObjectOfType<Gun>();
            if (gun != null)
            {
                gun.IncrementKillCount();
            }
            else
            {
                Debug.LogWarning("No Gun script found in the scene!");
            }
        }
    }
}

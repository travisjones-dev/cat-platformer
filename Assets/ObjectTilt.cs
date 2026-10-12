using UnityEngine;

public class ObjectTilt : MonoBehaviour
{
    public float tiltSensitivity = 5f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Cat"))
        {
            Rigidbody2D rb = GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                float hitDirection = collision.transform.position.x < transform.position.x ? -1f : 1f;

                float catSpeed = collision.relativeVelocity.magnitude;
                rb.AddTorque(hitDirection * tiltSensitivity * catSpeed, ForceMode2D.Impulse);
            }
        }
    }
}
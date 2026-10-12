using UnityEngine;

public class KnockableObject : MonoBehaviour
{
    private bool isKnockedOver = false;
    public float newYValue = 0.5f;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Cat") && !isKnockedOver)
        {
            isKnockedOver = true;
            TriggerKnockOverBehaviour();

            Vector2 currentPosition = collision.transform.position;

            currentPosition.y = newYValue;

            collision.transform.position = currentPosition;
        }
    }

    private void TriggerKnockOverBehaviour()
    {
        Debug.Log(gameObject.name + "was knocked over by the Clark!");

    }
}
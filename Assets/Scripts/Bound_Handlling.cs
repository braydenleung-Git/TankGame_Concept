using UnityEngine;

public class ConstrainToBounds : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D objectCollider;

    void Start()
    {
        // Get the Rigidbody2D and BoxCollider2D components attached to the GameObject
        rb = GetComponent<Rigidbody2D>();
        objectCollider = GetComponent<BoxCollider2D>();
    }

    void FixedUpdate()
    {
        // Calculate the boundaries defined by the BoxCollider2D
        Vector2 minBounds = objectCollider.bounds.min;
        Vector2 maxBounds = objectCollider.bounds.max;

        // Get the current position of the object
        Vector2 newPosition = rb.position;

        // Clamp the object's position to stay within the collider bounds
        newPosition.x = Mathf.Clamp(newPosition.x, minBounds.x, maxBounds.x);
        newPosition.y = Mathf.Clamp(newPosition.y, minBounds.y, maxBounds.y);

        // Update the object's position
        rb.MovePosition(newPosition);
    }
}

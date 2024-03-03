using UnityEngine;

public class ConstrainToBounds : MonoBehaviour
{
    public BoxCollider2D boundCollider;
    private BoxCollider2D objectCollider;
    private Rigidbody2D rb;
    //private GameObject boundColliderObject;//part of deprecated code

    void Start()
    {
        // Get the Rigidbody2D and BoxCollider2D components attached to the GameObject
        objectCollider = GetComponent<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        //code deprecated/unused, kept as reference.
        /*
        if(boundColliderObject == null){
            boundColliderObject = new GameObject("BoundCollider");
            BoxCollider2D screenCollider = boundColliderObject.AddComponent<BoxCollider2D>();
            
            // Calculate the size of the collider based on the camera's orthographic size
            float cameraOrthographicSize = Camera.main.orthographicSize;
            float aspectRatio = Screen.width / (float)Screen.height;
            float cameraHeight = cameraOrthographicSize * 2;
            float cameraWidth = cameraHeight * aspectRatio;

            // Set the size of the collider to match the camera's viewport
            screenCollider.size = new Vector2(cameraWidth, cameraHeight);

            // Set the position of the bound collider GameObject to match the camera's position
            boundColliderObject.transform.position = Camera.main.transform.position;

            // Set the object's Rigidbody2D as a child of the bound collider GameObject
            objectCollider.transform.SetParent(boundColliderObject.transform);
        }

        if (objectCollider.IsTouching(boundColliderObject.GetComponent<BoxCollider2D>()))
        {
            Debug.Log("Object is colliding with the screen bounds!");
            
            // Perform actions if necessary, such as stopping movement or changing behavior
        }
        */
        // Calculate the bounds of the larger box collider
        float minX = boundCollider.bounds.min.x + objectCollider.bounds.extents.x;
        float maxX = boundCollider.bounds.max.x - objectCollider.bounds.extents.x;
        float minY = boundCollider.bounds.min.y + objectCollider.bounds.extents.y;
        float maxY = boundCollider.bounds.max.y - objectCollider.bounds.extents.y;

        // Get the clamped position of the object within the bounds
        float clampedX = Mathf.Clamp(transform.position.x, minX, maxX);
        float clampedY = Mathf.Clamp(transform.position.y, minY, maxY);

        // Update the position of the object
        rb.MovePosition(new Vector2(clampedX, clampedY));
    }
}

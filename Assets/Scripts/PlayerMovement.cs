using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovment : MonoBehaviour
{
    private Vector2 movement;//horizontal movement
    public float speed; //Controls velocity multiplier
    public InputAction moveAction;//imports the user input to the script
    [SerializeField]private Rigidbody2D rb;
    //[SerializeField]private Transform groundCheck;//used for jumping, not needed
    [SerializeField]private LayerMask groundLayer;//might not be needed, kept just in case for further usage

    // Start is called before the first frame update
    void Start()
    {
        moveAction.Enable();
    }

    void Update()
    {
        movement = moveAction.ReadValue<Vector2>();
    }
    //update on each physics frame
    void FixedUpdate()
    {
        float gradSpeed = speed / 5;
        speed = 0f;
        for(int i = 0; i < 5; i++)
        {
            speed += gradSpeed;
            rb.velocity = new Vector2(movement.x * speed, rb.velocity.y);
        }
        
    }

}
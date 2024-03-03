using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovment : MonoBehaviour
{
    public float speed; //Controls velocity multiplier
    public InputAction moveAction;
    private Rigidbody2D rb;
    public Vector2 movement;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        moveAction.Enable();
    }

    void Update()
    {
        movement = moveAction.ReadValue<Vector2>();
    }
    //update on each physics frame
    void FixedUpdate()
    {
        movement.y = 0f;
        //Debug.Log(movement);
        move(movement);
    }
    void move(Vector2 direction){
        //the current position + 
        rb.MovePosition((Vector2)transform.position + (direction * Time.fixedDeltaTime * speed ));
    }
}

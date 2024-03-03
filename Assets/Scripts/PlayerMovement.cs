using UnityEngine;

public class PlayerMovment : MonoBehaviour
{
    public float speed; //Controls velocity multiplier
    public Rigidbody rb;
    public Vector2 movement;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
    }

    void Update()
    {
        movement = new Vector2(Input.GetAxis("Horizontal"),Input.GetAxis("Vertical"));
    }
    //update on each physics frame
    void FixedUpdate()
    {
        move(movement);
    }
    void move(Vector2 direction){
        rb.MovePosition((Vector2)transform.position + (direction * speed * Time.deltaTime));
    }
}

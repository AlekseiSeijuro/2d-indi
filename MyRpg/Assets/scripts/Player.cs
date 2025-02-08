using UnityEngine;

public class Player : MonoBehaviour
{

    private Rigidbody2D body;

    private float horizontal;
    private float vertical;
    private float moveLimiter = 0.7f;
    public float runSpeed = 7.0f;
    
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    void Update()
    {

    }

    void FixedUpdate()
    {
        move();
    }

    void move(){
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        if (horizontal != 0 && vertical != 0)
        {
            horizontal *= moveLimiter;
            vertical *= moveLimiter;
        } 

        body.linearVelocity = new Vector2(horizontal * runSpeed, vertical * runSpeed);
    }

}

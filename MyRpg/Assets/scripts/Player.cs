using UnityEngine;

public class Player : MonoBehaviour
{

    private Rigidbody2D body;
    private Animator anim;

    private float horizontal;
    private float vertical;
    private float moveLimiter = 0.7f;
    private float runSpeed = 7.0f;
    
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
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
        
        anim.SetFloat("moveX", horizontal);
        anim.SetFloat("moveY", vertical);

        if (horizontal != 0 && vertical != 0)
        {
            horizontal *= moveLimiter;
            vertical *= moveLimiter;
        } 

        body.linearVelocity = new Vector2(horizontal * runSpeed, vertical * runSpeed);
    }

    private void OnCollisionEnter(Collision collision)
    {
        print("Collision detected");
    }

}

using UnityEngine;

public class Skelet : MonoBehaviour
{
    private Rigidbody2D body;
    private Animator anim;

    private float horizontal = 0;
    private float vertical = 1;
    private float moveLimiter = 0.7f;
    public float runSpeed = 3.0f;
    private int stepsCount = 0;
    public int stepsForRotate = 100;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        move();
    }

    public void move()
    {
        if (stepsCount >= stepsForRotate)
        {
            vertical = -vertical;
            stepsCount = 0;
        }
        stepsCount++;

        anim.SetFloat("moveX", horizontal);
        anim.SetFloat("moveY", vertical);

        if (horizontal != 0 && vertical != 0)
        {
            horizontal *= moveLimiter;
            vertical *= moveLimiter;
        }

        body.linearVelocity = new Vector2(horizontal * runSpeed, vertical * runSpeed);
    }
}

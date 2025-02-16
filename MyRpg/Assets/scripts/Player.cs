using UnityEngine;

public class Player : MonoBehaviour
{

    private Rigidbody2D body;
    private Animator anim;
    private GameObject hpHud;

    private float horizontal;
    private float vertical;
    private float moveLimiter = 0.7f;
    private float runSpeed = 7.0f;

    private int health = 3;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        hpHud = GameObject.Find("HP_hud");

        hpHud.GetComponent<HP_hud>().addHealth(health);
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

    void OnCollisionEnter(Collision collision)
    {
        print("Collision detected");
    }

    public void takeDamage(int damage)
    {
        health -= damage;
        hpHud.GetComponent<HP_hud>().popHealth(damage);
    }

    public void takeHeal(int heal)
    {
        health -= heal;
        hpHud.GetComponent<HP_hud>().addHealth(heal);
    }

    public int getHealth()
    {
        return health;
    }
}

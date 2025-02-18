using UnityEngine;

public class Player : MonoBehaviour
{

    private Rigidbody2D body;
    private Animator anim;
    private GameObject hpHud;

    public GameObject attackPrefab;

    private float horizontal;
    private float vertical;
    private float moveLimiter = 0.7f;
    private float runSpeed = 7.0f;

    private float attackDamage = 1;
    private float attackActiveTime = 1;
    private float attackActiveTimer = 0;
    private float attackRange = 1;

    private GameObject attackLocation;

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
        attack();
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

    private void attack()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition)-transform.position;
        if (Input.GetMouseButtonDown(0) && (attackLocation==null))
        {
            attackActiveTimer = attackActiveTime;
            makeAttack(mousePos);
        }
        else if((attackLocation!=null) && (attackActiveTimer<=0))
        {
            Destroy(attackLocation);
            attackLocation = null;
        }
        else if (attackActiveTimer > 0)
        {
            attackActiveTimer -= Time.deltaTime;
        }
    }

    private void makeAttack(Vector2 mouseLocation)
    {
        attackLocation = Instantiate(attackPrefab, transform);
        attackLocation.GetComponent<AttackScript>().setDamage(attackDamage);

        float k = Mathf.Sqrt(Mathf.Pow(mouseLocation.x, 2) + Mathf.Pow(mouseLocation.y, 2)) / attackRange; //опять коэфицент подобия, ебать его в рот

        attackLocation.transform.localPosition = mouseLocation/k;

    }
}

using UnityEngine;
using System.Collections.Generic;

public class Skelet : MonoBehaviour
{
    public GameObject bulletPrefab;

    private Rigidbody2D body;
    private Animator anim;
    private GameObject player;

    private float moveLimiter = 0.7f;
    private float runSpeed = 3.0f;

    private float shotCullDown = 2.0f;
    private float shotTimer;
    private List<GameObject> bullets;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        player = GameObject.Find("Player");
        shotTimer = shotCullDown;
        bullets = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        hauntPlayer();
        shot();
    }

    public void hauntPlayer()
    {
        float difX = player.transform.position.x - transform.position.x;
        float difY = player.transform.position.y - transform.position.y;

        float horizontal = Mathf.Sign(difX);
        float vertical = Mathf.Sign(difY);

        anim.SetFloat("moveX", horizontal);
        anim.SetFloat("moveY", vertical);

        if ((Mathf.Abs(difX) < 0.1) && (Mathf.Abs(difY) < 0.1))
        {
            anim.SetFloat("moveX", 0);
            anim.SetFloat("moveY", 0);
            body.linearVelocity = new Vector2(0, 0);
        }
        else if (Mathf.Abs(difX) < 0.1)
        {
            anim.SetFloat("moveX", 0);
            body.linearVelocity = new Vector2(0, vertical * runSpeed);
        }
        else if (Mathf.Abs(difY) < 0.1)
        {
            anim.SetFloat("moveY", 0);
            body.linearVelocity = new Vector2(horizontal * runSpeed, 0);
        }
        else
        {

            if (horizontal != 0 && vertical != 0)
            {
                horizontal *= moveLimiter;
                vertical *= moveLimiter;
            }

            body.linearVelocity = new Vector2(horizontal * runSpeed, vertical * runSpeed);
        }
    }

    public void shot()
    {
        shotTimer -= Time.deltaTime;
        if (shotTimer <= 0)
        {
            shotTimer = shotCullDown;
            bullets.Add(Instantiate(bulletPrefab, transform));
        }
    }
}

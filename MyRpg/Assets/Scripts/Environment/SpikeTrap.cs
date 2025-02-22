using UnityEngine;

public class SpikeTrap : MonoBehaviour
{
    private Animator anim;
    private BoxCollider2D spikeCollider;

    private float cullDown = 5.0f;
    private float activeTime = 1f;
    private float timer;
    private int damage = 1;
    private bool isDamaged = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        timer = cullDown;
        anim = GetComponent<Animator>();
        spikeCollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            timer = cullDown;
            spikeCollider.enabled = true;
            anim.SetBool("Activated", true);
        }
        else if(timer< cullDown - activeTime)
        {
            spikeCollider.enabled = false;
            anim.SetBool("Activated", false);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        switch (collision.tag)
        {
            case "PlayerFeet":
                if(!isDamaged)
                {
                    GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().takeDamage(damage);
                    isDamaged = true;
                }
                break;

            default:
                break;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        isDamaged = false;
    }
}

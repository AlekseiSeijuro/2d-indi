using UnityEngine;

public class AttackScript : MonoBehaviour
{
    private float damage;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collider)
    {

        switch (collider.tag)
        {
            case "Monster":
                collider.gameObject.GetComponent<Skelet>().takeDamage(damage);
                break;

            default:
                break;
        }

    }

    public void setDamage(float damage)
    {
        this.damage = damage;
    }
}

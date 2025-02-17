using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody2D body;
    private GameObject playerObject;
    private Player player;
    private int damage = 1;

    private float speed = 10.0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        playerObject = GameObject.Find("Player");
        player = playerObject.GetComponent<Player>();

        float difX = playerObject.transform.position.x - transform.position.x;
        float difY = playerObject.transform.position.y - transform.position.y;

        float k = Mathf.Sqrt(Mathf.Pow(difX,2)+Mathf.Pow(difY,2))/speed; //коэфицент подобия прямоугольных треугольников, епта

        body.linearVelocity = new Vector2(difX/k, difY/k);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D collider)
    {

        switch (collider.tag)
        {
            case "Player":
                player.takeDamage(damage);
                Destroy(this.gameObject);
                break;

            case "Monster":
                break;

            default:
                Destroy(this.gameObject);
                break;
        }

    }
}

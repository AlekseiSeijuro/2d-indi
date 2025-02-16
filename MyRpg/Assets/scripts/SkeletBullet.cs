using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody2D body;
    private GameObject player;

    private float speed = 10.0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        player = GameObject.Find("Player");

        float difX = player.transform.position.x - transform.position.x;
        float difY = player.transform.position.y - transform.position.y;

        float k = Mathf.Sqrt(Mathf.Pow(difX,2)+Mathf.Pow(difY,2))/speed; //коэфицент подобия прямоугольных треугольников, епта

        body.linearVelocity = new Vector2(difX/k, difY/k);
    }

    // Update is called once per frame
    void Update()
    {
    }

}

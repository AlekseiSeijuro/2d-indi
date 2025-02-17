using UnityEngine;
using System.Collections.Generic;
public class HP_hud : MonoBehaviour
{
    private Stack<GameObject> hpStack;
    private float lastXPosition = 0;
    private float heartOffset = 0.8f;

    public GameObject hpPrefab;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        hpStack = new Stack<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void addHealth(int health)
    {
        for (int i = 0; i < health; i++)
        {
            GameObject hpHeart = Instantiate(hpPrefab, transform);
            hpHeart.transform.Translate(new Vector3(lastXPosition, 0));
            hpStack.Push(hpHeart);
            lastXPosition += heartOffset;
        }
    }

    public void popHealth(int health)
    {
        if (hpStack.Count != 0)
        {
            for (int i = 0; i < health; i++)
            {
                Destroy(hpStack.Pop());
                lastXPosition -= heartOffset;
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible_NC : MonoBehaviour
{
    public int pointValue = 1;
    public int level = 1;
    public Manager_NC manager;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject, Random.Range(3, 5));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject gameObject = collision.gameObject;
        if (gameObject.tag == "Player")
        {
            manager.updateBalance(pointValue, level);
            Destroy(this.gameObject);
        }
    }
}

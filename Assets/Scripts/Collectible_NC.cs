using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible_NC : MonoBehaviour
{
    public Manager_NC manager;

    // Start is called before the first frame update
    void Start()
    {
        if (this.tag == "Coin")
        {
            Destroy(this.gameObject, Random.Range(3, 5));
        }
        if (this.tag == "Trophy")
        {
            Destroy(this.gameObject, Random.Range(5, 7));
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

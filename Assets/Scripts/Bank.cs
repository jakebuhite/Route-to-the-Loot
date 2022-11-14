using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Bank : MonoBehaviour
{

    public Manager_NC manager;

    private AudioSource cashSound;

    // Start is called before the first frame update
    void Start()
    {
        cashSound = this.GetComponent<AudioSource>();
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
            if (manager.onHand > 0)
            {
                cashSound.PlayOneShot(cashSound.clip, 0.75f);
                manager.updateBalance(manager.onHand);
            }
        }
    }
}

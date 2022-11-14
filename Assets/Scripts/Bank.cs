using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Bank : MonoBehaviour
{

    public Manager_NC manager;
    private ParticleSystem stars;

    private AudioSource cashSound;

    // Start is called before the first frame update
    void Start()
    {
<<<<<<< HEAD
        stars = GetComponent<ParticleSystem>();
        stars.Stop();
=======
        cashSound = this.GetComponent<AudioSource>();
>>>>>>> df930916852e4973ada58ee42d4b85c0f869406b
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
<<<<<<< HEAD
            StartCoroutine(PlayStars());
            manager.updateBalance(manager.onHand);
=======
            if (manager.onHand > 0)
            {
                cashSound.PlayOneShot(cashSound.clip, 0.75f);
                manager.updateBalance(manager.onHand);
            }
>>>>>>> df930916852e4973ada58ee42d4b85c0f869406b
        }
    }

    IEnumerator PlayStars()
    {
        if (manager.onHand > 0)
        {
            stars.Play();
            yield return new WaitForSeconds(1.5f);
            stars.Stop();
        }
        yield return new WaitForSeconds(1);
    }
}

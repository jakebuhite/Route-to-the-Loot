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
        stars = GetComponent<ParticleSystem>();
        stars.Stop();
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
            StartCoroutine(PlayStars());
            if (manager.onHand > 0)
            {
                cashSound.PlayOneShot(cashSound.clip, 0.75f);
                manager.updateBalance(manager.onHand);
            }
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

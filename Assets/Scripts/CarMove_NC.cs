using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMove_NC : MonoBehaviour
{
    public float speed;
    public Manager_NC manager;
    public GameObject bloodSplat;

    new private Renderer renderer;
<<<<<<< HEAD
    private GameObject blood;
=======
    private AudioSource thudSound;
>>>>>>> df930916852e4973ada58ee42d4b85c0f869406b

    // Start is called before the first frame update
    void Start()
    {
        renderer = this.GetComponent<Renderer>();
        thudSound = this.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position += (speed * Time.deltaTime * transform.up);
        if (!renderer.isVisible)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject gameObject = collision.gameObject;
        if (gameObject.tag == "Player")
        {
<<<<<<< HEAD
            blood = Instantiate(bloodSplat);
            blood.transform.position = collision.transform.position;
            Destroy(blood, 0.25f);
=======
            thudSound.PlayOneShot(thudSound.clip, 0.75f);
>>>>>>> df930916852e4973ada58ee42d4b85c0f869406b
            Destroy(gameObject);
            manager.PlayerRespawn();
        }
    }
}

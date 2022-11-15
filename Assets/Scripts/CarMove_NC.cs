using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMove_NC : MonoBehaviour
{
    public float speed;
    public Manager_NC manager;
    public GameObject bloodSplat;

    new private Renderer renderer;
    private GameObject blood;

    // Start is called before the first frame update
    void Start()
    {
        renderer = this.GetComponent<Renderer>();
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
            blood = Instantiate(bloodSplat);
            blood.transform.position = collision.transform.position;
            Destroy(blood, 0.25f);
            Destroy(gameObject);
            manager.PlayerRespawn();
        }
    }
}

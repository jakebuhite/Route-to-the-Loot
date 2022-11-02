using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMove_NC : MonoBehaviour
{
    public float speed;
    public Manager_NC manager;

    new private Renderer renderer;

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
            Destroy(gameObject);
            manager.PlayerRespawn();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMove_NC : MonoBehaviour
{
    public float speed;

    private Renderer renderer;

    // Start is called before the first frame update
    void Start()
    {
        renderer = this.GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position += new Vector3(0, speed * Time.deltaTime * transform.up.y, 0);
        if (!renderer.isVisible)
        {
            Destroy(this.gameObject);
        }
    }
}

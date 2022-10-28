using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager_NC : MonoBehaviour
{
    public GameObject slowCarPrefab;
    public GameObject fastCarPrefab;

    private GameObject slowCar;
    private GameObject fastCar;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnSlowCar());
        StartCoroutine(SpawnFastCar());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator SpawnSlowCar()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(1, 3));
            slowCar = Instantiate(slowCarPrefab);
            slowCar.transform.position = new Vector3(-5, -14, 0);
            slowCar.transform.Rotate(0, 0, 0);
        }
    }

    IEnumerator SpawnFastCar()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(1, 3));
            fastCar = Instantiate(fastCarPrefab);
            fastCar.transform.position = new Vector3(15, -14, 0);
            fastCar.transform.Rotate(0, 0, 0);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager_NC : MonoBehaviour
{
    public GameObject slowCarPrefab;
    public GameObject fastCarPrefab;
    public GameObject playerPrefab;

    public float balance = 0.0f;

    private GameObject slowCar;
    private GameObject fastCar;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(playerPrefab);
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
            slowCar.transform.position = new Vector3(-5.15f, -14, 0);
            slowCar.transform.Rotate(0, 0, 0);
            CarMove_NC slowCarInst = slowCar.GetComponent<CarMove_NC>();
            slowCarInst.manager = this;
        }
    }

    IEnumerator SpawnFastCar()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(1, 3));
            fastCar = Instantiate(fastCarPrefab);
            fastCar.transform.position = new Vector3(18.57f, -14, 0);
            fastCar.transform.Rotate(0, 0, 0);
            CarMove_NC fastCarInst = fastCar.GetComponent<CarMove_NC>();
            fastCarInst.manager = this;
        }
    }

    public void PlayerRespawn()
    {
        balance = 0;
        Instantiate(playerPrefab);
    }
}

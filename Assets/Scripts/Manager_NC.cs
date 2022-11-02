using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager_NC : MonoBehaviour
{
    public GameObject slowCarPrefab;
    public GameObject fastCarPrefab;
    public GameObject playerPrefab;
    public GameObject coinPrefab;
    public GameObject trophyPrefab;

    public float balance = 0.0f;

    private GameObject slowCar;
    private GameObject fastCar;
    private GameObject coin;
    private GameObject trophy;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(playerPrefab);
        StartCoroutine(SpawnSlowCar());
        StartCoroutine(SpawnFastCar());
        StartCoroutine(SpawnCoin());
        StartCoroutine(SpawnTrophy());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator SpawnSlowCar()
    {
        while (true)
        {
            int whereSpawn = Random.Range(0, 2);
            yield return new WaitForSeconds(Random.Range(1, 4));
            slowCar = Instantiate(slowCarPrefab);
            if (whereSpawn == 0)
            {
                slowCar.transform.position = new Vector3(-5.15f, -14, 0);
                slowCar.transform.Rotate(0, 0, 0);
            }
            if (whereSpawn == 1)
            {
                slowCar.transform.position = new Vector3(-7.9f, 12, 0);
                slowCar.transform.Rotate(0, 0, 180);
            }
            CarMove_NC slowCarInst = slowCar.GetComponent<CarMove_NC>();
            slowCarInst.manager = this;
        }
    }

    IEnumerator SpawnFastCar()
    {
        while (true)
        {
            int whereSpawn = Random.Range(0, 2);
            yield return new WaitForSeconds(Random.Range(1, 4));
            fastCar = Instantiate(fastCarPrefab);
            if (whereSpawn == 0)
            {
                fastCar.transform.position = new Vector3(18.57f, -14, 0);
                fastCar.transform.Rotate(0, 0, 0);
            }
            if (whereSpawn == 1)
            {
                fastCar.transform.position = new Vector3(15.9f, 12, 0);
                fastCar.transform.Rotate(0, 0, 180);
            }
            CarMove_NC fastCarInst = fastCar.GetComponent<CarMove_NC>();
            fastCarInst.manager = this;
        }
    }

    IEnumerator SpawnCoin()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(1, 3));
            coin = Instantiate(coinPrefab);
            coin.transform.position = new Vector3(Random.Range(-3.15f, 12.57f), Random.Range(-12, 13), 0);
            Collectible_NC coinInst = coin.GetComponent<Collectible_NC>();
            coinInst.manager = this;
        }
    }

    IEnumerator SpawnTrophy()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(5, 7));
            trophy = Instantiate(trophyPrefab);
            trophy.transform.position = new Vector3(Random.Range(20.57f, 25), Random.Range(-12, 13), 0);
            Collectible_NC trophyInst = trophy.GetComponent<Collectible_NC>();
            trophyInst.manager = this;
        }
    }

    public void PlayerRespawn()
    {
        balance = 0;
        Instantiate(playerPrefab);
    }
}

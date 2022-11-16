using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class Manager_NC : MonoBehaviour
{
    public GameObject slowCarPrefab;
    public GameObject fastCarPrefab;
    public GameObject playerPrefab;

    public GameObject[] lvl1Collectibles;
    public GameObject[] lvl2Collectibles;

    public int onHand = 0;

    public float balance = 0.0f;
    public float timer = 0.0f;
    public float goal = 0.0f;
    public TMP_Text balanceText;
    
    private GameObject slowCar;
    private GameObject fastCar;

    // Start is called before the first frame update
    void Start()
    {
        reset();
        Instantiate(playerPrefab);
        StartCoroutine(SpawnSlowCar());
        StartCoroutine(SpawnFastCar());
        StartCoroutine(SpawnLvl1());
        StartCoroutine(SpawnLvl2());
        StartCoroutine(SpawnLvl2());
        setGoal();
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

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
                slowCar.transform.position = new Vector3(-5.15f, -14, -2);
                slowCar.transform.Rotate(0, 0, 0);
            }
            if (whereSpawn == 1)
            {
                slowCar.transform.position = new Vector3(-7.9f, 12, -2);
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
                fastCar.transform.position = new Vector3(18.57f, -14, -2);
                fastCar.transform.Rotate(0, 0, 0);
            }
            if (whereSpawn == 1)
            {
                fastCar.transform.position = new Vector3(15.9f, 12, -2);
                fastCar.transform.Rotate(0, 0, 180);
            }
            CarMove_NC fastCarInst = fastCar.GetComponent<CarMove_NC>();
            fastCarInst.manager = this;
        }
    }

    public void updateBalance(int value)
    {
        balance += onHand;
        onHand = 0;
        updateOnHand(onHand);
        if (balance >= goal) {
            balanceText.text = ("Balance: $" + goal + "/" + goal);
            StartCoroutine(ChangeScene());
        } else
        {
            balanceText.text = ("Balance: $" + balance + "/" + goal);
        }
    }

    IEnumerator SpawnLvl1()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(2, 5));
            GameObject newObj = Instantiate(getRandomCollectible(1));
            newObj.transform.position = new Vector3(Random.Range(-3.15f, 12.57f), Random.Range(-12, 13), 0);
            Collectible_NC instance = newObj.GetComponent<Collectible_NC>();
            instance.manager = this;
        }
    }

    IEnumerator SpawnLvl2()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(5, 8));
            GameObject newObj = Instantiate(getRandomCollectible(2));
            newObj.transform.position = new Vector3(Random.Range(20.57f, 25), Random.Range(-12, 13), 0);
            Collectible_NC instance = newObj.GetComponent<Collectible_NC>();
            instance.manager = this;
        }
    }

    public void PlayerRespawn()
    {
        onHand = 0;
        Instantiate(playerPrefab);
        updateOnHand(onHand);
    }

    public GameObject getRandomCollectible(int level)
    {
        if (level == 2)
        {
            return lvl2Collectibles[Random.Range(0, lvl2Collectibles.Length)];
        }
        return lvl1Collectibles[Random.Range(0, lvl1Collectibles.Length)];
    }

    public void setGoal()
    {
        goal = 10 * Constants.C.difficulty;
        balanceText.text = ("Balance: " + balance + "/" + goal);
    }

    public void updateOnHand(int value)
    {
        onHand += value;
        Constants.C.onHand = onHand;
    }

    IEnumerator ChangeScene()
    {
        passTimer();
        yield return new WaitForSeconds(1);
        UnityEngine.SceneManagement.SceneManager.LoadScene("GameOver");

    }

    public void passTimer(){
        Constants.C.currentTime = timer;

    }
    public void reset() {
        timer = 0;
        onHand = 0;
        balance = 0;
    }
}

   
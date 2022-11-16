using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;



public class GameOver : MonoBehaviour
{
    public TMP_Text currentTimeTxt;
    public TMP_Text highScoreTxt;
    public float pastTime = 0;
    public int difficulty = 0;
    
    //public float fastestTimeKey

    //----- Private vars
    private GameObject player;
    private const string easyTimeKey = "high_Score1";
    private const string mediumTimeKey = "high_Score2";
    private const string hardTimeKey = "high_Score3";
    // Start is called before the first frame update
    void Start()
    {
        //PlayerPrefs.SetFloat(easyTimeKey, 50.0f);
        //PlayerPrefs.SetFloat(mediumTimeKey, 100.0f);
        //PlayerPrefs.SetFloat(hardTimeKey, 100.0f);    
        difficulty = Constants.C.difficulty;

        if (difficulty == 1)
        {
            easyOutput();
        }
        else if (difficulty == 2)
        {
            mediumOutput();
        }
        else
        {
            hardOutput();
        }
    }

    // Update is called once per frame
    void Update()
    {
        getInput();
    }

    public void easyOutput()
    {
        if (PlayerPrefs.HasKey(easyTimeKey))
        {
            pastTime = PlayerPrefs.GetFloat(easyTimeKey);
            //Debug.Log("Found Time" + pastTime);
        }
        else
        {
            PlayerPrefs.SetFloat(easyTimeKey, Constants.C.currentTime);
            //Debug.Log("Setting Fastest Time");
        }
        checkInitializedTimes();

        // Check if fastest time set
        if (pastTime > Constants.C.currentTime)
        {
            currentTimeTxt.text = "Time: " + Constants.C.currentTime.ToString("0") + " seconds";
            currentTimeTxt.color = new Color(178, 251, 165);
            highScoreTxt.text = "Highscore: " + pastTime.ToString("0") + " seconds";
            pastTime = Constants.C.currentTime;
            PlayerPrefs.SetFloat(easyTimeKey, Constants.C.currentTime);
        }
        else
        {
            currentTimeTxt.text = "Time: " + Constants.C.currentTime.ToString("0") + " seconds";
            highScoreTxt.text = "Highscore: " + pastTime.ToString("0") + " seconds";
        }
    }

    public void mediumOutput()
    {
        if (PlayerPrefs.HasKey(mediumTimeKey))
        {
            pastTime = PlayerPrefs.GetFloat(mediumTimeKey);
            //Debug.Log("Found Time" + pastTime);
        }
        else
        {
            PlayerPrefs.SetFloat(mediumTimeKey, Constants.C.currentTime);
            //Debug.Log("Setting High Score");
        }
        checkInitializedTimes();

        // Check if fastest time set
        if (pastTime >Constants.C.currentTime)
        {
            currentTimeTxt.text = "Time: " + Constants.C.currentTime.ToString("0") + " seconds";
            currentTimeTxt.color = new Color(178, 251, 165);
            highScoreTxt.text = "Highscore: " + pastTime.ToString("0") + " seconds";
            pastTime = Constants.C.currentTime;
            PlayerPrefs.SetFloat(mediumTimeKey, Constants.C.currentTime);
        }
        else
        {
            currentTimeTxt.text = "Time: " + Constants.C.currentTime.ToString("0") + " seconds";
            highScoreTxt.text = "Highscore: " + pastTime.ToString("0") + " seconds";
        }
    }

    public void hardOutput()
    {
        if (PlayerPrefs.HasKey(hardTimeKey))
        {
            pastTime = PlayerPrefs.GetFloat(hardTimeKey);
            //Debug.Log("Found Time" + pastTime);
        }
        else
        {
            PlayerPrefs.SetFloat(hardTimeKey, Constants.C.currentTime);
            //Debug.Log("Setting High Score");
        }
        checkInitializedTimes();

        // Check if fastest time set
        if (pastTime > Constants.C.currentTime)
        {
            currentTimeTxt.text = "Time: " + Constants.C.currentTime.ToString("0") + " seconds";
            currentTimeTxt.color = new Color(178, 251, 165);
            highScoreTxt.text = "Highscore: " + pastTime.ToString("0") + " seconds";
            pastTime = Constants.C.currentTime;
            PlayerPrefs.SetFloat(hardTimeKey, Constants.C.currentTime);
        }
        else
        {
            currentTimeTxt.text = "Time: " + Constants.C.currentTime.ToString("0") + " seconds";
            highScoreTxt.text = "Highscore: " + pastTime.ToString("0") + " seconds";
        }
    }


    private void getInput()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            Constants.C.difficulty = 0;
            StartCoroutine(ChangeScene());
        }
    }

    IEnumerator ChangeScene()
    {
        yield return new WaitForSeconds(0);
        UnityEngine.SceneManagement.SceneManager.LoadScene("Splash");
    }

    public void checkInitializedTimes() {
        if (pastTime == 0)
            pastTime = 200;
    }
}


    


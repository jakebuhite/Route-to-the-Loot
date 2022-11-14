using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;



public class GameOver : MonoBehaviour
{
    public TMP_Text text;
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
            Debug.Log("Found Time" + pastTime);
        }
        else
        {
            PlayerPrefs.SetFloat(easyTimeKey, Constants.C.currentTime);

            Debug.Log("Setting Fastest Time");
        }


        if (pastTime > Constants.C.currentTime)
        {
            text.text = ("You  set  the new  fastest  time  of:\n" + (int) Constants.C.currentTime + "  seconds! \n You  beat  the  previous  score  of:\n" + (int) pastTime + "  seconds \n Congrats!");
            pastTime = Constants.C.currentTime;
            PlayerPrefs.SetFloat(easyTimeKey, Constants.C.currentTime);
        }
        else
        {
            text.text = ("Your  score  was:\n" + (int) Constants.C.currentTime + "  seconds! \n The  current  highscore  is:\n" + (int) pastTime + "  seconds \n Better  luck  next  time!");

        }
    }

    public void mediumOutput()
    {
        if (PlayerPrefs.HasKey(mediumTimeKey))
        {
            pastTime = PlayerPrefs.GetFloat(mediumTimeKey);
            Debug.Log("Found Time" + pastTime);
        }
        else
        {
            PlayerPrefs.SetFloat(mediumTimeKey, Constants.C.currentTime);

            Debug.Log("Setting High Score");
        }


        if (pastTime >Constants.C.currentTime)
        {
            text.text = ("You  set  the  new  fastest  time  of:\n" + Constants.C.currentTime + "  seconds! \n You  beat  the  previous  score  of:\n" + pastTime + "  seconds \n Congrats!");
            pastTime = Constants.C.currentTime;
            PlayerPrefs.SetFloat(mediumTimeKey, Constants.C.currentTime);
        }
        else
        {
            text.text = ("Your  score  was:\n" + Constants.C.currentTime + "  seconds! \n The  current  highscore  is:\n" + pastTime + "  seconds \n Better  luck  next  time!");
        }
    }

    public void hardOutput()
    {
        if (PlayerPrefs.HasKey(hardTimeKey))
        {
            pastTime = PlayerPrefs.GetFloat(hardTimeKey);
            Debug.Log("Found Time" + pastTime);
        }
        else
        {
            PlayerPrefs.SetFloat(hardTimeKey, Constants.C.currentTime);

            Debug.Log("Setting High Score");
        }


        if (pastTime > Constants.C.currentTime)
        {
            text.text = ("You  set  the  new  fastest  time  of:\n" + Constants.C.currentTime + "  seconds! \n You  beat  the  previous  score  of:\n" + pastTime + "  seconds \n Congrats!");
            pastTime = Constants.C.currentTime;
            PlayerPrefs.SetFloat(hardTimeKey, Constants.C.currentTime);
        }
        else
        {
            text.text = ("Your  score  was:\n" + Constants.C.currentTime + "  seconds! \n The  current  highscore  is:\n" + pastTime + "  seconds \n Better  luck  next  time!");
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
}


    


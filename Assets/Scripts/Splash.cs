using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Splash : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        getInput();
        
    }

    IEnumerator ChangeScene()
    {

        yield return new WaitForSeconds(1);
        UnityEngine.SceneManagement.SceneManager.LoadScene("GameScene");

    }

    private void getInput()
    {

        
        if (Input.GetKey(KeyCode.Alpha1))
        {
            Constants.C.difficulty = 1;
            StartCoroutine(ChangeScene());
        }

        if (Input.GetKey(KeyCode.Alpha2))
        {
            Constants.C.difficulty = 2;
            StartCoroutine(ChangeScene());
        }

        if (Input.GetKey(KeyCode.Alpha3))
        {
            Constants.C.difficulty = 3;
            StartCoroutine(ChangeScene());
        }
    }
}
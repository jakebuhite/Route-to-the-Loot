using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Constants : MonoBehaviour
{
    static public Constants C;

    public float currentTime = 0.0f;

    public int difficulty = 0;
    public int onHand = 0;

    private void Awake()
    {
        C = this; // C now points to Constants for entire
                  // time the game runs
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

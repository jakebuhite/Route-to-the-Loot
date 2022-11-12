using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class OnhandText : MonoBehaviour
{
    public TMP_Text onHandText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void updateOnHandText(int onHand) {
        onHandText.text = "wjfbe"+onHand;

    }
}

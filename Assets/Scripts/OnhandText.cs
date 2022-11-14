using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class OnhandText : MonoBehaviour
{
    public TMP_Text onHandText;
   
    public int onHand = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (onHand != Constants.C.onHand) {
            updateOnHandText();
        }
    }

    public void updateOnHandText() {
        onHand = Constants.C.onHand;
        onHandText.text = "" + onHand;

    }
}

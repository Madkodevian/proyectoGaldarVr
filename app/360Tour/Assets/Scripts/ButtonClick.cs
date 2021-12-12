using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonClick : MonoBehaviour
{
    public void Click(){
        Debug.Log ("Button Clicked. TestClick.");
    }

    public string Button { get; set; }
}

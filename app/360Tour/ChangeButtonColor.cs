using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class ChangeButtonColor : MonoBehaviour
{
    public Color wantedColor;
    public Button button;

    public Color normalColor;
    public Color highlightedColor;
    public Color pressedColor;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ButtonColorChange(){
        ColorBlock cb = button.colors;
        cb.normalColor = wantedColor;
        normalColor = cb.normalColor;

        cb.highlightedColor = wantedColor;
        highlightedColor = cb.highlightedColor;

        cb.pressedColor = wantedColor;
        pressedColor = cb.pressedColor;

        button.colors = cb;
    }
}


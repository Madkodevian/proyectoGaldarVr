using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.UI;
using System.Linq;
//using ChangeButtonColor;


public class TestChangeButtonColor{
    
    public Color wantedColor;
    public Button button;

    //Assert

    [Test]
    public void TestColorChange(){
        //INSTANCIA NORMAL SIN EL MONOBEHAVIOUR
        //ChangeButtonColor boton = new ChangeButtonColor();

        //INSTANCIA CON EL MONOBEHAVIOUR
        GameObject botonGO = new GameObject();
        ChangeButtonColor boton = botonGO.AddComponent<ChangeButtonColor>();
        boton = botonGO.GetComponent<ChangeButtonColor>();

        //MyScript script = obj.AddComponent<MyScript>();

        //boton = new ChangeButtonColor();
        //boton.ButtonColorChange();
        Color newNormalColor = new Color(255f, 0f, 85f, 255f);
        boton.normalColor = newNormalColor;
        boton.highlightedColor = newNormalColor;
        boton.pressedColor = newNormalColor;
    
        Assert.AreNotEqual(boton.normalColor, wantedColor, "El color no es el seleccionado.");
        Assert.AreNotEqual(boton.highlightedColor, wantedColor, "El color no es el seleccionado.");
        Assert.AreNotEqual(boton.pressedColor, wantedColor, "El color no es el seleccionado.");
    }
}

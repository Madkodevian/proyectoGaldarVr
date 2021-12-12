using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Text.RegularExpressions;

public class SignIn : MonoBehaviour
{
    public GameObject username;
    public GameObject email;
    public GameObject password;
    public GameObject confPassword;
    private string Username;
    private string Email;
    private string Password;
    private string ConfPassword;
    private string form;
    private bool EmailValid = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void RegisterButton()
    {
        print ("Registration Sucessful");
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Tab))
        {
            if(username.GetComponent<InputField>().isFocused)
            {
                email.GetComponent<InputField>().Select();
            }

            if(email.GetComponent<InputField>().isFocused)
            {
                password.GetComponent<InputField>().Select();
            }

            if(password.GetComponent<InputField>().isFocused)
            {
                confPassword.GetComponent<InputField>().Select();
            }
        }

            if(Input.GetKeyDown(KeyCode.Return))
            {
                if(Password != "" && Email != "" && Password != "" && ConfPassword != "")
                {
                    RegisterButton();
                }
            }
            
            Username = username.GetComponent<InputField>().text;
            Email = email.GetComponent<InputField>().text;
            Password = password.GetComponent<InputField>().text;
            ConfPassword = confPassword.GetComponent<InputField>().text;
    }
}

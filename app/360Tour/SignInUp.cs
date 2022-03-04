using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// log in Register
/// </summary>

public class SignInUp : MonoBehaviour
{
    //  Login success page
    public GameObject signSucceed;

    //  registration page
    public GameObject signUp;
    public InputField upUserName;
    public InputField upPassword;
    public InputField passwordAgain;
    public Text upTips;

    //  log in page
    public GameObject signIn;
    public InputField inUserName;
    public InputField inPassword;
    public Text inTips;

    bool didSignedUp = false;
    bool didSignedIn = false;

    void Update()
    {
        if (didSignedUp)
        {
            didSignedUp = false;
            upTips.text = "If you register success, please return to the login page to log in!";
            Debug.Log("Successfully registered, jump to login page");
        }
        if (didSignedIn)
        {
            didSignedIn = false;
            Debug.Log("Successfully logged in, jump to login success page");
            signSucceed.SetActive(true);
            signIn.SetActive(false);
        }
    }

    public void OnBackClicked() //  Register page Return button
    {
        signIn.SetActive(true);
        signUp.SetActive(false);
    }

    public void OnUpSignUpClicked() //  Register page registration button
    {
        var pass = passwordAgain.text.Trim();

        if (!upPassword.text.Trim().Equals(pass))
        {
            upTips.text = "The password input twice is inconsistent, please re-enter!";
            return;
        }
        else if (upUserName.text.Trim() == "" || upPassword.text.Trim() == "" || pass == "")
        {
            upTips.text = "The username password cannot be empty, please re-enter!";
            return;
        }
        else
        {
            PlayerPrefs.SetString(upUserName.text, upPassword.text); //  Store with the username of key name
            Debug.Log("username:" + upUserName.text);
            Debug.Log("password:" + upPassword.text);
            OnBackClicked();
        }
    }

    public void OnSignInClicked() //  Login page login button
    {
        if (inUserName.text.Trim() == "" || inPassword.text.Trim() == "")
        {
            inTips.text = "The username password cannot be empty, please re-enter!";
        }
        else if (PlayerPrefs.GetString(inUserName.text.Trim()) == null)
        {
            inTips.text = "User does not exist! Please log in again after registration!";
        }
        else if (PlayerPrefs.GetString(inUserName.text.Trim()) != inPassword.text.Trim())
        {
            inTips.text = "User password is incorrect, please re-enter!";
        }
        else
        {
            didSignedIn = true;
        }
    }

    public void OnInSignUpClicked() //  Login page registration button
    {
        signUp.SetActive(true);
        signIn.SetActive(false);
    }

    public void OnQuitClicked() //  Login Success Page Exit button
    {
        Application.Quit();
        UnityEditor.EditorApplication.isPlaying = false;
    }
}

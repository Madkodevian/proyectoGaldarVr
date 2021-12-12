using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class userDatabase : MonoBehaviour
{
    public TextMeshProUGUI userText; 

    public void NewUser()
    {
        //Set user text to value returned
        User user = APIHelper.GetNewUser();
        userText.text = user.value;
    }
}

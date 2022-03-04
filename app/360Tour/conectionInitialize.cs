using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class conectionInitialize : MonoBehaviour
{
public void Awake() {
        Debug.Log("Initializating users...");
        GetRequestUser();
    }
     [ContextMenu("Test Get User")]
    public async void GetRequestUser() {
        var httpClient = new conectionUsers();
        var url = "http://localhost:8080/api/users";
        var result = await httpClient.Get(url);
        }
}

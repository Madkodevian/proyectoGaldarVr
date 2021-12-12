using UnityEngine;
using System.Net;
using System.IO;

public static class APIHelper
{
    public static User GetNewUser()
    {
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://localhost:8080/api/users");
        HttpWebResponse response = (HttpWebResponse)request.GetResponse();
        StreamReader reader = new StreamReader(response.GetResponseStream());
        string json = reader.ReadToEnd();
        return JsonUtility.FromJson<User>(json);
    }
}

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

using Newtonsoft.Json;
using System.Threading.Tasks;

public class conectionUsers : MonoBehaviour
{
public async Task<User> Get(string url) {

        using var www = UnityWebRequest.Get(url);
        www.SetRequestHeader("Content-Type", "application/json");

        var operation = www.SendWebRequest();

        while (!operation.isDone) {
            await Task.Yield();
        }

        var jsonResponse = www.downloadHandler.text;

        if (www.result != UnityWebRequest.Result.Success) {
            Debug.LogError($"Failed: {www.error}");
        }

        try {
            List<User> result = JsonConvert.DeserializeObject<List<User>>(jsonResponse);
            foreach (User user in result) {
                Debug.Log($"user id: {user.id},  user_name: {user.firstName}");
            }

            Debug.Log($"Success: {www.downloadHandler.text}");
            return result[0];
        } catch (UnityException ex) {
            Debug.LogError($"{this} could not parse json {jsonResponse}. {ex.Message}");
            return default;
        }

    }
}

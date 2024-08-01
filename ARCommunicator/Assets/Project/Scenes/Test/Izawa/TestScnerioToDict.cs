using System.Collections.Generic;
using UnityEngine;
using Firebase.Database;

public class SearchID : MonoBehaviour
{
    private DatabaseReference databaseReference;
    private ScenarioToDict scenarioToDict;
    private Dictionary<int, string> dict;

    void Start()
    {
        databaseReference = FirebaseDatabase.DefaultInstance.RootReference;
        scenarioToDict = new ScenarioToDict();
        dict = scenarioToDict.GetScenarioDictionary();
        AttachMessageListener("user1", UseMessage);
    }

    public void AttachMessageListener(string userId, System.Action<string> useMessage)
    {
        DatabaseReference messageReference = databaseReference.Child(userId).Child("message");
        messageReference.ValueChanged += (object sender, ValueChangedEventArgs args) =>
        {
            if (args.DatabaseError != null)
            {
                Debug.LogError(args.DatabaseError.Message);
                return;
            }

            if (args.Snapshot != null && args.Snapshot.Exists)
            {
                string message = args.Snapshot.Value as string;
                if (!string.IsNullOrWhiteSpace(message))
                {
                    useMessage(message);
                }
            }
            else
            {
                Debug.Log($"{userId} message changed but snapshot is null or doesn't exist.");
            }
        };
    }

    void UseMessage(string message)
    {
        Debug.Log("Received message: " + message);
        FindIDByMessage(message);
    }

    void FindIDByMessage(string message)
    {
        foreach (KeyValuePair<int, string> kvp in dict)
        {
            if (kvp.Value == message)
            {
                Debug.Log("Message: " + kvp.Value + ", ID: " + kvp.Key);
                return;
            }
        }

        Debug.Log("Message not found in dictionary.");
    }

    void OnDestroy()
    {
        if (databaseReference != null)
        {
            DetachMessageListener("user1");
        }
    }

    void DetachMessageListener(string userId)
    {
        DatabaseReference messageReference = databaseReference.Child(userId).Child("message");
        messageReference.ValueChanged -= (object sender, ValueChangedEventArgs args) =>
        {
            if (args.DatabaseError != null)
            {
                Debug.LogError(args.DatabaseError.Message);
                return;
            }

            if (args.Snapshot != null && args.Snapshot.Exists)
            {
                Debug.Log($"{userId} message changed: {args.Snapshot.Value}");
            }
            else
            {
                Debug.Log($"{userId} message changed but snapshot is null or doesn't exist.");
            }
        };
    }
}

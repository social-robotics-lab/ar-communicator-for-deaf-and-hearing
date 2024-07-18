using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Database;
using static Firebase.Extensions.TaskExtension;
using UnityEngine.UI;

public class GetIsDHHScript : MonoBehaviour
{
    private DatabaseReference reference;
    // Start is called before the first frame update
    void Start()
    {
        // Get the root reference location of the database.
        reference = FirebaseDatabase.DefaultInstance.RootReference;

        // 各ユーザのisDHHを取得
        GetIsDHH("user1");
        GetIsDHH("user2");
        GetIsDHH("user3");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void GetIsDHH(string userId)
    {
        reference.Child(userId).Child("isDHH")
          .GetValueAsync().ContinueWithOnMainThread(task => {
              
              if (task.IsFaulted)
              {
                  // Handle the error...
                  Debug.Log("Could not read Firebase a static snapshot");
                }
              else if (task.IsCompleted)
              {
                DataSnapshot snapshot = task.Result;
                  // Do something with snapshot...
                  Debug.Log($"{userId} is DHH: {snapshot.Value}");
                }
          });
    }
}

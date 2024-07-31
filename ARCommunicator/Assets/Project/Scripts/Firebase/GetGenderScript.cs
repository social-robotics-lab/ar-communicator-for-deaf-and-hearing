using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Database;
using static Firebase.Extensions.TaskExtension;
using UnityEngine.UI;
using System.Threading.Tasks;

public class GetGenderScript
{
    public async Task<string> GetGenderAsync(string userId)
    {
        string result = null;

        DatabaseReference reference = FirebaseDatabase.DefaultInstance.RootReference;

        await reference.Child(userId).Child("gender")
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
                  // Debug.Log($"{userId} is DHH: {snapshot.Value}");
                  result = (string)snapshot.Value;
              }
          });

        if (!string.IsNullOrWhiteSpace(result))
        {
            return result;
        }
        else
        {
            throw new System.ArgumentNullException($"{userId} gender is null");

        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Database;
using static Firebase.Extensions.TaskExtension;
using UnityEngine.UI;
using System.Threading.Tasks;

public class GetIsDHHScript : MonoBehaviour
{
    private DatabaseReference reference;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public async Task<bool> GetIsDHHAsync(string userId)
    {
        bool? result=null;

        reference = FirebaseDatabase.DefaultInstance.RootReference;

        await reference.Child(userId).Child("isDHH")
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
                  result = (bool)snapshot.Value;
                }
          });

        if (result is bool boolOfResult)
        {
            return boolOfResult;
        }
        else
        {
            throw new System.ArgumentNullException($"{userId} isDHH is null");

        }
    }
}

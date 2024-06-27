using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase.Extensions;
using Firebase;
using Firebase.Database;



public class DataBaseScript : MonoBehaviour
{
    private Firebase.FirebaseApp app;
    
    private DatabaseReference databaseReference;


    // Start is called before the first frame update
    void Start()
    {
        Firebase.FirebaseApp.CheckAndFixDependenciesAsync().ContinueWithOnMainThread(task => {
            var dependencyStatus = task.Result;
            if (dependencyStatus == Firebase.DependencyStatus.Available)
            {
                // FirebaseApp???????????????????
                app = Firebase.FirebaseApp.DefaultInstance;

                // Firebase???????????????????????
                Debug.Log("Firebase is ready to use.");

                // ???????????????
                databaseReference = FirebaseDatabase.DefaultInstance.RootReference;

                // ??????message???????????????
                AttachValueChangedListeners();
            }
            else
            {
                UnityEngine.Debug.LogError(System.String.Format(
                  "Could not resolve all Firebase dependencies: {0}", dependencyStatus));
                // Firebase Unity SDK is not safe to use here.
            }
        });

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void AttachValueChangedListeners()
    {
        // ?e???[?U?[??message?t?B?[???h?????X?????????????B
        AttachMessageListener("user1");
        AttachMessageListener("user2");
        AttachMessageListener("user3");
    }

    void AttachMessageListener(string userId)
    {
        DatabaseReference messageReference = databaseReference.Child(userId).Child("message");
        messageReference.ValueChanged += (object sender, ValueChangedEventArgs args) => {
            if (args.DatabaseError != null)
            {
                Debug.LogError(args.DatabaseError.Message);
                return;
            }

            if (args.Snapshot != null && args.Snapshot.Exists)
            {
                // ?????????f?[?^??????
                Debug.Log($"{userId} message changed: {args.Snapshot.Value}");
            }
            else
            {
                Debug.Log($"{userId} message changed but snapshot is null or doesn't exist.");
            }
        };
    }

    
    

    void OnDestroy()
    {
        
        if (databaseReference != null)
        {
            // ?e???[?U?[??message?t?B?[???h?????X?????????????????B
            DetachMessageListener("user1");
            DetachMessageListener("user2");
            DetachMessageListener("user3");
        }
    }

    void DetachMessageListener(string userId)
    {
        DatabaseReference messageReference = databaseReference.Child(userId).Child("message");

        messageReference.ValueChanged -= HandleValueChanged;
       
    }
    void HandleValueChanged(object sender, ValueChangedEventArgs args)
    {
        if (args.DatabaseError != null)
        {
            Debug.LogError(args.DatabaseError.Message);
            return;
        }

        if (args.Snapshot != null && args.Snapshot.Exists)
        {
            Debug.Log($"{args.Snapshot.Reference.Key} message changed: {args.Snapshot.Value}");
        }
        else
        {
            Debug.Log($"{args.Snapshot.Reference.Key} message changed but snapshot is null or doesn't exist.");
        }
    }
}

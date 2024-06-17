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
                // FirebaseAppのデフォルトインスタンスを取得します。
                app = Firebase.FirebaseApp.DefaultInstance;

                // Firebaseの準備が整ったことを示すフラグをセットします。
                Debug.Log("Firebase is ready to use.");

                // データベースのルート参照を取得
                databaseReference = FirebaseDatabase.DefaultInstance.RootReference;

                // 各ユーザーのmessageフィールドの変更を監視します。
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
        // 各ユーザーのmessageフィールドの変更を監視します。
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
                // 取得したデータの処理
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
            // 各ユーザーのmessageフィールドの変更監視を解除します。
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

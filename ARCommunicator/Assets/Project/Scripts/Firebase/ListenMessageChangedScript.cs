using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase.Extensions;
using Firebase;
using Firebase.Database;



public class ListenMessageChangedScript : MonoBehaviour
{
    private DatabaseReference databaseReference;

    // Start is called before the first frame update
    void Start()
    {
        // データベースのルート参照を取得
        databaseReference = FirebaseDatabase.DefaultInstance.RootReference;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public delegate void UseMessage(string message);

    public void AttachMessageListener(string userId, System.Action<string> UseMessage)
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
                if (!string.IsNullOrWhiteSpace((string)args.Snapshot.Value))
                {
                    UseMessage((string)args.Snapshot.Value);
                }
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

using System.Collections.Generic;
using UnityEngine;
using Firebase.Database;

public class SearchID : MonoBehaviour
{
    private DatabaseReference databaseReference;  // Firebase Realtime Databaseへの参照
    private ScenarioToDict scenarioToDict;        // ScenarioToDictクラスのインスタンス
    private Dictionary<int, string> dict;          // IDとメッセージの辞書
    private List<string> userIds = new List<string> { "user1", "user2", "user3" };  // 監視するユーザーのIDリスト

    void Start()
    {
        // Firebaseのデータベースのルート参照を取得
        databaseReference = FirebaseDatabase.DefaultInstance.RootReference;

        // ScenarioToDictを初期化し、辞書を取得
        scenarioToDict = new ScenarioToDict();
        dict = scenarioToDict.GetScenarioDictionary();

        // 各ユーザーに対してメッセージリスナーを設定
        foreach (string userId in userIds)
        {
            AttachMessageListener(userId, UseMessage);
        }
    }

    // メッセージリスナーを指定したユーザーに追加するメソッド
    public void AttachMessageListener(string userId, System.Action<string> useMessage)
    {
        DatabaseReference messageReference = databaseReference.Child(userId).Child("message");
        messageReference.ValueChanged += (object sender, ValueChangedEventArgs args) =>
        {
            // データベースエラーのチェック
            if (args.DatabaseError != null)
            {
                Debug.LogError(args.DatabaseError.Message);
                return;
            }

            // スナップショットが存在するかのチェック
            if (args.Snapshot != null && args.Snapshot.Exists)
            {
                // メッセージの取得と処理
                string message = args.Snapshot.Value as string;
                if (!string.IsNullOrWhiteSpace(message))
                {
                    useMessage(message);  // メッセージを使って処理を呼び出す
                }
            }
            else
            {
                Debug.Log($"{userId} message changed but snapshot is null or doesn't exist.");
            }
        };
    }

    // メッセージを受け取ってIDを検索するメソッド
    void UseMessage(string message)
    {
        Debug.Log("Received message: " + message);
        FindIDByMessage(message);  // メッセージからIDを検索するメソッドを呼び出す
    }

    // メッセージに基づいてIDを辞書から検索するメソッド
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

    // オブジェクトが破棄される際に呼ばれるメソッド
    void OnDestroy()
    {
        if (databaseReference != null)
        {
            // 各ユーザーのメッセージフィールドの変更監視を解除する
            foreach (string userId in userIds)
            {
                DetachMessageListener(userId);
            }
        }
    }

    // メッセージリスナーを指定したユーザーから削除するメソッド
    void DetachMessageListener(string userId)
    {
        DatabaseReference messageReference = databaseReference.Child(userId).Child("message");
        messageReference.ValueChanged -= (object sender, ValueChangedEventArgs args) =>
        {
            // データベースエラーのチェック
            if (args.DatabaseError != null)
            {
                Debug.LogError(args.DatabaseError.Message);
                return;
            }

            // スナップショットが存在するかのチェック
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

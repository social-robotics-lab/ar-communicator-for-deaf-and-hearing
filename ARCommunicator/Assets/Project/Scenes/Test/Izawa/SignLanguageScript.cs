using System.Collections.Generic;
using UnityEngine;
using Firebase.Database;

public class SearchIDHandler : MonoBehaviour
{
    private DatabaseReference databaseReference;
    private ScenarioToDict scenarioToDict;
    private Dictionary<int, string> dict;
    private List<string> userIds = new List<string> { "user1", "user2", "user3" };

    // Animatorの参照を追加
    public Animator animator;
    public string animatorParameterName = "MotionID"; // ここにAnimatorのパラメーター名を指定
    private const int idleMotionID = 0; // idleMotionのIDを定数として定義

    void Start()
    {
        // Firebaseのデータベースのルート参照を取得
        databaseReference = FirebaseDatabase.DefaultInstance.RootReference;

        // ScenarioToDictを初期化し、辞書を取得
        scenarioToDict = new ScenarioToDict();
        dict = scenarioToDict.GetScenarioDictionary();

        // 初期状態でAnimatorのパラメーターをidleMotionIDに設定
        if (animator != null)
        {
            animator.SetInteger(animatorParameterName, idleMotionID);
            Debug.Log("Animator parameter set to idleMotionID: " + idleMotionID);
        }
        else
        {
            Debug.LogError("Animator is not assigned.");
        }

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

                // AnimatorのパラメーターにIDを設定
                if (animator != null)
                {
                    animator.SetInteger(animatorParameterName, kvp.Key);
                    Debug.Log("Animator parameter set to ID: " + kvp.Key);
                }
                else
                {
                    Debug.LogError("Animator is not assigned.");
                }

                return;
            }
        }

        Debug.Log("Message not found in dictionary.");
    }
}

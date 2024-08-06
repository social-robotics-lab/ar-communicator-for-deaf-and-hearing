using System.Collections.Generic;
using UnityEngine;
using Firebase.Database;

public class SearchID : MonoBehaviour
{
    private DatabaseReference databaseReference;
    private ScenarioToDict scenarioToDict;
    private Dictionary<int, string> dict;

    // Animatorの参照を追加
    public Animator animator;
    public string animatorParameterName = "SignMessageId"; // ここにAnimatorのパラメーター名を指定

    // 監視するユーザーIDを指定できるようにするための変数
    public string targetUserId = "user1";

    // ScenarioIdMessageDictを定義
    private Dictionary<int, string> ScenarioIdMessageDict;

    void Start()
    {
        // Firebaseのデータベースのルート参照を取得
        databaseReference = FirebaseDatabase.DefaultInstance.RootReference;

        // ScenarioToDictを初期化し、辞書を取得
        scenarioToDict = new ScenarioToDict();
        dict = scenarioToDict.GetScenarioDictionary();
        ScenarioIdMessageDict = dict; // ScenarioIdMessageDictに辞書を設定

        // 特定のユーザーに対してメッセージリスナーを設定
        AttachMessageListener(targetUserId, UseMessage);
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
        foreach (KeyValuePair<int, string> kvp in ScenarioIdMessageDict)
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

                // SignLanguageメソッドを呼び出してAnimatorにIDを設定
                SignLanguage(kvp.Key);

                return;
            }
        }

        Debug.Log("Message not found in dictionary.");
    }

    // メッセージIDに基づいてAnimatorのパラメーターを設定するメソッド
    public void SignLanguage(int messageId)
    {
        if (animator != null)
        {
            animator.SetInteger("SignMessageId", messageId);
            Debug.Log("SignMessageId parameter set to ID: " + messageId);
        }
        else
        {
            Debug.LogError("Animator is not assigned.");
        }
    }
}

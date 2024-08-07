using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignLanguageScript : MonoBehaviour
{
    private GameObject Avatar;

    // Animatorの参照を追加
    public Animator animator;
    public string animatorParameterName = "SignMessageId"; // ここにAnimatorのパラメーター名を指定
    private Dictionary<int, string> ScenarioIdMessageDict; // ScenarioIdMessageDictを定義

    private void Start()
    {
        Avatar = this.gameObject;

        // ScenarioToDictを初期化し、辞書を取得
        ScenarioToDict scenarioToDict = new ScenarioToDict();
        Dictionary<int, string> dict = scenarioToDict.GetScenarioDictionary();
        ScenarioIdMessageDict = dict; // ScenarioIdMessageDictに辞書を設定
    }

    public void SignLanguage(string message)
    {
        Debug.Log($"this avatar is {Avatar.name}\nSignLanguageメソッド(message: {message})");

        foreach (KeyValuePair<int, string> kvp in ScenarioIdMessageDict)
        {
            if (kvp.Value == message)
            {
                // AnimatorのパラメーターにIDを設定
                if (animator != null)
                {
                    animator.SetInteger(animatorParameterName, kvp.Key);
                    animator.SetTrigger("MotionTrigger"); // トリガーをONにする
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

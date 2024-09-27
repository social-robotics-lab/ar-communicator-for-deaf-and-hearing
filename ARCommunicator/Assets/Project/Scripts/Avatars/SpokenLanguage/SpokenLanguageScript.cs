using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpokenLanguageScript : MonoBehaviour
{
    private GameObject Avatar;

    // AudioSourceをアタッチ
    public AudioSource audioSource;

    // Animatorにリンクする
    public Animator animator;

    // 69個の音声クリップを保持するリスト
    public List<AudioClip> audioClips;

    public string animatorParameterName = "SpokenMessageId"; // ここにAnimatorのパラメーター名を指定
    private Dictionary<int, string> ScenarioIdMessageDict; // ScenarioIdMessageDictを定義

    private void Start()
    {
        Avatar = this.gameObject;

        // ScenarioToDictを初期化し、辞書を取得
        ScenarioToDict scenarioToDict = new ScenarioToDict();
        Dictionary<int, string> dict = scenarioToDict.GetScenarioDictionary();
        ScenarioIdMessageDict = dict; // ScenarioIdMessageDictに辞書を設定

    }

    public void SpokenLanguage(string message)
    {
        Debug.Log($"this avatar is {Avatar.name}\nSpokenLanguageメソッド(message: {message})");

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
                    // 該当する音声を再生
                    audioSource.clip = audioClips[kvp.Key];
                    audioSource.Play();

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

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

                    // 音声再生完了まで待機してからパラメーターをリセット
                    StartCoroutine(WaitForAudioToFinishAndResetParameter(kvp.Key));
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

    // 音声再生が終わるまで待機し、その後パラメーターをリセット
    private IEnumerator WaitForAudioToFinishAndResetParameter(int key)
    {
        if (audioSource.clip != null)
        {
            // 音声の再生時間だけ待機
            yield return new WaitForSeconds(audioSource.clip.length);

            // 音声が終了したらAnimatorパラメーターをリセット
            if (animator != null)
            {
                animator.SetInteger(animatorParameterName, 0);
                Debug.Log("Animator parameter reset to 0 after audio finished.");
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoiceSync : MonoBehaviour
{
    // AudioSourceをアタッチ
    public AudioSource audioSource;

    // Animatorにリンクする
    public Animator animator;

    // 69個の音声クリップを保持するリスト
    public List<AudioClip> audioClips;

    // Animatorのパラメータ名
    private const string SpokenMessageIdParam = "SpokenMessageId";
    private const string MotionTriggerParam = "MotionTrigger";

    void Update()
    {
        // AnimatorのSpokenMessageIdを取得
        int messageId = animator.GetInteger(SpokenMessageIdParam);

        // MotionTriggerがトリガーされたか確認
        bool isMotionTriggered = animator.GetBool(MotionTriggerParam);

        // 69個の音声ファイルの範囲内かどうか確認
        if (messageId >= 0 && messageId < audioClips.Count && isMotionTriggered )
        {
            // 再生中でない場合のみ音声を再生する
            if (!audioSource.isPlaying)
            {
                // 該当する音声を再生
                audioSource.clip = audioClips[messageId];
                audioSource.Play();
            }
        }
    }
}

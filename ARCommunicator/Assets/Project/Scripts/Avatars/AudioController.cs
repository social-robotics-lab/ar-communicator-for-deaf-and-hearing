using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoiceSync : MonoBehaviour
{
    // AudioSource���A�^�b�`
    public AudioSource audioSource;

    // Animator�Ƀ����N����
    public Animator animator;

    // 69�̉����N���b�v��ێ����郊�X�g
    public List<AudioClip> audioClips;

    // Animator�̃p�����[�^��
    private const string SpokenMessageIdParam = "SpokenMessageId";
    private const string MotionTriggerParam = "MotionTrigger";

    void Update()
    {
        // Animator��SpokenMessageId���擾
        int messageId = animator.GetInteger(SpokenMessageIdParam);

        // MotionTrigger���g���K�[���ꂽ���m�F
        bool isMotionTriggered = animator.GetBool(MotionTriggerParam);

        // 69�̉����t�@�C���͈͓̔����ǂ����m�F
        if (messageId >= 0 && messageId < audioClips.Count && isMotionTriggered )
        {
            // �Đ����łȂ��ꍇ�̂݉������Đ�����
            if (!audioSource.isPlaying)
            {
                // �Y�����鉹�����Đ�
                audioSource.clip = audioClips[messageId];
                audioSource.Play();
            }
        }
    }
}

using System.Collections.Generic;
using UnityEngine;
using Firebase.Database;

public class SearchIDHandler : MonoBehaviour
{
    private DatabaseReference databaseReference;
    private ScenarioToDict scenarioToDict;
    private Dictionary<int, string> dict;
    private List<string> userIds = new List<string> { "user1", "user2", "user3" };

    // Animator�̎Q�Ƃ�ǉ�
    public Animator animator;
    public string animatorParameterName = "MotionID"; // ������Animator�̃p�����[�^�[�����w��
    private const int idleMotionID = 0; // idleMotion��ID��萔�Ƃ��Ē�`

    void Start()
    {
        // Firebase�̃f�[�^�x�[�X�̃��[�g�Q�Ƃ��擾
        databaseReference = FirebaseDatabase.DefaultInstance.RootReference;

        // ScenarioToDict�����������A�������擾
        scenarioToDict = new ScenarioToDict();
        dict = scenarioToDict.GetScenarioDictionary();

        // ������Ԃ�Animator�̃p�����[�^�[��idleMotionID�ɐݒ�
        if (animator != null)
        {
            animator.SetInteger(animatorParameterName, idleMotionID);
            Debug.Log("Animator parameter set to idleMotionID: " + idleMotionID);
        }
        else
        {
            Debug.LogError("Animator is not assigned.");
        }

        // �e���[�U�[�ɑ΂��ă��b�Z�[�W���X�i�[��ݒ�
        foreach (string userId in userIds)
        {
            AttachMessageListener(userId, UseMessage);
        }
    }

    // ���b�Z�[�W���X�i�[���w�肵�����[�U�[�ɒǉ����郁�\�b�h
    public void AttachMessageListener(string userId, System.Action<string> useMessage)
    {
        DatabaseReference messageReference = databaseReference.Child(userId).Child("message");
        messageReference.ValueChanged += (object sender, ValueChangedEventArgs args) =>
        {
            // �f�[�^�x�[�X�G���[�̃`�F�b�N
            if (args.DatabaseError != null)
            {
                Debug.LogError(args.DatabaseError.Message);
                return;
            }

            // �X�i�b�v�V���b�g�����݂��邩�̃`�F�b�N
            if (args.Snapshot != null && args.Snapshot.Exists)
            {
                // ���b�Z�[�W�̎擾�Ə���
                string message = args.Snapshot.Value as string;
                if (!string.IsNullOrWhiteSpace(message))
                {
                    useMessage(message);  // ���b�Z�[�W���g���ď������Ăяo��
                }
            }
            else
            {
                Debug.Log($"{userId} message changed but snapshot is null or doesn't exist.");
            }
        };
    }

    // ���b�Z�[�W���󂯎����ID���������郁�\�b�h
    void UseMessage(string message)
    {
        Debug.Log("Received message: " + message);
        FindIDByMessage(message);  // ���b�Z�[�W����ID���������郁�\�b�h���Ăяo��
    }

    // ���b�Z�[�W�Ɋ�Â���ID���������猟�����郁�\�b�h
    void FindIDByMessage(string message)
    {
        foreach (KeyValuePair<int, string> kvp in dict)
        {
            if (kvp.Value == message)
            {
                Debug.Log("Message: " + kvp.Value + ", ID: " + kvp.Key);

                // Animator�̃p�����[�^�[��ID��ݒ�
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

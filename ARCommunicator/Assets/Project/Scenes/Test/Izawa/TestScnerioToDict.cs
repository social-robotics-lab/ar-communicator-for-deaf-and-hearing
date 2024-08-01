using System.Collections.Generic;
using UnityEngine;
using Firebase.Database;

public class SearchID : MonoBehaviour
{
    private DatabaseReference databaseReference;  // Firebase Realtime Database�ւ̎Q��
    private ScenarioToDict scenarioToDict;        // ScenarioToDict�N���X�̃C���X�^���X
    private Dictionary<int, string> dict;          // ID�ƃ��b�Z�[�W�̎���
    private List<string> userIds = new List<string> { "user1", "user2", "user3" };  // �Ď����郆�[�U�[��ID���X�g

    void Start()
    {
        // Firebase�̃f�[�^�x�[�X�̃��[�g�Q�Ƃ��擾
        databaseReference = FirebaseDatabase.DefaultInstance.RootReference;

        // ScenarioToDict�����������A�������擾
        scenarioToDict = new ScenarioToDict();
        dict = scenarioToDict.GetScenarioDictionary();

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
                return;
            }
        }

        Debug.Log("Message not found in dictionary.");
    }

    // �I�u�W�F�N�g���j�������ۂɌĂ΂�郁�\�b�h
    void OnDestroy()
    {
        if (databaseReference != null)
        {
            // �e���[�U�[�̃��b�Z�[�W�t�B�[���h�̕ύX�Ď�����������
            foreach (string userId in userIds)
            {
                DetachMessageListener(userId);
            }
        }
    }

    // ���b�Z�[�W���X�i�[���w�肵�����[�U�[����폜���郁�\�b�h
    void DetachMessageListener(string userId)
    {
        DatabaseReference messageReference = databaseReference.Child(userId).Child("message");
        messageReference.ValueChanged -= (object sender, ValueChangedEventArgs args) =>
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
                Debug.Log($"{userId} message changed: {args.Snapshot.Value}");
            }
            else
            {
                Debug.Log($"{userId} message changed but snapshot is null or doesn't exist.");
            }
        };
    }
}

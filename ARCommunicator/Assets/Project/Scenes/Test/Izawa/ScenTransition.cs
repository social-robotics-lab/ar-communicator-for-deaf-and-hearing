using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    public GameObject[] avatars;  // �A�o�^�[�̔z��
    public string nextSceneName;  // �J�ڐ�̃V�[����

    private void Awake()
    {
        // �V�[�����܂����ł��̃I�u�W�F�N�g���j������Ȃ��悤�ɂ���
        DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
        // B�{�^���������ꂽ��V�[����ύX
        if (OVRInput.GetDown(OVRInput.Button.Two))  // B�{�^��
        {
            OnButtonClick();
        }
    }

    public void OnButtonClick()
    {
        SaveAvatarState();
        SceneManager.LoadScene(nextSceneName);  // �V�[�������[�h
    }

    // �A�o�^�[�̈ʒu�Ɖ�]��ۑ�
    void SaveAvatarState()
    {
        foreach (var avatar in avatars)
        {
            PlayerPrefs.SetFloat(avatar.name + "_posX", avatar.transform.position.x);
            PlayerPrefs.SetFloat(avatar.name + "_posY", avatar.transform.position.y);
            PlayerPrefs.SetFloat(avatar.name + "_posZ", avatar.transform.position.z);
            PlayerPrefs.SetFloat(avatar.name + "_rotY", avatar.transform.eulerAngles.y);
        }
    }

    // �A�o�^�[�̈ʒu�Ɖ�]��ǂݍ���
    void LoadAvatarState()
    {
        foreach (var avatar in avatars)
        {
            float posX = PlayerPrefs.GetFloat(avatar.name + "_posX", avatar.transform.position.x);
            float posY = PlayerPrefs.GetFloat(avatar.name + "_posY", avatar.transform.position.y);
            float posZ = PlayerPrefs.GetFloat(avatar.name + "_posZ", avatar.transform.position.z);
            float rotY = PlayerPrefs.GetFloat(avatar.name + "_rotY", avatar.transform.eulerAngles.y);

            avatar.transform.position = new Vector3(posX, posY, posZ);
            avatar.transform.rotation = Quaternion.Euler(0, rotY, 0);
        }
    }

    // �V�[�������[�h���ꂽ�Ƃ��ɃA�o�^�[�̈ʒu�Ɖ�]�𕜌�
    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        LoadAvatarState();
    }
}

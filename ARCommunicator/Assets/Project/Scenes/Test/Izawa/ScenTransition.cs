using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    public GameObject[] avatars;  // アバターの配列
    public string nextSceneName;  // 遷移先のシーン名

    private void Awake()
    {
        // シーンをまたいでこのオブジェクトが破棄されないようにする
        DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
        // Bボタンが押されたらシーンを変更
        if (OVRInput.GetDown(OVRInput.Button.Two))  // Bボタン
        {
            OnButtonClick();
        }
    }

    public void OnButtonClick()
    {
        SaveAvatarState();
        SceneManager.LoadScene(nextSceneName);  // シーンをロード
    }

    // アバターの位置と回転を保存
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

    // アバターの位置と回転を読み込み
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

    // シーンがロードされたときにアバターの位置と回転を復元
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

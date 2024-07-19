using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public class AvatarControllerScript : MonoBehaviour
{
    public string myUserId;
    public string partnerUserId;

    public GameObject partnerAvatar;


    private bool myIsDHH;
    private bool partnerIsDHH;

    // Start is called before the first frame update
    async void Start()
    {

        await SetIsDHHAsync();
        BehaviorAvatar();
    }

    private async Task SetIsDHHAsync()
    {
        GetIsDHHScript GetIsDHHScript = GameObject.Find("Firebase").GetComponent<GetIsDHHScript>();

        // 使用者のisDHHを取得
        try
        {
            myIsDHH = await GetIsDHHScript.GetIsDHHAsync(myUserId);
            Debug.Log($"my isDHH: {myIsDHH}");
        }
        catch (System.ArgumentNullException error)
        {
            Debug.LogError(error);
        }

        // 相手のisDHHを取得
        try
        {
            partnerIsDHH = await GetIsDHHScript.GetIsDHHAsync(partnerUserId);
            Debug.Log($"partner's isDHH: {partnerIsDHH}");
        }
        catch (System.ArgumentNullException error)
        {
            Debug.LogError(error);
        }
    }

    private void BehaviorAvatar()
    {
        ListenMessageChangedScript ListenMessageChangedScript = GameObject.Find("Firebase").GetComponent<ListenMessageChangedScript>();

        if (myIsDHH == true)
        {
            if (partnerIsDHH == true)
            {
                partnerAvatar.SetActive(false);
            }
            else
            {
                ListenMessageChangedScript.AttachMessageListener(partnerUserId, SignLanguage);
            }
        }
        else
        {
            if (partnerIsDHH == true)
            {
                ListenMessageChangedScript.AttachMessageListener(partnerUserId, Talk);
            }
        }
    }


    // Update is called once per frame
    void Update()
    {

    }


    // TODO: SignLanguageメソッドを別ファイルに切り出す
    public void SignLanguage(string message)
    {
        Debug.Log($"SignLanguageメソッド(message: {message})");
        // TODO: 相手のアバター(partnerAvatar)に手話させる
    }


    // TODO: Speech,Gesture,Talkメソッドを１つにまとめた別ファイルに切り出す
    public void Speech(string message)
    {
        Debug.Log($"Speechメソッド(message: {message})");
        // TODO: 相手のアバター(partnerAvatar)に発話させる
    }
    public void Gesture(string message)
    {
        Debug.Log($"Gestureメソッド(message: {message})");
        // TODO: 相手のアバター(partnerAvatar)にジェスチャーさせる
    }
    public void Talk(string message)
    {
        Speech(message);
        Gesture(message);
    }
}

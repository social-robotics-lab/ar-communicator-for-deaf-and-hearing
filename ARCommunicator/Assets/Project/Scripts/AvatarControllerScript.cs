using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
using Cysharp.Threading.Tasks;

public class AvatarControllerScript : MonoBehaviour
{
    private string myUserId;
    [HideInInspector] public string avatarUserId=null;

    private GameObject avatar;


    private bool myIsDHH;
    private bool partnerIsDHH;

    // Start is called before the first frame update
    async void Start()
    {
        avatar=this.gameObject;
        myUserId = avatar.GetComponentInParent<AllAvatarsManagerScript>().myUserId;

        await UniTask.WaitUntil(() => avatar.GetComponentInParent<AllAvatarsManagerScript>().isCompleted);

        if (string.IsNullOrWhiteSpace(avatarUserId))
        {
            Destroy(avatar);
        }
        else
        {
            Debug.Log($"{avatar.name} is {avatarUserId}");

            // 使用者と相手のisDHHを取得
            await SetIsDHHAsync();
            // messageから相手のアバターの振る舞いを決定
            BehaviorAvatar();
        }

    }

    private async Task SetIsDHHAsync()
    {
        GetIsDHHScript GetIsDHH = new GetIsDHHScript();

        // 使用者のisDHHを取得
        try
        {
            myIsDHH = await GetIsDHH.GetIsDHHAsync(myUserId);
            Debug.Log($"my isDHH: {myIsDHH}");
        }
        catch (System.ArgumentNullException error)
        {
            Debug.LogError(error);
        }

        // 相手のisDHHを取得
        try
        {
            partnerIsDHH = await GetIsDHH.GetIsDHHAsync(avatarUserId);
            Debug.Log($"this avatar is {avatar.name}\npartner's isDHH: {partnerIsDHH}");
        }
        catch (System.ArgumentNullException error)
        {
            Debug.LogError(error);
        }
    }

    private void BehaviorAvatar()
    {
        ListenMessageChangedScript ListenMessageChangedScript = GameObject.Find("Firebase").GetComponent<ListenMessageChangedScript>();

        SignLanguageScript SignLanguage = avatar.GetComponent<SignLanguageScript>(); ;
        SpokenLanguageScript SpokenLanguage = avatar.GetComponent<SpokenLanguageScript>();

        if (myIsDHH == true)
        {
            if (partnerIsDHH == true)
            {
                avatar.SetActive(false);
            }
            else
            {
                ListenMessageChangedScript.AttachMessageListener(avatarUserId,SignLanguage.SignLanguage);
            }
        }
        else
        {
            if (partnerIsDHH == true)
            {
                ListenMessageChangedScript.AttachMessageListener(avatarUserId, SpokenLanguage.SpokenLanguage);
            }
            else
            {
                avatar.SetActive(false);
            }
        }
    }


    // Update is called once per frame
    void Update()
    {

    }
}

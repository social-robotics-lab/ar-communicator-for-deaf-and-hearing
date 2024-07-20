using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public class AvatarControllerScript : MonoBehaviour
{
    public string myUserId;
    public string partnerUserId;

    private GameObject Avatar;


    private bool myIsDHH;
    private bool partnerIsDHH;

    // Start is called before the first frame update
    async void Start()
    {
        Avatar=this.gameObject;
        
        // 使用者と相手のisDHHを取得
        await SetIsDHHAsync();
        // messageから相手のアバターの振る舞いを決定
        BehaviorAvatar();
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
            partnerIsDHH = await GetIsDHH.GetIsDHHAsync(partnerUserId);
            Debug.Log($"this avatar is {Avatar.name}\npartner's isDHH: {partnerIsDHH}");
        }
        catch (System.ArgumentNullException error)
        {
            Debug.LogError(error);
        }
    }

    private void BehaviorAvatar()
    {
        ListenMessageChangedScript ListenMessageChangedScript = GameObject.Find("Firebase").GetComponent<ListenMessageChangedScript>();

        SignLanguageScript SignLanguage = Avatar.GetComponent<SignLanguageScript>(); ;
        SpokenLanguageScript SpokenLanguage = Avatar.GetComponent<SpokenLanguageScript>();

        if (myIsDHH == true)
        {
            if (partnerIsDHH == true)
            {
                Avatar.SetActive(false);
            }
            else
            {
                ListenMessageChangedScript.AttachMessageListener(partnerUserId,SignLanguage.SignLanguage);
            }
        }
        else
        {
            if (partnerIsDHH == true)
            {
                ListenMessageChangedScript.AttachMessageListener(partnerUserId, SpokenLanguage.SpokenLanguage);
            }
            else
            {
                Avatar.SetActive(false);
            }
        }
    }


    // Update is called once per frame
    void Update()
    {

    }
}

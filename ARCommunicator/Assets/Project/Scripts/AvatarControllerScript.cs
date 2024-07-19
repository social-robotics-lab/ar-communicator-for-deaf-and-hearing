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
        // 使用者と相手のisDHHを取得
        await SetIsDHHAsync();
        // messageから相手のアバターの振る舞いを決定
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

        SignLanguageScript SignLanguage = new SignLanguageScript();
        SpokenLanguageScript SpokenLanguage = new SpokenLanguageScript();

        if (myIsDHH == true)
        {
            if (partnerIsDHH == true)
            {
                partnerAvatar.SetActive(false);
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
        }
    }


    // Update is called once per frame
    void Update()
    {

    }
}

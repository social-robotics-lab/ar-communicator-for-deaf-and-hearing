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
        GetIsDHHScript getIsDHHScript = GameObject.Find("Firebase").GetComponent<GetIsDHHScript>();

        // 使用者のisDHHを取得
        try
        {
            myIsDHH = await getIsDHHScript.GetIsDHHAsync(myUserId);
            Debug.Log(myIsDHH);
        }
        catch (System.ArgumentNullException error)
        {
            Debug.LogError(error);
        }

        // 相手のisDHHを取得
        try
        {
            partnerIsDHH = await getIsDHHScript.GetIsDHHAsync(partnerUserId);
            Debug.Log(partnerIsDHH);
        }
        catch(System.ArgumentNullException error)
        {
            Debug.LogError(error);
        }
    }


    // Update is called once per frame
    void Update()
    {
        if (myIsDHH == true)
        {
            if (partnerIsDHH == true)
            {
                partnerAvatar.SetActive(false);
            }
            else
            {
                // TODO: 相手のmessageの変更を取得
                // TODO: 相手のアバター(partnerAvatar)に手話させる
            }
        }
        else
        {
            if (partnerIsDHH == true)
            {
                // TODO: 相手のmessageの変更を取得
                // TODO: 相手のアバター(partnerAvatar)に発話＆ジェスチャーさせる
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvatarControllerScript : MonoBehaviour
{
    public string myUserId;
    public string partnerUserId;

    public GameObject partnerAvatar;

    private bool myIsDHH;
    private bool partnerIsDHH;

    // Start is called before the first frame update
    void Start()
    {
        // TODO: 使用者のisDHHを取得
        myIsDHH = true;
        // TODO: 相手のisDHHを取得
        partnerIsDHH = false;
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

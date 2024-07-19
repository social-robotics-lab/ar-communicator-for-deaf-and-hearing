using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignLanguageScript : MonoBehaviour
{
    private GameObject Avatar;

    private void Start()
    {
        Avatar = this.gameObject;
    }

    public void SignLanguage(string message)
    {
        Debug.Log($"this avatar is {Avatar.name}\nSignLanguageメソッド(message: {message})");
        // TODO: 相手のアバター(Avatar)に手話させる
    }

}

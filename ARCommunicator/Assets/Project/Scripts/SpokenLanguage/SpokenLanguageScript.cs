using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpokenLanguageScript : MonoBehaviour
{
    private GameObject Avatar;

    private void Start()
    {
        Avatar = this.gameObject;
    }

    private void Speech(string message)
    {
        Debug.Log($"Speechメソッド(message: {message})");
        // TODO: 相手のアバター(partnerAvatar)に発話させる
    }
    private void Gesture(string message)
    {
        Debug.Log($"Gestureメソッド(message: {message})");
        // TODO: 相手のアバター(partnerAvatar)にジェスチャーさせる
    }
    public void SpokenLanguage(string message)
    {
        Speech(message);
        Gesture(message);
    }

}

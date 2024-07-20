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
        Debug.Log($"this avatar is {Avatar.name}\nSpeechメソッド(message: {message})");
        // TODO: 相手のアバター(Avatar)に発話させる
    }
    private void Gesture(string message)
    {
        Debug.Log($"this avatar is {Avatar.name}\nGestureメソッド(message: {message})");
        // TODO: 相手のアバター(Avatar)にジェスチャーさせる
    }
    public void SpokenLanguage(string message)
    {
        Speech(message);
        Gesture(message);
    }

}

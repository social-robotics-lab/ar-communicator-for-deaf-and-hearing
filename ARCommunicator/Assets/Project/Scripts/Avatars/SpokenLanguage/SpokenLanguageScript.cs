using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SpokenLanguageScript : MonoBehaviour
{
    private GameObject avatar;
    public GameObject face;
    private Animator animator;
    public AudioClip sound1;
    AudioSource audioSource;

    private void Start()
    {
        avatar = this.gameObject;
    }

    private void Speech(string message)
    {
        Debug.Log($"this avatar is {avatar.name}\nSpeechメソッド(message: {message})");

        // TODO: 相手のアバター(avatar)に発話させる
        //UserIdの取得
        //string avatarUserId = avatar.GetComponent<AvatarControllerScript>().avatarUserId;

        
        animator = face.GetComponent<Animator>();
        audioSource = face.GetComponent<AudioSource>();
        //Bool型のパラメーターをTrueにする
        animator.SetBool("blTalk", true);
        //サウンドを再生
        audioSource.PlayOneShot(sound1);


    }
    private void Gesture(string message)
    {
        Debug.Log($"this avatar is {avatar.name}\nGestureメソッド(message: {message})");
        // TODO: 相手のアバター(avatar)にジェスチャーさせる
    }
    public void SpokenLanguage(string message)
    {
        Speech(message);
        Gesture(message);
    }

}

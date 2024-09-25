using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnSelectUserButtonClickedScript : MonoBehaviour
{

    public OnButtonClickedScript onButtonClickedScript;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnUser1Clicked()
    {
        onButtonClickedScript.userId = "user1";
    }

    public void OnUser2Clicked()
    {
        onButtonClickedScript.userId = "user2";
    }

    public void OnUser3Clicked()
    {
        onButtonClickedScript.userId = "user3";
    }

}

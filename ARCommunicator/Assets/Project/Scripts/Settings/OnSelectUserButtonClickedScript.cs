using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnSelectUserButtonClickedScript : MonoBehaviour
{

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
        OnButtonClickedScript.userId = "user1";
    }

    public void OnUser2Clicked()
    {
        OnButtonClickedScript.userId = "user2";
    }

    public void OnUser3Clicked()
    {
        OnButtonClickedScript.userId = "user3";
    }

}

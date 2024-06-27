using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserDataScript : MonoBehaviour
{

    public class UserData
    {
        public bool isDHH;

        public void SetUserData(bool isDHH)
        {
            this.isDHH = isDHH;
        }
    }

    public UserData User1;
    public UserData User2;
    public UserData User3;

    private void Awake()
    {
        User1 = new UserData();
        User2 = new UserData();
        User3 = new UserData();
    }
}

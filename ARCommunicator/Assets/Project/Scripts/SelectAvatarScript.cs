using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectAvatarScript : MonoBehaviour
{
    public GameObject Avatar1;
    public GameObject Avatar2;
    public GameObject Avatar3;
    public GameObject Avatar4;

    // Start is called before the first frame update
    async void Start()
    {
        Destroy(Avatar1);
        Destroy(Avatar2);

        GetGenderScript GetGender = new GetGenderScript();

        string gender;
        gender = await GetGender.GetGenderAsync("user1");
        Debug.Log(gender);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

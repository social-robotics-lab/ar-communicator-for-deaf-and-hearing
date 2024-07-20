using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectAvatarScript : MonoBehaviour
{
    public string myUserId;

    public int numberOfUsers;

    public GameObject[] maleAvatars;
    public GameObject[] femaleAvatars;

    // Start is called before the first frame update
    async void Start()
    {
        VerifyAvatars(numberOfUsers, maleAvatars);
        VerifyAvatars(numberOfUsers, femaleAvatars);
        //Destroy(maleAvatars[0]);
        //Destroy(maleAvatars[1]);

        GetGenderScript GetGender = new GetGenderScript();

        string gender;
        gender = await GetGender.GetGenderAsync("user1");
        Debug.Log(gender);
    }

    private void VerifyAvatars(int numberOfUsers, GameObject[] avatars)
    {
        HashSet<GameObject> avatarsHashSet = new HashSet<GameObject>();
        foreach(GameObject avatar in avatars)
        {
            if (avatarsHashSet.Add(avatar) == false)
            {
                Debug.LogError($"{avatar.name} is already used. Attach a different avatar.");
            }
            if (avatar == null)
            {
                Debug.LogError("An avatar is null. Attach all avatars.");
            }
        }

        if (avatars.Length < numberOfUsers - 1)
        {
            Debug.LogError($"There are not enough avatars. At least {numberOfUsers - 1} avatars are required.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

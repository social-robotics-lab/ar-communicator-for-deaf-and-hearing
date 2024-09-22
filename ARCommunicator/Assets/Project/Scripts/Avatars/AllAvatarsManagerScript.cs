using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using System.Linq;
using System;

public class AllAvatarsManagerScript : MonoBehaviour
{
    public string myUserId;

    public int numberOfUsers;

    public GameObject[] maleAvatars;
    public GameObject[] femaleAvatars;

    private string[] userIds;

    public InitializeFirebaseScript initializeFirebaseScript;

    [HideInInspector] public bool isCompleted=false;

    // Start is called before the first frame update
    async void Start()
    {
        VerifyAvatars(numberOfUsers, maleAvatars);
        VerifyAvatars(numberOfUsers, femaleAvatars);

        userIds = GenerateUserIds(numberOfUsers);

        await UniTask.WaitUntil(() => initializeFirebaseScript.isCompleted);

        await AssignUserIdToAvatarByGender(userIds, maleAvatars, femaleAvatars);
        Debug.Log("userId assigned to avatar is completed.");
        isCompleted = true;
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

        if (avatars.Length < numberOfUsers)
        {
            Debug.LogError($"There are not enough avatars. At least {numberOfUsers} avatars are required.");
        }
    }

    private string[] GenerateUserIds(int numberOfUsers)
    {
        string[] userIds = new string[numberOfUsers];

        for(int i=0; i<numberOfUsers; i++)
        {
            userIds[i] = $"user{i+1}";
        }

        return userIds;
    }

    private async Task AssignUserIdToAvatarByGender(string[] userIds, GameObject[] maleAvatars, GameObject[] femaleAvatars)
    {
        GetGenderScript GetGender = new GetGenderScript();

        for(int i=0;i<numberOfUsers; i++)
        {
            string gender = null;
            string userId = userIds[i];

            if (userId != myUserId)
            {
                try
                {
                    gender = await GetGender.GetGenderAsync(userId);
                    if (gender != null)
                    {
                        if (gender == "m")
                        {
                            maleAvatars[i].GetComponent<AvatarControllerScript>().avatarUserId = userId;
                        }
                        else
                        {
                            femaleAvatars[i].GetComponent<AvatarControllerScript>().avatarUserId = userId;
                        }
                    }
                }
                catch(System.NullReferenceException error)
                {
                    Debug.LogError(error);
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

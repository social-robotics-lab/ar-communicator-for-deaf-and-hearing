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
        myUserId = OnButtonClickedScript.userId;

        Debug.Log($"My userId is {myUserId}.");

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

        if (avatars.Length < numberOfUsers - 1)
        {
            Debug.LogError($"There are not enough avatars. At least {numberOfUsers - 1} avatars are required.");
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

        GameObject[] randomMaleAvatars = maleAvatars.OrderBy(i => Guid.NewGuid()).ToArray();
        GameObject[] randomFemaleAvatars = femaleAvatars.OrderBy(i => Guid.NewGuid()).ToArray();

        int maleCount = 0;
        int femaleCount = 0;
        foreach (string userId in userIds)
        {
            if (userId != myUserId)
            {
                try
                {
                    string gender = null;
                    gender = await GetGender.GetGenderAsync(userId);
                    if (gender != null)
                    {
                        if (gender == "m")
                        {
                            randomMaleAvatars[maleCount].GetComponent<AvatarControllerScript>().avatarUserId = userId;
                            maleCount++;
                        }
                        else
                        {
                            randomFemaleAvatars[femaleCount].GetComponent<AvatarControllerScript>().avatarUserId = userId;
                            femaleCount++;
                        }
                    }
                }
                catch (System.ArgumentNullException error)
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

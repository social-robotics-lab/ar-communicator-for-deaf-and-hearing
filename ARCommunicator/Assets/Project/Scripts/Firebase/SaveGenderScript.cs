using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Database;
using UnityEngine.UI;


public class SaveGenderScript : MonoBehaviour
{
    public string userId;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void WriteGender(string userId, string newGender)
    {
        DatabaseReference databaseReference = FirebaseDatabase.DefaultInstance.RootReference;

        DatabaseReference genderReference = databaseReference.Child(userId).Child("gender");
        genderReference.SetValueAsync(newGender);
    }
}

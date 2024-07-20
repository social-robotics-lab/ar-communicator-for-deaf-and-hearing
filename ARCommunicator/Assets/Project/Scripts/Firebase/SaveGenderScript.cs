using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Database;
using UnityEngine.UI;


public class SaveGenderScript : MonoBehaviour
{
    public Button femaleButton;
    public Button maleButton;

    public string userId;
    private DatabaseReference databaseReference;
    // Start is called before the first frame update
    void Start()
    {
        // Get the root reference location of the database.
        databaseReference = FirebaseDatabase.DefaultInstance.RootReference;

        femaleButton.onClick.AddListener(() => WriteGender(userId, "f"));
        maleButton.onClick.AddListener(() => WriteGender(userId, "m"));
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void WriteGender(string userId, string newGender)
    {
        DatabaseReference genderReference = databaseReference.Child(userId).Child("gender");
        genderReference.SetValueAsync(newGender);
    }
}

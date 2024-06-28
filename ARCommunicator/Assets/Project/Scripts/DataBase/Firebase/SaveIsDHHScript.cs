using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Database;
using UnityEngine.UI;

public class SaveIsDHHScript : MonoBehaviour
{
    public Button TrueButton;
    public Button FalseButton;

    public string userId;
    private DatabaseReference databaseReference;
    // Start is called before the first frame update
    void Start()
    {
        // Get the root reference location of the database.
        databaseReference = FirebaseDatabase.DefaultInstance.RootReference;

        TrueButton.onClick.AddListener(()=>WriteIsDHH(userId,true));
        FalseButton.onClick.AddListener(() => WriteIsDHH(userId, false));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void WriteIsDHH(string userId, bool newIsDHH)
    {
        DatabaseReference isDHHReference = databaseReference.Child(userId).Child("isDHH");
        isDHHReference.SetValueAsync(newIsDHH);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Database;

public class SaveIsDHHScript : MonoBehaviour
{
    private DatabaseReference databaseReference;
    // Start is called before the first frame update
    void Start()
    {
        // Get the root reference location of the database.
        databaseReference = FirebaseDatabase.DefaultInstance.RootReference;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void WriteIsDHH(string userId, bool newIsDHH)
    {
        DatabaseReference isDHHReference = databaseReference.Child(userId).Child("isDHH");
        isDHHReference.SetValueAsync(newIsDHH);
    }
}

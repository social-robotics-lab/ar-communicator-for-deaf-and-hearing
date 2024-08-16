using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Database;
using UnityEngine.UI;

public class SaveIsDHHScript : MonoBehaviour
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

    public void WriteIsDHH(string userId, bool newIsDHH)
    {
        DatabaseReference databaseReference = FirebaseDatabase.DefaultInstance.RootReference;

        DatabaseReference isDHHReference = databaseReference.Child(userId).Child("isDHH");
        isDHHReference.SetValueAsync(newIsDHH);
    }
}

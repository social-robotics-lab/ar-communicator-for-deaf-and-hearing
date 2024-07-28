using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnButtonSelected : MonoBehaviour
{
    public GameObject Firebase;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnMaleButtonSelected()
    {
        SaveGenderScript SaveGender = Firebase.GetComponent<SaveGenderScript>();
        SaveGender.WriteGender("user1", "m");

    }
}

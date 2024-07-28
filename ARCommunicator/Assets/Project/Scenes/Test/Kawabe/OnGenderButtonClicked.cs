using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnGenderButtonClicked : MonoBehaviour
{
    public SaveGenderScript SaveGenderScript;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnMaleButtonClicked()
    {
        SaveGenderScript.WriteGender(SaveGenderScript.userId, "m");
    }

    public void OnFemaleButtonClicked()
    {
        SaveGenderScript.WriteGender(SaveGenderScript.userId, "f");
    }
}

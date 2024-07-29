using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnButtonClickedScript : MonoBehaviour
{
    public SaveIsDHHScript saveIsDHHScript;

    public SaveGenderScript saveGenderScript;
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
        saveGenderScript.WriteGender(saveGenderScript.userId, "m");
    }

    public void OnFemaleButtonClicked()
    {
        saveGenderScript.WriteGender(saveGenderScript.userId, "f");
    }

    public void OnDeafButtonClicked()
    {
        saveIsDHHScript.WriteIsDHH(saveIsDHHScript.userId, true);
    }

    public void OnHearingButtonClicked()
    {
        saveIsDHHScript.WriteIsDHH(saveIsDHHScript.userId, false);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class OnButtonClickedScript : MonoBehaviour
{

    public SaveIsDHHScript saveIsDHHScript;

    public SaveGenderScript saveGenderScript;

    public TextMeshProUGUI displayCurrentUserId;

    public string mainSceneName;


    [HideInInspector] public static string userId;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        displayCurrentUserId.text = userId;
        
    }


    public void OnMaleButtonClicked()
    {
        saveGenderScript.WriteGender(userId, "m");
    }

    public void OnFemaleButtonClicked()
    {
        saveGenderScript.WriteGender(userId, "f");
    }

    public void OnDeafButtonClicked()
    {
        saveIsDHHScript.WriteIsDHH(userId, true);
    }

    public void OnHearingButtonClicked()
    {
        saveIsDHHScript.WriteIsDHH(userId, false);
    }

    public void OnStartButtonClicked()
    {
        //メインシーンに移動
        Debug.Log("Move to main scene.");
        SceneManager.LoadScene(mainSceneName);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectAvatarScript : MonoBehaviour
{
    public GameObject Avatar1;
    public GameObject Avatar2;
    public GameObject Avatar3;
    public GameObject Avatar4;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(Avatar1);
        Destroy(Avatar2);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

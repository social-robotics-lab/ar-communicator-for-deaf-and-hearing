using UnityEngine;

public class AvatarPositionControllerScript : MonoBehaviour
{
    public GameObject[] avatars;  // ???????????A?o?^?[???????z????????
    private int currentAvatarIndex = 0;  // ?????????????A?o?^?[???C???f?b?N?X

    public float moveSpeed = 1.0f;  // ?????X?s?[?h
    public float rotateSpeed = 60.0f;  // ???]?X?s?[?h
    private bool isControlEnabled = true;  // ?R???g???[?????L???E??????????

    void Start()
    {
        // ???????A?o?^?[?????????????????I??
        SelectAvatar(currentAvatarIndex);
    }

    void Update()
    {
        // B?{?^?????R???g???[?????L??/??????????????
        if (OVRInput.GetDown(OVRInput.Button.Two))  // B?{?^??
        {
            isControlEnabled = !isControlEnabled;
        }

        // A?{?^?????????????????A?o?^?[??????????
        if (OVRInput.GetDown(OVRInput.Button.One) && isControlEnabled)  // A?{?^??
        {
            SwitchAvatar();
        }

        // ?R???g???[?????L???????????????A?o?^?[??????
        if (isControlEnabled)
        {
            ControlAvatar(avatars[currentAvatarIndex]);
        }
    }

    // ?A?o?^?[?????????????????????\?b?h
    void SwitchAvatar()
    {
        currentAvatarIndex++;
        if (currentAvatarIndex >= avatars.Length)
        {
            currentAvatarIndex = 0;
        }
        SelectAvatar(currentAvatarIndex);
    }

    // ?I???????A?o?^?[???????????????????A?????????????o?I??????
    void SelectAvatar(int index)
    {
        for (int i = 0; i < avatars.Length; i++)
        {
            // ??: ?A?o?^?[???F?????????A?I???????A?o?^?[?????o?I??????
            if (i == index)
            {
                avatars[i].GetComponent<Renderer>().material.color = Color.red;  // ?I?????????A?o?^?[?????F
            }
            else
            {
                avatars[i].GetComponent<Renderer>().material.color = Color.white;  // ?????????A?o?^?[?????F
            }
        }
    }

    // ?I?????????A?o?^?[???R???g???[???[??????
    void ControlAvatar(GameObject avatar)
    {
        Vector2 leftStickInput = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick);  // ???X?e?B?b?N
        Vector2 rightStickInput = OVRInput.Get(OVRInput.Axis2D.SecondaryThumbstick);  // ?E?X?e?B?b?N

        // ???????? (?O?????E)
        Vector3 moveDirection = new Vector3(leftStickInput.x, 0, leftStickInput.y);
        avatar.transform.position += moveDirection * moveSpeed * Time.deltaTime;

        // ???]?????i???E???]?j
        float rotation = rightStickInput.x * rotateSpeed * Time.deltaTime;
        avatar.transform.Rotate(Vector3.up, rotation);

        // ?{?^?????????????????i?????????j
        if (OVRInput.Get(OVRInput.Button.PrimaryHandTrigger))  // ?g???K?[?{?^????????
        {
            avatar.transform.position += Vector3.up * moveSpeed * Time.deltaTime;
        }
        if (OVRInput.Get(OVRInput.Button.SecondaryHandTrigger))  // ?t?g???K?[?????~
        {
            avatar.transform.position -= Vector3.up * moveSpeed * Time.deltaTime;
        }
    }
}

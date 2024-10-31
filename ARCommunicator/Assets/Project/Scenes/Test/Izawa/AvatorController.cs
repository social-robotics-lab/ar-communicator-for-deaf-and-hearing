using UnityEngine;

public class AvatarController : MonoBehaviour
{
    public GameObject[] avatars;  // ����Ώۂ̃A�o�^�[������z��ŊǗ�
    private int currentAvatarIndex = 0;  // ���ݑ��쒆�̃A�o�^�[�̃C���f�b�N�X

    public float moveSpeed = 1.0f;  // �ړ��X�s�[�h
    public float rotateSpeed = 60.0f;  // ��]�X�s�[�h
    private bool isControlEnabled = true;  // �R���g���[���̗L���E�������Ǘ�

    void Start()
    {
        // �ŏ��̃A�o�^�[�𑀍�ΏۂƂ��đI��
        SelectAvatar(currentAvatarIndex);
    }

    void Update()
    {
        // B�{�^���ŃR���g���[���̗L��/������؂�ւ�
        if (OVRInput.GetDown(OVRInput.Button.Two))  // B�{�^��
        {
            isControlEnabled = !isControlEnabled;
        }

        // A�{�^�����������Ƃ��ɃA�o�^�[��؂�ւ�
        if (OVRInput.GetDown(OVRInput.Button.One) && isControlEnabled)  // A�{�^��
        {
            SwitchAvatar();
        }

        // �R���g���[�����L���ȏꍇ�ɂ̂݃A�o�^�[�𑀍�
        if (isControlEnabled)
        {
            ControlAvatar(avatars[currentAvatarIndex]);
        }
    }

    // �A�o�^�[�̑����؂�ւ��郁�\�b�h
    void SwitchAvatar()
    {
        currentAvatarIndex++;
        if (currentAvatarIndex >= avatars.Length)
        {
            currentAvatarIndex = 0;
        }
        SelectAvatar(currentAvatarIndex);
    }

    // �I�𒆂̃A�o�^�[�ɖڈ������ȂǁA�؂�ւ������o�I�Ɏ���
    void SelectAvatar(int index)
    {
        for (int i = 0; i < avatars.Length; i++)
        {
            // ��: �A�o�^�[�̐F��ς��āA�I�𒆂̃A�o�^�[�����o�I�ɋ��
            if (i == index)
            {
                avatars[i].GetComponent<Renderer>().material.color = Color.red;  // �I�����ꂽ�A�o�^�[�͗ΐF
            }
            else
            {
                avatars[i].GetComponent<Renderer>().material.color = Color.white;  // ���̑��̃A�o�^�[�͔��F
            }
        }
    }

    // �I�����ꂽ�A�o�^�[���R���g���[���[�ő���
    void ControlAvatar(GameObject avatar)
    {
        Vector2 leftStickInput = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick);  // ���X�e�B�b�N
        Vector2 rightStickInput = OVRInput.Get(OVRInput.Axis2D.SecondaryThumbstick);  // �E�X�e�B�b�N

        // �ړ����� (�O�㍶�E)
        Vector3 moveDirection = new Vector3(leftStickInput.x, 0, leftStickInput.y);
        avatar.transform.position += moveDirection * moveSpeed * Time.deltaTime;

        // ��]�����i���E��]�j
        float rotation = rightStickInput.x * rotateSpeed * Time.deltaTime;
        avatar.transform.Rotate(Vector3.up, rotation);

        // �{�^�����͂ō��������i�㉺�ړ��j
        if (OVRInput.Get(OVRInput.Button.PrimaryHandTrigger))  // �g���K�[�{�^���ŏ㏸
        {
            avatar.transform.position += Vector3.up * moveSpeed * Time.deltaTime;
        }
        if (OVRInput.Get(OVRInput.Button.SecondaryHandTrigger))  // �t�g���K�[�ŉ��~
        {
            avatar.transform.position -= Vector3.up * moveSpeed * Time.deltaTime;
        }
    }
}

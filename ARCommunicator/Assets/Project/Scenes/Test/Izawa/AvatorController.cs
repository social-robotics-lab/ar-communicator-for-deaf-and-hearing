using UnityEngine;

public class AvatarController : MonoBehaviour
{
    public GameObject[] avatars;  // 操作対象のアバターたちを配列で管理
    private int currentAvatarIndex = 0;  // 現在操作中のアバターのインデックス

    public float moveSpeed = 1.0f;  // 移動スピード
    public float rotateSpeed = 60.0f;  // 回転スピード
    private bool isControlEnabled = true;  // コントロールの有効・無効を管理

    void Start()
    {
        // 最初のアバターを操作対象として選択
        SelectAvatar(currentAvatarIndex);
    }

    void Update()
    {
        // Bボタンでコントロールの有効/無効を切り替え
        if (OVRInput.GetDown(OVRInput.Button.Two))  // Bボタン
        {
            isControlEnabled = !isControlEnabled;
        }

        // Aボタンを押したときにアバターを切り替え
        if (OVRInput.GetDown(OVRInput.Button.One) && isControlEnabled)  // Aボタン
        {
            SwitchAvatar();
        }

        // コントロールが有効な場合にのみアバターを操作
        if (isControlEnabled)
        {
            ControlAvatar(avatars[currentAvatarIndex]);
        }
    }

    // アバターの操作を切り替えるメソッド
    void SwitchAvatar()
    {
        currentAvatarIndex++;
        if (currentAvatarIndex >= avatars.Length)
        {
            currentAvatarIndex = 0;
        }
        SelectAvatar(currentAvatarIndex);
    }

    // 選択中のアバターに目印をつけるなど、切り替えを視覚的に示す
    void SelectAvatar(int index)
    {
        for (int i = 0; i < avatars.Length; i++)
        {
            // 例: アバターの色を変えて、選択中のアバターを視覚的に区別
            if (i == index)
            {
                avatars[i].GetComponent<Renderer>().material.color = Color.red;  // 選択されたアバターは緑色
            }
            else
            {
                avatars[i].GetComponent<Renderer>().material.color = Color.white;  // その他のアバターは白色
            }
        }
    }

    // 選択されたアバターをコントローラーで操作
    void ControlAvatar(GameObject avatar)
    {
        Vector2 leftStickInput = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick);  // 左スティック
        Vector2 rightStickInput = OVRInput.Get(OVRInput.Axis2D.SecondaryThumbstick);  // 右スティック

        // 移動処理 (前後左右)
        Vector3 moveDirection = new Vector3(leftStickInput.x, 0, leftStickInput.y);
        avatar.transform.position += moveDirection * moveSpeed * Time.deltaTime;

        // 回転処理（左右回転）
        float rotation = rightStickInput.x * rotateSpeed * Time.deltaTime;
        avatar.transform.Rotate(Vector3.up, rotation);

        // ボタン入力で高さ調整（上下移動）
        if (OVRInput.Get(OVRInput.Button.PrimaryHandTrigger))  // トリガーボタンで上昇
        {
            avatar.transform.position += Vector3.up * moveSpeed * Time.deltaTime;
        }
        if (OVRInput.Get(OVRInput.Button.SecondaryHandTrigger))  // 逆トリガーで下降
        {
            avatar.transform.position -= Vector3.up * moveSpeed * Time.deltaTime;
        }
    }
}

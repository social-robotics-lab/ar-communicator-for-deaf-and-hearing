using UnityEngine;

public class KeyboardAnimationController : MonoBehaviour
{
    public Animator animator;  // ここがパブリックであることを確認

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            animator.SetInteger("motion", 0);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            animator.SetInteger("motion", 1);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            animator.SetInteger("motion", 2);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            animator.SetInteger("motion", 3);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            animator.SetInteger("motion", 4);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            animator.SetInteger("motion", 5);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            animator.SetInteger("motion", 6);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            animator.SetInteger("motion", 7);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            animator.SetInteger("motion", 8);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            animator.SetInteger("motion", 9);
        }
    }
}

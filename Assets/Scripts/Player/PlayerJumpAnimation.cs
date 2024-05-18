using UnityEngine;


public class PlayerJumpAnimation : MonoBehaviour
{
    [Header("Dependencies")]
    [SerializeField]
    private Animator anim;


    public void Jump()
    {
        anim.Play("Player_Jump_Anim");
    }
}


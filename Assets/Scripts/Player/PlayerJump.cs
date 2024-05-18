using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class PlayerJump : MonoBehaviour
{
    [Header("Dependencies")]
    [SerializeField]
    private Rigidbody2D rb;

    [Header("Jumping")]
    [SerializeField]
    private float jumpPower;
    [SerializeField]
    private BoolVariable isGrounded;
    [SerializeField]
    private IntVariable jumpsLeft;

    [Header("Events")]
    [SerializeField] private UnityEvent JumpEvent;

    public void Jump(InputAction.CallbackContext context)
    {
        if (isGrounded.Value)
        {
            if (context.performed)
            {
                JumpEvent.Invoke();
                rb.velocity = new Vector2(rb.velocity.x, jumpPower);
                jumpsLeft.Value--;
            }
            else if (context.canceled)
            {
                rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * .5f);
            }
        }
        else if (!isGrounded.Value && jumpsLeft.Value > 0)
        {
            if (context.performed)
            {
                JumpEvent.Invoke();
                rb.velocity = new Vector2(rb.velocity.x, jumpPower);
                jumpsLeft.Value--;
            }
            else if (context.canceled)
            {
                rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * .5f);
            }
        }
    }

}

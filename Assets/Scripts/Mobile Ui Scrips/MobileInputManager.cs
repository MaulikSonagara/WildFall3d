using UnityEngine;

public class MobileInputManager : MonoBehaviour
{
    public PlayerMovement player;
    public FixedJoystick moveJoystick;   // your joystick

    void Update()
    {
#if UNITY_ANDROID || UNITY_IOS

        Vector2 move = new Vector2(
            moveJoystick.Horizontal,
            moveJoystick.Vertical
        );

        player.Move(move);

#endif
    }

    public void JumpButton()
    {
        player.Jump();
    }
}
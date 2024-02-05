using UnityEngine;

[RequireComponent(typeof(Animator))]
public class AnimationSwitcher : MonoBehaviour
{
    private const int UpDirection = 1;
    private const int DownDirection = 2;
    private const int LeftDirection = 3;
    private const int RightDirection = 4;

    private int _direction = Animator.StringToHash("DirectionIndex");
    private Vector3 _previusPosition;
    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _previusPosition = transform.position;
    }

    private void Update()
    {
        Vector3 currentVelocity = ((transform.position - _previusPosition) / Time.deltaTime).normalized;

        float horizontalMovement = currentVelocity.x;
        float verticalMovement = currentVelocity.y;

        if (verticalMovement > 0)
            _animator.SetInteger(_direction, UpDirection);
        else if (verticalMovement < 0)
            _animator.SetInteger(_direction, DownDirection);
        else if (horizontalMovement > 0)
            _animator.SetInteger(_direction, RightDirection);
        else if (horizontalMovement < 0)
            _animator.SetInteger(_direction, LeftDirection);

        _previusPosition = transform.position;
    }
}
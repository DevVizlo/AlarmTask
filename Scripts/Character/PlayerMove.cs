using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private const string _walk = "Walk";

    [SerializeField] private float _rotateSpeed;
    
    private readonly string _horizontal = "Horizontal";
    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        bool isMoving = Input.GetKey(KeyCode.W);
        _animator.SetBool(_walk, isMoving);

        float rotation = Input.GetAxis(_horizontal);
        transform.Rotate(rotation * _rotateSpeed * Time.deltaTime * Vector3.up);
    }
}

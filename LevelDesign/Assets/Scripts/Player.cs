using UnityEngine;

public class Player : MonoBehaviour
{
    CharacterController _charController;
    Camera _mainCam;
    Vector3 fallVelocity = Vector3.zero;
    [SerializeField]
    Transform GroundCheck;
    [SerializeField]
    LayerMask GroundMask;
    [SerializeField]
    float Speed = 7f, SprintSpeed = 4f, MouseSensitivity = 350f, JumpForce = 4f, Gravity = 9.807f, TillGroundCheck = 0.2f;
    private float _horizontalLookDir, _verticalLookDir, _camHeight = 1f;
    private bool _onGround;

    void Start()
    {
        _charController = GetComponent<CharacterController>();
        _mainCam = Camera.main;
    }

    void Update()
    {
        _mainCam.transform.position = transform.position + new Vector3(0.2f, _camHeight);
        GroundCheck.transform.position = transform.position + new Vector3(0, -1.02f);
        PlayerInput();
        PlayerCamera();
        PGravity();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ammo"))
        {
            other.gameObject.SetActive(false);
            var AK = _mainCam.gameObject.GetComponentInChildren<AK47>();
            AK.AddAmmo();
        }
    }

    private void PlayerCamera()
    {
        float _mouseX = Input.GetAxis("Mouse X") * Time.deltaTime * MouseSensitivity;
        float _mouseY = Input.GetAxis("Mouse Y") * Time.deltaTime * MouseSensitivity;

        transform.Rotate(Vector3.up, _mouseX);
        _horizontalLookDir += _mouseX;
        _verticalLookDir -= _mouseY;
        _verticalLookDir = Mathf.Clamp(_verticalLookDir, -90f, 90f);
        _mainCam.transform.localRotation = Quaternion.Euler(_verticalLookDir, _horizontalLookDir, 0f);
    }

    private void PlayerInput()
    {
        float _movementx = Input.GetAxis("Horizontal");
        float _movementz = Input.GetAxis("Vertical");
        Vector3 _movedirection = (transform.forward * _movementz) + (transform.right * _movementx);
        _charController.Move(_movedirection * Speed * Time.deltaTime);

        if (_onGround && Input.GetKeyDown(KeyCode.Space))
        {
            fallVelocity.y = JumpForce;
        }

        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            _charController.radius /= 6;
            _charController.height /= 6;
            Speed -= 3;
            _charController.center = new Vector3(0, -0.5f);
            _camHeight = -0.02f;
        }

        if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            _charController.radius *= 6;
            _charController.height *= 6;
            Speed += 3;
            _charController.center = new Vector3(0, 0);
            _camHeight = 1f;
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            Speed += SprintSpeed;
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            Speed -= SprintSpeed;
        }

    }

    private void PGravity()
    {
        _onGround = Physics.CheckSphere(GroundCheck.position, TillGroundCheck, GroundMask);

        if (_onGround && fallVelocity.y <= 0)
        {
            fallVelocity = Vector3.zero;
        }
        else
        {
            fallVelocity.y += Gravity * Time.deltaTime *-1;
            _charController.Move(fallVelocity * Time.deltaTime);
        }
    }

}

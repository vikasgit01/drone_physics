using UnityEngine;

public class DroneController : MonoBehaviour
{
    [SerializeField] Transform _fanFrontRight;
    [SerializeField] Transform _fanFrontLeft;
    [SerializeField] Transform _fanBackRight;
    [SerializeField] Transform _fanBackLeft;

    public float _sensitivity;
    public float _thrust;
    float _thrustFrontRight;
    float _thrustFrontLeft;
    float _thrustBackRight;
    float _thrustBackLeft;
    [SerializeField] float _thrustStep;

    [SerializeField] float _turnAngle;

    Rigidbody _rb;
    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            transform.localEulerAngles = new Vector3(0, transform.localEulerAngles.y, 0);
            _rb.angularVelocity = Vector3.zero;
        }
        if(Input.GetKey(KeyCode.UpArrow)) _thrust += _thrustStep;
        else if (Input.GetKey(KeyCode.DownArrow)) _thrust -= _thrustStep;

        _thrustFrontRight = _thrust;
        _thrustFrontLeft  = _thrust;
        _thrustBackRight  = _thrust;
        _thrustBackLeft   = _thrust;


        //PITCH
        if(Input.GetKeyDown(KeyCode.W))
        {
            _thrustFrontRight -= _sensitivity;
            _thrustFrontLeft  -= _sensitivity;
            _thrustBackRight  += _sensitivity;
            _thrustBackLeft   += _sensitivity;
        }
        else if (Input.GetKeyUp(KeyCode.W))
        {
            transform.localEulerAngles = new Vector3(0, transform.localEulerAngles.y, 0);
            _rb.velocity.Normalize();
            _thrust = 2.454f;
        }
        if(Input.GetKeyDown(KeyCode.S))
        {
            _thrustFrontRight += _sensitivity;
            _thrustFrontLeft  += _sensitivity;
            _thrustBackRight  -= _sensitivity;
            _thrustBackLeft   -= _sensitivity;
        }
        else if (Input.GetKeyUp(KeyCode.S))
        {
            transform.localEulerAngles = new Vector3(0, transform.localEulerAngles.y, 0);
            _rb.velocity.Normalize();
            _thrust = 2.454f;
        }

        //ROLL
        if (Input.GetKeyDown(KeyCode.A))
        {
            _thrustFrontRight += _sensitivity;
            _thrustFrontLeft -= _sensitivity;
            _thrustBackRight += _sensitivity;
            _thrustBackLeft -= _sensitivity;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            _thrustFrontRight -= _sensitivity;
            _thrustFrontLeft += _sensitivity;
            _thrustBackRight -= _sensitivity;
            _thrustBackLeft += _sensitivity;
        }

        //YAW

        if(Input.GetKey(KeyCode.RightArrow))
        {

            _fanFrontRight.localRotation = Quaternion.Euler(          0, 0, -_turnAngle);
            _fanFrontLeft.localRotation  = Quaternion.Euler( _turnAngle, 0,           0);
            _fanBackRight.localRotation  = Quaternion.Euler(-_turnAngle, 0,           0);
            _fanBackLeft.localRotation   = Quaternion.Euler(       0,    0, _turnAngle);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            _fanFrontRight.localRotation = Quaternion.Euler(          0, 0,  _turnAngle);
            _fanFrontLeft.localRotation  = Quaternion.Euler(-_turnAngle, 0,           0);
            _fanBackRight.localRotation  = Quaternion.Euler( _turnAngle, 0,           0);
            _fanBackLeft.localRotation   = Quaternion.Euler(          0, 0, -_turnAngle);
        }
        else
        {
            _fanFrontRight.localRotation = Quaternion.identity;
            _fanFrontLeft.localRotation = Quaternion.identity;
            _fanBackRight.localRotation = Quaternion.identity;
            _fanBackLeft.localRotation = Quaternion.identity;
        }


    }

    void FixedUpdate()
    {
        _rb.AddForceAtPosition(_fanFrontRight.up * _thrustFrontRight, _fanFrontRight.position, ForceMode.Force);
        _rb.AddForceAtPosition(_fanFrontLeft.up  * _thrustFrontLeft, _fanFrontLeft.position , ForceMode.Force);
        _rb.AddForceAtPosition(_fanBackRight.up  * _thrustBackRight, _fanBackRight.position , ForceMode.Force);
        _rb.AddForceAtPosition(_fanBackLeft.up   * _thrustBackLeft, _fanBackLeft.position  , ForceMode.Force);
    }
}

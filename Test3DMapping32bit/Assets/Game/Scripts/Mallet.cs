using System;
using UnityEngine;

public class Mallet : MonoBehaviour {

    public PointerColor ColorOfPointerToFollow;
    public float Speed;
    public float DistanceToStop;
    public float AngularSpeed;
    public float AngleTolerance;

    private Transform _pointerToFollow;

    private Rigidbody _rigidbody;

	void Start () {

        switch (ColorOfPointerToFollow)
        {
            case (PointerColor.Red):
                _pointerToFollow = GameObject.FindGameObjectWithTag("RedPointer").transform;
                break;
            case (PointerColor.Blue):
                _pointerToFollow = GameObject.FindGameObjectWithTag("BluePointer").transform;
                break;
            default:
                break;
        }

        _rigidbody = GetComponent<Rigidbody>();

    }
	
	void Update () {
	
	}

    void FixedUpdate()
    {

        if (_rigidbody != null)
        {
            if (OutsideStoppingDistanceFromPointer())
            {
                ApproachPointer();
            }
            else
            {
                StopForces();
            }

            LimitSpeed();
            RotateToMatchPointer();
        }
    }

    private void LimitSpeed()
    {
        float currentSpeed = Vector3.Magnitude(_rigidbody.velocity);
        if (currentSpeed > Speed / 100)

        {
            float brakeSpeed = currentSpeed - Speed / 100;

            Vector3 normalisedVelocity = _rigidbody.velocity.normalized;
            Vector3 brakeVelocity = normalisedVelocity * brakeSpeed;

            _rigidbody.AddForce(-brakeVelocity);
        }
    }

    private void ApproachPointer()
    {
        _rigidbody.drag = 0f;
        var direction = Vector3.zero;
        direction = _pointerToFollow.position - transform.position;
        _rigidbody.AddRelativeForce(direction.normalized * Speed, ForceMode.Force);
    }

    private void RotateToMatchPointer()
    {
        _rigidbody.angularVelocity = Vector3.zero;
        _rigidbody.AddTorque(Vector3.Cross(transform.up, _pointerToFollow.transform.up) * AngularSpeed);
        _rigidbody.AddTorque(Vector3.Cross(transform.right, _pointerToFollow.transform.right) * AngularSpeed);
    }

    private void StopForces()
    {
        _rigidbody.drag = 1000f;
    }

    private bool OutsideStoppingDistanceFromPointer()
    {
        return Vector3.Distance(transform.position, _pointerToFollow.position) > DistanceToStop;
    }
}

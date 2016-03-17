using System;
using UnityEngine;

public class Mallet : MonoBehaviour {

    public Transform Target;
    public float Speed;
    public float DistanceToStop;
    public float AngularSpeed;
    public float AngleTolerance;

    private Rigidbody _rigidbody;

	// Use this for initialization
	void Start () {
        _rigidbody = GetComponent<Rigidbody>();

    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void FixedUpdate()
    {

        if (_rigidbody != null)
        {
            if (OutsideStoppingDistanceFromTarget())
            {
                ApproachTarget();
            }
            else
            {
                StopForces();
            }

            LimitSpeed();
            RotateToMatchTarget();
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

    private void ApproachTarget()
    {
        _rigidbody.drag = 0f;
        var direction = Vector3.zero;
        direction = Target.position - transform.position;
        _rigidbody.AddRelativeForce(direction.normalized * Speed, ForceMode.Force);
    }

    private void RotateToMatchTarget()
    {
        _rigidbody.angularVelocity = Vector3.zero;
        _rigidbody.AddTorque(Vector3.Cross(transform.up, Target.transform.up) * AngularSpeed);
        _rigidbody.AddTorque(Vector3.Cross(transform.right, Target.transform.right) * AngularSpeed);
    }

    private void StopForces()
    {
        _rigidbody.drag = 1000f;
    }

    private bool OutsideStoppingDistanceFromTarget()
    {
        return Vector3.Distance(transform.position, Target.position) > DistanceToStop;
    }
}

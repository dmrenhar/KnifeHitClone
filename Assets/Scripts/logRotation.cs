using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class logRotation : MonoBehaviour
{
    [System.Serializable]
    private class RotationELement
    {
        #pragma warning disable 0649
        public float speed;
        public float duration;
        #pragma warning restore 0649
    }

    [SerializeField]
    private RotationELement[] rotationPattern;

    private WheelJoint2D wheelJoint;
    private JointMotor2D motor;

    private void Awake()
    {
        wheelJoint = GetComponent<WheelJoint2D>();
        motor = new JointMotor2D();
        StartCoroutine("PlayRotationPattern");
    }

    private IEnumerator PlayRotationPattern()
    {
        int rotationIndex = 0;
        while(true)
        {
            yield return new WaitForFixedUpdate();

            motor.motorSpeed = rotationPattern[rotationIndex].speed;
            motor.maxMotorTorque = 10000;
            wheelJoint.motor = motor;


            yield return new WaitForSeconds(rotationPattern[rotationIndex].duration);
            rotationIndex++;
            rotationIndex = rotationIndex < rotationPattern.Length ? rotationIndex: 0;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/* This is in inverse kinematics script for calculating 
 * limb positions based on the positions of the controllers */
public class IK : MonoBehaviour {

	// Init Public Variables
	public Transform upperArm;
	public Transform forearm;
	public Transform hand;
	public Transform target;
	public Transform elbowTarget;
	public bool IsEnabled;
	public bool debug;
	public float transition;

	// Init Private Variables
	private Quaternion upperArmStartRotation;
	private Quaternion forearmStartRotation;
	private Quaternion handStartRotation;
	private Vector3 targetRelativeStartPosition;
	private Vector3 elbowTargetRelativeStartPosition;

	/* At beginning of execution, assign initialize variables */
	void start () {
		upperArmStartRotation = upperArm.rotation;
		forearmStartRotation = forearm.rotation;
		handStartRotation = hand.rotation;
		targetRelativeStartPosition = target.position - upperArm.position;
		elbowTargetRelativeStartPosition = elbowTarget.position - upperArm.position;
	}


	void update () {}

}



//START IK
/*


function Start()
{
    upperArmStartRotation = upperArm.rotation;
    forearmStartRotation = forearm.rotation;
    handStartRotation = hand.rotation;
    targetRelativeStartPosition = target.position - upperArm.position;
    elbowTargetRelativeStartPosition = elbowTarget.position - upperArm.position;
}

function LateUpdate()
{
    if (!IsEnabled)
    {
        return;
    }
    CalculateIK();
}

function CalculateIK()
{
    //Calculate ikAngle variable.
    var upperArmLength : float = Vector3.Distance(upperArm.position, forearm.position);
    var forearmLength : float = Vector3.Distance(forearm.position, hand.position);
    var armLength : float = upperArmLength + forearmLength;
    var hypotenuse : float = upperArmLength;
    var targetDistance : float = Vector3.Distance(upperArm.position, target.position);
    targetDistance = Mathf.Min(targetDistance, armLength - 0.0001); //Do not allow target distance be further away than the arm's length.
                                                                    //var adjacent : float = (targetDistance * hypotenuse) / armLength;
    var adjacent : float = (Mathf.Pow(hypotenuse, 2) - Mathf.Pow(forearmLength, 2) + Mathf.Pow(targetDistance, 2)) / (2 * targetDistance);
    var ikAngle : float = Mathf.Acos(adjacent / hypotenuse) * Mathf.Rad2Deg;
    //Store pre-ik info.
    var targetPosition : Vector3 = target.position;
    var elbowTargetPosition : Vector3 = elbowTarget.position;
    var upperArmParent : Transform = upperArm.parent;
    var forearmParent : Transform = forearm.parent;
    var handParent : Transform = hand.parent;
    var upperArmScale : Vector3 = upperArm.localScale;
    var forearmScale : Vector3 = forearm.localScale;
    var handScale : Vector3 = hand.localScale;
    var upperArmLocalPosition : Vector3 = upperArm.localPosition;
    var forearmLocalPosition : Vector3 = forearm.localPosition;
    var handLocalPosition : Vector3 = hand.localPosition;
    var upperArmRotation : Quaternion = upperArm.rotation;
    var forearmRotation : Quaternion = forearm.rotation;
    var handRotation : Quaternion = hand.rotation;
    //Reset arm.
    target.position = targetRelativeStartPosition + upperArm.position;
    elbowTarget.position = elbowTargetRelativeStartPosition + upperArm.position;
    upperArm.rotation = upperArmStartRotation;
    forearm.rotation = forearmStartRotation;
    hand.rotation = handStartRotation;
    //Work with temporaty game objects and align & parent them to the arm.
    transform.position = upperArm.position;
    transform.LookAt(targetPosition, elbowTargetPosition - transform.position);
    var upperArmAxisCorrection : GameObject = new GameObject("upperArmAxisCorrection");
    var forearmAxisCorrection : GameObject = new GameObject("forearmAxisCorrection");
    var handAxisCorrection : GameObject = new GameObject("handAxisCorrection");
    upperArmAxisCorrection.transform.position = upperArm.position;
    upperArmAxisCorrection.transform.LookAt(forearm.position, transform.root.up);
    upperArmAxisCorrection.transform.parent = transform;
    upperArm.parent = upperArmAxisCorrection.transform;
    forearmAxisCorrection.transform.position = forearm.position;
    forearmAxisCorrection.transform.LookAt(hand.position, transform.root.up);
    forearmAxisCorrection.transform.parent = upperArmAxisCorrection.transform;
    forearm.parent = forearmAxisCorrection.transform;
    handAxisCorrection.transform.position = hand.position;
    handAxisCorrection.transform.parent = forearmAxisCorrection.transform;
    hand.parent = handAxisCorrection.transform;
    //Reset targets.
    target.position = targetPosition;
    elbowTarget.position = elbowTargetPosition;
    //Apply rotation for temporary game objects.
    upperArmAxisCorrection.transform.LookAt(target, elbowTarget.position - upperArmAxisCorrection.transform.position);
    upperArmAxisCorrection.transform.localRotation.eulerAngles.x -= ikAngle;
    forearmAxisCorrection.transform.LookAt(target, elbowTarget.position - upperArmAxisCorrection.transform.position);
    handAxisCorrection.transform.rotation = target.rotation;
    //Restore limbs.
    upperArm.parent = upperArmParent;
    forearm.parent = forearmParent;
    hand.parent = handParent;
    upperArm.localScale = upperArmScale;
    forearm.localScale = forearmScale;
    hand.localScale = handScale;
    upperArm.localPosition = upperArmLocalPosition;
    forearm.localPosition = forearmLocalPosition;
    hand.localPosition = handLocalPosition;
    //Clean up temporary game objets.
    Destroy(upperArmAxisCorrection);
    Destroy(forearmAxisCorrection);
    Destroy(handAxisCorrection);
    //Transition.
    transition = Mathf.Clamp01(transition);
    upperArm.rotation = Quaternion.Slerp(upperArmRotation, upperArm.rotation, transition);
    forearm.rotation = Quaternion.Slerp(forearmRotation, forearm.rotation, transition);
    hand.rotation = Quaternion.Slerp(handRotation, hand.rotation, transition);
    //Debug.
    if (debug)
    {
        Debug.DrawLine(forearm.position, elbowTarget.position, Color.yellow);
        Debug.DrawLine(upperArm.position, target.position, Color.red);
    }
}
*/
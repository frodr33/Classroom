using UnityEngine;
using System.Collections;

public class HeadControl : MonoBehaviour
{
	public GameObject followedObject;
	public GameObject holdHeight;

	// Use this for initialization
	void Start()
	{
		transform.parent = followedObject.transform;
		float theHeight = holdHeight.transform.position.y;
		float percentage = (theHeight / 1.75f);
		//float headSize = (percentage / 1000);
		Vector3 _tmp = this.transform.localScale;
		//percentage of the avatar height
		Debug.Log("In start");
		_tmp.x = (this.transform.localScale.x * percentage * .088f);
		_tmp.y = (this.transform.localScale.y * percentage * .088f);
		_tmp.z = (this.transform.localScale.z * percentage * .088f);
		this.transform.localScale = _tmp;
	}

	void followPosition()
	{
		Vector3 _tmp = followedObject.transform.position;
		//_tmp.x = followedObject.transform.position.x - 0.1f;
		//_tmp.y = followedObject.transform.position.y - 0.1f;
		//_tmp.z = followedObject.transform.position.z - 0.03f;
		_tmp.x = followedObject.transform.position.x + 0.1f;
		_tmp.y = followedObject.transform.position.y + 0.15f;
		_tmp.z = followedObject.transform.position.z;
		this.transform.position = _tmp;
	}

	void followRotation()
	{
		Vector3 _tmp2 = followedObject.transform.eulerAngles;
		_tmp2.x = followedObject.transform.eulerAngles.x;
		_tmp2.y = followedObject.transform.eulerAngles.y;
		_tmp2.z = followedObject.transform.eulerAngles.z;
		this.transform.eulerAngles = _tmp2;
	}

	// Update is called once per frame
	void Update()
	{
		followPosition();
		followRotation();
	}
}
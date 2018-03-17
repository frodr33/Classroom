using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class playback : MonoBehaviour {
	/* Playback turns controlls whether or not 
	 * the TV is currently playing. In the on 
	 * state, TV is playing video. In the off
	 * state, TV is a black material representing
	 * the color of a TV */

	public Material tv;
	public Material white;
	private bool isOn = false;
	private VideoPlayer videoplayer;
	private MeshRenderer mesh;

	// Initaliziation
	void Start () {
		mesh = GetComponent<MeshRenderer>();
		videoplayer = GetComponent<VideoPlayer> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown("space")) {
			if (isOn) {
				turnOffTv ();
			} else {
				turnOnTv ();
			}
		} 
	}

	/* Turns TV on by playing
	 * video and changing mesh
	 * material */
	void turnOnTv() {
		Debug.Log ("Turning TV on");
		mesh.material = white;
		videoplayer.Play ();
		isOn = true;
	}

	/* Turns TV off by stopping
	 * video and changing mesh
	 * material */
	void turnOffTv() {
		Debug.Log ("Turning TV off");
		videoplayer.Stop ();
		mesh.material = tv;
		isOn = false;
	}
}

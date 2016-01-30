using UnityEngine;
using System.Collections;

public class CamFollowPlayer : MonoBehaviour {
    Vector3 relativePos;
    public GameObject player;

	// Use this for initialization
	void Start () {
        relativePos = player.transform.position - transform.position;
	}
	
	// Update is called once per frame
	void LateUpdate () {
        transform.position = player.transform.position - relativePos;
	}
}

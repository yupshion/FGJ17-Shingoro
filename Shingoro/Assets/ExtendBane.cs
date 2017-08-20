using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtendBane : MonoBehaviour {

	public GameObject StartPosition;

	public GameObject TargetPos;

	// Use this for initialization
	void Start () {
		//StartPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update () {

		//距離に応じて拡大縮小をする
		Vector3 inputPosition = new Vector3(TargetPos.transform.position.x, TargetPos.transform.position.y, 0);
		Vector3 targetPos = TargetPos.transform.position;
		Vector3 mediumPos = (targetPos - StartPosition.transform.position) / 2.0f;
		float dist = Vector3.Distance(targetPos, StartPosition.transform.position);

		//transform.position = mediumPos;
		transform.localScale = new Vector3(0.5f, 1.0f*(dist/10), 1.0f);
		//transform.LookAt(targetPos);
	}

}

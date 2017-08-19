using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkshopManager : MonoBehaviour {


	[SerializeField]
	private GameObject m_prefab;

	public Transform[] ExtistPositions;

	// Use this for initialization
	void Start () {

		float marge = Screen.height / 6;

		int idx = Random.Range (1, 15);

		for(int j=1; j <2; j++){
			for(int i=0; i < 5; i++){

				GameObject workshopchara = Instantiate(m_prefab, new Vector3(Screen.width * j, marge * (i +1), 0), Quaternion.identity);
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

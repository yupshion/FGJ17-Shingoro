using UnityEngine;
using System.Collections;

public class drawws : MonoBehaviour
{
	public bool useRandam = true;
	public int charNo = 1;
	public string siteName = "https://drawws.kgr-lab.com";

	private GameObject armr, arml;
	private bool flag = false;

	[SerializeField]
	private GameObject m_rshingorow,m_lshingorow;

	private float rotecounter = 0;
	private int rote = 1;
	private float roterate = 5;

	private float counter =0;
	private int armrote = 1;
	private float armroterate = 5;

	// Use this for initialization
	IEnumerator Start ()
	{
		if(useRandam){
			charNo = Random.Range (1, 14);
		}

		switch (Random.Range (0, 3)) {

		case 0:
			m_rshingorow.SetActive (true);
			break;
		case 1:
			m_lshingorow.SetActive (true);
			break;
		case 2:
			m_rshingorow.SetActive (true);
			m_lshingorow.SetActive (true);
			break;

		}

		roterate = 1f + Random.value  *1f;
		armroterate = 4f + Random.value  *3f;

		GameObject body = transform.Find ("body").gameObject;
		Renderer bodyRenderer = body.GetComponent<Renderer> ();

		armr = transform.Find ("armr").gameObject;
		Renderer armrRenderer = armr.GetComponent<Renderer> ();

		arml = transform.Find ("arml").gameObject;
		Renderer armlRenderer = arml.GetComponent<Renderer> ();

		string bodyFile = string.Format ("/b{0:0000}", charNo);
		string armFile = string.Format ("/a{0:0000}", charNo);

		Texture2D tbody;
		Texture2D tarm;
		tbody = Resources.Load<Texture2D> ("Texture" + bodyFile);
		tarm = Resources.Load<Texture2D> ("Texture" + armFile);

		if (tbody == null || tarm == null) {
			WWW bodyWWW = new WWW (siteName + bodyFile + ".png");
			WWW armWWW = new WWW (siteName + armFile + ".png");
			yield return bodyWWW;
			yield return armWWW;
			bodyRenderer.material.mainTexture = bodyWWW.texture;
			armrRenderer.material.mainTexture = armWWW.texture;
			armlRenderer.material.mainTexture = armWWW.texture;
		} else {
			bodyRenderer.material.mainTexture = tbody;
			armrRenderer.material.mainTexture = tarm;
			armlRenderer.material.mainTexture = tarm;
		}

		flag = true;
	}

	// Update is called once per frame
	void Update ()
	{
		if (flag) {

			rotecounter += roterate * rote;
			this.transform.Rotate(0, 0, roterate * rote);
			if (rotecounter > 30 || rotecounter < -30) {
				rote *= -1;

			}

			counter += armroterate;
			armr.transform.Rotate (0, armroterate * armrote, 0);
			arml.transform.Rotate (0, -armroterate * armrote, 0);

			if (counter > 100) {
				armrote *= -1;
				counter = 0;
			}

		}
	}
}

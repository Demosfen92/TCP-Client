using UnityEngine;
using System.Collections;

public class PlayerConroller : MonoBehaviour {

	public float speed;
	public float turnSpeed;

	// Use this for initialization
//	void Start () {
//	
//	}
	
	// Update is called once per frame
	void Update () {

		var inputX = Input.GetAxisRaw ("Horizontal");
		var inputY = Input.GetAxisRaw ("Vertical");

		if ((Mathf.Abs (inputX) + Mathf.Abs(inputY)) > 0) {
			transform.position += new Vector3 (inputX, inputY, 0).normalized * Time.deltaTime * speed;
		}

		Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		transform.rotation = Quaternion.LookRotation(Vector3.forward, mousePos - transform.position);
	}
}

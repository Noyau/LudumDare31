using UnityEngine;
using System.Collections;

[RequireComponent (typeof(CircleCollider2D))]
public class CursorScript : MonoBehaviour {

	private static CursorScript instance = null;

	public static CursorScript GetSingleton() {
		if (!instance) {
			instance = FindObjectOfType(typeof(CursorScript)) as CursorScript;
			if(!instance)
						Debug.LogError ("You need a cursor in order to play the game");
				}
		return instance;
	}

	public GameObject lastPath;
	private Vector3 pointerPosition;

	// Use this for initialization
	void Start () {
		instance = this;
		Screen.showCursor = false;
		this.lastPath = null;
		this.pointerPosition = Vector3.zero;
	}
	
	// Update is called once per frame
	void Update () {
		CircleCollider2D circleCollider = GetComponent <CircleCollider2D> ();

		Vector3 mousePosition = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		mousePosition.z = 0.0f;

		this.pointerPosition = mousePosition;
		this.pointerPosition.x += circleCollider.center.x;
		this.pointerPosition.y += circleCollider.center.y;

		transform.localPosition = mousePosition;

		if (Input.GetMouseButtonDown (0) && lastPath) {
						Debug.Log ("Holy Shit, It Works!");
				}
	}
}

using UnityEngine;
using System.Collections;

[ RequireComponent ( typeof ( PolygonCollider2D ) ) ]
public class PathfindingScript : MonoBehaviour
{

	private CursorScript cursor = null;

	void Awake () {
		this.cursor = CursorScript.GetSingleton ();
	}

	void OnTriggerStay2D () {
		this.cursor.lastPath = gameObject;
	}

	void OnTriggerExit2D() {
		this.cursor.lastPath = null;
	}

}

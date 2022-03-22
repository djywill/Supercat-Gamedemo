using UnityEngine;
using System.Collections;

/// <summary>
/// Destroys host gameobject with specified delay eg. bullets
/// </summary>
public class DestroySFXDelay : MonoBehaviour
{
	public float delay;		// how long to wait before destroying gameobject

	void Start () 
	{
		Destroy(gameObject, delay);
	}

}

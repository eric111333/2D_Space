using UnityEngine;
using System.Collections;

public class PSDestroy : MonoBehaviour {

	// Use this for initialization
	void Start () {
#pragma warning disable CS0618 // 類型或成員已經過時
		//Destroy(gameObject, GetComponent<ParticleSystem>().duration);
#pragma warning restore CS0618 // 類型或成員已經過時
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

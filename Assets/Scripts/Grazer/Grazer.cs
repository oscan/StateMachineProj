using UnityEngine;
using System.Collections;

public class Grazer : MonoBehaviour {

	StateMachine sm;
	// Use this for initialization
	void Start () {
		sm = GetComponent<StateMachine>();
		sm.changeState(new Idle(gameObject));
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

using UnityEngine;
using System.Collections;

public class Grazer : MonoBehaviour {

	public StateMachine sm;
	public float hunger = 0.0f;
	public Vector3 forward;
	public LayerMask foodMask;
	
	// Use this for initialization
	void Start () {
		sm = GetComponent<StateMachine>();
		sm.changeState(new Idle(gameObject));
	}
	
	// Update is called once per frame
	void Update () {
		if(!(sm.currentState is Eating)){
			hunger += Time.deltaTime * 0.1f;
		}
		forward = transform.forward;
	}
}

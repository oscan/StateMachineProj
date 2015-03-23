using UnityEngine;
using System.Collections;

public class Grazer : MonoBehaviour {

	public StateMachine sm;
	public float hunger = 0.0f;
	public float hunger_limit = 0.5f;
	public float fear = 0.0f;
	public Vector3 forward;
	public LayerMask foodMask;
	public GameObject alert;
	
	// Use this for initialization
	void Start () {
		hunger_limit *= Random.Range(0.8f, 1.2f);
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

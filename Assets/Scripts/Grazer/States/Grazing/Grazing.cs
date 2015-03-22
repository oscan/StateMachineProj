using UnityEngine;
using System.Collections;

public class Grazing : State {

	public Grazer grazer;
	public Transform foodTarget;	
	public GameObject target;
	
	public Grazing(GameObject go) : base(go){
		grazer = go.GetComponent<Grazer>();
		foodTarget = go.transform.FindChild("foodTarget");
	}
	
	public override void EnterState ()
	{
		
	}
	
	public override void Update (float dt)
	{
		
	}
	
	public override void ExitState ()
	{
		
	}
}

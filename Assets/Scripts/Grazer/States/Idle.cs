using UnityEngine;
using System.Collections;

public class Idle : State {
	
	public Idle(GameObject go) : base(go){
		
	}
	
	public override void EnterState ()
	{
		
	}
	
	public override void Update (float dt)
	{
		Grazer grazer = gameObject.GetComponent<Grazer>();
		if(grazer.hunger > 0.5f){
			grazer.sm.changeState(new Grazing(gameObject));
		}
	}
	
	public override void ExitState ()
	{
		
	}
}

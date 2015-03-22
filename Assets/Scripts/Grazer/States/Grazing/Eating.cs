using UnityEngine;
using System.Collections;

public class Eating : Grazing {
	
	Grass grass;
	
	public Eating(GameObject go, GameObject _target) : base(go){
		target = _target;
		grass = target.GetComponent<Grass>();
	}
	
	public override void EnterState ()
	{
		gameObject.GetComponent<Animator>().SetTrigger("Eat");
	}
	
	public override void Update (float dt)
	{
		grazer.hunger -= dt * 0.1f;
		grass.quantity -= dt * 0.1f;
		if(grass.quantity < 0) {
			grazer.sm.changeState( new Idle(gameObject));
			GameObject.Destroy(grass);
		}
	}
	
	public override void ExitState ()
	{
		
	}
}

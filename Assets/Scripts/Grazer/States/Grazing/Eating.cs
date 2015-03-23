using UnityEngine;
using System.Collections;

public class Eating : Grazing {
	
	Grass grass;
	
	public Eating(GameObject go, GameObject _target) : base(go){
		target = _target;
		grass = target.GetComponent<Grass>();
		grass.eaten = true;
	}
	
	public override void EnterState ()
	{
		gameObject.GetComponent<Animator>().SetTrigger("Eat");
	}
	
	public override void Update (float dt)
	{
		if(grass && grass.quantity > 0){
			grazer.hunger -= dt * 0.1f * Random.Range(0.9f,1.1f);
			grass.quantity -= dt * 0.1f;
			if(grass.quantity < 0) {
				GameObject.Destroy(target);
				grass = null;
				target = null;
				grazer.sm.changeState( new Idle(gameObject));
			}
		} else {
			grazer.sm.changeState( new Idle(gameObject));
		}
	}
	
	public override void ExitState ()
	{
		gameObject.GetComponent<Animator>().SetTrigger("FinishedEat");
	}
}

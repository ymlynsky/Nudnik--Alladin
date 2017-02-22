using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AnimationManager : MonoBehaviour {

	[System.Serializable]
	public class AnimationSet{
		public AnimationClip animation;
		public float speedAnimation = 1;
	}

	public AnimationSet run, turnLeft, turnRight, jumpUp, jumpLoop, jumpDown, roll, slide, needles, dead, fly, flyLeft, flyRight, flyUp;

	public delegate void AnimationHandle();
	public AnimationHandle animationState;

	private Controller controller;
	private float speed_Run, needles_Run, speed_slide, speed_roll;

	void Start(){
		controller = this.GetComponent<Controller>();
		animationState = Run;
	}

	void Update () {
		if(animationState != null){
			animationState();	
		}
	}

	public void Run(){
		if (Controller.jPuck == false) {
			GetComponent<Animation> ().Play (run.animation.name);
			speed_Run = Generation.speed * (run.speedAnimation);
			GetComponent<Animation> () [run.animation.name].speed = speed_Run;
		}
	}

	public void Jump(){
		GetComponent<Animation>().Play(jumpUp.animation.name);
		if(GetComponent<Animation>()[jumpUp.animation.name].normalizedTime > 0.65f && Controller.swiped2==true){
			animationState = JumpLoop;
		}
		else if(GetComponent<Animation>()[jumpUp.animation.name].normalizedTime > 0.95f){
			animationState = JumpLoop;
		}
	}

	public void JumpSecond(){
		GetComponent<Animation>().Play(roll.animation.name);
		if(GetComponent<Animation>()[roll.animation.name].normalizedTime > 0.95f){
			animationState = JumpLoop;
		}
	}

	public void JumpLoop(){
		GetComponent<Animation>().CrossFade(jumpLoop.animation.name);
		if(GetComponent<Animation>()[jumpLoop.animation.name].normalizedTime > 0.12f){
			if(Controller.isGround == true){
				animationState = Run;	
			}
		}
	}

	public void TurnLeft(){
		GetComponent<Animation>()[turnLeft.animation.name].speed = turnLeft.speedAnimation;
		GetComponent<Animation>().Play(turnLeft.animation.name);
		if(GetComponent<Animation>()[turnLeft.animation.name].normalizedTime > 0.95f){
			animationState = Run;	
		}
	}

	public void TurnRight(){
		GetComponent<Animation>()[turnRight.animation.name].speed = turnRight.speedAnimation;
		GetComponent<Animation>().Play(turnRight.animation.name);
		if(GetComponent<Animation>()[turnRight.animation.name].normalizedTime > 0.95f){
			animationState = Run;	
		}
	}

	public void Roll(){
		speed_roll = Generation.speed *(roll.speedAnimation);
		GetComponent<Animation>()[roll.animation.name].speed = speed_roll;
		GetComponent<Animation>().Play(roll.animation.name);
		if(GetComponent<Animation>()[roll.animation.name].normalizedTime > 0.95f){
			controller.isRoll = false;
			animationState = Run;
		}else{
			controller.isRoll = true;	
		}
	}
	
	public void Slide(){
		speed_slide = Generation.speed*(slide.speedAnimation);
		GetComponent<Animation>()[slide.animation.name].speed = speed_slide;
		GetComponent<Animation>().Play(slide.animation.name);
		if(GetComponent<Animation>()[slide.animation.name].normalizedTime > 0.95f){
			controller.isSlide = false;
			animationState = Run;
		}else{
			controller.isSlide = true;	
		}
	}

	public void Dead(){
		GetComponent<Animation>().Play(dead.animation.name);
	}

	public void JumpBetman(){
		if (Controller.jPuck == false) {
				GetComponent<Animation> ().Play (jumpDown.animation.name);
				if (GetComponent<Animation> () [jumpDown.animation.name].normalizedTime > 0.6f) {
						animationState = Run;	
				}
		}
	}

	public void JumpBetman2(){
		if (Controller.jPuck == false) {
				GetComponent<Animation> ().Play (jumpDown.animation.name);
				if (GetComponent<Animation> () [jumpDown.animation.name].normalizedTime > 0.99f) {
						animationState = Run;	
				}
		}
	}

	public void Needles(){
		GetComponent<Animation>().Play(needles.animation.name);
		GetComponent<Animation>()[needles.animation.name].speed = needles.speedAnimation*Generation.speed;
		needles_Run = Generation.speed*(needles.speedAnimation);
		GetComponent<Animation>()[needles.animation.name].speed = needles_Run;
		if(GetComponent<Animation>()[needles.animation.name].normalizedTime > 0.95f){
			animationState = Run;	
		}
	}

	public void FlyUpper(){
		GetComponent<Animation>().Play(flyUp.animation.name);
		if(GetComponent<Animation>()[flyUp.animation.name].normalizedTime > 0.95f){
			animationState = Flying;
		}
	}

	public void Flying(){
		GetComponent<Animation>().Play(fly.animation.name);
		GetComponent<Animation>()[fly.animation.name].speed = Generation.speed*(fly.speedAnimation);
	}

	public void fLeft(){
		GetComponent<Animation>()[flyLeft.animation.name].speed = flyLeft.speedAnimation;
		GetComponent<Animation>().Play(flyLeft.animation.name);
		if(GetComponent<Animation>()[flyLeft.animation.name].normalizedTime > 0.95f){
			animationState = Flying;	
		}
	}

	public void fRight(){
		GetComponent<Animation>()[flyRight.animation.name].speed = flyRight.speedAnimation;
		GetComponent<Animation>().Play(flyRight.animation.name);
		if(GetComponent<Animation>()[flyRight.animation.name].normalizedTime > 0.95f){
			animationState = Flying;	
		}
	}
}

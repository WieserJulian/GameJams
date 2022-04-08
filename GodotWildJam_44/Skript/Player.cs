using Godot;
using System;

public class Player : KinematicBody2D
{
		Vector2 _velocity = new Vector2();
        private Vector2 UP = new Vector2(0, -1);
    	private const int MAX_SPEED = 220;
        private const int ACCELARATION = 80;
        private const int MAX_FALL_SPEED = 450;
        private const int GRAVITY = 60;
        private const int JUMP = 900;
        bool canjumpAir = true;
	
        public override void _PhysicsProcess(float delta){
	        _velocity.y += GRAVITY;
	        if (_velocity.y > MAX_FALL_SPEED){
		        _velocity.y = MAX_FALL_SPEED;
	        }
	        _velocity.x = Mathf.Clamp(_velocity.x, -MAX_SPEED, MAX_SPEED);
        
	        if (Input.IsActionPressed("MoveLeft")){
		        _velocity.x -= ACCELARATION*2;
	        }
	        else if (Input.IsActionPressed("MoveRigth")){
		        _velocity.x += ACCELARATION*2;
	        }
	        else {
		        _velocity.x = Mathf.Lerp(_velocity.x, 0, 0.2f);
	        }
	        if (Input.IsActionJustPressed("MoveJump") && (IsOnFloor() || canjumpAir)){
		        if (!IsOnFloor()){
			        _velocity.y = -JUMP;
			        canjumpAir = false;
		        }else{
			        _velocity.y -= JUMP;
			        canjumpAir = true;
		        }
	        }
	        if (IsOnFloor()){
		        canjumpAir = true;
	        }
    
	        _velocity = MoveAndSlide( _velocity, UP);
        }
        
}

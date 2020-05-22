using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class subControl : MonoBehaviour
{
	public Rigidbody2D sub;
    protected Joystick joystick;
    float someScale;
    float flip_direction;
    public float desired_pitch;
    public float desired_fwd_speed;
    public float desired_vert_speed;
    public float velocity_buoyancy;
    public float nose_up_pitch;
    public bool rot_corrected_neg;
    public bool rot_corrected_pos;
    public float depth;
    public bool diving;
    public float time_spent_underwater;
    public float previous_timestamp;
    public float dt;

    // Start is called before the first frame update
    void Start()
    {
    	sub = GetComponent<Rigidbody2D>();
        //joystick = FindObjectOfType<Joystick>();
        someScale = transform.localScale.x;
        velocity_buoyancy = 0.5f; 
        nose_up_pitch = 1f;
        rot_corrected_neg = false;
        rot_corrected_pos = true;
        diving = false;
        time_spent_underwater = 0.0f;
        previous_timestamp = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        // computing dt
        dt = Time.time - previous_timestamp;
        previous_timestamp = Time.time;

        float vert_velocity = velocity_buoyancy + desired_vert_speed;
        float horiz_velocity = desired_fwd_speed;
        float current_pitch = sub.rotation;

        if(nose_up_pitch*desired_pitch > current_pitch){
            sub.rotation += 0.2f;
        }
        else if(nose_up_pitch*desired_pitch < current_pitch){
            sub.rotation -= 0.2f;
        }

        float cmd_vert_velocity = vert_velocity + horiz_velocity * Convert.ToSingle(Math.Sin(sub.rotation * Math.PI/180));
        float cmd_horiz_velocity = horiz_velocity * Convert.ToSingle(Math.Cos(sub.rotation * Math.PI/180));

        sub.velocity = new Vector2(cmd_horiz_velocity, cmd_vert_velocity);
        Debug.Log(sub.rotation);

        // Flipping the sub acording to the direction of movement
        if (sub.velocity.x>0.2){
            transform.localScale = new Vector2(someScale, transform.localScale.y);
            nose_up_pitch = 1f;
            if (!rot_corrected_pos){
                sub.rotation = -sub.rotation;
                rot_corrected_pos = true;
                rot_corrected_neg = false;
            }
        }
        else if (sub.velocity.x<-0.2) {
            transform.localScale = new Vector2(-someScale, transform.localScale.y);
            nose_up_pitch = -1f;
            if (!rot_corrected_neg){
                sub.rotation = -sub.rotation;
                rot_corrected_neg = true;
                rot_corrected_pos = false;
            }   
        }

        // Measure the depth of the vehicle
        // surface is y = 6.6. 1 m of depth = 0.4 in y. y at sea bed = -24.4. water depth ~ 77.5
        depth = -1f*((sub.position.y - 6.6f) /0.4f);
        if (depth>2.5){
            diving = true;
        }
        else {
            diving = false;
        }

        // Time spent underwater counter
        if (diving) {
            time_spent_underwater += dt;
        }
        else{
            time_spent_underwater = 0.0f;
        }
        
        Debug.Log(time_spent_underwater);



    }

   // pickup an object and the object disappears 
    private void OnTriggerEnter2D(Collider2D collectSample){
    	if (collectSample.gameObject.CompareTag("Treasures"))
    	{
    		Destroy(collectSample.gameObject);
    	}
    }

    // indicate depth, pose and velocity
    // add a counter for battery power
    // add a counter for weight
    // motion of the ship
    // ship loitering
    // ship moving towards the sub when at surface
    // acoustic messages to ship
    // battery recharge when near the ship
    // drop weight
    // motion near the surface
    // discover the map as the sub moves
    // Sample the moving fish mission



    public void desiredPitch(float pitch) {
        desired_pitch = pitch;
    }

    public void desiredFwdSpeed(float speed) {
        desired_fwd_speed = speed;
        // sub.velocity = new Vector2(speed * Convert.ToSingle(Math.Sin(sub_pitch)),
        //     speed * Convert.ToSingle(Math.Cos(sub_pitch)));
    }

    public void desiredBuoyancy(float buoyancy) {
        desired_vert_speed = -buoyancy;
    }
}

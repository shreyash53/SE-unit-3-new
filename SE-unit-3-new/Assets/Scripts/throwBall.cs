using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Diagnostics;
using System.Threading;


public class throwBall : MonoBehaviour
{	
    // int score = 0;
    // private GameObject[] pins;
    // private GameObject[] ball;
    // Vector3[] pin_positions;
    // Vector3 ball_position;
    // float rotation_reset_speed = 1.0f;
    // public Transform pin_transform;
	// public Rigidbody rb;
	// public Text total_score;
	// int ts = 0;
	// public Text[] sc;
	// public Text chances_left;
	// int k = 1;
    // bool flag = false;
    void Start(){
	    // //rb = GetComponent<Rigidbody>();
        // ball = GameObject.FindGameObjectsWithTag("ball");
        // pins = GameObject.FindGameObjectsWithTag("Pins");
        // ball_position = ball[0].transform.position;
        // pin_positions = new Vector3[pins.Length];
	    // //sc = new Text[10];
        // for(int i=0;i<pins.Length;i++){
        //     pin_positions[i] = pins[i].transform.position;
        // }
        // pin_transform = pins[0].transform;   
        // //rb.AddForce(transform.forward * 500); 
    }

    void Update(){
        // if(flag){
        //     //UnityEngine.Debug.Log(rb.velocity.magnitude);
        //     //flag = false;
        // }
       
    }
    public void routine(){
        AudioSource src = GetComponent<AudioSource>();
        src.Play();
        // Stopwatch stopwatch = new Stopwatch();
        // stopwatch.Start();
        // for (int i = 0; i < 10000; i++){
        //         Thread.Sleep(1);
        // }
        // stopwatch.Stop();
        //float velocity = rb.velocity.magnitude;
        //flag = true;
        //yield return new WaitUntil(() => velocity < 0.5 );
        //UnityEngine.Debug.Log("Velocity Zero!"+velocity);
        // countPinsDown();
        // reset_pins();
    }
    public void OnTriggerEnter(Collider other){//IEnumerator
        if(other.gameObject.tag == "ball"){
            // if(ball[0].transform.position.z >= 6.5){ 
            routine();  
            // }
        }
    }

    // void countPinsDown(){
    //     for(int i=0;i<pins.Length;i++){

    //         float z = pins[i].transform.eulerAngles.z;
    //         float x = pins[i].transform.eulerAngles.x; 

    //         if( !((z < 275 && z > 265) || (x < 5 && x > -5)&& pins[i].activeSelf)  ){//
    //             UnityEngine.Debug.Log("Pin down!");
    //             score++;
    //             pins[i].SetActive(false);
    //         }
    //     }

 	// 	UnityEngine.Debug.Log(score);
	// 	sc[k-1].text = score.ToString();
	// 	ts = ts + score;
	// 	total_score.text = ts.ToString();
	// 	int diff = 11 - k;
	//   	chances_left.text = diff.ToString();
    //         score = 0;
	// 	k++;
    // }

    // void reset_pins(){
    //     UnityEngine.Debug.Log("reset function");
    //     for(int i=0;i<pins.Length;i++){
    //         pins[i].SetActive(true);
    //         pins[i].transform.position = pin_positions[i];
    //         pins[i].GetComponent<Rigidbody>().velocity=Vector3.zero;
    //         pins[i].GetComponent<Rigidbody>().angularVelocity=Vector3.zero;
    //         pins[i].transform.rotation = Quaternion.Slerp(pins[i].transform.rotation, pin_transform.rotation, Time.time * rotation_reset_speed);
    //     }
    //     ball[0].transform.position = ball_position;
    //     ball[0].GetComponent<Rigidbody>().velocity = Vector3.zero;
    //     ball[0].GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
    //     ball[0].transform.rotation = Quaternion.identity;
    // }

}

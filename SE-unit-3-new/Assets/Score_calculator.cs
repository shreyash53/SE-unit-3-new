using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score_calculator : MonoBehaviour
{
    int score = 0;
    public GameObject[] pins;
    public GameObject[] ball;
    Vector3[] pin_positions;
    Vector3 ball_position;
    float rotation_reset_speed = 1.0f;
    public Transform pin_transform;
    public Rigidbody rb;
    // Start is called before the first frame update
    void Start(){

        rb = GetComponent<Rigidbody>();
        ball = GameObject.FindGameObjectsWithTag("ball");
        pins = GameObject.FindGameObjectsWithTag("Pins");
        ball_position = ball[0].transform.position;
        pin_positions = new Vector3[pins.Length];
        for(int i=0;i<pins.Length;i++){
            pin_positions[i] = pins[i].transform.position;
        }
        pin_transform = pins[0].transform;
    }

    // Update is called once per frame
    void Update()
    {
        if(ball[0].transform.position.z > 6){
            Vector3 vel = rb.velocity;
            //while(vel == Vector3.zero){
                countPinsDown();
                reset_pins();
            //}
        }
    }

    void countPinsDown(){
        for(int i=0;i<pins.Length;i++){
            float z = pins[i].transform.eulerAngles.z;
            float x = pins[i].transform.eulerAngles.x; 

            if( !((z < 275 && z > 265) || (x < 5 && x > -5)) && pins[i].activeSelf ){//
                Debug.Log("Pin down!");
                score++;
                pins[i].SetActive(false);
            }
            Debug.Log(score);
            score = 0;
        }
    }

    void reset_pins(){
        Debug.Log("reset function");
        for(int i=0;i<pins.Length;i++){
            pins[i].SetActive(true);
            pins[i].transform.position = pin_positions[i];
            pins[i].GetComponent<Rigidbody>().velocity=Vector3.zero;
            pins[i].GetComponent<Rigidbody>().angularVelocity=Vector3.zero;
            pins[i].transform.rotation = Quaternion.Slerp(pins[i].transform.rotation, pin_transform.rotation, Time.time * rotation_reset_speed);
        }
        ball[0].transform.position = ball_position;
        ball[0].GetComponent<Rigidbody>().velocity = Vector3.zero;
        ball[0].GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        ball[0].transform.rotation = Quaternion.identity;
    }


}

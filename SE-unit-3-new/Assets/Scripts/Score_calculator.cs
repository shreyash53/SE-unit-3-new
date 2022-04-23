using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;
using System.IO;

public class Score_calculator : MonoBehaviour
{
    int score = 0;
    private GameObject[] pins;
    private GameObject[] ball;
    Vector3[] pin_positions;
    Vector3 ball_position;
    float rotation_reset_speed = 1.0f;
    public Transform pin_transform;
    public Rigidbody rb;
	
	public Text total_score;
	public Text[] sc;
    public Text[] t1;
    public Text[] t2;

    int []  throw1;
    int[] throw2;
    int[] score_array;
	int ts = 0;
    public static int final_score;

    private string PlayerScore;

	public Text chances_left;
	int k = 1;
    // int t = 1;
    bool flag = false;
    bool pinsFellDebugFlag;

    // Start is called before the first frame update
    void Start(){
        k = 1;
        PlayerScore = Application.persistentDataPath + "/PlayerScore.txt";
        ts = 0;
        rb = GetComponent<Rigidbody>();
        ball = GameObject.FindGameObjectsWithTag("ball");
        pins = GameObject.FindGameObjectsWithTag("Pins");
        ball_position = ball[0].transform.position;
        pin_positions = new Vector3[pins.Length];
        Debug.Log("Storing pin initial position");
        for(int i=0;i<pins.Length;i++){
            pin_positions[i] = pins[i].transform.position;
        }
        pin_transform = pins[0].transform;

        throw1 = new int[10]; 
        throw2 = new int[10];
        score_array = new int[10];  
        // reset_pins();
        pinsFellDebugFlag = true;
    }

    // Update is called once per frame
    void Update()
    {   
        
        if( (ball[0].transform.position.z > 6.5 )  && !flag ){// (ball[0].transform.position.x < 1.5 && ball[0].transform.position.x > -1.5 ) 
            flag =true;
            // Debug.Log(t);
            // t++;
            //Vector3 vel = rb.velocity;
            //while(vel == Vector3.zero){
            // countPinsDown();
            //}
        }
    }

    public void OnTriggerEnter(Collider other){//IEnumerator
        if(other.gameObject.tag == "collider" && pinsFellDebugFlag){
            // if(ball[0].transform.position.z >= 6.5){ 
            Debug.Log("in collider trigger");
            pinsFellDebugFlag = false;
            StartCoroutine(wait_function());  
            // }
        }
    }

    public IEnumerator wait_function()
    {
        Debug.Log("Started Coroutine at timestamp : " + Time.time);

        yield return new WaitForSeconds(5);

        Debug.Log("Finished Coroutine at timestamp : " + Time.time);
        countPinsDown();
        pinsFellDebugFlag = true;
    }
    void countPinsDown(){
        score = 0;
        
        for(int i=0;i<pins.Length;i++){
            float z = pins[i].transform.eulerAngles.z;
            float x = pins[i].transform.eulerAngles.x; 
            // Debug.Log(z + "angle" + x);
            if( !((z < 275 && z > 265) || (x < 5 && x > -5)) && pins[i].activeSelf ){//
                // Debug.Log("Pin down!");
                score++;
                pins[i].SetActive(false);
            }
        }

        if(k%2==1){
            t1[k/2].text = score.ToString();
            throw1[k/2] = score;
            score_array[k/2] = score;
            ts = ts + score;
            total_score.text = ts.ToString();

            reset_ball();
            //flag = false;

        }else{
            t2[(k/2)-1].text = score.ToString();
            throw2[(k/2)-1] = score;
            score_array[(k/2)-1] += score;
            sc[(k/2)-1].text = score_array[k/2 -1].ToString();
            ts = ts + score;
            total_score.text = ts.ToString();

            reset_ball();
            reset_pins();
            //flag = false;
        }

        Debug.Log("score:" + score);
		int diff = 20 - k;
	  	chances_left.text = diff.ToString();

        if(score==10){
            if(k%2==1){
                k++;
                reset_pins();
            }
        }

        // score = 0;
		k++;

        if(k==21){
            addScore(ts);
            exit_prompt();
        }
        // flag = false;
    }

    void addScore(int total_score){
        // if (File.Exists(PlayerScore)){
            using (StreamWriter writer = new StreamWriter(new FileStream(PlayerScore, FileMode.Append)))  
            {  
               writer.WriteLine(total_score);
            }  
        // }
    }


    void exit_prompt(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1 );
    }

    void reset_pins(){
        Debug.Log("Pins reset function");
        for(int i=0;i<pins.Length;i++){
            pins[i].SetActive(true);
            pins[i].transform.rotation = Quaternion.Euler (0, 0, 270f);
            // pins[i].transform.rotation = Quaternion.Slerp(pins[i].transform.rotation, pin_transform.rotation, Time.time * rotation_reset_speed);
            pins[i].GetComponent<Rigidbody>().velocity=Vector3.zero;
            pins[i].GetComponent<Rigidbody>().angularVelocity=Vector3.zero;
            pins[i].transform.position = pin_positions[i];
        }
    }

    void reset_ball(){
        ball[0].transform.position = ball_position;
        ball[0].GetComponent<Rigidbody>().velocity = Vector3.zero;
        ball[0].GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        ball[0].transform.rotation = Quaternion.identity;
    }

}

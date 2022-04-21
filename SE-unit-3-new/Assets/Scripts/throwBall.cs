using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class throwBall : MonoBehaviour
{
    // // Start is called before the first frame update
    // void Start()
    // {
        
    // }

    // // Update is called once per frame
    // void Update()
    // {
        
    // }

    public static int one;
    public void OnTriggerEnter(Collider other){
        // one++;
        // Debug.Log(other.gameObject.name + " " + one);
        if(other.gameObject.name == "Bowling Ball"){
            AudioSource src = GetComponent<AudioSource>();
            src.Play();
            Debug.Log("here");
        }
    }

}

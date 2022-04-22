using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.IO;
using System;

public class FileHandling : MonoBehaviour
{
    private string PlayerScore;
    // private const string PlayerScore = "PlayerScore.txt";
    public TextMeshProUGUI score_debug1;
    public TextMeshProUGUI score_debug2;
    public TextMeshProUGUI[] scores;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(Application.persistentDataPath);
        PlayerScore = Application.persistentDataPath + "/PlayerScore.txt";
        
    }

    // Update is called once per frame
    void Update()
    {
        // if(flag){
            if (File.Exists(PlayerScore))
            {
                
                var jsonString = File.ReadAllText(PlayerScore);
                // var hitCount = JsonUtility.FromJson<HitCount>(jsonString);
                // score_debug1.text = "file exists";
                score_debug2.text = jsonString;
            }
            else{
                score_debug1.text = "file does not exists";

                File.WriteAllText(PlayerScore, "something other");
            }
        // }
    }

    void scoreDisplay(){
        if (File.Exists(PlayerScore)){
            using (StreamReader reader = new StreamReader(new FileStream(PlayerScore, FileMode.Open)))  
            {  
                string line;  
                // Read line by line  
                while ((line = reader.ReadLine()) != null)  
                {  
                    string[] floats = line.Split(" "[0]);
                    int[] nums = Array.ConvertAll(floats, int.Parse);
                    Array.Sort(nums);
                    // floats = Array.ConvertAll(nums, Convert.ToString);
                    for(int i=0; i<9; i++){
                        scores[i].text = nums[i].ToString();
                    }
                }
            }  
        }
    }  
        
        
}

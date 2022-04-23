using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.IO;
using System;
using UnityEngine.SceneManagement;

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
        scoreDisplay();
    }

    // Update is called once per frame
    void Update()
    {
        // if(flag){
            // if (File.Exists(PlayerScore))
            // {
                
            //     var jsonString = File.ReadAllText(PlayerScore);
            //     // var hitCount = JsonUtility.FromJson<HitCount>(jsonString);
            //     // score_debug1.text = "file exists";
            //     score_debug2.text = jsonString;
            // }
            // else{
            //     score_debug1.text = "file does not exists";

            //     File.WriteAllText(PlayerScore, "something other");
            // }
        // }
    }

    void scoreDisplay(){
        if (File.Exists(PlayerScore)){
            // using (StreamReader reader = new StreamReader(new FileStream(PlayerScore, FileMode.Open)))  
            // {  
            //     string line;  
            //     // Read line by line  
            //     while ((line = reader.ReadLine()) != null)  
            //     {  
            //         string[] floats = line.Split(" "[0]);
            //         Debug.Log(floats.Length);
            //         if(floats.Length > 0){
            //             int[] nums = Array.ConvertAll(floats, int.Parse);
            //             Array.Sort(nums);
            //             // floats = Array.ConvertAll(nums, Convert.ToString);
            //             int i;
            //             for(i=0; i<=9; i++){
            //                 scores[i].text = (i+1).ToString() + ".  ";
            //                 if(i < nums.Length)
            //                     scores[i].text += nums[i].ToString();
            //             }
            //         }
            //         else{
            //             for(i=0; i<=9; i++){
            //                 scores[i].text = "";
            //             }
            //             score_debug1.text = "No scores saved";
            //         }
            //     }
            // }  
            string[] lines = File.ReadAllLines(PlayerScore);
            if(lines.Length > 0){
                int[] nums = Array.ConvertAll(lines, int.Parse);
                Array.Sort(nums);
                Array.Reverse(nums);
                // floats = Array.ConvertAll(nums, Convert.ToString);
                int i;
                for(i=0; i<=9; i++){
                    scores[i].text = (i+1).ToString() + ".  ";
                    if(i < nums.Length)
                        scores[i].text += nums[i].ToString();
                }
            }
            else{
                for(int i=0; i<=9; i++){
                    scores[i].text = "";
                }
                score_debug1.text = "No scores saved";
            }
            
        }
        else{
            using (StreamWriter writer = new StreamWriter(new FileStream(PlayerScore, FileMode.Create)))  
            {  
               writer.WriteLine("");
            } 
            score_debug1.text = "No scores saved";
        }
    }  
        
    public void GetMainMenu(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex -3 );
    }

    public void ResetScore(){
        File.WriteAllText(PlayerScore, "");
        scoreDisplay();
    }
}

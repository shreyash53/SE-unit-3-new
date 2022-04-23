using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;

public class endMenu : MonoBehaviour
{

    public Text score;
    private string PlayerScore;

    // Start is called before the first frame update
    void Start()
    {
        PlayerScore = Application.persistentDataPath + "/PlayerScore.txt";
        if (File.Exists(PlayerScore)){
            string[] lines = File.ReadAllLines(PlayerScore);
            int cnt = lines.Length-1;
            string lastline;
            if(cnt == -1)
                lastline = "-1";
            else
                lastline = lines[cnt];
                
            score.text = lastline;
        }
        else{
            score.text = "-1";
        }

    }

    public void RestartGame(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1 );
    }
    
    public void GetMainMenu(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2 );

    }
}

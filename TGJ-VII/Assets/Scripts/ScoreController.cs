using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreController : MonoBehaviour {

    public bool canSubmit = true;
    public string playerName;

    public int currentScore;

	// Use this for initialization
	void Start () {
        playerName = "Dude";
	}
	
	// Update is called once per frame
	void Update () {

        //print(playerName);
	}

    public void GiveScore(int givenScore)
    {
        currentScore += givenScore;
    }

    public void ReduceScore(int givenScore)
    {
        currentScore -= givenScore;
    }


    public void ResetScore()
    {
        currentScore = 0;
    }


    //Koodausjumalat, antakaa minulle anteeksi
    public void SubmitScore()
    {
        if (canSubmit == true)
        {

            bool scoresChecked = false; ;
            string tempScorer1;
            string tempScorer2;
            string tempScorer3;
            string tempScorer4;
            string tempScorer5;

            int tempScore1;
            int tempScore2;
            int tempScore3;
            int tempScore4;
            int tempScore5;

            tempScorer1 = PlayerPrefs.GetString("Top1Scorer", "");
            tempScorer2 = PlayerPrefs.GetString("Top2Scorer", "");
            tempScorer3 = PlayerPrefs.GetString("Top3Scorer", "");
            tempScorer4 = PlayerPrefs.GetString("Top4Scorer", "");
            tempScorer5 = PlayerPrefs.GetString("Top5Scorer", "");

            tempScore1 = PlayerPrefs.GetInt("Top1Score");
            tempScore2 = PlayerPrefs.GetInt("Top2Score");
            tempScore3 = PlayerPrefs.GetInt("Top3Score");
            tempScore4 = PlayerPrefs.GetInt("Top4Score");
            tempScore5 = PlayerPrefs.GetInt("Top5Score");


            if (currentScore > PlayerPrefs.GetInt("Top1Score", 0) && scoresChecked == false)
            {
                PlayerPrefs.SetString("Top2Scorer", tempScorer1);
                PlayerPrefs.SetString("Top3Scorer", tempScorer2);
                PlayerPrefs.SetString("Top4Scorer", tempScorer3);
                PlayerPrefs.SetString("Top5Scorer", tempScorer4);

                PlayerPrefs.SetInt("Top2Score", tempScore1);
                PlayerPrefs.SetInt("Top3Score", tempScore2);
                PlayerPrefs.SetInt("Top4Score", tempScore3);
                PlayerPrefs.SetInt("Top5Score", tempScore4);



                PlayerPrefs.SetInt("Top1Score", currentScore);
                PlayerPrefs.SetString("Top1Scorer", playerName);
                scoresChecked = true;
            }

            if (currentScore > PlayerPrefs.GetInt("Top2Score", 0) && scoresChecked == false)
            {


                PlayerPrefs.SetString("Top3Scorer", tempScorer2);
                PlayerPrefs.SetString("Top4Scorer", tempScorer3);
                PlayerPrefs.SetString("Top5Scorer", tempScorer4);


                PlayerPrefs.SetInt("Top3Score", tempScore2);
                PlayerPrefs.SetInt("Top4Score", tempScore3);
                PlayerPrefs.SetInt("Top5Score", tempScore4);


                PlayerPrefs.SetInt("Top2Score", currentScore);
                PlayerPrefs.SetString("Top2Scorer", playerName);
                scoresChecked = true;
            }

            if (currentScore > PlayerPrefs.GetInt("Top3Score", 0) && scoresChecked == false)
            {

                PlayerPrefs.SetString("Top4Scorer", tempScorer3);
                PlayerPrefs.SetString("Top5Scorer", tempScorer4);


                PlayerPrefs.SetInt("Top4Score", tempScore3);
                PlayerPrefs.SetInt("Top5Score", tempScore4);



                PlayerPrefs.SetInt("Top3Score", currentScore);
                PlayerPrefs.SetString("Top3Scorer", playerName);
                scoresChecked = true;
            }

            if (currentScore > PlayerPrefs.GetInt("Top4Score", 0) && scoresChecked == false)
            {

                PlayerPrefs.SetString("Top5Scorer", tempScorer4);
                PlayerPrefs.SetInt("Top5Score", tempScore4);




                PlayerPrefs.SetInt("Top4Score", currentScore);
                PlayerPrefs.SetString("Top4Scorer", playerName);
                scoresChecked = true;
            }

            if (currentScore > PlayerPrefs.GetInt("Top5Score", 0) && scoresChecked == false)
            {
                PlayerPrefs.SetInt("Top5Score", currentScore);
                PlayerPrefs.SetString("Top5Scorer", playerName);
                scoresChecked = true;
            }

        }
        canSubmit = false;
    }


    
    

}

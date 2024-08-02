using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class ScoreSet : MonoBehaviour
{

    //0.9926
    private TextMeshProUGUI txtmsh;
    float skor;
    void Start()
    {
        if(this.gameObject.name == "fff")
        {
            if (ScoreController.instance != null)
            {
                skor = ScoreController.instance.best;
                txtmsh = this.gameObject.GetComponentInChildren<TextMeshProUGUI>();
                txtmsh.text = "1. score: " + skor.ToString();
            }
            else
            {
                Debug.LogError("ScoreController instance is null. Make sure the ScoreController is properly initialized.");
            }
            
        }
        else if(this.gameObject.name == "sss")
        {
            if (ScoreController.instance != null)
            {
                skor = ScoreController.instance.second;
                txtmsh = this.gameObject.GetComponentInChildren<TextMeshProUGUI>();
                txtmsh.text = "2. score: " + skor.ToString();
            }
            else
            {
                Debug.LogError("ScoreController instance is null. Make sure the ScoreController is properly initialized.");
            }
            
        }
        else if(this.gameObject.name == "ttt")
        {
            if (ScoreController.instance != null)
            {
                skor = ScoreController.instance.third;
                txtmsh = this.gameObject.GetComponentInChildren<TextMeshProUGUI>();
                txtmsh.text = "3. score: " + skor.ToString();
            }
            else
            {
                Debug.LogError("ScoreController instance is null. Make sure the ScoreController is properly initialized.");
            }
            
        }
    }
    /*
    private void Start()
    {
        if (this.gameObject.name == "fff" || this.gameObject.name == "sss" || this.gameObject.name == "ttt")
        {
            txtmsh = this.gameObject.GetComponentInChildren<TextMeshProUGUI>();

            if (txtmsh == null)
            {
                Debug.LogError("TextMeshPro bileþeni bulunamadý!");
                return;
            }

            float score = 0;

            switch (this.gameObject.name)
            {
                case "fff":
                    score = ScoreController.instance.GetScore(1);
                    break;
                case "sss":
                    score = ScoreController.instance.GetScore(2);
                    break;
                case "ttt":
                    score = ScoreController.instance.GetScore(3);
                    break;
            }

            txtmsh.text = $"{this.gameObject.name[0]}. score: {score}";
        }
    }*/



}

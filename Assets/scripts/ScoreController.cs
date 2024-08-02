using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreController : MonoBehaviour
{
    public static ScoreController instance;
    public float finalscore = 0f;
    public float best = 0f;
    public float second = 0f;
    public float third = 0f;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
        else if(instance != this)
        {
            Destroy(gameObject);
        }


    }

    public void AddScore(float score)
    {
        finalscore += score;
    }



    public float GetScore(int d)
    {
        if(d == 1)
        {
            return best;
        }
        else if(d == 2)
        {
            return second;
        }
        else if(d == 3)
        {
            return third;
        }
        return -1;
    }

}

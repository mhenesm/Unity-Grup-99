using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private Vector3 originalScale;
    public float enterSizeEffect = 1.2f;
    

    private void Start()
    {
        if(this.gameObject.tag == "buttons")
        {
            originalScale = this.gameObject.transform.localScale;
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        transform.localScale = originalScale * enterSizeEffect;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        transform.localScale = originalScale;
    }

    public void PlayButton()
    {
        SceneManager.LoadScene("GameScene");
        ScoreController.instance.finalscore+=8f;
    }
    public void ScoreButton()
    {
        SceneManager.LoadScene("ScoreScene");
        ScoreController.instance.AddScore(5f);
    }
    public void ExitButton()
    {
        Application.Quit();
    }
    public void denemebuton()
    {
        SceneManager.LoadScene("SampleScene");
        ScoreController.instance.AddScore(10f);
    }
    
    public void backMenuButon()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DeathManager : MonoBehaviour
{
    //prefab rocks operations
    public float engellerspeed=3f;
    public GameObject[] prefabs;
    public Transform spawnPoint1;
    public Transform spawnPoint2;
    public Transform spawnPoint3;
    public Transform spawnPoint4;
    private Transform spawnPointcurrent;
    private bool canSpawn = true;
    public float mincd = 3f;
    public float maxcd = 6f;
    public float minv = 3f;
    public float maxv = 6f;
    public float secondPhaseTime = 10f;
    public float thirdPhaseTime = 25f;
    public float thirdmincd =1;
    public float thirdmaxcd =3;
    public float secondmincd =2;
    public float secondmaxcd =5;
    private int prefabIndex;
    private float currminv;
    private float currmaxv;
    private bool goPlatform = false;
    GameObject spawnedPrefab;
    Rigidbody2D prrb;
    public int can = 3;
    //other operations
    public GameObject txtobj;
    private TextMeshProUGUI txt;
    public GameObject gameOverScreen;
    public float score = 0f;
    public float scorepersec = 1f;
    public bool isAlive = true;
    public GameObject chr;
    [SerializeField] float ttime=0f;

    private void FixedUpdate()
    {
        if(can == 0 && isAlive==true)
        {
            isAlive = false;
            if (score > ScoreController.instance.best)
            {
                ScoreController.instance.second = ScoreController.instance.best;
                ScoreController.instance.best = score;
            }
            else if (score > ScoreController.instance.second)
            {
                ScoreController.instance.third = ScoreController.instance.second;
                ScoreController.instance.second = score;
            }
            else if (score > ScoreController.instance.third)
            {
                ScoreController.instance.third = score;
            }
            gameOverScreen.SetActive(true);
        }
        if (deneme != null)
        {
            denemrb = deneme.gameObject.GetComponent<Rigidbody2D>();
            if (denemrb != null)
            {
                denemrb.velocity = new Vector2(-1 * engellerspeed, 0);
                //prrb.AddForce(Vector2.left*Random.Range(minforce,maxforce));
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        

        /*if (collision.gameObject.CompareTag("char"))
        {
            isAlive = false;
            if (score > ScoreController.instance.best)
            {
                ScoreController.instance.second = ScoreController.instance.best;
                ScoreController.instance.best = score;
            }
            else if (score > ScoreController.instance.second)
            {
                ScoreController.instance.third = ScoreController.instance.second;
                ScoreController.instance.second = score;
            }
            else if (score > ScoreController.instance.third)
            {
                ScoreController.instance.third = score;
            }
            gameOverScreen.SetActive(true);
        }*/
        if (collision.gameObject.CompareTag("engel"))
        {
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("nonengel"))
        {
            Destroy(collision.gameObject);
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("gold"))
        {
            Destroy(collision.gameObject);
            score += 30;
        }
        if (collision.gameObject.CompareTag("kalp"))
        {
            Destroy(collision.gameObject);
            can--;
        }
    }
    GameObject deneme;
    Rigidbody2D denemrb;
    
    private void Awake()
    {
        txt = txtobj.GetComponent<TextMeshProUGUI>();
        StartCoroutine(ScorePerSecond());
        StartCoroutine(SpawnPrefab());
        StartCoroutine(ZorlukDegistir());
    }
    
    IEnumerator SpawnPrefab()
    {
        
        while (canSpawn)
        {
            if (goPlatform)
            {
                spawnPointcurrent = spawnPoint4;
                spawnedPrefab = Instantiate(prefabs[3], spawnPointcurrent.position, Quaternion.identity);

                deneme = spawnedPrefab;
                /*prrb = spawnedPrefab.GetComponent<Rigidbody2D>();
                if (prrb != null)
                {
                    prrb.velocity = new Vector2(-1 * Random.Range(currminv, currmaxv), 0);
                    //prrb.AddForce(Vector2.left*Random.Range(minforce,maxforce));
                }*/
                goPlatform = false;
            }
            float spawnSuresi =Random.Range(mincd,maxcd);
            yield return new WaitForSeconds(spawnSuresi);

            int prefabLuck = Random.Range(0, 6);
            if (0 <= prefabLuck && prefabLuck < 3)
            {
                prefabIndex = 0;
                currminv = minv;
                currmaxv = maxv;
                spawnPointcurrent = spawnPoint1;
            }else if(3<= prefabLuck && prefabLuck < 5)
            {
                spawnPointcurrent = spawnPoint2;
                currminv = minv;
                currmaxv = maxv;
                prefabIndex = 1;
            }else if (prefabLuck == 5)
            {
                prefabIndex = 2;
                currminv = minv-1;
                currmaxv = maxv-2;
                spawnPointcurrent = spawnPoint3;
            }
            
            spawnedPrefab = Instantiate(prefabs[prefabIndex], spawnPointcurrent.position,Quaternion.identity);
            prrb = spawnedPrefab.GetComponent<Rigidbody2D>();
            if (prrb != null)
            {
                prrb.velocity = new Vector2(-1*Random.Range(currminv, currmaxv), 0);
                //prrb.AddForce(Vector2.left*Random.Range(minforce,maxforce));
            }
        }
    }

    IEnumerator ZorlukDegistir()
    {
        yield return new WaitForSeconds(secondPhaseTime);
        mincd = secondmincd;
        maxcd = secondmaxcd;

        yield return new WaitForSeconds(thirdPhaseTime);
        goPlatform = true;
    }
    IEnumerator ScorePerSecond()
    {
        while (isAlive)
        {
            yield return new WaitForSeconds(1f);
            score += scorepersec;
            ttime += 1;
            updateText();
        }
        
    }

    private void updateText()
    {
        txt.text = "Score: "+score.ToString();
    }

}

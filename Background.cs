using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Background : MonoBehaviour
{
    public GameObject BackgroundMain, BackgroundSecond;
    public Sprite forest, desert, snowForest, halloween;
    SpriteRenderer spriteRenderer;
    Transform backTransform;
    public float speed = 1;
    float startPos, size;
    int backgroundIntNow;
    
    void Start() 
    {
        Application.targetFrameRate = 60;
        backTransform = GetComponent<Transform>();
        size = GetComponent<SpriteRenderer>().bounds.size.x;
        if (PlayerPrefs.HasKey("IntBackground"))
        {
            backgroundIntNow = PlayerPrefs.GetInt("IntBackground");
            ChangeBackground(backgroundIntNow);
        }
        if (PlayerPrefs.HasKey("floatSpeed"))
        {
            speed = PlayerPrefs.GetFloat("floatSpeed");
        }
    }
    void Update() 
    {
        Move();
    }
    void Move()
    {
        startPos += speed / 25f;
        startPos = Mathf.Repeat(startPos, size);
        backTransform.position = new Vector3(startPos, transform.position.y, transform.position.z);
    }
    public void SpeedSlider(Slider q)
    {
        speed = (float)q.value;
        PlayerPrefs.SetFloat("floatSpeed", speed);
    }
    public void ChangeBackground(int w)
    {
        PlayerPrefs.SetInt("IntBackground", w);
        if (w == 1)
        {
            BackgroundMain.GetComponent<SpriteRenderer>().sprite = forest;
            BackgroundSecond.GetComponent<SpriteRenderer>().sprite = forest;
        }
        else if (w == 2)
        {
            BackgroundMain.GetComponent<SpriteRenderer>().sprite = desert;
            BackgroundSecond.GetComponent<SpriteRenderer>().sprite = desert;
        }
        else if (w == 3)
        {
            BackgroundMain.GetComponent<SpriteRenderer>().sprite = snowForest;
            BackgroundSecond.GetComponent<SpriteRenderer>().sprite = snowForest;
        }
        else if (w == 4)
        {
            BackgroundMain.GetComponent<SpriteRenderer>().sprite = halloween;
            BackgroundSecond.GetComponent<SpriteRenderer>().sprite = halloween;
        }
    }
}

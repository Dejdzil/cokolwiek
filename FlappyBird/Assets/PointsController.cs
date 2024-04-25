using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PointsController : MonoBehaviour
{
    public TextMeshProUGUI textField;
    public BirdController birdController;
    public bool isHighScore;

    // Start is called before the first frame update
    void Start()
    {
        textField.text = "0";   
    }

    // Update is called once per frame
    void Update()
    {
        if(isHighScore)
        {
            textField.text = PlayerPrefs.GetInt("HighScore").ToString();
        }
        else
        {
            textField.text = birdController.points.ToString();
        }
        
    }
}

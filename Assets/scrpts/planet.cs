using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class planet : MonoBehaviour
{
    [SerializeField]
    public int amoutShips;
    // Start is called before the first frame update
    Text text; 
    float timeCount;
     Color newColor;
    void Start()
    {  
        text = gameObject.transform.Find("Text").GetComponent<Text> ();
        timeCount = 0f;
        this.amoutShips = Random.Range(10, 150);
        text.text = "" + this.amoutShips;
    }
    void Update() {
        this.timeCount += Time.deltaTime;    
        if(gameObject.tag == "netural"){
            text = gameObject.transform.Find("Text").GetComponent<Text> ();
            text.text = "" + this.amoutShips;         
        }
        if(gameObject.tag == "planet" && (timeCount > 0.2f)){
            this.amoutShips += 1;
            text = gameObject.transform.Find("Text").GetComponent<Text> ();
            text.text = "" + this.amoutShips;
           
            SpriteRenderer renderer = transform.GetComponent<SpriteRenderer>();
            timeCount = 0f;
        }
    }

}

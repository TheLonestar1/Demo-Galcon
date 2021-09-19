using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class capture : MonoBehaviour
{
    Color newColor;
    private void OnTriggerEnter(UnityEngine.Collider otherObj)
	{
       
		//Object.Instantiate<GameObject>(this.explosion, base.transform.position, base.transform.rotation);
        if(otherObj.tag == "netural"){
		Destroy(base.gameObject);
        otherObj.transform.GetComponent<planet>().amoutShips-= 2;
        if(otherObj.transform.GetComponent<planet>().amoutShips < 0){
            otherObj.tag = "planet";
            newColor = new Color(0f,1f,1f,1f);
            otherObj.GetComponent<SpriteRenderer>().color = newColor;
        }
        
        }
        if(otherObj.tag == "planet"){
            Destroy(base.gameObject);
            otherObj.transform.GetComponent<planet>().amoutShips+= 2;
        } 
	}

	// Token: 0x04000001 RID: 1
	//public GameObject explosion;
}

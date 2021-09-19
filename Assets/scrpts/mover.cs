using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mover : MonoBehaviour
{
    // Start is called before the first frame update
    Ray lastRay;
    RaycastHit raycastHit;
    
    planet planets;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0)) {
            this.lastRay = Camera.main.ScreenPointToRay(Input.mousePosition);
			
            if (Physics.Raycast(this.lastRay, out raycastHit) && (raycastHit.collider.tag == "planet"))
		    {
                planets = raycastHit.transform.GetComponent<planet>();
                
		    }
            if (Physics.Raycast(this.lastRay, out raycastHit) && (raycastHit.collider.tag == "planet"))
		    {
                planets = raycastHit.transform.GetComponent<planet>();
                
		    }
            if (Physics.Raycast(this.lastRay, out raycastHit) && (raycastHit.collider.tag == "planet"))
		    {
                planets = raycastHit.transform.GetComponent<planet>();
                
		    }
        }
    }
}

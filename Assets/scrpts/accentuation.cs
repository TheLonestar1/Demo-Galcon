using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class accentuation : MonoBehaviour
{
    public GameObject ship;
    SpriteRenderer render;
    Ray lastRay;
    RaycastHit raycastHit;
    planet planets;
    Transform transforme;
    Transform pos;
    private int num;
    private int flag;
    private int flag2;
    NavMeshAgent ships;
    GameObject[] cloneship;
    RaycastHit n_planet;
    float angle;
    
    // Start is called before the first frame update
    void Start()
    {
        render = GetComponent<SpriteRenderer>();
        flag = 0;
        flag = 0;
        cloneship = new GameObject[1]; 
    }

    // Update is called once per frame
    void Update()
    {
       
        if(Input.GetMouseButtonDown(0)){
            this.lastRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(this.lastRay, out raycastHit) && (raycastHit.collider.tag == "planet"))
		    {
                Color newColor = new Color(0f, 1f, 1f, 1f);
                if(planets != null){
                    newColor = new Color(0f, 1f, 1f, 1f);
                    render.color = newColor;
                }
                render = raycastHit.transform.GetComponent<SpriteRenderer>();
                render.color = Color.blue;
                planets = raycastHit.transform.GetComponent<planet>();
                transforme = raycastHit.transform.GetComponent<Transform>();
		    }
            else if (Physics.Raycast(this.lastRay, out raycastHit) && (raycastHit.collider.tag == "bg"))
		    {
                Color newColor = new Color(0f, 1f, 1f, 1f);
                render.color = newColor;
		    }
            else if (Physics.Raycast(this.lastRay, out raycastHit) && raycastHit.collider.tag == "netural"  && planets != null) 
            {
                int n = planets.amoutShips / 2;
                planets.amoutShips -= n;
                planets = null;
                n = n / 2;
                this.num = n;
                this.n_planet = raycastHit;
                pos = raycastHit.transform.GetComponent<Transform>();
                cloneship = new GameObject[num]; 
                Color newColor = new Color(0f, 1f, 1f, 1f);
                render.color = newColor;
                spawner(n,transforme,pos);
                raycastHit.collider.isTrigger = true;
                this.flag = 1;
		    }
            
        }
        if(this.flag == 1){
             
            int sum = 0;
            
            for(int i = 0; i < this.num;i++) {
                Debug.Log(sum);
                if(cloneship[i] == null){
                    sum++;
                }
                else {
                    Vector3 direct = pos.position - cloneship[i].transform.position;
                    this.angle = Mathf.Atan2(direct.y,direct.x)*Mathf.Rad2Deg;  
                    cloneship[i].transform.rotation = Quaternion.Euler(0,0,angle + 77f);
                }
            }
            if(sum == num){
                n_planet.collider.isTrigger = false;
                flag = 0;
            } 
        }
    }

    private void spawner(int n,Transform position,Transform pos){
        for(int i = 0; i < n; i++){
            Vector3 new_pos = new Vector3(3f,0f,0f);
            Vector3 buff = position.position;
            buff += new_pos;
               
			cloneship[i] = Object.Instantiate<GameObject>(this.ship, buff,position.rotation);
            ships = cloneship[i].GetComponent<NavMeshAgent>();
            ships.updateUpAxis = false;
            ships.updateRotation = false;
            ships.SetDestination(pos.position);
        }
    }     
}

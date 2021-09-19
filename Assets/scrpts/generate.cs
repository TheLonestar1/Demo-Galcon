using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class generate : MonoBehaviour
{
    // Start is called before the first frame update
    NavMeshSurface surface;
        Vector3 size;
    [SerializeField]
    private int p;
    public GameObject camera;   

    public GameObject planet;
    public Transform parent;

    GameObject[] a; 

    
    private Collider renderer;

    Color newColor;
  
    void Start()
    {
      
        a = new GameObject[p];
        generates();
        surface =  GetComponent<NavMeshSurface>();
        surface.BuildNavMesh(); 
        int rand_n = Random.Range(0, p-1);
        a[rand_n].tag = "planet"; 
        newColor = new Color(0f,1f,1f,1f);
        a[rand_n].GetComponent<SpriteRenderer>().color = newColor;

    }

    // Update is called once per frame
    void  generates(){
        Vector2 min = Camera.main.ViewportToWorldPoint (new Vector2 (0,0));
       
        Vector2 max = Camera.main.ViewportToWorldPoint (new Vector2 (1,1));
        Vector3 buff = min;
        Vector3 buff2 = max;
        
        
        Vector3 xcam = buff + camera.transform.position;
        Vector3 xcam2 = buff2 + camera.transform.position;
       
        
        int i = 0;
        float sum = 0;
        float z = 7f;
        int flag = 0;
        int u = 0;
        while(p > i && u < 10000){
            sum = 0;
            float x = Random.Range(xcam.x+2f, xcam2.x-4f);
            float y = Random.Range(xcam.y+2f, xcam2.y-2f);
            Vector3 position = new Vector3(x, y, z);
            flag = 0;
            int q = 0;
            
            float []ranges = new float[p];
            int []index = new int[p];
            float mini  = 1000;
            for(int j = 0; j < p;j++){
                ranges[j] = 0;
            }
            for(int j = 0; j < i; j++){
                renderer = a[0].GetComponent<Collider> ();
                size =  renderer.bounds.size;
                Vector3 pos_old =a[j].GetComponent<Transform>().position;
                float range = Mathf.Sqrt(Mathf.Pow(position.x - pos_old.x,2) + Mathf.Pow(position.y - pos_old.y,2));
                ranges[j] = range;
                   
                /*if(range > sum){
                    sum += size.x;
                    a[j] = Instantiate(planet, position, Quaternion.identity) as GameObject;
                    break;
                }*/
            }
            for(int j = 0; j < i;j++){
                if(Mathf.Abs(ranges[j]) <= mini){
                    mini = ranges[j];
                    index[0] = j;
                }
            }
            
            for(int j = 0; j < i;j++){
                renderer = a[0].GetComponent<Collider> ();
                size =  renderer.bounds.size; 
                
                if((mini > ranges[j] - 5)&&(mini != ranges[j])){
                    q++;
                }
            }
            if(q == 0 && mini < size.x){
                flag = 1;
            }
              
            for(int j = 0; j < q;j++){
                renderer = a[0].GetComponent<Collider>();
                size =  renderer.bounds.size;
                sum += size.x;   
            }
            for(int j = 0; j < i; j++){
               

                Vector3 pos_old =a[j].GetComponent<Transform>().position;
                float range = Mathf.Sqrt(Mathf.Pow(position.x - pos_old.x,2) + Mathf.Pow(position.y - pos_old.y,2)); 
                
                if(range < size.x*2 + sum){

                    flag = 1;
                }
            }
            if(flag == 0){
                a[i] = Instantiate(planet, position, Quaternion.identity,parent) as GameObject;
                newColor = new Color(0.5f,0.5f,0.5f,1f);
            
        
                a[i].GetComponent<SpriteRenderer>().color = newColor;
                
                Debug.Log("sum: i :"+ i + sum*2); 
                Debug.Log("min: i :"+ i + mini);  
                i += 1;
            }
            u++;
            
        }

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObjects : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Plane;
    public GameObject Cube;
    public double PlaneTop{get;set;}
    public double PlaneBottom{get;set;}
    public double PlaneRight{get;set;}
    public double PlaneLeft{get;set;}
    void Start()
    {
        PlaneTop = Plane.transform.lossyScale.z*5 - Cube.transform.lossyScale.z/2;
        PlaneRight = Plane.transform.lossyScale.x*5 - Cube.transform.lossyScale.x/2;
        PlaneBottom = PlaneTop-Plane.transform.lossyScale.z*10+Cube.transform.lossyScale.z;
        PlaneLeft = PlaneRight-Plane.transform.lossyScale.x*20+Cube.transform.lossyScale.x;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.UpArrow) && Cube.transform.position.z+0.1f<=PlaneTop)
        {
            Cube.transform.position = new Vector3(Cube.transform.position.x,Cube.transform.position.y,Cube.transform.position.z+0.1f);
        }
        else if(Input.GetKey(KeyCode.DownArrow) && Cube.transform.position.z-0.1f>=PlaneBottom){
            Cube.transform.position = new Vector3(Cube.transform.position.x,Cube.transform.position.y,Cube.transform.position.z-0.1f);
        }
        else if(Input.GetKey(KeyCode.RightArrow) && Cube.transform.position.x+0.1f<=PlaneLeft+Plane.transform.localScale.x*10-Cube.transform.localScale.x){
            Cube.transform.position = new Vector3(Cube.transform.position.x+0.1f,Cube.transform.position.y,Cube.transform.position.z);
        }
        else if(Input.GetKey(KeyCode.LeftArrow) && Cube.transform.position.x-0.1f>=PlaneLeft){
            Cube.transform.position = new Vector3(Cube.transform.position.x-0.1f,Cube.transform.position.y,Cube.transform.position.z);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouse : MonoBehaviour {
    public GameObject gameObject;
    private Vector2 pre_position=new Vector2();
    public bool isDown = false;
    private Transform current_object=null;
    private static int complete = 7;

    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 fin_position = Input.mousePosition;
        
        if ((!isDown)&&Input.GetMouseButtonDown(0))
        {
            pre_position = fin_position;
            isDown = true;

            Ray origin_ray = Camera.main.ScreenPointToRay(fin_position);
            Vector2 origin = new Vector2(origin_ray.origin.x, origin_ray.origin.y);
            Vector2 fin = new Vector2(fin_position.x, fin_position.y);
            Ray new_ray = new Ray(origin, fin_position);
            RaycastHit2D raycastHit = Physics2D.Raycast(origin, fin);

            if (raycastHit)
            {
                Transform temp = raycastHit.transform;
                if (temp.tag == "Puzzle"||temp.tag=="Back")
                {
                    current_object = temp;
                }
            }
        }
        
        // move with mouse
        if (isDown&&current_object&& current_object.tag == "Puzzle")
        {
            current_object.position = Camera.main.ScreenToWorldPoint(new Vector3(fin_position.x, fin_position.y, 10));
        }

        // change direction
        if (Input.GetMouseButtonUp(0))
        {
            if (current_object&&current_object.tag == "Position")
            {
                string position_name = current_object.GetComponent<Puzzle>().position;
                Vector3 match = GameObject.Find(position_name).transform.localPosition;
                Vector3 target = new Vector3(match.x, match.y, 0);
                current_object.localPosition = target;
                if (--complete==0)
                {
                    Ending ending = GameObject.Find("Ending").GetComponent<Ending>();
                    ending.showPics();
                }
            }
            else if (current_object&&current_object.tag == "Puzzle"&&
                 fin_position.x == pre_position.x && fin_position.y == pre_position.y)
            {
                 Vector3 angle = new Vector3(0, 0, current_object.eulerAngles.z);
                 angle.z = angle.z + 45;
                 if (angle.z >= 360)
                 {
                    angle.z = angle.z - 360;
                 }

                 current_object.eulerAngles = angle;
                 pre_position = new Vector2();

            }
            else if(current_object && current_object.tag == "Back")
            {
                //back to last scene
                current_object.GetComponent<Back>().GoBack();
            }
            isDown = false;
            current_object = null;
        }
    }
}

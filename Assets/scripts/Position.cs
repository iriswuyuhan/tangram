using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.scripts.common;

public class Position : MonoBehaviour {
    private bool enter = false;
    private string currentObject = null;
    private bool occupied = false;
    private static double[] accept_angle = { 90.0,180.0,360.0,360.0,360.0};

    public GameObject gameObject;
    
	// Use this for initialization
	void Start () {
	}

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.tag == "Puzzle")
        {
            string positionName = this.name.Substring(9, this.name.Length-10);
            string puzzleName = collision.gameObject.name.Substring(0,collision.gameObject.name.Length-1);
            
            //the puzzle fits in
            if (positionName == puzzleName)
            {
                enter = true;
                currentObject = collision.gameObject.name;
            }

        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Puzzle")
        {
            //if it's the same puzzle
            string puzzleName = collision.gameObject.name;
            if (currentObject == puzzleName&&(!occupied)&&Input.GetMouseButtonUp(0))
            {
                Vector3 rotation = collision.gameObject.transform.eulerAngles;
                Vector3 expectedRotation = this.transform.eulerAngles;
                string puzzleType = puzzleName.Substring(0, puzzleName.Length - 2);
                int index = Index.getAngleIndex(puzzleType);
                double angle = accept_angle[index];
                float minus = rotation.z - expectedRotation.z;
                while (minus < 90)
                {
                    minus = minus + 360;
                }
                    
                if (minus%angle-0.0<0.01)
                {
                    print(2);
                    Puzzle current_puzzle = collision.gameObject.GetComponent<Puzzle>();
                    current_puzzle.position= this.name;
                    current_puzzle.tag = "Position";
                    occupied = true;
                }

            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Puzzle")
        {
            string puzzleName = collision.gameObject.name;
            if (currentObject == puzzleName)
            {
                print("I have exited!");
                enter = false;
                currentObject = null;
            }

        }
    }
}

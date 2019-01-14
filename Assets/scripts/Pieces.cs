using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pieces : MonoBehaviour {

    private float maxWidth;
    private float maxHeight;
    private float[] rotate = new float[] { 0, 45,90,135, 180,225, 270 };

	// Use this for initialization
	void Start () {
        Vector3 screenPos = new Vector3(Screen.width, Screen.height,0);
        Vector3 movePos = Camera.main.ScreenToWorldPoint(screenPos);
        maxWidth = (float)(movePos.x/2.0);
        maxHeight = (float)(movePos.y/2.0);
        foreach(Transform puzzle in transform)
        {
            if (puzzle.childCount <= 0)
            {
                Init_Position(puzzle);
            }
            else
            {
                for (int i=0;i<puzzle.childCount;i++)
                {
                    Init_Position(puzzle.GetChild(i).transform);
                }
            }
        }
		
	}

    private void Init_Position(Transform sub_puzzle){
        System.Random rnd = new System.Random(Get_Random_Seed());
        float x = Random.Range(-maxWidth, maxWidth);
        float y = Random.Range(-maxHeight, maxHeight);
        int i = rnd.Next(6);
        sub_puzzle.position = new Vector3(x, y, (float)0.0);
        sub_puzzle.eulerAngles = new Vector3(0,0,rotate[i]);
        print(sub_puzzle.name + ":" + sub_puzzle.eulerAngles+";"+rotate[i]);
    }

    private int Get_Random_Seed(){
        byte[] bytes = new byte[4];
        System.Security.Cryptography.RNGCryptoServiceProvider rng = new System.Security.Cryptography.RNGCryptoServiceProvider();
        rng.GetBytes(bytes);
        return System.BitConverter.ToInt32(bytes, 0);
    }


    // Update is called once per frame
    void Update () {
        
	}
}

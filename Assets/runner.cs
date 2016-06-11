using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class runner : MonoBehaviour {

    public citiessightlines test;
    public Text output;
    public void redoInput(string fulltext)
    {
        string[] input = fulltext.Split(new string[] { System.Environment.NewLine }, System.StringSplitOptions.None);
        foreach(GameObject g in test.todelete)
        {
            Destroy(g);
        }
        output.text = test.calcSight(input).ToString();
    }

    void Update()
    {
        Vector2 mouseDelta = new Vector2(Input.GetAxisRaw("Mouse X") * 3, Input.GetAxisRaw("Mouse Y") * 3);
        transform.RotateAround(transform.position, transform.right, -mouseDelta.y);
        transform.RotateAround(transform.position, Vector3.forward, mouseDelta.x);
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
	
}

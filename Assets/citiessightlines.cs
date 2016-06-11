using UnityEngine;
using System.Collections;

public class citiessightlines : MonoBehaviour {

    public ArrayList todelete;
    void Start()
    {
        todelete = new ArrayList();
    }
    public int calcSight(string[]input)
    {
        todelete = new ArrayList();
        int total = 0;
        ArrayList check = new ArrayList();
        for (int y=0;y < input.Length; y++)
        {
            char[] line = input[y].ToCharArray();
            for (int x = 0; x < line.Length; x++)
            {
                char c = line[x];
                if (c == '*')
                {
                    GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    cube.transform.position = new Vector3(x, y);
                    todelete.Add(cube);
                }
                if (c == '@')
                {
                    transform.position = new Vector3(x, y);
                }
            }
        }
        for (int angle=0; angle < 3600; angle++)
        {
            RaycastHit hit;
            Physics.Raycast(transform.position, Quaternion.Euler(0, 0, angle/10) * Vector3.up, out hit);
            if (hit.collider!=null)
            {
                GameObject hitObject = hit.collider.gameObject;
                if (!check.Contains(hitObject)&&hitObject!=this)
                {
                    total += 1;
                    check.Add(hitObject);
                }
           }
        }
        return total;
    }
}

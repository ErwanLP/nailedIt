using UnityEngine;
using System.Collections;

public class Hammer : MonoBehaviour
{
    private GameObject hammer;

    public Hammer()
    {
        Object prefab = Resources.Load("Prefabs/m01", typeof(GameObject));
        this.hammer = Instantiate(prefab) as GameObject;
        this.hammer.transform.position = new Vector3((float)0.6, (float)1.7, (float)-6.7);
        this.hammer.transform.Rotate(0, 0, 85);
    }

    public GameObject getGameObject()
    {
        return this.hammer;
    }
}

using UnityEngine;
using System.Collections;

public class Hammer : MonoBehaviour
{
    private GameObject _game_object;
    Vector3 originalPosition;

    public Hammer()
    {
        Object prefab = Resources.Load("Prefabs/m01", typeof(GameObject));
        this._game_object = Instantiate(prefab) as GameObject;
        this._game_object.transform.position = new Vector3((float)0.6, (float)1.7, (float)-6.7);
        this._game_object.transform.Rotate(0, 0, 85);
        this.originalPosition = this._game_object.transform.position;
    }


    public Hammer(string hammerPrefabName)
    {
        Object prefab = Resources.Load("Prefabs/" + hammerPrefabName, typeof(GameObject));
        this._game_object = Instantiate(prefab) as GameObject;
        this._game_object.transform.position = new Vector3((float)0.6, (float)1.7, (float)-6.7);
        this._game_object.transform.Rotate(0, 0, 85);
        this.originalPosition = this._game_object.transform.position;

    }


    public void resetPosition()
    {
        this._game_object.transform.position = this.originalPosition;
    }

    public GameObject getGameObject()
    {
        return this._game_object;
    }
}

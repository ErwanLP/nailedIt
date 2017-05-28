using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class positionController : MonoBehaviour {

    public GameObject clou;
    public GameObject table;
    public BoxCollider bc_table;
    public BoxCollider bc_clou;
    public Text t_delta;
    public Text t_gameMode;
    private bool win = false;
    private float delta;
    private string gameMode;

    // Use this for initialization
    void Start () {
    }
	
	// Update is called once per frame
	void Update () {
        delta = (bc_clou.bounds.center.y + bc_clou.bounds.size.y / 2) - (bc_table.bounds.center.y + bc_table.bounds.size.y / 2);

        t_delta.text = "Delta : " +delta;

        switch (PlayerPrefs.GetInt("GameMode"))
        {
            case 1:
                gameMode = "Solo";
                break;
            case 2:
                gameMode = "Multijoueur";
                break;
        }

        t_gameMode.text = "Game Mode : " + gameMode;

        if (delta <= 0)
        {
            win = true;
            Debug.Log("WIN");
        }
    }
}

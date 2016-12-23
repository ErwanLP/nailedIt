using UnityEngine;
using System.Collections;

public class gameController : MonoBehaviour {

    public int numberPlayer;
    public Player[] playerList;
    public InputManager im;
    public int selectedPlayer;
    public bool moving;
    private IEnumerator coroutine;
    public float waitTime;



    // Use this for initialization
    void Start () {
        new CustomSocket();
        this.numberPlayer = 2;
        this.waitTime = 2.0f;
        Debug.Log("Nomber Player : " + this.numberPlayer);

        // create player array;
        playerList = new Player[this.numberPlayer];
        for (int i = 0; i < numberPlayer; i++)
        {
            int hammerPrefabName = 1 + i;
            Debug.Log("CREATION GAMER : " + hammerPrefabName);
            playerList[i] = new Player("m0" + hammerPrefabName.ToString());
            playerList[i].getHammer().getGameObject().SetActive(false);
        }
        this.selectedPlayer = 0;
        playerList[this.selectedPlayer].getHammer().getGameObject().SetActive(true);

        this.im = new InputManager(handleInputManager);
        this.moving = false;
    }

    private void handleInputManager(Movement m)
    {
        if(this.moving == false)
        {
            Debug.Log("User selected :" + this.selectedPlayer);
            playerList[this.selectedPlayer].getHammer().getGameObject().GetComponent<mPhys>().boom(m);
            this.moving = true;
            StartCoroutine(WaitMovement( this.waitTime));

        }
        else
        {
            Debug.Log("ALready in mouvement");
        }

    }

    // Update is called once per frame
    void Update () {
        //this.im.getInput();

    }

    private void incrementeSelectedGamer()
    {
        this.selectedPlayer++;
        if(this.selectedPlayer == numberPlayer)
        {
            this.selectedPlayer = 0;
        }
    }

    private IEnumerator WaitMovement(float waitTime)
    {
        while (this.moving)
        {
            yield return new WaitForSeconds(waitTime);            
            playerList[this.selectedPlayer].getHammer().getGameObject().SetActive(false);
            this.incrementeSelectedGamer();
            playerList[this.selectedPlayer].getHammer().resetPosition();
            playerList[this.selectedPlayer].getHammer().getGameObject().SetActive(true);
            this.moving = false;
        }
    }





}

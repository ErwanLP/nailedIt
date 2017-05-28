using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Globalization;

public class gameController : MonoBehaviour {

    // variable 
    private int playerNumber;
    private Player[] playerList;
    private int selectedPlayerIndex;
    private bool lockInputManager;
    private bool moving;
    public float waitTime;
    // class
    private CustomSocket customSocket;
    public InputManager inputManager;



    /*public int myid;
    public player[] playerlist;
    public int selectedplayer;
    public bool moving;
    public bool myturn;
    private ienumerator coroutine;
    ;
    public text t_speed;
    */

    // Use this for initialization
    void Start () {
        this.playerNumber = 2;
        this.selectedPlayerIndex = 0;
        this.lockInputManager = true;
        this.waitTime = 0.1f;
        this.playerList = this.createPlayerList(this.playerNumber);
        this.localPlayerAction(this.selectedPlayerIndex);
    }

    // Create List of player
    private Player[] createPlayerList(int playerNumber)
    {
        playerList = new Player[playerNumber];
        for (int i = 0; i < playerNumber; i++)
        {
            int hammerPrefabName = 1 + i;
            playerList[i] = new Player("m0" + hammerPrefabName.ToString());
            playerList[i].getHammer().getGameObject().SetActive(false);
        }
        return playerList;
    }


    // Update is called once per frame
    void Update()
    {
        if (this.inputManager != null && this.lockInputManager == false)
        {
            this.inputManager.getInput();
        }
        for (int i = 0; i < this.playerNumber; i++)
        {
            playerList[i].getHammer().getGameObject().SetActive(i == this.selectedPlayerIndex);
        }
    }

    private void localPlayerAction(int selectedPlayerIndex)
    {
        this.playerList[selectedPlayerIndex].getHammer().resetPosition();
        this.inputManager = new InputManager(this.startHammerMovement);
        this.lockInputManager = false;
    }


    private void startHammerMovement(Movement m)
    {
        this.moving = true;
        this.lockInputManager = true;
        playerList[this.selectedPlayerIndex].getHammer().getGameObject().GetComponent<mPhys>().boomWithSpeed(m.getYSpeed());
        StartCoroutine(WaitMovement(this.waitTime, this.afterMovementCallback));
    }

    private void afterMovementCallback()
    {
        this.selectedPlayerIndex = this.getNextSelectedPlayerIndex(this.selectedPlayerIndex, this.playerNumber);
        this.localPlayerAction(this.selectedPlayerIndex);
    }

    private IEnumerator WaitMovement(float waitTime, System.Action callback)
    {
        Vector3 oldPosition = playerList[selectedPlayerIndex].getHammer().getGameObjectPosition();
        while (this.moving)
        {
            yield return new WaitForSeconds(waitTime);
            Vector3 newPosition = playerList[selectedPlayerIndex].getHammer().getGameObjectPosition();
            if(oldPosition == newPosition)
            {
                this.moving = false;
                callback();
            }
            else
            {
                oldPosition = newPosition;
            }
        }
    }

    // Utils
    private int getNextSelectedPlayerIndex(int oldIndex, int playerNumber)
    {
        int newIndex = oldIndex+1;
        if (newIndex == playerNumber)
        {
            newIndex = 0;
        }
        return newIndex;
    }
}

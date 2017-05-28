using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Globalization;

public class gameController : MonoBehaviour {

    public int numberPlayer;
    public int myId;
    public Player[] playerList;
    public InputManager im;
    public int selectedPlayer;
    public bool moving;
    public bool myTurn;
    private IEnumerator coroutine;
    public float waitTime;
    public Text t_speed;
    public CustomSocket cs;

    // Use this for initialization
    void Start () {
        this.numberPlayer = 2;
        this.waitTime = 2.0f;
        this.myId = (int)Random.Range(0.0f, 1000000.0f);
        playerList = new Player[this.numberPlayer];
        for (int i = 0; i < numberPlayer; i++)
        {
            int hammerPrefabName = 1 + i;
            playerList[i] = new Player("m0" + hammerPrefabName.ToString());
            playerList[i].getHammer().getGameObject().SetActive(false);
        }

        this.multiPlayerInit();
    }

    private void multiPlayerInit()
    {
        this.cs = new CustomSocket();
        this.cs.setCallbackRoomFound(multiPlayerRoomFound);
        this.cs.sendMessage("SEARCH_ROOM");
    }

    private void multiPlayerRoomFound(string[] data)
    {
        this.myTurn = data[2] == "first";
        this.moving = false;
        if (this.myTurn)
        {
            this.selectedPlayer = 0;
        } else
        {
            this.selectedPlayer = 1;
        }
        playerList[this.selectedPlayer].getHammer().getGameObject().SetActive(true);
        this.im = new InputManager(handleMultiPlayerInputManager);
        this.cs.setCallbackBoom(multiPlayerBoom);

    }

    private void multiPlayerBoom(string[] data)
    {
        this.moving = true;
        float speed = float.Parse(data[3], CultureInfo.InvariantCulture.NumberFormat);
        playerList[this.selectedPlayer].getHammer().getGameObject().GetComponent<mPhys>().boomWithSpeed(speed);
        this.myTurn = true;
        StartCoroutine(WaitMovement(this.waitTime));
    }



    private void handleMultiPlayerInputManager(Movement m)
    {
        if(this.myTurn && this.moving)
        {
            t_speed.text = "Speed : " + m.getYSpeed().ToString();
            if(m.getYSpeed() == 0)
            {
                Debug.Log("Movement null");
            } else
            {
                playerList[this.selectedPlayer].getHammer().getGameObject().GetComponent<mPhys>().boom(m);
                this.myTurn = false;
                this.cs.sendMessage("BOOM;1;" + this.myId + ";" + m.getYSpeed());
                StartCoroutine(WaitMovement(this.waitTime));
            }
        }
        else
        {
            Debug.Log("Not allowed");
        }

    }

    // Update is called once per frame
    void Update () {
        if(this.im != null)
        {
            this.im.getInput();
        }

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

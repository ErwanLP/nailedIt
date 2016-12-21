using UnityEngine;
using System.Collections;

public class gameController : MonoBehaviour {

    public int numberPlayer;
    public Player[] playerList;
    public InputManager im;
    public int selectedPlayer;


	// Use this for initialization
	void Start () {

        this.numberPlayer = 2;
        Debug.Log("Nomber Player : " + this.numberPlayer);

        // create player array;
        playerList = new Player[this.numberPlayer];
        for (int i = 0; i < numberPlayer; i++)
        {
            Debug.Log("CREATION GAMER : " + i);
            playerList[i] = new Player();
            playerList[i].getHammer().getGameObject().SetActive(false);
        }
        this.selectedPlayer = 0;
        playerList[this.selectedPlayer].getHammer().getGameObject().SetActive(true);

        this.im = new InputManager(handleInputManager);
    }

    private void handleInputManager(Movement m)
    {

        playerList[this.selectedPlayer].getHammer().getGameObject().GetComponent<mPhys>().boom(m);
        StartCoroutine(this.Example());
        //playerList[this.selectedPlayer].getHammer().getGameObject().SetActive(false);
        this.incrementeSelectedGamer();
        //playerList[this.selectedPlayer].getHammer().getGameObject().SetActive(true);
    }

    // Update is called once per frame
    void Update () {
        this.im.getInput();

    }

    private void incrementeSelectedGamer()
    {
        this.selectedPlayer++;
        if(this.selectedPlayer == numberPlayer)
        {
            this.selectedPlayer = 0;
        }
    }

    private IEnumerator Example()
    {
        print(Time.time);
        yield return new WaitForSeconds(5);
        print(Time.time);
    }





}

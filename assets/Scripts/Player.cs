using UnityEngine;
using System.Collections;

public class Player
{
    private Hammer hammer;

    public Player()
    {
        this.hammer = new Hammer();
    }

    public Player(string hammerPrefabName)
    {
        this.hammer = new Hammer(hammerPrefabName);
    }

    public Hammer getHammer()
    {
        return this.hammer;
    }

}

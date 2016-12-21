using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
    private Hammer hammer;

    public Player()
    {
        this.hammer = new Hammer();
    }

    public Hammer getHammer()
    {
        return this.hammer;
    }

}

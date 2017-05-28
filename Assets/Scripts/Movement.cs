﻿using UnityEngine;
using System.Collections;

public class Movement  {

    private Vector3 initPosition;
    private Vector3 finalPosition;
    private float initTime;
    private float finalTime;

    public Movement()
    {
    }

    public Movement(Vector3 initPosition)
    {
        this.setInitPosition(initPosition);
    }

    public override string ToString()
    {
        return this.getYSpeed().ToString();
    }


    public void setInitPosition(Vector3 initPosition)
    {
        this.initPosition = initPosition;
        this.initTime = Time.time;
    }

    public void setFinalPosition(Vector3 finalPosition)
    {
        this.finalPosition = finalPosition;
        this.finalTime = Time.time;
    }

    public void log()
    {
        Debug.Log("Speed : " + this.getYSpeed());
    }

    public float getDeltaTime()
    {
        return this.finalTime - this.initTime;
    }
    public Vector3 getDeltaPosition()
    {
        return this.initPosition - this.finalPosition;
    }
    public float getYSpeed()
    {
        return this.getDeltaPosition().y / this.getDeltaTime();
    }



}

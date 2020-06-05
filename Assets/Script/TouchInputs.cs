using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;

public class TouchInputs : MonoBehaviour
{
    public Text pText, sText, lText;

    Vector2 startPosition;
    Vector2 endPosition;

    bool isTouching = false;

    float timeStart;
    float timeFinish;
    float timeTotal;

    Touch touch;

    List<Entry> entries;
    Entry lastEntry;

    // Update is called once per frame
    void Update()
    {
        touch = Input.GetTouch(0);
        Debug.Log(touch.phase);

        if (Input.touchCount > 0)
        {
            isTouching = true;
            timeStart = Time.time;
            startPosition = touch.position;
        }

        if (Input.touchCount <= 0 && isTouching == true)
        {
            isTouching = false;

            timeFinish = Time.time;
            endPosition = touch.position;

            entries.Add(new Entry(touch.pressure, startPosition, endPosition, getTotalTime()));
            lastEntry = entries[entries.Count - 1];

            Console.WriteLine("Finger Pressure: " + lastEntry.getPressure());
            pText.text = "Finger Pressure: " + lastEntry.getPressure();

            Console.WriteLine("Swipe Speed: " + lastEntry.getSpeed());
            sText.text = "Swipe Speed: " + lastEntry.getSpeed();

            Console.WriteLine("Swipe Length: " + lastEntry.getLength());
            lText.text = "Swipe Length: " + lastEntry.getLength();
        }
    }

    float getTotalTime()
    {
        return timeFinish - timeStart;
    }

    List<Entry> GetEntries()
    {
        return entries;
    }
}

class Entry
{
    float swipeSpeed;
    float swipeLength;

    private float pressure;
    private float sSpeed;
    private float sLength;

    public Entry(float pressure_, Vector2 startPosition, Vector2 endPosition, float totalTime)
    {
        pressure = pressure_;
        sSpeed = calcSwipeSpeed(totalTime);
        sLength = calcSwipeLength(startPosition, endPosition);
    }

    float calcSwipeLength(Vector2 startPosition, Vector2 endPosition)
    {
        return Vector2.Distance(startPosition, endPosition);
    }

    float calcSwipeSpeed(float totalTime)
    {
        return swipeLength / totalTime;
    }

    public float getPressure()
    {
        return pressure;
    }

    public float getSpeed()
    {
        return sSpeed;
    }

    public float getLength()
    {
        return sLength;
    }
}

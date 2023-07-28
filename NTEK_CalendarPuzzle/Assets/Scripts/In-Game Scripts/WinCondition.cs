using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Globalization;

public class WinCondition : MonoBehaviour
{
    [SerializeField]private List<GameObject> days;
    [SerializeField]private List<GameObject> months;

    // Update is called once per frame
    private void Update()
    {
        Winning();
    }

    private void Winning()
    {
        // Get the current date and time
        DateTime currentDate = DateTime.Now;

        // Access different components of the date
        int currentDay = currentDate.Day;
        int currentMonth = currentDate.Month;

        // Check if all the day tiles and month tiles are unoccupied
        bool allDaysMatched = true;
        foreach (GameObject day in days)
        {
            Tile tile = day.GetComponent<Tile>();
            if (tile != null)
            {
                int dayNumber;
                if (int.TryParse(day.name, out dayNumber))
                {
                    if (tile.IsOccupied() || dayNumber != currentDay)
                    {
                        allDaysMatched = false;
                        break; // No need to continue checking, we already found one mismatch
                    }
                }
            }
        }

        bool allMonthsMatched = true;
        foreach (GameObject month in months)
        {
            Tile tile = month.GetComponent<Tile>();
            if (tile != null)
            {
                string monthName = month.name;
                int monthNumber = MonthNumberFromName(monthName);
                if (tile.IsOccupied() || monthNumber != currentMonth)
                {
                    allMonthsMatched = false;
                    break; // No need to continue checking, we already found one mismatch
                }
            }
        }

        // If both allDaysMatched and allMonthsMatched are true, then the player has matched all cells with today's date
        if (allDaysMatched && allMonthsMatched)
        {
            // Player has matched all cells with today's date, they have won!
            // Put your winning logic here.
            Debug.Log("Congratulations! You have won!");
        }
    }

    private int MonthNumberFromName(string monthName)
    {
        switch (monthName)
        {
            case "Jan": return 1;
            case "Feb": return 2;
            case "Mar": return 3;
            case "Apr": return 4;
            case "May": return 5;
            case "Jun": return 6;
            case "Jul": return 7;
            case "Aug": return 8;
            case "Sep": return 9;
            case "Oct": return 10;
            case "Nov": return 11;
            case "Dec": return 12;
            default: return 0; // If the abbreviation is not recognized, return 0
        }
    }

}

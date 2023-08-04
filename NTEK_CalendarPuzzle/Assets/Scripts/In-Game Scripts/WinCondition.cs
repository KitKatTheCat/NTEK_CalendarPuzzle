using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class WinCondition : MonoBehaviour
{
    [SerializeField] private List<GameObject> days;
    [SerializeField] private List<GameObject> months;
    private string currentMonth;

    public void Winning()
    {
        // Get the current date and time
        DateTime currentDate = DateTime.Now;

        // Access different components of the date
        int currentDay = currentDate.Day;
        int currentMonthInt = currentDate.Month;

        // Counters for unoccupied day and month tiles
        int unoccupiedDays = 0;
        int unoccupiedMonths = 0;
        GameObject lastUnoccupiedDayTile = null;
        GameObject lastUnoccupiedMonthTile = null;

        foreach (GameObject day in days)
        {
            Tile tile = day.GetComponent<Tile>();
            if (tile != null)
            {
                // Make sure the day number has leading zeros for matching
                string formattedDayNumber = currentDay.ToString("D2");
                if (!tile.IsOccupied())
                {
                    unoccupiedDays++;
                    lastUnoccupiedDayTile = day;
                }

                // Log the status of each day
                // Debug.Log("Day " + day.name + " Occupied: " + tile.IsOccupied());
                // Debug.Log("LastUnoccupiedDayTile: " + lastUnoccupiedDayTile);
            }
        }

        foreach (GameObject month in months)
        {
            Tile tile = month.GetComponent<Tile>();
            if (tile != null)
            {
                // Make sure the month name is capitalized for matching
                string formattedMonthName = currentMonthInt.ToString("MMM");
                if (!tile.IsOccupied())
                {
                    unoccupiedMonths++;
                    lastUnoccupiedMonthTile = month;
                }

                // Log the status of each month
                // Debug.Log("Month " + month.name + " Occupied: " + tile.IsOccupied());
                // Debug.Log("LastUnoccupiedMonthTile: " + lastUnoccupiedMonthTile);
            }
        }

        switch(currentMonthInt)
        {
            case 1:
                currentMonth = "Jan";
                break;
            case 2:
                currentMonth = "Feb";
                break;
            case 3:
                currentMonth = "Mar";
                break;
            case 4:
                currentMonth = "Apr";
                break;
            case 5:
                currentMonth = "May";
                break;
            case 6:
                currentMonth = "Jun";
                break;
            case 7:
                currentMonth = "Jul";
                break;
            case 8:
                currentMonth = "Aug";
                break;
            case 9:
                currentMonth = "Sep";
                break;
            case 10:
                currentMonth = "Oct";
                break;
            case 11:
                currentMonth = "Nov";
                break;
            case 12:
                currentMonth = "Dec";
                break;
        }

        // Log the values of unoccupiedDays and unoccupiedMonths
        // Debug.Log("Unoccupied Days: " + unoccupiedDays);
        // Debug.Log("Unoccupied Months: " + unoccupiedMonths);

        // If there is exactly 1 unoccupied day and 1 unoccupied month, and the current day and month are also unoccupied, the player has won
        if (unoccupiedDays == 1 && unoccupiedMonths == 1)
        {
            // Debug.Log("Unoccupieds Checked!");
            // Check if the last unoccupied day and month tiles match today's date
            if (lastUnoccupiedDayTile.name.Equals(currentDay.ToString("D2")) &&
                lastUnoccupiedMonthTile.name.Equals(currentMonth))
            {
                // Put your winning logic here.
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                // Debug.Log("You Win!");
            }
        }
        // Debug.Log(currentDay.ToString("00"));
        // Debug.Log(lastUnoccupiedDayTile);
        // Debug.Log(currentMonth);
        // Debug.Log(lastUnoccupiedMonthTile.name);
    }
}

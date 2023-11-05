using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        List<string> results = new List<string> { "3:1", "2:2", "0:1", "4:2", "3:a", "3-12" };

        Dictionary<string, int> teamPoints = new Dictionary<string, int>();

        foreach (string result in results)
        {
            string[] parts = result.Split(':');

            if (parts.Length == 2)
            {
                if (int.TryParse(parts[0], out int homeGoals) && int.TryParse(parts[1], out int awayGoals))
                {
                    if (homeGoals > awayGoals)
                    {
                        UpdateTeamPoints(teamPoints, "Команда 1", 3);
                    }
                    else if (homeGoals == awayGoals)
                    {
                        UpdateTeamPoints(teamPoints, "Команда 1", 1);
                        UpdateTeamPoints(teamPoints, "Команда 2", 1);
                    }
                    else
                    {
                        UpdateTeamPoints(teamPoints, "Команда 2", 3);
                    }
                }
                else
                {
                    Console.WriteLine($"Недопустимые значения голов в результате матча {result}");
                }
            }
            else
            {
                Console.WriteLine($"Недопустимый формат результата матча {result}");
            }
        }

        foreach (var kvp in teamPoints)
        {
            Console.WriteLine($"{kvp.Key}: {kvp.Value} очков");
        }
    }

    static void UpdateTeamPoints(Dictionary<string, int> teamPoints, string teamName, int points)
    {
        if (teamPoints.ContainsKey(teamName))
        {
            teamPoints[teamName] += points;
        }
        else
        {
            teamPoints[teamName] = points;
        }
    }
}

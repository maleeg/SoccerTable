using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using Newtonsoft.Json;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace soccerTableProject.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SoccerTableController : ControllerBase
    {

        private readonly ILogger<SoccerTableController> _logger;

        [HttpGet]

        public SoccerTable Get()
        {

            List<string> listTeams = new List<string>();
            List<int> goals = new List<int>();
            List<int> goalDifferences = new List<int>();
            List<int> points = new List<int>();
            List<int> losses = new List<int>();
            List<int> draws = new List<int>();
            List<int> wins = new List<int>();
            var teamScore = 0;
            var opponentScore = 0;
            int score = 0;
            int goalDifference = 0;
            int point = 0;
            int win = 0;
            int loss = 0;
            int draw = 0;

            using (var reader = new StreamReader(@"C:\Users\Malesa.Masoma\Documents\input.csv"))
            {


                int index = 0;
                reader.ReadLine();
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();

                    foreach (var values in line.Split(','))
                    {
                        if (index == 0)
                        {
                            listTeams.Add(values);
                            index++;
                            Console.WriteLine(listTeams);
                        }
                        else
                        {
                            teamScore = Convert.ToInt32(values.Substring(0, values.IndexOf('-')-1));
                            opponentScore = Convert.ToInt32(values.Substring(values.IndexOf('-') + 1));

                            if (teamScore > opponentScore)
                            {
                                point += 3;
                                win += 1;


                            }
                            else if (teamScore == opponentScore)
                            {
                                point += 1;
                                draw += 1;
                            }
                            else if (teamScore < opponentScore)
                            {
                                loss += 1;
                            }
                            goalDifference += teamScore - opponentScore;
                            score += Convert.ToInt32(teamScore);
                            index++;
                        }

                    }
                    goalDifferences.Add(goalDifference);
                    goals.Add(score);
                    points.Add(point);
                    draws.Add(draw);
                    losses.Add(loss);
                    wins.Add(win);
                    index = 0;
                    score = 0;
                    goalDifference = 0;
                    point = 0;
                }
                int index2 = 0;
                foreach (var team in listTeams)
                {
                    var finGoals = goals[index2];
                    Console.WriteLine("Team name: " + team + " Goals: " + goals[index2] + " Points: " + points[index2] + " Goal difference: " + goalDifferences[index2]);
                    index2++;

                }

            }
            return new SoccerTable
            {
                Goals = goals,
                GoalDifferences = goalDifferences,
                Draws = draws,
                Losses = losses,
                Wins = wins,
                Teams = listTeams,
                Points = points
            };
        }



    }
}
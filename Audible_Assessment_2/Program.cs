using System;
using System.Collections.Generic;
using System.Linq;

namespace Audible_Assessment_2
{
    class Program
    {
        static void Main(string[] args)
        {
            var empScores = new List<int>()
            {
                9, 17, 12, 10, 2, 7, 2, 11, 20, 8, 3, 4
            };

            Console.WriteLine(teamFormation(empScores, 3, 4));
            Console.ReadKey();
        }

        public static long teamFormation(List<int> score, int team, int m)
        {
            long teamScore = 0;

            score.RemoveAt(score.Count - 1);
            score.RemoveAt(score.Count - 1);

            var scoreAdjusted = score;

            for (var numEmps = 0; numEmps < team; numEmps++)
            {
                Console.WriteLine(string.Join(",", scoreAdjusted));

                if (scoreAdjusted.Count == 1)
                {
                    teamScore += scoreAdjusted.First();
                    break;
                }

                if (scoreAdjusted.Count < m)
                {
                    var defaultScoreToAdd = scoreAdjusted.Max();
                    Console.WriteLine(defaultScoreToAdd);
                    teamScore += defaultScoreToAdd;
                    scoreAdjusted.Remove(defaultScoreToAdd);
                    continue;
                }

                var firstTeam = scoreAdjusted.Take(m);
                var maxFirst = firstTeam.Max();
                var maxFirstIndex = scoreAdjusted.IndexOf(maxFirst);

                var lastTeam = scoreAdjusted.Skip(scoreAdjusted.Count - m);
                var maxLast = lastTeam.Max();

                var scoreToAdd = maxFirst < maxLast ? maxLast : maxFirst;
                Console.WriteLine(scoreToAdd);
                teamScore += scoreToAdd;

                scoreAdjusted.RemoveAt(maxFirstIndex);
            }

            return teamScore;
        }
    }
}

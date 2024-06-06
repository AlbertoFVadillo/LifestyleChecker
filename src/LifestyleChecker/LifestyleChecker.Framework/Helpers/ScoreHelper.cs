using LifestyleChecker.DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LifestyleChecker.Framework.Helpers
{
    public static class ScoreHelper
    {
        public static int Calculate(int age, List<ScoreDto> scoreTable, Dictionary<int, bool> answers)
        {
            var totalScore = 0;
            var ageRange = scoreTable.FirstOrDefault(x => x.From <= age && x.To >= age);

            if (ageRange != null)
            {
                foreach(var answer in answers)
                {
                    switch (answer.Key)
                    {
                        case 1:
                            if(answer.Value)
                            {
                                totalScore = totalScore + ageRange.Q1;
                            }
                            break;
                        case 2:
                            if (answer.Value)
                            {
                                totalScore = totalScore + ageRange.Q2;
                            }
                            break;
                        case 3:
                            if (!answer.Value)
                            {
                                totalScore = totalScore + ageRange.Q3;
                            }
                            break;
                    }
                }
            }

            return totalScore;
        }
    }
}

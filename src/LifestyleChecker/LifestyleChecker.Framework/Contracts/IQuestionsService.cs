using System;
using System.Collections.Generic;
using System.Linq;
namespace LifestyleChecker.Framework.Contracts
{
    public interface IQuestionsService
    {
        Task<int?> CalculateScore(int age, Dictionary<int, bool> answers);
    }
}

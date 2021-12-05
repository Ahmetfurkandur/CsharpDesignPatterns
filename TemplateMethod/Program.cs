using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace TemplateMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            ScoringAlgorithm scoringAlgorithm;
            Console.WriteLine("Mans");
            scoringAlgorithm = new MensScoringAlgorithm();
            Console.WriteLine(scoringAlgorithm.GenerateScore(8,new TimeSpan(0,1,53)));

            Console.WriteLine("Women");
            scoringAlgorithm = new WomenScoringAlgorithm();
            Console.WriteLine(scoringAlgorithm.GenerateScore(8,new TimeSpan(0,1,53)));

            Console.WriteLine("Mans");
            scoringAlgorithm = new ChildrensScoringAlgorithm();
            Console.WriteLine(scoringAlgorithm.GenerateScore(8,new TimeSpan(0,1,53)));
            Console.ReadLine();
        }
    }

    abstract class ScoringAlgorithm
    {
        public int GenerateScore(int hits,TimeSpan time)
        {
            int score = CalculateBaseScore(hits);
            int reduction = CalculateReduction(time);
            return CalculateOverallScore(score, reduction);
        }

        protected abstract int CalculateOverallScore(int score, int reduction);

        public abstract int CalculateReduction(TimeSpan time);

        public abstract int CalculateBaseScore(int hits);

    }

    class MensScoringAlgorithm:ScoringAlgorithm
    {
        protected override int CalculateOverallScore(int score, int reduction)
        {
            return score - reduction;
        }

        public override int CalculateReduction(TimeSpan time)
        {
            return (int)time.TotalSeconds / 5;
        }

        public override int CalculateBaseScore(int hits)
        {
            return hits * 100;
        }
    }
    
    class WomenScoringAlgorithm:ScoringAlgorithm
    {
        protected override int CalculateOverallScore(int score, int reduction)
        {
            return score - reduction;
        }

        public override int CalculateReduction(TimeSpan time)
        {
            return (int)time.TotalSeconds / 3;
        }

        public override int CalculateBaseScore(int hits)
        {
            return hits * 100;
        }
    }

    class ChildrensScoringAlgorithm:ScoringAlgorithm
    {
        protected override int CalculateOverallScore(int score, int reduction)
        {
            return score - reduction;
        }

        public override int CalculateReduction(TimeSpan time)
        {
            return (int)time.TotalSeconds / 2;
        }

        public override int CalculateBaseScore(int hits)
        {
            return hits * 80;
        }
    }


}

namespace Grades
{
    public class GradeStatistics
    {
        public GradeStatistics()
        {
            HighestGrade = 0;
            LowestGrade = float.MaxValue;
        }
        public string Description
        {
            get
            {
                string description;
                switch(LetterGrade)
                {
                    case "A":
                        description = "Excellent";
                        break;
                    case "B":
                        description = "Good";
                        break;
                    case "C":
                        description = "Average";
                        break;
                    default:
                        description = "Failed";
                        break;
                }
                return description;
            }
        }
        public string LetterGrade
        {
            get
            {
                string result;
                if (AverageGrade >= 90)
                {
                    result = "A";
                }
                else if (AverageGrade >= 80)
                {
                    result = "B";
                }
                else if (AverageGrade >= 70)
                {
                    result = "C";
                }
                else
                {
                    result = "D";
                }
                return result;
            }
        }
        public float AverageGrade;
        public float HighestGrade;
        public float LowestGrade;
    }
}
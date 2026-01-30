using System;

public interface Exam
{
    public double calculateScore();
    public static string evaluateResult(double percentage)
    {
        if(percentage >= 85)
        return "Merit";
        else if(percentage >= 60)
        return "Pass";
        else
        return "Fail";
    }
}

class OnlineTest : Exam
{
    string studentName;
    int totalQuestions;
    int correctAnswers;
    int wrongAnswers;
    string questionType;

    public OnlineTest(string studentName, int totalQuestions, int correctAnswers, int wrongAnswers, string questionType)
    {
        this.studentName = studentName;
        this.totalQuestions = totalQuestions;
        this.correctAnswers = correctAnswers;
        this.wrongAnswers = wrongAnswers;
        this.questionType = questionType;
    }

    public double calculateScore()
    {
        double totalScore;
        double percentage;
        if(questionType == "MCQ")
        {
           totalScore = (correctAnswers * 2) - (wrongAnswers * 2 * 0.10);
           percentage = (totalScore/ (totalQuestions * 2)) * 100;
        }

        else
        {
           totalScore = (correctAnswers * 5) - (wrongAnswers * 5 * 0.10);
           percentage = (totalScore/ (totalQuestions * 5)) * 100;  
        }

        return percentage;

    }
}
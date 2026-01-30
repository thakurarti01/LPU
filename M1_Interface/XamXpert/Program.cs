using System;

class UserInterface
{
    static void Main()
    {
        Console.WriteLine("Enter Exam Details:");

        Console.WriteLine("Enter Student Name: ");
        string studentName = Console.ReadLine();

        Console.WriteLine("QuestionType(MCQ/Coding):");
        string questionType = Console.ReadLine();

        Console.WriteLine("Total Questions: ");
        int totalQuestions = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Correct Answers: ");
        int correctAnswers = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Wrong Answers: ");
        int wrongAnswers = Convert.ToInt32(Console.ReadLine());

        

        Console.WriteLine("Exam Summary:");

        OnlineTest obj = new OnlineTest(studentName, totalQuestions, correctAnswers, wrongAnswers, questionType);

        double percentage = obj.calculateScore();
        string finalResult = Exam.evaluateResult(percentage);

        Console.WriteLine($"{questionType}: {studentName}, {percentage.ToString("F1")}, Result: {finalResult}");
        
    }
}
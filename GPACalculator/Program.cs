using ExtensionMethods;
using GPA.Model;
using GPACalculator.UI;

Console.WriteLine("Welcome to the GPA calculator created by Ogheneruemu Karieren");

var studentFullName = "";
bool active = true;
while (active)
{
    Console.Write("Please enter student's fullname: ");
    studentFullName = Console.ReadLine();
    if (!studentFullName.IsAValidName())
    {
        continue;
    }
    active = false;
}

var gpaModel = GPAModel.GetInstance();
active = true;
while (active)
{
    Console.Write("How many courses did you offer? ");
    var numberOfCoursesOfferedText = Console.ReadLine();
    (bool isValid, int numberOfCoursesOffered) = numberOfCoursesOfferedText.IsAValidNumber();

    if(!isValid)
    {
        continue;
    }

    for (int courses = 0; courses < numberOfCoursesOffered; courses++)
    {
        UI.UserPrompt(gpaModel);
    }
    active = false;
}

UI.Header(studentFullName);

UI.Body(gpaModel);

UI.Footer(gpaModel);
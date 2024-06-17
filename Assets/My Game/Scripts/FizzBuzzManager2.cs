using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FizzBuzzManager2 : MonoBehaviour
{

    public TextMeshProUGUI randomNumberText;
    public TextMeshProUGUI feedbackText;
    public TextMeshProUGUI positiveFeedback;
    public GameObject panel;
    public AudioSource audioSource;
    public AudioClip correctAnswer;
    public AudioClip wrongAnswer;
    private int randomNumber;
    private string fizz = "Fizz";
    private string buzz = "Buzz";
    private string fizzBuzz = "FizzBuzz";
    private string number = "Number";

    void Start()
    {
        GenerateNumber();
    }

    void Update()
    {
        UserInput();
    }

    void UserInput()
    {

        if (Input.GetKeyDown(KeyCode.LeftArrow))
            CheckAnswer(fizz);

        else if (Input.GetKeyDown(KeyCode.RightArrow))
            CheckAnswer(buzz);

        else if (Input.GetKeyDown(KeyCode.UpArrow))
            CheckAnswer(fizzBuzz);

        else if (Input.GetKeyDown(KeyCode.DownArrow))
            CheckAnswer(number);

        else if (Input.GetKeyDown(KeyCode.Space))
            GenerateNumber();

    }

    void GenerateNumber()
    {

        randomNumber = Random.Range(0, 1001);
        randomNumberText.text = randomNumber.ToString();
        feedbackText.text = "";
        positiveFeedback.text = "";
        panel.GetComponent<Image>().color = new Color(1f, 1f, 1f, 0.4f);

    }

    void CheckAnswer(string answer)
    {

        bool canDivideBy3 = randomNumber % 3 == 0;
        bool canDivideBy5 = randomNumber % 5 == 0;

        if (canDivideBy3 && canDivideBy5)
        {
            if (answer == fizzBuzz)
                DisplayFeedback(Color.green, fizzBuzz, true);

            else
                DisplayFeedback(Color.red, WrongAnswer(canDivideBy3, canDivideBy5), false);
        }

        else if (canDivideBy3)
        {
            if (answer == fizz)
                DisplayFeedback(Color.green, fizz, true);

            else
                DisplayFeedback(Color.red, WrongAnswer(canDivideBy3, canDivideBy5), false);
        }

        else if (canDivideBy5)
        {
            if (answer == buzz)
                DisplayFeedback(Color.green, buzz, true);

            else
                DisplayFeedback(Color.red, WrongAnswer(canDivideBy3, canDivideBy5), false);
        }

        else
        {
            if (answer == number)
                DisplayFeedback(Color.green, number, true);

            else
                DisplayFeedback(Color.red, WrongAnswer(canDivideBy3, canDivideBy5), false);
        }

    }

    string WrongAnswer(bool canDivideBy3, bool canDivideBy5)
    {

        if (canDivideBy3 && canDivideBy5)
            return "Eine Zahl ist durch 3 teilbar, wenn ihre Quersumme durch 3 teilbar ist / Eine Zahl ist durch 5 teilbar, wenn ihre letzte Ziffer eine 0 oder eine 5 ist";

        else if (canDivideBy3)
            return "Eine Zahl ist durch 3 teilbar, wenn ihre Quersumme durch 3 teilbar ist";

        else if (canDivideBy5)
            return "Eine Zahl ist durch 5 teilbar, wenn ihre letzte Ziffer eine 0 oder eine 5 ist";

        else
            return "Eine Zahl ist durch 3 teilbar, wenn ihre Quersumme durch 3 teilbar ist / Eine Zahl ist durch 5 teilbar, wenn ihre letzte Ziffer eine 0 oder eine 5 ist";

    }

    void DisplayFeedback(Color color, string message, bool isCorrect)
    {

        panel.GetComponent<Image>().color = new Color(color.r, color.g, color.b, 0.4f);
        feedbackText.text = message;

        if (isCorrect)
        {
            audioSource.PlayOneShot(correctAnswer);
            positiveFeedback.text = "gut gemacht!";
        }
        else
        {
            audioSource.PlayOneShot(wrongAnswer);
        }

    }

}


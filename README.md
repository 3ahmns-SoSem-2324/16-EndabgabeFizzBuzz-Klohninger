FizzBuzz - Interactive 

Ziel des Spiels
Das Ziel des Spiels ist es, die richtige Antwort für eine zufällig generierte Zahl zu geben. Sie müssen entscheiden, ob die Zahl durch 3, 5, beide oder keine der beiden teilbar ist und die entsprechende Eingabe machen.

Regeln des Spiels

Zahlenanzeige:

Eine zufällige Zahl zwischen 0 und 1000 wird auf dem Bildschirm angezeigt.
Eingabemöglichkeiten:

linke Pfeiltaste für "Fizz" (wenn die Zahl durch 3 teilbar ist)
rechte Pfeiltaste für "Buzz" (wenn die Zahl durch 5 teilbar ist)
obere Pfeiltaste für "FizzBuzz" (wenn die Zahl sowohl durch 3 als auch durch 5 teilbar ist)
untere Pfeiltaste für "Number" (wenn die Zahl weder durch 3 noch durch 5 teilbar ist)
Leertaste, um eine neue Zahl zu generieren

Feedback:

Nach Ihrer Eingabe wird sofort angezeigt, ob Ihre Antwort korrekt oder falsch war.
Ein grünes Feedback und ein positiver Kommentar ("gut gemacht!") erscheinen, wenn Ihre Antwort korrekt ist.
Ein rotes Feedback und eine Erklärung, warum Ihre Antwort falsch ist, erscheinen, wenn Ihre Antwort falsch ist.
Audiosignale unterstützen das Feedback: ein positives Geräusch bei einer korrekten Antwort und ein negatives Geräusch bei einer falschen Antwort.

Spielablauf:

Das Spiel startet automatisch und zeigt eine zufällig generierte Zahl an.
Sie entscheiden basierend auf der Zahl, welche Taste Sie drücken.
Sie erhalten sofortiges Feedback basierend auf Ihrer Eingabe.
Sie können jederzeit durch Drücken der Leertaste eine neue Zahl generieren und weiterspielen.

```mermaid
classDiagram
    class FizzBuzzManager2 {
        +TextMeshProUGUI randomNumberText
        +TextMeshProUGUI feedbackText
        +TextMeshProUGUI positiveFeedback
        +GameObject panel
        +AudioSource audioSource
        +AudioClip correctAnswer
        +AudioClip wrongAnswer
        -int randomNumber
        -string fizz
        -string buzz
        -string fizzBuzz
        -string number
        +void Start()
        +void Update()
        +void UserInput()
        +void GenerateNumber()
        +void CheckAnswer(string answer)
        -string WrongAnswer(bool canDivideBy3, bool canDivideBy5)
        -void DisplayFeedback(Color color, string message, bool isCorrect)
    }

    FizzBuzzManager2 --> TextMeshProUGUI : uses
    FizzBuzzManager2 --> GameObject : uses
    FizzBuzzManager2 --> AudioSource : uses
    FizzBuzzManager2 --> AudioClip : uses
    FizzBuzzManager2 --> Image : uses

    class TextMeshProUGUI {
        +string text
    }

    class GameObject {
        +Image GetComponent<Image>()
    }

    class AudioSource {
        +void PlayOneShot(AudioClip clip)
    }

    class AudioClip {
    }

    class Image {
        +Color color
    }

    class Color {
        +float r
        +float g
        +float b
        +float a
    }

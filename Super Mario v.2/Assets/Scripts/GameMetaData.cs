/// <summary>
/// Класс для хранения данных, которые нужно переноситьс уровня на уровень
/// </summary>
public static class GameMetaData
{
    private static int level = 1;

    public static int Level
    {
        get { return level; }
        set { level = value; }
    }

    private static int score;

    public static int Score
    {
        get { return score; }
        set
        {
            if (value < 0)
            {
                score = 0;
            }
            else
            {
                score = value;
            }
        }
    }

    private static int hearts = 5;

    public static int Hearts
    {
        get { return hearts; }
        set { hearts = value; }
    }
}
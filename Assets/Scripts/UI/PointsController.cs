using UnityEngine;
using UnityEngine.UI;

public class PointsController : MonoBehaviour
{
    [SerializeField] private Text _pointsText; //Переменная типа текст, содержащая количество очков.
    [SerializeField] private Text _redCountText; //Переменная типа текст, содержащая количество красных шариков.
    [SerializeField] private Text _yellowCountText; //Переменная типа текст, содержащая количество желтых шариков.
    [SerializeField] private Text _greenCountText; //Переменная типа текст, содержащая количество зеленых шариков.
    [SerializeField] private Text _blueCountText; //Переменная типа текст, содержащая количество голубых шариков.

    private int _points; //Переменная типа int, содержащая количество очков.
    private int _redCount;
    private int _yellowCount;
    private int _greenCount;
    private int _blueCount;

    public static int QuestColorsCount; //Статическая переменная типа int. 
    private void Start()
    {
        BallController.OnBallCollected += BallCollected; //Метод BallCollected подписывается на ивент.

        _redCount = RandomColour(); //Записывает рандомное число в переменную с количеством красных шариков необходимых для выполнения квеста.
        _redCountText.text = _redCount.ToString(); //Вывод на экран количество красных шариков.

        _yellowCount = RandomColour();
        _yellowCountText.text = _yellowCount.ToString();

        _greenCount = RandomColour();
        _greenCountText.text = _greenCount.ToString();

        _blueCount = RandomColour();
        _blueCountText.text = _blueCount.ToString();

        QuestColorsCount = _redCount + _yellowCount + _greenCount + _blueCount; //Определяет количество всех шариков необходимых для завершения квеста и записывает их сумму в статическую переменную.
    }

    private void OnDestroy() //Метод BallCollected отписывается от события во время удаления объекта.
    {
        BallController.OnBallCollected -= BallCollected;
    }
    private void BallCollected(BallController ball) //Метод отвечающий за очки и квест. В качестве входных параметров передается шарик.
    {
        _points++; //Когда шарик лопает, количество очков увеличивается на 1.
        _pointsText.text = _points.ToString(); //Вывод количества очков на экран.

        int ballColor = ball.SpriteIndex; //Записывает индекс цвета шарика.
        if (ballColor == 0) //Если индекс равен 0... 
        {
            if (_redCount != 0) //Если квест не выполнен...
            {
                _redCount--; //От количества красных квестовых шариков отнимается 1.
                _redCountText.text = _redCount.ToString(); //Вывод нового количества красных квестовых шариков на экран.
            }
            if(_redCount == 0) //Если квест выполнен...
            {
                _redCountText.gameObject.SetActive(false); //Объект, с выводом на экран информации о красных квестовых шариках, выключается.
            }
        }
        else if (ballColor == 1) //Иначе если индекс равен 1... Срабатывает таже самая логика, только для желтого шарика.
        {
            if (_yellowCount != 0)
            {
                _yellowCount--;
                _yellowCountText.text = _yellowCount.ToString();
            }
            if (_yellowCount == 0)
            {
                _yellowCountText.gameObject.SetActive(false);
            }
        }
        else if (ballColor == 2) //Иначе если индекс равен 2... Срабатывает таже самая логика, только для зеленого шарика.
        {
            if (_greenCount != 0)
            {
                _greenCount--;
                _greenCountText.text = _greenCount.ToString();
            }
            if (_greenCount == 0)
            {
                _greenCountText.gameObject.SetActive(false);
            }
        }
        else if (ballColor == 3) //Иначе если индекс равен 3... Срабатывает таже самая логика, только для голубого шарика.
        {
            if (_blueCount != 0)
            {
                _blueCount--;
                _blueCountText.text = _blueCount.ToString();
            }
            if (_blueCount == 0)
            {
                _blueCountText.gameObject.SetActive(false);
            }
        }

        QuestColorsCount = _redCount + _yellowCount + _greenCount + _blueCount; //После изменений сумма квестовых шариков пересчитывается.
    }

    private int RandomColour() //Возвращает рандомное число.
    {
        int colorCount = Random.Range(50, 100); //Записывает в переменную рандомное число.
        return colorCount; //Возвращает переменную с рандомным числом.
    }
}

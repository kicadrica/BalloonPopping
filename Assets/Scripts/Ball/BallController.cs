using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    [HideInInspector] public int SpriteIndex; 

    public static event System.Action<BallController> OnBallCollected; 
    public List<BallController> Neighbors = new List<BallController>(); 
    public static List<BallController> BallsList = new List<BallController>(); 
    private SpriteRenderer _sr; 
    private Animator _anim; 
    private bool _isPopped; 

    private void Start()
    {
        BallsList.Add(this); 
        SpriteIndex = Random.Range(0, SpritesDataBase.Instance.BallSprites.Length); 
        _sr = GetComponent<SpriteRenderer>(); 
        _sr.sprite = SpritesDataBase.Instance.BallSprites[SpriteIndex]; 
        _anim = GetComponent<Animator>(); 
    }

    private void Update()
    {
        _sr.sortingOrder = 1000 - (int)(transform.position.y * 100); //Следующий ряд шариков перекрывает предыдущий.
    }

    public void PlaceRandom() //Метод отвечающий за рандомную позицию шарика.
    {
        transform.position = new Vector3(Random.Range(-2.4f, 2.4f), Random.Range(-7f, -10f)); 
    }

    private void OnTriggerEnter2D(Collider2D col) //Метод срабатывающий при столкновении шариков. Записывает в лист соседей шарика. 
    {
        var ballController = col.gameObject.GetComponent<BallController>(); 

        if (ballController && SpriteIndex == ballController.SpriteIndex) 
        {
            Neighbors.Add(ballController); 
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (_isPopped) return; //Если шарик лопнул, метод предывается.
        var ballController = col.gameObject.GetComponent<BallController>(); 

        if (ballController && SpriteIndex == ballController.SpriteIndex) 
        {
            Neighbors.Remove(ballController); 
        }
    }

    private void OnMouseDown() //Если в листе есть элементы, а игра не окончена и не выиграна, то шарики лопают.
    {
        if (Neighbors.Count > 0 && !GameOver.IsGameOver && !GameWin.IsGameWin) 
        {
            Pop(); 
        }
    }
    
    public void Pop() //Метод отвечающий за лопание шариков.
    {
        if (_isPopped) return; 
        _isPopped = true; 
        OnBallCollected?.Invoke(this); 
        StartCoroutine(BallAnimationDestroy()); 
        foreach (var neighbor in Neighbors) 
        {
            neighbor.Pop(); 
        }

    }

    private IEnumerator BallAnimationDestroy() //Метод анимации уничтожения шарика.
    {
        _anim.enabled = true; 
        _anim.SetInteger("ColorIndex", SpriteIndex); 

        yield return new WaitForSeconds(0.25f); 
        Destroy(gameObject); 
    }
    private void OnDestroy() 
    {
        BallsList.Remove(this); 
    }

   
}

using UnityEngine;
using UnityEngine.UI;


public class Player : MonoBehaviour
{

    [Header("移動速度"), Range(0, 300)]
    public float speed = 3.5f;
    [Header("虛擬搖桿")]
    public FixedJoystick joystick;
    [Header("變形元件")]
    public Transform tra;
    [Header("動畫元件")]
    public Animator ani;
    [Header("偵測範圍")]
    public float rangeAttack = 2.5f;
    [Header("音效來源")]
    public AudioSource aud;
    [Header("攻擊音效")]
    public AudioClip soundAttack;





    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(1, 0, 0, 0.2f);
        Gizmos.DrawSphere(transform.position, rangeAttack);


    }


    private void Move()
    {
        float h = joystick.Horizontal;

        tra.Translate(h * speed * Time.deltaTime, 0 , 0 );

        ani.SetFloat("水平", h);


    }
    public  void Attack()
    {

        aud.PlayOneShot(soundAttack, 0.5f);

        RaycastHit2D hit = Physics2D.CircleCast(transform.position, rangeAttack, transform.up, 0,1<<8);

        if (hit && hit.collider.tag == "道具") hit.collider.GetComponent<Item>().DropProp();

    }
    private void Hit()
    {

    }
    private void Dead()
    {

    }


    private void Start()
    {
        Move();
    }
    private void Update()
    {
        Move();
    }


    [Header("吃蘋果特效")]
    public AudioClip soundEat;
    [Header("蘋果數量")]
    public Text textcoin;


    private int coin;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.tag == "蘋果")
        {
            coin++;
            aud.PlayOneShot(soundEat);
            Destroy(collision.gameObject);

            textcoin.text = "果實:" + coin;

        }


    }

}

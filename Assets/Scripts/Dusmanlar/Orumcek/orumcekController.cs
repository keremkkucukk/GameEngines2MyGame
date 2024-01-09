using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class orumcekController : MonoBehaviour
{
    [SerializeField]
    Transform[] posizyonlar;

    public float orumcekHizi;

    public float beklemeSuresi;

    float beklemeSayac;

    Animator anim;

    int kacinciPosizyon;

    Transform hedefPlayer;

    public float takipMesafesi = 5f;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    private void Start()
    {
        hedefPlayer = GameObject.Find("Player").transform;

        foreach (Transform pos in posizyonlar)
        {
            pos.parent = null;
        }
    }
    private void Update()
    {
        if(beklemeSayac > 0)
        {
            beklemeSayac -= Time.deltaTime;
            anim.SetBool("hareketEtsinmi", false);
        }
        else
        {
            if(hedefPlayer.position.x > posizyonlar[0].position.x && hedefPlayer.position.x < posizyonlar[1].position.x)
            {
                transform.position = Vector3.MoveTowards(transform.position, hedefPlayer.position, orumcekHizi * Time.deltaTime);

                anim.SetBool("hareketEtsinmi", true);

                if (transform.position.x > hedefPlayer.position.x)
                {
                    transform.localScale = new Vector3(-1, 1, 1);
                }
                else if (transform.position.x < hedefPlayer.position.x)
                {
                    transform.localScale = Vector3.one;
                }
            }
            else
            {
                anim.SetBool("hareketEtsinmi", true);

                transform.position = Vector3.MoveTowards(transform.position, posizyonlar[kacinciPosizyon].position, orumcekHizi * Time.deltaTime);


                if (transform.position.x > posizyonlar[kacinciPosizyon].position.x)
                {
                    transform.localScale = new Vector3(-1, 1, 1);
                }
                else if (transform.position.x < posizyonlar[kacinciPosizyon].position.x)
                {
                    transform.localScale = Vector3.one;
                }


                if (Vector3.Distance(transform.position, posizyonlar[kacinciPosizyon].position) < 0.1f)
                {
                    beklemeSayac = beklemeSuresi;
                    PosizyonuDegistir();
                }


            }



        }
        
    }

    void PosizyonuDegistir()
    {
        kacinciPosizyon++;

        if (kacinciPosizyon >= posizyonlar.Length)
            kacinciPosizyon = 0;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;

        Gizmos.DrawWireSphere(transform.position, takipMesafesi);
    }

}

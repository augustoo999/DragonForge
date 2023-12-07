using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ResetCena : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D rb;

    [SerializeField]
    private string Reset;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Enemy") && rb.velocity.y <= 0)
        {
            ResetarCena();
        }
    }
    public void ResetarCena()
    {
        SceneManager.LoadScene(Reset);
    }
}

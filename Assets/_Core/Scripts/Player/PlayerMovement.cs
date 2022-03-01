using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour

{
  public Rigidbody2D rb;
  public float velocidad;
  public float fuerzaSalto;
  private float horizontal;
  private bool estaEnSuelo;
  public Animator anim;
  public bool bloquearMovimiento = false;

    void Start()
    {
  //  Debug.Log("Hola Mundo");
    }

    void Update()
    {  
      if(bloquearMovimiento){return;}
        //0= No moverce 
       //1=Moverce Derecha
       //-1=Moverce Izquierda
      CheckSalto();
      CheckMovimiento();
      ChecarSuelo();
      Voltear();
      anim.SetBool("isJumping",!estaEnSuelo);
    }
     private void CheckSalto(){
         if(Input.GetKeyDown(KeyCode.Space)&&estaEnSuelo){
        Debug.Log("Salta!!!");
         rb.velocity = new Vector2(rb.velocity.x, fuerzaSalto);
       }
        
     }
    private void  CheckMovimiento(){
      horizontal = Input.GetAxisRaw("Horizontal");
      rb.velocity=new Vector2(horizontal* velocidad , rb.velocity.y);
      anim.SetBool("isMoving",horizontal !=0);
    }
  private void ChecarSuelo(){
   Debug.DrawRay(transform.position,Vector3.down * 1f,Color.red);
      if(Physics2D.Raycast(transform.position,Vector2.down,1f)){
        estaEnSuelo=true;
      }else{
        estaEnSuelo=false;
      }
  }
  public bool estaVolteandoADerecha = true;
  private void Voltear(){
    if((horizontal<0 && estaVolteandoADerecha || (horizontal>0 &&!estaVolteandoADerecha))){
      estaVolteandoADerecha =!estaVolteandoADerecha;
      transform.Rotate(0,180,0);
    }
    
  }
}
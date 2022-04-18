using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plano : MonoBehaviour
{
    GameObject obj1;
    bool vericolision = false, canticolision = false;
    public float x1 = 0.0f, v1 = 0.0f, h = 0.1f, r1 = 0.0f, Masa_1 = 0.0f, e = 0.0f, y1 = 0.0f, Angulo_1 = 0.0f;

    private float densidad = 1.2041f, area = 0.002f;
    public float coefric1 = 0.0f;
    private float calconst;

    private float gravedad = 9.81f;
    int pruebita = 0;
    private float vy = 0.0f, vx = 0.0f, dis = 0.0f, tiempo = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        obj1 = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        obj1.transform.localScale = new Vector3(2 * r1, 2 * r1, 2 * r1);
        Angulo_1 = (Angulo_1 * Mathf.PI) / 180.0f;
        //Velocidades movimiento
        vx = Mathf.Cos(Angulo_1) * v1;
        vy = Mathf.Sin(Angulo_1) * v1;
        print("vx " + vx);
        print("vy " + vy);
        calconst = (densidad * area * coefric1) / (2 * Masa_1);
    }

    // Update is called once per frame
    void Update()
    {
        //if (y1 >= r1 && y1 < 3.0f)
        //{
        //    y1 = r1 + 0.5f;
        //}
        //if (canticolision == true && vy <= 0.0f)
        //{
        //    print("SI ENTRO GÜE");
        //    vy = 0.0f;
        //    y1 = r1 + 0.5f;
        //}
        //print("vy " + vy);
        //obj1.transform.position = new Vector3(x1, y1, 0.0f);
        dis = y1;
        //print("time delta cosa "+tiempo);
        nomas();
    }

    void nomas()
    {
        float veloinicial = 0.0f;
        //if (dis > r1)//&& vy>0.0f
        //{
        //    if (vericolision == false)
        //    {
        //        movimiento();
        //    }
        //    else if (vericolision == true)
        //    {
        //print("y: "+ y1);

        //    }
        //}
        
        if (dis <= r1) //&& vy>0.0f
        {
            //print("distancia: "+ dis);
            //pruebita++;
            //print("numero colision: " + pruebita);
            
            while (y1<=r1)
            {
                y1 = y1 + 0.1f;
            }
            calculos();
            //print("Vy justo en colision: "+ vy);
            //print("y justo en colision: "+ y1);
            //y1 = movimientopostcolision(y1);
            //tiempo = 0.0f;
            vericolision = true;
        }
        transform.position = new Vector3(transform.position.x, y1, transform.position.z);
        veloinicial = RungeKutta(vy);
        y1 = y1 + veloinicial * tiempo;
    }
    void movimiento()
    {
        x1 = vx * h + x1;
        y1 = vy * h + y1;
    }
    void calculos()
    {
        //if (canticolision == false)
        //{
            
        //    canticolision = true;
        //}
        vy = -vy;
        vy = vy * e;
    }
    float RungeKutta(float v)
    {
        float m1, m2, m3, m4, v1, v2, v3;
        float velocidad;
        m1 = ((-gravedad) + (calconst * Mathf.Pow(v, 2))) * tiempo;
        v1 = v + (m1 / 2);
        m2 = ((-gravedad) + (calconst * Mathf.Pow(v1, 2))) * tiempo;
        v2 = v + (m2 / 2);
        m3 = ((-gravedad) + (calconst * Mathf.Pow(v2, 2))) * tiempo;
        v3 = v + m3;
        m4 = ((-gravedad) + (calconst * Mathf.Pow(v3, 2))) * tiempo;
        velocidad = v + (m1 / 6) + (m2 / 3) + (m3 / 3) + (m4 / 6);

        return velocidad;
    }
    //float movimientopostcolision(float yanterior)
    //{
    //    float m1, m2, m3, m4;
    //    float tp1, tp2, tp3;
    //    float ynueva;

    //    m1 = (vy - gravedad * tiempo) * h;
    //    tp1 = tiempo + (h / 2);

    //    m2 = (vy - gravedad * tp1) * h;
    //    tp2 = tiempo + (h / 2);

    //    m3 = (vy - gravedad * tp2) * h;
    //    tp3 = tiempo + (h);

    //    m4 = (vy - gravedad * tp3) * h;

    //    ynueva = yanterior + (m1 / 6) + (m2 / 3) + (m3 / 3) + (m4 / 6);
    //    tiempo += 0.1f;
    //    x1 = vx * h + x1;

    //    return ynueva;

    //}

}

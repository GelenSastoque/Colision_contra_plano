using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colision_cualquierplano : MonoBehaviour
{
    GameObject plane, esfera;
    public Plane plano;
    Vector3 Position;
    Vector3 Normal;
    private float velocidad = 0.0f, dis = 0.0f;
    public float  gravedad = 9.81f, masa = 0.09f, y = 0.0f, x=0.0f, veloinicial = 0.0f, radio = 0.0f, e = 0.0f, Angulo=0.0f, Angulo_Normal=0.0f;
    private float tiempo = 0.0f, vx = 0, vy = 0, h = 0.1f, vxn = 0.0f, vyn = 0.0f, vn = 0.0f, anguloplano = 0.0f, vpnew = 0.0f, vxp = 0.0f, vyp = 0.0f,vp = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        Angulo = Angulo * (Mathf.PI / 180f);
        anguloplano = Angulo_Normal * (Mathf.PI / 180f);
        vx = veloinicial * Mathf.Cos(Angulo);
        vy= veloinicial * Mathf.Sin(Angulo);
        print("vx: " + vx);
        plane = GameObject.CreatePrimitive(PrimitiveType.Plane);
        plane.transform.localScale = new Vector3(100f, 100f, 100f);
        plane.transform.Rotate(Angulo_Normal,0f, 0f);
        esfera = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        esfera.transform.localScale = new Vector3(2 * radio, 2 * radio, 2 * radio);
        Position = new Vector3(0f, 0f, 0f);

        Normal = new Vector3(Mathf.Cos(Angulo_Normal), Mathf.Sin(Angulo_Normal), 0f);
        plane.transform.position = new Vector3(0f, 0f, 0f);
        plano.SetNormalAndPosition(Normal, Position);
        
        
    }

    // Update is called once per frame
    void Update()
    {
        float aumentar=0.0f;
        if(Angulo_Normal>0&&Angulo_Normal<=Mathf.PI/2)
        {
            aumentar = 0.1f;
        }
        else if(Angulo_Normal > Mathf.PI / 2 && Angulo_Normal < Mathf.PI)
        {
            aumentar = -0.1f;
        }
        Vector3 Positionesfera;
        Positionesfera = new Vector3(x, y, 0f);
        dis=plano.GetDistanceToPoint(Positionesfera);
        if (dis <= radio)
        {
            choque();
                y = y + 0.1f;
                x = x + aumentar;
          
        }
        esfera.transform.position = new Vector3(x, y, 0.0f);
        vy = RungeKuttavel(vy,y,-gravedad);
        vx = RungeKuttavel(vx, x, 0f);
        
        y = RungeKuttaposi(vy, y, -gravedad);
        x = RungeKuttaposi(vx, x, 0f);
    }
    void choque()
    {
        vxp = Mathf.Cos(anguloplano) * vx;
        vyp = Mathf.Sin(anguloplano) * vy;
        vxn = -Mathf.Sin(anguloplano) * vx;
        vyn = Mathf.Cos(anguloplano) * vy;
        vn = vxn + vyn;
        vp = vxp + vyp;
        vpnew = -vp * e;
        vx = vpnew * Mathf.Cos(anguloplano) - vn * Mathf.Sin(anguloplano);
        vy = vpnew * Mathf.Sin(anguloplano) + vn * Mathf.Cos(anguloplano);
    }
    float calculos(float vel)
    {
        vel = -vel;
        vel = vel * e;
        return vel;
    }

    float RungeKuttavel(float v, float pos, float aceleracion)
    {
        float m1, m2, m3, m4, l1, l2, l3, l4;
        m1 = v;
        l1 = aceleracion;
        m2 = v + ((h * l1) / 2);
        l2 = aceleracion;
        m3 = v + ((h * l2) / 2);
        l3 = aceleracion;
        m4 = v + ((h * l3) / 2);
        l4 = aceleracion;
        v=v + (h / 6) * (l1 + 2 * l2 + 2 * l3 + l4);
        //tiempo += 0.1f;
        return v;
    }
    float RungeKuttaposi(float vel, float pos, float aceleracion)
    {
        float m1, m2, m3, m4, l1, l2, l3, l4;
        m1 = vel;
        l1 = aceleracion;
        m2 = vel + ((h * l1) / 2);
        l2 = aceleracion;
        m3 = vel + ((h * l2) / 2);
        l3 = aceleracion;
        m4 = vel + ((h * l3) / 2);
        l4 = aceleracion;
        pos = pos + (h / 6) * (m1 + 2 * m2 + 2 * m3 + m4);
        //tiempo += 0.1f;
        return pos;
    }
}

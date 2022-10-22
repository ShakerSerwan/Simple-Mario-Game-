using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CsGL.OpenGL;

namespace CG
{
    public class GLClass : OpenGLControl
    {

        protected override void InitGLContext()
        {
            base.InitGLContext();

            
        }

        public override void glDraw()
        {
            //base.glDraw();
            GL.glClear(GL.GL_COLOR_BUFFER_BIT);
            GL.glLoadIdentity();

            GL.gluLookAt(0, 0, 7, 0, 0, 0, 0, 1, 0);


      

            drawSquare1();
        
           GL.glTranslated(0, step, 0);
            // GL.glRotated(step, 0, 0, 0);
            drawCricle();
            // GL.glScaled(1, 1, 1);
            //  GL.glPushMatrix();
            // GL.glTranslated(0, -2, 0);
            //  GL.glRotated(60, 1, 0, 0);
            //// drawSquare();
            //  GL.glPopMatrix();

            //GL.glTranslated(-2, -1, 0);

            //drawTriangle();


            this.Refresh();
        }

        public double step = 0;
        public bool flag = true;
        public double x = 3.5;

        public override void Refresh()
        { 
            base.Refresh();
            if(flag)
            {
              
                step = step + 0.005;
          
                if(step>=x)
                {
                    flag = false;
                    x = x - 0.5;
                }
            }
            else
            {
                step = step - 0.005;
                if(step<=-1)
                {
                    flag = true;
                }
            }
            

        }
        public void drawSquare1()
        {
            GL.glBegin(GL.GL_POLYGON);
            GL.glColor3d(1, 1, 0);
            GL.glVertex3d(3, 1, -1);
            GL.glVertex3d(3, -1, 1);
            GL.glVertex3d(-3,-1,1);
            GL.glVertex3d(-3,1,-1);
            GL.glEnd();
        }
        public void drawCricle()
        {
            GL.glBegin(GL.GL_TRIANGLE_FAN);
            GL.glColor3d(1, 0, 0);
            GL.glVertex3d(0, 0, 0);

            double r = 0.5;
            for (double o = 0; o <= 2 * Math.PI; o = o + 0.005)
            {
                double x = Math.Cos(o) * r;
                double y = Math.Sin(o) * r;
                GL.glVertex3d(x, y, 0);
            }
            GL.glEnd();
        }
        private void drawSquare()
        {
            //Front Face (Cyan Color)
            GL.glBegin(GL.GL_POLYGON);
            GL.glColor3f(0.0f, 1.0f, 1.0f);
            GL.glVertex3f(0.0f, 1.0f, 1.0f);
            GL.glVertex3f(0.0f, 0.0f, 1.0f);
            GL.glVertex3f(1.0f, 0.0f, 1.0f);
            GL.glVertex3f(1.0f, 1.0f, 1.0f);
            GL.glEnd();
            
        }

        private void drawTriangle()
        {
            //Front Face (Cyan Color)
            GL.glBegin(GL.GL_TRIANGLES);
            GL.glColor3f(1.0f, 1.0f, 0.0f);
            GL.glVertex3f(-2.0f, -1.0f, 1.0f);
            GL.glVertex3f(-2.0f, -2.0f, 1.0f);
            GL.glVertex3f(-1.0f, -2.0f, 1.0f);
            GL.glEnd();

        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);

            GL.glMatrixMode(GL.GL_PROJECTION);
            GL.gluPerspective(45.0f, (double)Size.Width / (double)Size.Height, 0.1f, 100.0f);
            GL.glMatrixMode(GL.GL_MODELVIEW);
            GL.glLoadIdentity();

        }
    }
}

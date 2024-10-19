using Grupo701D2.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace Grupo701D2
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        public UTRNGEntities db = new UTRNGEntities();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            alumnos alumno = new alumnos();
            alumno.Matricula = long.Parse(TextBox1.Text);

            alumno.NombreC = TextBox2.Text;
            alumno.Telefono = TextBox3.Text;
            alumno.CorreoE = TextBox4.Text;

            db.alumnos.Add(alumno);
            db.SaveChanges();

          
        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            alumnos alumno = new alumnos();
            long matricula = int.Parse(TextBox1.Text);

             alumno = db.alumnos.Find(matricula);
            TextBox2.Text = alumno.NombreC;
            TextBox3.Text = alumno.Telefono;
            TextBox4.Text = alumno.CorreoE;
        }



        protected void Button3_Click(object sender, EventArgs e)
        {
            alumnos alumno = new alumnos();
            alumno.Matricula = int.Parse(TextBox1.Text);
            alumno.NombreC = TextBox2.Text;
            alumno.Telefono = TextBox3.Text;
            alumno.CorreoE = TextBox4.Text;
            db.Entry(alumno).State = EntityState.Modified;
            db.SaveChanges();
        }


        protected void Button4_Click(object sender, EventArgs e)
        {
            int matricula = int.Parse(TextBox1.Text);
            alumnos alumno = db.alumnos.Find(matricula);
            db.alumnos.Remove(alumno);
            db.SaveChanges();
        }

     
    }
}
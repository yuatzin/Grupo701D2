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
    public partial class WebForm2 : System.Web.UI.Page
    {
        public  TerminalEntities db = new TerminalEntities();
        protected void Page_Load(object sender, EventArgs e)
        {
            

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            autobuses autobuses = new autobuses();

            autobuses.Id = int.Parse(TextBox1.Text);
            autobuses.Ruta = TextBox2.Text;
            autobuses.Precio = float.Parse(TextBox3.Text);
            autobuses.Marca = TextBox4.Text;
            autobuses.TotalP = short.Parse(TextBox5.Text);
            autobuses.Conductor = TextBox6.Text;

            db.autobuses.Add(autobuses);
            db.SaveChanges();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            autobuses autobuses = new autobuses();
            int id = int.Parse(TextBox1.Text);

            autobuses = db.autobuses.Find(id);
            TextBox2.Text = autobuses.Ruta;
            TextBox3.Text = autobuses.Precio.ToString();
            TextBox4.Text = autobuses.Marca;
            TextBox5.Text = autobuses.TotalP.ToString();
            TextBox6.Text = autobuses.Conductor;
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            autobuses autobuses = new autobuses();

            autobuses.Id = int.Parse(TextBox1.Text);
            autobuses.Ruta = TextBox2.Text;
            autobuses.Precio = float.Parse(TextBox3.Text);
            autobuses.Marca = TextBox4.Text;
            autobuses.TotalP = short.Parse(TextBox5.Text);
            autobuses.Conductor = TextBox6.Text;



            db.Entry(autobuses).State = EntityState.Modified;
            db.SaveChanges();
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            int id = int.Parse(TextBox1.Text);
            autobuses autobuses = db.autobuses.Find(id);
            db.autobuses.Remove(autobuses);
            db.SaveChanges();
        }
    }
}
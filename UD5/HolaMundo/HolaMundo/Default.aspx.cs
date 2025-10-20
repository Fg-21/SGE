using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HolaMundo
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            String miNombre = Nombre.Text;
            if (!string.IsNullOrEmpty(miNombre))
            {
                resultado.Text = miNombre;
            }
            else
            {
                error.Text = "Está Vacío";
            }
        }
    }
}
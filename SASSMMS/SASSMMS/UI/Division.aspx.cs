﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SASSMMS.Repository;

namespace SASSMMS.UI
{
    public partial class Division : System.Web.UI.Page
    {
        readonly GenericRepository rep=new GenericRepository();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            var division = rep.GetDivisions();
        }
    }
}
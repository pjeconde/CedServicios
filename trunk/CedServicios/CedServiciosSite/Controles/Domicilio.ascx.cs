﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CedServicios.Site.Controles
{
    public partial class Domicilio : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public string Calle
        {
            get
            {
                return CalleTextBox.Text;
            }
            set
            {
                CalleTextBox.Text = value;
                CalleTextBox.DataBind();
            }
        }
        public string Nro
        {
            get
            {
                return NroTextBox.Text;
            }
            set
            {
                NroTextBox.Text = value;
                NroTextBox.DataBind();
            }
        }
        public string Piso
        {
            get
            {
                return PisoTextBox.Text;
            }
            set
            {
                PisoTextBox.Text = value;
                PisoTextBox.DataBind();
            }
        }
        public string Depto
        {
            get
            {
                return DeptoTextBox.Text;
            }
            set
            {
                DeptoTextBox.Text = value;
                DeptoTextBox.DataBind();
            }
        }
        public string Sector
        {
            get
            {
                return SectorTextBox.Text;
            }
            set
            {
                SectorTextBox.Text = value;
                SectorTextBox.DataBind();
            }
        }
        public string Torre
        {
            get
            {
                return TorreTextBox.Text;
            }
            set
            {
                TorreTextBox.Text = value;
                TorreTextBox.DataBind();
            }
        }
        public string Manzana
        {
            get
            {
                return ManzanaTextBox.Text;
            }
            set
            {
                ManzanaTextBox.Text = value;
                ManzanaTextBox.DataBind();
            }
        }
        public string Localidad
        {
            get
            {
                return LocalidadTextBox.Text;
            }
            set
            {
                LocalidadTextBox.Text = value;
                LocalidadTextBox.DataBind();
            }
        }
        public string IdProvincia
        {
            get
            {
                return ProvinciaDropDownList.SelectedValue;
            }
            set
            {
                ProvinciaDropDownList.SelectedValue = value;
                ProvinciaDropDownList.DataBind();
            }
        }
        public string DescrProvincia
        {
            get
            {
                return ProvinciaDropDownList.SelectedItem.Text;
            }
        }
        public string CodPost
        {
            get
            {
                return CodPostTextBox.Text;
            }
            set
            {
                CodPostTextBox.Text = value;
                CodPostTextBox.DataBind();
            }
        }
        public List<FeaEntidades.CodigosProvincia.CodigoProvincia> ListaProvincia
        {
            set
            {
                ProvinciaDropDownList.DataSource = value;
            }
        }
        public bool Enabled
        {
            set
            {
                CalleTextBox.Enabled = value;
                NroTextBox.Enabled = value;
                PisoTextBox.Enabled = value;
                DeptoTextBox.Enabled = value;
                SectorTextBox.Enabled = value;
                TorreTextBox.Enabled = value;
                ManzanaTextBox.Enabled = value;
                LocalidadTextBox.Enabled = value;
                ProvinciaDropDownList.Enabled = value;
                CodPostTextBox.Enabled = value;
            }
        }
    }
}
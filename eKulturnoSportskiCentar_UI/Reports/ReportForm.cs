﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using eKulturnoSportskiCentar_API.Models;
using Microsoft.Reporting.WinForms;

namespace eKulturnoSportskiCentar_UI.Reports
{
    public partial class ReportForm : Form
    {
        public List<Dogadjaj_Detalji_Result> Dogadjaji { get; set; }
        public DateTime pocetniDatum{ get; set; }
        public DateTime krajnjiDatum { get; set; }
        public string sala { get; set; }
        public string korisnik { get; set; }
        public string satnica { get; set; }

        public string vrstaDogadjaja { get; set; }
        public List<DodatnaOprema> DodatnaOprema =
            new List<DodatnaOprema>();

        public ReportForm()
        {
            InitializeComponent();
        }

        private void ReportForm_Load(object sender, EventArgs e)
        {

            
            ReportDataSource rds=new ReportDataSource("dbDogadjajiFilter", Dogadjaji);
            this.reportViewer1.LocalReport.DataSources.Add(rds);
            this.reportViewer1.LocalReport.SetParameters(new ReportParameter("Sala", sala));
            this.reportViewer1.LocalReport.SetParameters(new ReportParameter("PocetniDatum", pocetniDatum.ToString()));
            this.reportViewer1.LocalReport.SetParameters(new ReportParameter("KrajnjiDatum", krajnjiDatum.ToString()));
            this.reportViewer1.LocalReport.SetParameters(new ReportParameter("VrstaDogadjaja", vrstaDogadjaja));

            this.reportViewer1.RefreshReport();
           
        }


    }
}

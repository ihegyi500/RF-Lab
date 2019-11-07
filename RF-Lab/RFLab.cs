using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Drawing.Printing;

namespace RFLab
{
    public partial class RFLab : Form
    {
        int A = 450, textboxcounter = 2;
        const int B = 25;
        List<string> lista = new List<string>();

        public RFLab()
        {
            InitializeComponent();
            //Nyomtatólista feltöltése
            PrinterSettings settings = new PrinterSettings();
            foreach (String printer in PrinterSettings.InstalledPrinters)
            {
                PrintersList.Items.Add(printer.ToString());
            }
            this.PrintersList.SelectedItem = settings.PrinterName;
        }

        private void PrintAndSaveButton_Click(object sender, EventArgs e)
        {
            ListRefresh();
            PrintClass print = new PrintClass(lista, PrintersList, textboxcounter);
            print.Printing();
            SQLClass datab = new SQLClass(lista,textboxcounter);
            datab.Sqlcon();
        }

        private void PrintingButton_Click(object sender, EventArgs e)
        {
            ListRefresh();
            PrintClass print = new PrintClass(lista, PrintersList, textboxcounter);
            print.Printing();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            ListRefresh();
            SQLClass datab = new SQLClass(lista, textboxcounter);
            datab.Sqlcon();
        }

        private void PrintPreviewLabel_Click(object sender, EventArgs e)
        {
            ListRefresh();
            PrintClass print = new PrintClass(lista, PrintersList, textboxcounter);
            print.PrintPreviewLabel_Click(sender,e);
        }

        //Új vonalkód kattintásra
        private void NewBarcode_Click(object sender, EventArgs e)
        {
            if (textboxcounter / 2 > 5)
                newBarcode.Enabled = false;
            else
            {
                AddNewLabel(A, B, "Username");
                AddNewLabel(A, B + 45, "Password");
                A += 150;
            }
        }
        public void AddNewLabel(int A, int B, string text)
        {
            TextBox txt = new TextBox();
            Label lb = new Label();
            txt.Top = B + 20;
            txt.Left = A;
            lb.Top = B;
            lb.Left = A + 25;
            lb.Text = text;
            Controls.Add(txt);
            Controls.Add(lb);
            textboxcounter++;
        }
        public void ListRefresh()
        {
            lista.Clear();
            lista = this.Controls.OfType<TextBox>()
                .Select(r => r.Text).ToList();
        }
    }
}

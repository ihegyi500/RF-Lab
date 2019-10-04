using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Drawing.Printing;
using Nyomtatas;

namespace BCPS
{
    public partial class BarcodePrinter : Form
    {
        int A = 450, B, textboxcounter = 2;
        List<string> lista = new List<string>();

        public BarcodePrinter()
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
            Stringbollista();
            PrintClass print = new PrintClass(lista, PrintersList, textboxcounter);
            print.Printing();
            SQLClass datab = new SQLClass(lista,textboxcounter);
            datab.Sqlcon();
        }

        private void PrintingButton_Click(object sender, EventArgs e)
        {
            Stringbollista();
            PrintClass print = new PrintClass(lista, PrintersList, textboxcounter);
            print.Printing();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            Stringbollista();
            SQLClass datab = new SQLClass(lista, textboxcounter);
            datab.Sqlcon();
        }

        private void PrintPreviewLabel_Click(object sender, EventArgs e)
        {
            Stringbollista();
            PrintClass print = new PrintClass(lista, PrintersList, textboxcounter);
            print.PrintPreviewLabel_Click(sender,e);
        }

        //Új vonalkód kattintásra
        private void NewBarcode_Click(object sender, EventArgs e)
        {
            if (textboxcounter / 2 > 5)
                MessageBox.Show("Egyszerre maximum 1 oldalnyi címkét nyomtathatsz!", "Figyelmeztetés!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                B = 25;
                AddNewBarcode(A, B + 20);
                AddNewLabel(A + 25, B, "Username");
                B = 70;
                AddNewBarcode(A, B + 20);
                AddNewLabel(A + 25, B, "Password");
                A += 150;
            }
        }

        //Új szövegdoboz
        public TextBox AddNewBarcode(int A, int B)
        {
            TextBox txt = new TextBox();
            Controls.Add(txt);
            txt.Top = B;
            txt.Left = A;
            textboxcounter++;
            return txt;
        }

        //Új címke
        public Label AddNewLabel(int A, int B, string text)
        {
            Label lb = new Label();
            Controls.Add(lb);
            lb.Top = B;
            lb.Left = A;
            lb.Text = text;
            return lb;
        }

        public void Stringbollista()
        {
            lista.Clear();
            lista = this.Controls.OfType<TextBox>()
                .Select(r => r.Text).ToList();
        }
    }
}

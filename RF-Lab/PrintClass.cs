using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing.Printing;
using System.Drawing;

namespace RFLab
{
    class PrintClass
    {
        //private readonly Form form;
        ComboBox PrintersList;
        private readonly List<string> lista;
        private int posx;
        private int posy;
        private int i;
        private int j;
        private readonly int textboxcounter;

        public PrintClass(List<string> listap, ComboBox PrintersListp, int textboxcounterp)
        {
            PrintersList = PrintersListp;
            lista = listap;
            textboxcounter = textboxcounterp;
        }

        public void Printing()
        {
            PrintDocument PrintDoc = new PrintDocument();
            PrintDoc.PrinterSettings.PrinterName =
            PrintersList.SelectedItem.ToString();
            PrintDoc.PrintPage += new PrintPageEventHandler(PrintPageMethod);
            PrintDialog printdlg = new PrintDialog();
            printdlg.Document = PrintDoc;
            if (printdlg.ShowDialog() == DialogResult.OK)
            {
                PrintDoc.Print();
            }
        }


        public void PrintPreviewLabel_Click(object sender, EventArgs e)
        {
            PrintDocument PrintDoc = new PrintDocument();
            PrintDoc.PrinterSettings.PrinterName =
            PrintersList.SelectedItem.ToString();
            PrintDoc.PrintPage += new PrintPageEventHandler(PrintPageMethod);
            PrintPreviewDialog printPrvDlg = new PrintPreviewDialog();
            printPrvDlg.Document = PrintDoc;
            printPrvDlg.ShowDialog();
        }

        public void PrintPageMethod(object sender, PrintPageEventArgs ppev)
        {
            posx = 50;
            posy = 50;
            for (i = 1, j = 0; i <= (textboxcounter / 2); i++, j += 2)
            {
                if (lista[j] != "" && lista[j+1] != "")
                {
                    if (i % 2 == 0)
                    {
                        DrawTicket(posx, posy, ppev, lista[j], lista[j+1]);
                        posy += 300;
                    }
                    else
                    {
                        posx = 50;
                        DrawTicket(posx, posy, ppev, lista[j], lista[j+1]);
                        posx = 500;
                    }
                }
            }
        }

        //Egy címke kirajzolása
        public void DrawTicket(int x, int y, PrintPageEventArgs ppev, string UserName, string Password)
        {
            int rectheight = 100, rectwidth = 250;

            Graphics g = ppev.Graphics;
            Font font = new Font("Free 3 of 9 Extended", 42);
            SolidBrush brush = new SolidBrush(Color.Black);
            Rectangle rect = new Rectangle(x, y, rectwidth, rectheight);
            Pen myPen = new Pen(Color.Black, 5);

            Label UserLabel = new Label();
            UserLabel.Text = "*" + UserName.ToUpper() + "*";
            UserLabel.Font = font;

            Label PasswordLabel = new Label();
            PasswordLabel.Text = "*" + Password.ToUpper() + "*";
            PasswordLabel.Font = font;

            g.DrawRectangle(myPen, rect);
            StringFormat format = new StringFormat();
            format.Alignment = StringAlignment.Center;          //Szélesség
            format.LineAlignment = StringAlignment.Center;      //Magasság
            g.DrawString(UserLabel.Text, font, brush,rect,format);

            font = new Font("Arial", 14, FontStyle.Bold);
            format.LineAlignment = StringAlignment.Far;
            g.DrawString(UserName.ToUpper(), font, brush, rect, format);

            rect.Location = new Point(x, y + 110);
            g.DrawRectangle(myPen, rect);

            font = new Font("Free 3 of 9 Extended", 36);
            format.LineAlignment = StringAlignment.Center;
            g.DrawString(PasswordLabel.Text, font, brush, rect, format);

            font = new Font("Arial", 12, FontStyle.Bold);
            format.LineAlignment = StringAlignment.Far;
            g.DrawString(Password.ToUpper(), font, brush, rect, format);
        }
    }
}

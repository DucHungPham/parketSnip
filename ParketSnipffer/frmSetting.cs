using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ParketSnipffer
{
    public partial class frmSetting : Form
    {
        public frmSetting()
        {
            InitializeComponent();
        }

        private void color_Click(object sender, EventArgs e)
        {
            Button b = sender as Button;
            ColorDialog dlg = new ColorDialog();
            dlg.FullOpen = true;
            dlg.Color = b.BackColor;
            if (dlg.ShowDialog() == DialogResult.OK) 
            {
                
                b.BackColor = dlg.Color;
               
            }

        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            Properties.Settings.Default.txtSendCl = btnClTran.BackColor;

            Properties.Settings.Default.txtRecCl = btnClRec.BackColor;
            Properties.Settings.Default.txtRecFont = lbRec.Font;
            this.Close();
        }

        private void frmSetting_Load(object sender, EventArgs e)
        {
            btnClRec.BackColor  = Properties.Settings.Default.txtRecCl;
            btnClTran.BackColor = Properties.Settings.Default.txtSendCl;
            lbTran.Font = lbRec.Font = Properties.Settings.Default.txtRecFont;
            btnFont.Text = Properties.Settings.Default.txtRecFont.Name.ToString() +','+ Properties.Settings.Default.txtRecFont.Size.ToString();
            
        }

        private void btnFont_Click(object sender, EventArgs e)
        {
            FontDialog fontDlg = new FontDialog();

            fontDlg.Font = lbTran.Font;
            //fontDlg.ShowColor = false;
            //fontDlg.ShowApply = false;
            //fontDlg.ShowEffects = false;
            //fontDlg.ShowHelp = false;
            if (fontDlg.ShowDialog() == DialogResult.OK)
            {
                //textBox1.Font = fontDlg.Font;
                //label1.Font = fontDlg.Font;
                btnFont.Text = fontDlg.Font.Name.ToString() + ',' + fontDlg.Font.Size.ToString();
                lbRec.Font = lbTran.Font = fontDlg.Font;
            }  
        }

        

    }
}

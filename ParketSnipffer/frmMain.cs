using System;
using System.Data;
using System.Drawing;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using System.IO.Ports;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Windows.Forms.DataVisualization.Charting;

//using System.Management; //add project referent

namespace ParketSnipffer
{
    
    public partial class frmMain : Form
    {
        
        public SerialPort Com = new SerialPort();
        System.IO.StreamReader file;
        int graph_scaler = 100;
        uint btsRec = 0;
        uint btsSend = 0;


        public frmMain()
        {
            InitializeComponent();
            for (int i = 0; i < 5 && i < 5; i++)
                graph.Series[i].Points.Add(0);           
        }
        
        public static byte[] HexStringToByteArray(string hex)
        {
            hex = hex.Replace("#", "");
            return Enumerable.Range(0, hex.Length)
                                .Where(x => x % 2 == 0)
                                .Select(x => Convert.ToByte(hex.Substring(x, 2), 16)) // phai dam bao dinh dang chuoi dung
                                .ToArray();
            
        }
        
        /*
        public static byte[] StringToByteArray(string hex)
        {
            if (hex.Length % 2 == 1)
                throw new Exception("The binary key cannot have an odd number of digits");

            byte[] arr = new byte[hex.Length >> 1];

            for (int i = 0; i < hex.Length >> 1; ++i)
            {
                arr[i] = (byte)((GetHexVal(hex[i << 1]) << 4) + (GetHexVal(hex[(i << 1) + 1])));
            }

            return arr;
        }

        public static int GetHexVal(char hex)
        {
            // them cac dieu kien dam bao chuoi nhap vao
            int val = (int)hex;
            //For uppercase A-F letters:
            return val - (val < 58 ? 48 : 55);
            //For lowercase a-f letters:
            //return val - (val < 58 ? 48 : 87);
            //Or the two combined, but a bit slower:
            //return val - (val < 58 ? 48 : (val < 97 ? 55 : 87));
        }
        */
        string  BytesArrTohexString (byte[] dat)
        {
            string hexvalues = "";
            foreach (byte b in dat)
            {

                hexvalues = hexvalues + (b.ToString("X2")) + " ";

            }
            return hexvalues;

            /**
             * /
             * // BitConverter can also be used to put all bytes into one string  
            string bitString = BitConverter.ToString(bytes);  
            Console.WriteLine(bitString);  
             * */
        }
        
        void serial_send(string strS)
        {
            if (Com.IsOpen)
            {
                if (strS == "") return;
            
                string strSend;

                //listBox1.Items.Add(DateTime.Now.TimeOfDay + " -> " + txtSend.Text);//DateTime.Now.ToString("HH:mm:ss.ffff")
 
                byte[] byteSend={0};

                // bộ ghõ đã endcode(để nhìn thấy ký tự), nên để gửi đi đúng số byte phải decode trước khi gửi

                //byteSend = Encoding.UTF8.GetBytes(strS);//lấy bytes trước khi endcodeUTF8
                //aghướng dẫn đầnsr gsr$12#af9678##ab124289#rnaz#B2 3$gsr aer#B233343bada#roer ad rere //45$fgA$f gfhảo hảod#as
                String regex = @"\#[a-fA-F0-9]+\#";

                MatchCollection matchColl = Regex.Matches(strS, regex);
               

                String[] splitString = Regex.Split(strS, regex);

                // số cụm còn lại >= số cụm lấy ra (= | >1;

                if(splitString.Length>0 && matchColl.Count>0)
                {
                    if (splitString.Length > matchColl.Count) { byteSend = Encoding.UTF8.GetBytes(splitString[0]).ToArray(); splitString[0] = null; }
                    for (int i= 0; i < matchColl.Count; i++)
                    {
                        if (matchColl[i].Length % 2==1)
                        {
                            MessageBox.Show("Wrong hex format.", "Parket Snipffer", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return; 
                        }
                       byteSend = byteSend.Concat(HexStringToByteArray(matchColl[i].Value)).ToArray();
                       if (splitString[i] != null)byteSend= byteSend.Concat(Encoding.UTF8.GetBytes(splitString[i])).ToArray();
                            
                    }
                    if (splitString.Length > matchColl.Count) { byteSend = byteSend.Concat(Encoding.UTF8.GetBytes(splitString[splitString.Length-1])).ToArray(); }
                }else
                    byteSend = Encoding.UTF8.GetBytes(strS);//lấy bytes trước khi endcodeUTF8
                /*
                string test1 = "A g 3 4de7 8";
                try
                {
                    byteSend = HexStringToByteArray(test1);
                }
                catch //(Exception ex) 
                {
                    MessageBox.Show("Wrong hex format.", "Parket Snipffer", MessageBoxButtons.OK, MessageBoxIcon.Error);//ex.ToString()ex.Message.ToString()
                    return; 
                }
                */

                //Console.WriteLine("byte send\n"+BytesArrTohexString(byteSend));

                Com.Write(byteSend, 0, byteSend.Length);//Com.Write(String); không gửi ký tự ngoài bảng mã ascii, thay bằng 3F='?'

                if (fmtHEX.Checked == true)
                {
                    strSend = BytesArrTohexString(byteSend);//txtSend.Text.toAray() -> mảng char các ký tự trong Unicode(table)
                }
                    /*
                else if (fmtDEC.Checked == true)
                {
                    string decvalues = "";
                    foreach (byte b in byteSend)
                    {

                        decvalues = decvalues + (b.ToString("D3")) + " ";

                    }
                    strSend = decvalues;
                }
                    */
                else strSend = strS;

                switch (mainTab.SelectedIndex)
                {
                    case 0: //rawdata
                        int tmp = rtReceive.TextLength;
                        // handle 2 "enter" in a string??
                        rtReceive.Select(tmp, tmp + strSend.Length);

                        rtReceive.SelectionColor = txtSend.ForeColor;//Properties.Settings.Default.txtSendCl;
                        rtReceive.AppendText(strSend);
                        rtReceive.SelectionColor = rtReceive.ForeColor;
                        break;
                    case 1: //data log
                        lbxLog.Items.Add(DateTime.Now.TimeOfDay + " -> " + strSend);
                        break;
                    case 2: //graphic
                        break;
                }
                
                btsSend += (uint)byteSend.Length;
                sttSendBytes.Text = "Send: " + btsSend.ToString();
            }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            // String DEC, String HEX
            //string test = "xin chào 1 2 $123456765456$ aere$434$$$ erere#123478";
            
            //Console.WriteLine(BytesArrTohexString(Encoding.Default.GetBytes(test)));
            //Console.WriteLine(BytesArrTohexString(Encoding.UTF8.GetBytes(test)));
            //byte[] bufTest = Encoding.UTF8.GetBytes(test);
            //Console.WriteLine(StringFromCursor(test,0,40));
            
            //grapTime.Start();
            
            serial_send(txtSend.Text);
            
        }


        private void frmMain_Load(object sender, EventArgs e)
        {

            cbCom.Text = Properties.Settings.Default.comName;
            cmBaudRate.Text =  Properties.Settings.Default.comBaund.ToString();
            cmDatLen.Text=Properties.Settings.Default.comDatLen.ToString();
            cmParity.Text=Properties.Settings.Default.comParyti.ToString();
            cmStpBit.Text=Properties.Settings.Default.comStpbit.ToString();

            rtReceive.ForeColor = Properties.Settings.Default.txtRecCl;
            txtSend.ForeColor = Properties.Settings.Default.txtSendCl;
            tmpF1.ForeColor = tmpF2.ForeColor = tmpF3.ForeColor = txtSend.ForeColor;

            txtSend.Font = rtReceive.Font = Properties.Settings.Default.txtRecFont;
           
            tmpF1.Font = tmpF2.Font = tmpF3.Font = txtSend.Font;

           

                       
        }

    

        private void cbCom_DropDown(object sender, EventArgs e)
        {
            
           //cbCom.DataSource = null;
         
            cbCom.Items.Clear();
            int index_ok = -1;
            int index = -1;
            foreach (string s in SerialPort.GetPortNames())
            {
                cbCom.Items.Add(s);
                index++;
            }
            if (index_ok >= 0) cbCom.SelectedIndex = index_ok;

            /*
            // Getting Serial Port Information
            cbCom.Items.Clear();
            int index_ok = -1;
            int index = -1;

            using (var searcher = new ManagementObjectSearcher("SELECT * FROM Win32_PnPEntity WHERE Caption like '%(COM%'"))
            {
                var portnames = SerialPort.GetPortNames();
                var ports = searcher.Get().Cast<ManagementBaseObject>().ToList().Select(p => p["Caption"].ToString());

                var portList = portnames.Select(n => n + " - " + ports.FirstOrDefault(s => s.Contains(n))).ToList();

                foreach (string s in portList)
                {
                    //Console.WriteLine(s);
                    cbCom.Items.Add(s);
                    index++;
                }
                if (index_ok >= 0) cbCom.SelectedIndex = index_ok;
            }
            */


        }

        private void btnCon_Click(object sender, EventArgs e)
        {
            if (isCom.Checked == true) {
                try
                {
                    if (Com.IsOpen)
                    {
                        Com.Close();
                        grConfig.Enabled = true;
                        btsRec = 0;
                        btsSend = 0;
                        sttRecBytes.Text = "Rec: " + btsRec.ToString();
                        sttSendBytes.Text = "Send: " + btsSend.ToString();
                        btnCon.Text = "Open";
                       
                        connectStt.Text = "Close";
                        connectStt.ForeColor = Color.Gray;
                    }
                    else
                    {
                        // Com.Encoding = System.Text.Encoding.GetEncoding(1252);
         
                        Com.PortName = cbCom.Text;
                        Com.BaudRate = int.Parse(cmBaudRate.Text);
                        Com.DataBits = int.Parse(cmDatLen.Text);
                        Com.StopBits = (StopBits)Enum.Parse(typeof(StopBits), cmStpBit.Text);
                        Com.Parity = (Parity)Enum.Parse(typeof(Parity), cmParity.Text);
                        Com.Handshake = Handshake.None;

                        Com.DtrEnable = cmDTR.Checked;
                        Com.RtsEnable = cmRTS.Checked;

                        Com.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(Com_DataReceived);  

                        Com.Open();
                        grConfig.Enabled = false;
                        btnCon.Text = "Close";

                        connectStt.Text = "Open";
                        connectStt.ForeColor = Color.Green;
                        configStt.Text = cbCom.Text + ' ' + cmBaudRate.Text + ' ' + cmDatLen.Text + ' ' + cmStpBit.Text + ' ' + cmParity.Text;

                        this.Text ="Parket Snipffer V1.0" + " - "+ txtNamePro.Text;
                    }
                }
                catch (Exception ex)
                {
                    //statusDisp.Text = ex.ToString();
                    MessageBox.Show(ex.Message.ToString(), "Parket Snipffer",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    
                    connectStt.Text = "Open Err";
                    connectStt.ForeColor = Color.Red;
                }
            }
            
        }

        private void Com_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            string Rec="";
            int bytes = Com.BytesToRead;

            byte[] buffer = new byte[bytes];
            Com.Read(buffer, 0, bytes);
            
            //data = Com.ReadExisting();//=> chi nhan ky tu ASCII
            //if (fmtASCII.Checked == true)
            //    Rec = System.Text.Encoding.ASCII.GetString(buffer);
            //else 
            if(fmtUTF8.Checked == true)
                Rec = System.Text.Encoding.UTF8.GetString(buffer);
            else if (fmtHEX.Checked == true)
            {                
                Rec = BytesArrTohexString(buffer);
            }
                /*
            else if (fmtDEC.Checked == true) {
                string decvalues = "";
                foreach (byte b in buffer)
                {

                    decvalues = decvalues + (b.ToString("D3")) + " ";

                }
                Rec = decvalues;
            }
            */
            if (Rec != String.Empty)
            {
                rtReceiveUpdate(Rec);
                btsRec += (uint)bytes;
                sttRecBytes.Text = "Rec: " + btsRec.ToString();                
            }
           

        }
        
        //Data recived from the serial port is coming from another thread context than the UI thread.
        //Instead of reading the content directly in the SerialPortDataReceived, we need to use a delegate.
        delegate void CallbackFunction(string text);
        private void rtReceiveUpdate(string dat)
        {
            //using endcoding?
            //The buffer size, in bytes. The default value is 4096; the maximum value is that of a positive int, or 2147483647.
            //Referen document .Net

            //listBox1.Items.Add(DateTime.Now.TimeOfDay + " <- " + data);
            /*
            if(cbTiStamp.Checked == true)
                rtReceive.AppendText(DateTime.Now.TimeOfDay + " <- " + data);
            else
                rtReceive.AppendText(data);
          */

            //rtReceive.HideSelection = false;// false to autoscoll


            //if (rtReceive.Lines.Count() > 100) rtReceive.Clear();
/*
            if (cbEchoRec.Checked == true)
            {
                string tmpl = data.Replace(" ","");
                tmp = rtReceive.TextLength;
                int len = tmpl.Length;
                byte[] dat = new byte[len];
                dat = StringToByteArray(tmpl);
                uart.SendData(dat, 0, dat.Length);//len/2
                Console.WriteLine(tmpl);
                rtReceive.AppendText(tmpl);
                rtReceive.Select(tmp, tmp + tmpl.Length);
                rtReceive.SelectionColor = button2.BackColor;
            }
            */
            if (this.rtReceive.InvokeRequired)
            {
                CallbackFunction d = new CallbackFunction(rtReceiveUpdate);
                this.Invoke(d, new object[] { dat });

            }
            else {
                // đầu ra sau dạng string
                switch (mainTab.SelectedIndex) { 
                    case 0: //rawdata
                        rtReceive.AppendText(dat);
                        break;
                    case 1: //data log
                        lbxLog.Items.Add(DateTime.Now.TimeOfDay + " <- " + dat);
                        break;
                    case 2: //graphic
                        {
                            double number;
                            string[] variables = dat.Split('\n')[0].Split(',');
                            for (int i = 0; i < variables.Length && i < 5; i++)
                            {
                                if (double.TryParse(variables[i], out number))
                                {
                                    if (graph.Series[i].Points.Count > graph_scaler)
                                        graph.Series[i].Points.RemoveAt(0);
                                    graph.Series[i].Points.Add(number);
                                }
                            }
                            graph.ResetAutoValues();
                        }
                        break;
                }
                 
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {

            switch (mainTab.SelectedIndex)
            {
                case 0: //rawdata
                    rtReceive.Clear();
                    break;
                case 1: //data log
                    break;
                case 2: //graphic
                    //for (int i = 0; i < 5; i++)
                     //   graph.Series[i].Points.Clear();
                    foreach (var series in graph.Series)
                    {
                        series.Points.Clear();
                    }

                    break;
            }
 
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtSearch.Text == "") return;
            int start = 0;
            int end = rtReceive.Text.LastIndexOf(txtSearch.Text);

            rtReceive.SelectAll();
            rtReceive.SelectionBackColor = Color.White;

            while (start < end)
            {
                rtReceive.Find(txtSearch.Text, start, rtReceive.TextLength, RichTextBoxFinds.MatchCase);

                rtReceive.SelectionBackColor = Color.Yellow;

                start = rtReceive.Text.IndexOf(txtSearch.Text, start) + 1;
            }
        }

        private void tlSetting_Click(object sender, EventArgs e)
        {
            using (frmSetting frmSt = new frmSetting())
            {
                frmSt.ShowDialog(this);
            }
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Com.IsOpen) Com.Close();
            Properties.Settings.Default.comName = cbCom.Text;
            Properties.Settings.Default.comBaund = uint.Parse(cmBaudRate.Text);
            Properties.Settings.Default.comDatLen = byte.Parse(cmDatLen.Text);
            Properties.Settings.Default.comParyti = cmParity.Text;
            Properties.Settings.Default.comStpbit = byte.Parse(cmStpBit.Text);
            Properties.Settings.Default.Save();    
        }

        private void exportLogToolStripMenuItem_Click(object sender, EventArgs e)
        {
                       
            SaveFileDialog saveDialg = new SaveFileDialog();
            switch (mainTab.SelectedIndex)
            {
                case 0: //rawdata
                    //using(File.Create(path));
                    //rtReceive.SaveFile(path, RichTextBoxStreamType.RichText);                    
                    saveDialg.Title = "Save Log";
                    saveDialg.DefaultExt = "txt";
                    saveDialg.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
                    saveDialg.FilterIndex = 1;
                    saveDialg.RestoreDirectory = true;
                    saveDialg.OverwritePrompt = true;
                    if (saveDialg.ShowDialog() == DialogResult.OK)
                        rtReceive.SaveFile(saveDialg.FileName, RichTextBoxStreamType.UnicodePlainText);// chú ý decode
                    break;
                case 1: //data log
                    break;
                case 2: //graphic
                    saveDialg.Title = "Graphic Save";
                    saveDialg.DefaultExt = "png";
                    saveDialg.Filter = "Image files (*.png)|*.png|All files (*.*)|*.*";
                    saveDialg.FilterIndex = 1;
                    saveDialg.RestoreDirectory = true;
                    saveDialg.OverwritePrompt = true;
                    if (saveDialg.ShowDialog() == DialogResult.OK)
                        graph.SaveImage(saveDialg.FileName, ChartImageFormat.Png);
                    break;
            }
        }

        private void cmDTR_CheckedChanged(object sender, EventArgs e)
        {
            
                Com.DtrEnable=cmDTR.Checked;
        }
     
        private void cmRTS_CheckedChanged(object sender, EventArgs e)
        {
            Com.RtsEnable = cmRTS.Checked;
        }

        private void txtSend_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (e.Shift == false)
                {
                    serial_send(txtSend.Text);
                    txtSend.Clear();
                    e.Handled = true;
                }
                //else
                 //   txtSend.AppendText(System.Environment.NewLine);
            }
            else if (e.KeyCode == Keys.F1)
            {
                serial_send(tmpF1.Text);
            }
            else if (e.KeyCode == Keys.F2)
            {
                serial_send(tmpF2.Text);
            }
            else if (e.KeyCode == Keys.F3)
            {
                serial_send(tmpF3.Text);
            }
           
        }

        private void btnBowerTemp_Click(object sender, EventArgs e)
        {
            var dlg = new OpenFileDialog();
            txtDirTemp.Text = "";
            dlg.Filter = "Text files (*.txt)|*.txt";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                txtDirTemp.Text = dlg.FileName;
                /*
                byte[] br = File.ReadAllBytes(txt_file.Text);
                cs = 0;
                for (Int32 i = 0; i < br.Length; i++)
                {
                    cs += br[i];
                }
                label1.Text = "CS: " + cs.ToString("X8");
                 * */

            }
        }

        private void btnBrwFile_Click(object sender, EventArgs e)
        {
            var dlg = new OpenFileDialog();
            txtDirFile.Text = "";
            dlg.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            dlg.FilterIndex = 1;
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                txtDirFile.Text = dlg.FileName;
            }
        }

        private void btnTmpSF_Click(object sender, EventArgs e)
        {
            
             // slu1 
            grFTmp.Enabled = false;
            cbAutoTmp.Enabled = false;
            // Read the file and display it line by line.  
            file =new System.IO.StreamReader(txtDirTemp.Text);
            
            timeSendTmp.Interval = (Int32)rdLineTime.Value;
            //timeSendTmp.Enabled = true;
            timeSendTmp.Start();
            
            /*
            //slu2
            TextReader reader = new StreamReader(txtDirTemp.Text);

            rtReceive.AppendText(reader.ReadToEnd());

            reader.Close();
             */
        }

        private void timeSendTmp_Tick(object sender, EventArgs e)
        {
            if (cbAutoTmp.Checked != true)
            {
                string line;
                if ((line = file.ReadLine()) != null)
                {
                    //System.Console.WriteLine(line);
                    //rtReceive.AppendText(line);
                    serial_send(line);
                }
                else
                {
                    file.Close();
                    timeSendTmp.Stop();
                    grFTmp.Enabled = true;
                    cbAutoTmp.Enabled = true;
                }
            }
            else {
                if (cbf1.Checked == true) serial_send(tmpF1.Text);
                if (cbf2.Checked == true) serial_send(tmpF2.Text);
                if (cbf3.Checked == true) serial_send(tmpF3.Text);
            }
        }

        private void cbAutoTmp_CheckedChanged(object sender, EventArgs e)
        {
            if (cbAutoTmp.Checked == true)
            {
                grFTmp.Enabled = false;
                timeSendTmp.Interval = (Int32)autoTime.Value;
                autoTime.Enabled = false;
                //timeSendTmp.Enabled = true;
                timeSendTmp.Start();
            }
            else
            {
                autoTime.Enabled = true;
                grFTmp.Enabled = true;
                timeSendTmp.Stop();
            }
        }


        void alert(string mes) {
            MessageBox.Show(mes, "Parket Snipffer", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    
        }
        /* Plotter ------*/
        private void graph_speed_ValueChanged(object sender, EventArgs e)
        {
            graph.ChartAreas[0].AxisY.Interval = (int)graph_speed.Value;
        }
        /* change graph scale*/
        private void graph_scale_ValueChanged(object sender, EventArgs e)
        {
            graph_scaler = (int)graph_scale.Value;
            for (int i = 0; i < 5; i++)
                graph.Series[i].Points.Clear();
        }
        /* set graph max value*/
        private void set_graph_max_enable_CheckedChanged(object sender, EventArgs e)
        {
            if (set_graph_max_enable.Checked)
                try
                {
                    graph_max.Value = (int)graph.ChartAreas[0].AxisY.Maximum;
                    graph.ChartAreas[0].AxisY.Maximum = (int)graph_max.Value;
                }
                catch { alert("Invalid Minimum value"); }
            else
                graph.ChartAreas[0].AxisY.Maximum = Double.NaN;

            graph_max.Enabled = set_graph_max_enable.Checked;
        }
        private void graph_max_ValueChanged(object sender, EventArgs e)
        {
            if (graph_max.Value > graph_min.Value)
                graph.ChartAreas[0].AxisY.Maximum = (int)graph_max.Value;
            else
                alert("Invalid Maximum value");
        }
        /* set graph min value*/
        private void set_graph_min_enable_CheckedChanged(object sender, EventArgs e)
        {
            if (set_graph_min_enable.Checked)
                try
                {
                    graph_min.Value = (int)graph.ChartAreas[0].AxisY.Minimum;
                    graph.ChartAreas[0].AxisY.Minimum = (int)graph_min.Value;
                }
                catch { alert("Invalid Minimum value"); }
            else
                graph.ChartAreas[0].AxisY.Minimum = Double.NaN;

            graph_min.Enabled = set_graph_min_enable.Checked;
        }
        private void graph_min_ValueChanged(object sender, EventArgs e)
        {

        }

        private void btnCal_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("Calc");
        }

        private void bntNote_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("Notepad.exe");
        }

        private void btnAbout_Click(object sender, EventArgs e)
        {
            MessageBox.Show("hello!");
        }
     
/*        
        private void grapTime_Tick(object sender, EventArgs e)
        {
            Random random = new Random();
            random.Next(0, 100);
            string data = random.Next(0, 200).ToString() +"," +random.Next(0, 500).ToString() +"\n";
            //else if (plotter_flag)
                {
                    double number;
                    string[] variables = data.Split('\n')[0].Split(',');
                    for (int i = 0; i < variables.Length && i < 5; i++)
                    {
                        if (double.TryParse(variables[i], out number))
                        {
                            if (graph.Series[i].Points.Count > graph_scaler)
                                graph.Series[i].Points.RemoveAt(0);
                            graph.Series[i].Points.Add(number);
                        }
                    }
                    graph.ResetAutoValues();
                }
        }
        */
     
    }
}

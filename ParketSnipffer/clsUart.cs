using System;
using System.IO.Ports;

//Doc ky cac muc trong DOC cua .net
//Docs  .NET  .NET API Browser  System.IO.Ports  SerialPort
// timeout va cac thuoc tinh khac
namespace ParketSnipffer
{
    public class ComEventArgs : EventArgs
    {
        public ComEventArgs(string d, Exception e)
        {
            Data = d;
            Error = e;
        }
        public Exception Error;
        public string Data;
    }

    public delegate void ComPortHandler(object sender, ComEventArgs e);

    public class UART
    {
        #region khai báo thuộc tính

        public event ComPortHandler ComError;
        public event ComPortHandler Connected;
        public event ComPortHandler DisConnect;
        public event ComPortHandler DataReceived;

        private SerialPort Com;
        private string _Ret = string.Empty;


        public int index_data_rev = 0;

        public string PortName
        {
            get { return Com.PortName; }
            set { Com.PortName = value; }
        }
        public int BaudRate { get { return Com.BaudRate; } }
        public string Ret { get { return _Ret; } }
        public bool IsOpen { get { return Com.IsOpen; } }
        #endregion

        #region phương thức khởi tạo
        public UART() { com_init(); }
        private void com_init()
        {
            try
            {
                Com = new SerialPort();
                Com.Encoding = System.Text.Encoding.GetEncoding(1252);
                Com.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(Com_DataReceived);
            }
            catch (Exception ex)
            {
                ComEventArgs e = new ComEventArgs("Error at com_init", ex);
                OnError(e);
            }
        }
        #endregion

        #region phương thức ảo xử lý sự kiện
        protected virtual void OnError(ComEventArgs e)
        {
            if (ComError != null)
                ComError(this, e);
        }
        protected virtual void onDataReceived(ComEventArgs e)
        {
            if (DataReceived != null)
                DataReceived(this, e);
        }
        protected virtual void OnConnected(ComEventArgs e)
        {
            if (Connected != null)
                Connected(this, e);
        }
        protected virtual void OnDisConnect(ComEventArgs e)
        {
            if (DisConnect != null)
                DisConnect(this, e);
        }
        #endregion

        #region phương thức quan trọng: xử lý khi mudule trả dữ liệu về

        public int BytesToReaded;

        private void Com_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            int bytes = Com.BytesToRead;
            byte[] buffer = new byte[bytes];
            Com.Read(buffer, 0, bytes);
            string hexvalues = "";
            foreach (byte b in buffer)
            {

                hexvalues = hexvalues + (b.ToString("X2")) + " ";

            }
            //_Ret = hexvalues;
            _Ret = System.Text.Encoding.UTF8.GetString(buffer);//System.Text.Encoding.ASCII.GetString(buffer)
            //_Ret = Com.ReadExisting();//=> chi nhan ky tu ASCII
    
            onDataReceived(new ComEventArgs(_Ret, null));
        }
        #endregion

        #region phương thức public để giao tiếp bên ngoài
        public void com_connect(string Port, int BaudRate)
        {
            try
            {
                if (Com.IsOpen)
                    Com.Close();
                // Com.Encoding = System.Text.Encoding.GetEncoding(1252);
                Com.PortName = Port;
                Com.BaudRate = BaudRate;
                Com.DataBits = 8;
                Com.StopBits = StopBits.One;
                Com.Parity = Parity.None;
                Com.Handshake = Handshake.None;
                Com.Open();
                OnConnected(new ComEventArgs("Connected to " + Port, null));
            }
            catch (Exception ex)
            {
                ComEventArgs e = new ComEventArgs("Error at com_connect", ex);
                OnError(e);
            }
        }
        public void Open(string Port, int BaudRate = 9600)
        {
            try
            {
                com_connect(Port, BaudRate);
            }
            catch (Exception ex)
            {
                ComEventArgs e = new ComEventArgs("Error at Open connect", ex);
                OnError(e);
            }
        }

        /// <summary>
        /// Send data
        /// </summary>
        public void SendData(byte[] dat, int offset, int count)//string Data
        {
            try
            {
                Com.Write(dat, offset, count); //Com.Write(Data)
            }
            catch (Exception ex)
            {
                ComEventArgs e = new ComEventArgs("Error at SendData", ex);
                OnError(e);
            }
        }

        public void close()
        {
            try
            {
                Com.Close();
                OnDisConnect(new ComEventArgs("Disconnected", null));
            }
            catch (Exception ex)
            {
                ComEventArgs e = new ComEventArgs("Error at com_close", ex);
                OnError(e);
            }
        }


        #endregion
    }
}

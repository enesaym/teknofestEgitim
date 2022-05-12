using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;

namespace arduınoSoru
{
    public partial class Form1 : Form
    {
        private string data;
        public Form1()
        {
            InitializeComponent();
        }
        int saniye=120;
        private void Form1_Load(object sender, EventArgs e)
        {
            pictureBox2.Visible = false;
            timer1.Interval = 1000;
            progressBar1.Maximum = 120;
            progressBar1.Value = saniye;
            timer1.Start();
            //arduino baglantısı 
            serialPort1.PortName = "COM7";
            serialPort1.BaudRate = 9600;
            serialPort1.Open();

            serialPort1.DataReceived += new SerialDataReceivedEventHandler(SerialPort1_DataReceived);
          


        }
        private void SerialPort1_DataReceived(object sender,SerialDataReceivedEventArgs e)
        {
            data = serialPort1.ReadExisting();
            this.Invoke(new EventHandler(displayData_event));
          
        }
        private void displayData_event(object sender,EventArgs e)
        {

            label3.Text = data.ToString();
            if (data == "E")
            {
                pictureBox2.Visible = true;
            }
            else
            {
                pictureBox2.Visible = false;

            }
        }

        private void progressBar1_Click(object sender, EventArgs e)
        {
            

        }

        private void timer1_Tick(object sender, EventArgs e)
        {

           

            if (saniye != 0)
            {
                saniye--;
            }
            label1.Text = Convert.ToString(saniye);
            progressBar1.Value = saniye;
            

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (serialPort1.IsOpen) serialPort1.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
           
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
    }
}

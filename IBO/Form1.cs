using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;
using System.Threading;
using System.Media;

namespace IBO
{
    public partial class Form1 : Form
    {
        Thread readThread,headThread;
        string[] selectedPort;
        string message1 = "";
        bool testReceive1 = true;
        bool testReceive2 = true;

        public Form1()
        {
            InitializeComponent();
            initialize();
        }
 

        private void initialize()
        {
           selectedPort=SerialPort.GetPortNames();
           button1.Enabled = false;
           button2.Enabled = false;
           button3.Enabled = false;
           button4.Enabled = false;
           button5.Enabled = false;
           button6.Enabled = false;
           button7.Enabled = false;
           button8.Enabled = false;
           button9.Enabled = false;
           button10.Enabled = false;
           button11.Enabled = false;
           button12.Enabled = false;
           button13.Enabled = false;
           button14.Enabled = false;
           button15.Enabled = false;
           button16.Enabled = false;
           button17.Enabled = false;
           button18.Enabled = false;
           
        }



        /////////////////////////// Mouse click/////////////////////////////////

        private void button5_Click(object sender, EventArgs e)
        {
            button5.BackColor = System.Drawing.Color.LimeGreen;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                serialPort1.Open();
                button1.Enabled = true;
                button2.Enabled = true;
                button3.Enabled = true;
                button4.Enabled = true;
                button5.Enabled = true;
                button6.Enabled = false;
                button7.Enabled = true;
                button8.Enabled = true;
                button13.Enabled = true;
                button15.Enabled = true;
                button16.Enabled = true;
                button17.Enabled = true;
                button18.Enabled = true ;
            
            }
            catch (Exception d)
            {
                MessageBox.Show(d.Message);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                serialPort1.Close();
                if (!testReceive1)
                {

                    button9.BackColor = System.Drawing.Color.LightGray;
                    button10.BackColor = System.Drawing.Color.LightGray;
                    button11.BackColor = System.Drawing.Color.LightGray;
                    button12.BackColor = System.Drawing.Color.LightGray;
                    button14.BackColor = System.Drawing.Color.LightGray;
                    readThread.Abort();

                }

                if (!testReceive2)
                {
                    headThread.Abort();
                }
                button5.BackColor = System.Drawing.Color.LightGray;
                
                button1.Enabled = false;
                button2.Enabled = false;
                button3.Enabled = false;
                button4.Enabled = false;
                button5.Enabled = false;
                button6.Enabled = true;
                button7.Enabled = false;
                button8.Enabled = false;
                button9.Enabled = false;
                button10.Enabled = false;
                button11.Enabled = false;
                button12.Enabled = false;
                button13.Enabled = false;
                button14.Enabled = false;
                button15.Enabled = false;
                button16.Enabled = false;
                button17.Enabled = false;
                button18.Enabled = false;
                comboBox1.Enabled = true;
                
            }
            catch (Exception d)
            {
                MessageBox.Show(d.Message);
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            button5.BackColor = System.Drawing.Color.LightGray;
            play_welcome();

        }

        private void button13_Click(object sender, EventArgs e)
        {

            button5.BackColor = System.Drawing.Color.LightGray;
            button9.Enabled = true;
            button10.Enabled = true;
            button11.Enabled = true;
            button12.Enabled = true;
            button14.Enabled = true;
            button13.Enabled = false;
            testReceive1 = false;
            readThread = new Thread(new ThreadStart(readPort));
            readThread.Start();

        }

        private void button15_Click(object sender, EventArgs e)
        {
            button5.BackColor = System.Drawing.Color.LightGray;
            try
            {
                serialPort1.WriteLine("3");
            }
            catch (Exception k)
            {
                MessageBox.Show(k.Message);
            }
        }

        private void button16_Click(object sender, EventArgs e)
        {
            button5.BackColor = System.Drawing.Color.LightGray;
            try
            {
                serialPort1.WriteLine("2");
            }
            catch (Exception k)
            {
                MessageBox.Show(k.Message);
            }
        }

        private void button17_Click(object sender, EventArgs e)
        {
            button5.BackColor = System.Drawing.Color.LightGray;
            try
            {
                serialPort1.WriteLine("1");

            }
            catch (Exception k)
            {
                MessageBox.Show(k.Message);
            }
        }

        private void button18_Click(object sender, EventArgs e)
        {
            testReceive2 = false;
            headThread = new Thread(new ThreadStart(head_move));
            headThread.Start();

        }


        //////////////////////////Mouse Down/////////////////////////////

        private void button1_MouseDown(object sender, MouseEventArgs e)
        {
            button5.BackColor = System.Drawing.Color.LightGray;
            try
            {
                serialPort1.WriteLine("w");
            }
            catch (Exception k)
            {
                MessageBox.Show(k.Message);
            }
        }

        private void button2_MouseDown(object sender, MouseEventArgs e)
        {
            button5.BackColor = System.Drawing.Color.LightGray;
            try
            {
                serialPort1.WriteLine("s");
            }
            catch (Exception k)
            {
                MessageBox.Show(k.Message);
            }
        }

        private void button3_MouseDown(object sender, MouseEventArgs e)
        {
            button5.BackColor = System.Drawing.Color.LightGray;
            try
            {
                serialPort1.WriteLine("a");
            }
            catch (Exception k)
            {
                MessageBox.Show(k.Message);
            }
        }

        private void button4_MouseDown(object sender, MouseEventArgs e)
        {
            button5.BackColor = System.Drawing.Color.LightGray;
            try
            {
                serialPort1.WriteLine("d");
            }
            catch (Exception k)
            {
                MessageBox.Show(k.Message);
            }
        }

        private void button8_MouseDown(object sender, MouseEventArgs e)
        {
            button8.BackColor = System.Drawing.Color.LimeGreen;
        }

        private void button15_MouseDown(object sender, MouseEventArgs e)
        {
            button15.BackColor = System.Drawing.Color.LimeGreen;
        }

        private void button16_MouseDown(object sender, MouseEventArgs e)
        {
            button16.BackColor = System.Drawing.Color.LimeGreen;
        }

        private void button17_MouseDown(object sender, MouseEventArgs e)
        {
            button17.BackColor = System.Drawing.Color.LimeGreen;
        }

        //////////////////////Mouse up/////////////////////////////////////
        
        private void button1_MouseUp(object sender, MouseEventArgs e)
        {
            try
            {
                serialPort1.WriteLine("z");   
            }
            catch (Exception k)
            {
                MessageBox.Show(k.Message);
            }
        }

        private void button2_MouseUp(object sender, MouseEventArgs e)
        {
            try
            {
                serialPort1.WriteLine("z");
            }
            catch (Exception k)
            {
                MessageBox.Show(k.Message);
            }
        }

        private void button3_MouseUp(object sender, MouseEventArgs e)
        {
            try
            {
                serialPort1.WriteLine("z");
            }
            catch (Exception k)
            {
                MessageBox.Show(k.Message);
            }
        }

        private void button4_MouseUp(object sender, MouseEventArgs e)
        {
            try
            {
                serialPort1.WriteLine("z");
            }
            catch (Exception k)
            {
                MessageBox.Show(k.Message);
            }
        }

        private void button8_MouseUp(object sender, MouseEventArgs e)
        {
            button8.BackColor = System.Drawing.Color.LightGray;
        }

        private void button15_MouseUp(object sender, MouseEventArgs e)
        {
            button15.BackColor = System.Drawing.Color.LightGray;
        }

        private void button16_MouseUp(object sender, MouseEventArgs e)
        {
            button16.BackColor = System.Drawing.Color.LightGray;
        }

        private void button17_MouseUp(object sender, MouseEventArgs e)
        {
            button17.BackColor = System.Drawing.Color.LightGray;
        }


        ////////////////////////// Key control//////////////////////////////////

        private void button5_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                switch (e.KeyCode)
                {
                    case Keys.W:
                        serialPort1.WriteLine("w");
                        break;
                    case Keys.A:
                        serialPort1.WriteLine("a");
                        break;
                    case Keys.S:
                        serialPort1.WriteLine("s");
                        break;
                    case Keys.D:
                        serialPort1.WriteLine("d");
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " key down event occur ");
            }
        }

        private void button5_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                switch (e.KeyCode)
                {
                    case Keys.W:
                        serialPort1.WriteLine("z");
                        break;
                    case Keys.A:
                        serialPort1.WriteLine("z");
                        break;
                    case Keys.S:
                        serialPort1.WriteLine("z");
                        break;
                    case Keys.D:
                        serialPort1.WriteLine("z");
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " key up event occur ");
            }
        }

        private void button5_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                switch (e.KeyChar)
                {
                    case '1':
                        serialPort1.WriteLine("1");
                        break;
                    case '2':
                        serialPort1.WriteLine("2");
                        break;
                    case '3':
                        serialPort1.WriteLine("3");
                        break;
                    case 'f':
                        play_welcome();
                        break;
                    case 'h':
                        button18_Click(sender, e);
                        break;
                    case 't':
                        button13_Click(sender, e);
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " key down event occur ");
            }
        }

/// <summary>
/// ////////other functions/////////////////////////////////////
/// </summary>     
        private void readPort() {
            try
            {
                while (true)
                {
                    try
                    {//problem = reporting msg from the bigining. nt where thread strts
                        string message = serialPort1.ReadLine();
                         
                        if (message == "w" || message1 == "w")
                        {
                            message1 = "w";
                            if (message == "w")
                            {
                                button10.BackColor = System.Drawing.Color.Green;
                            }
                            else
                            {
                                button10.BackColor = System.Drawing.Color.Red;
                            }
                        }
                        if (message == "s" || message1 == "s")
                        {

                            message1 = "s";
                            if (message == "s")
                            {
                                button11.BackColor = System.Drawing.Color.Green;
                            }
                            else
                            {
                                button11.BackColor = System.Drawing.Color.Red;
                            }
                        }
                        if (message == "a" || message1 == "a")
                        {

                            message1 = "a";
                            if (message == "a")
                            {

                                button9.BackColor = System.Drawing.Color.Green;
                            }
                            else
                            {
                                button9.BackColor = System.Drawing.Color.Red;
                            }
                        }
                        if (message == "d" || message1 == "d")
                        {

                            message1 = "d";
                            if (message == "d")
                            {
                                button12.BackColor = System.Drawing.Color.Green;
                            }
                            else
                            {
                                button12.BackColor = System.Drawing.Color.Red;
                            }
                        }
                        if (message == "1" )
                        {
                            button14.BackColor = System.Drawing.Color.Lime;
                        }
                        if (message == "2")
                        {
                            button14.BackColor = System.Drawing.Color.Yellow;
                        }
                        if (message == "3")
                        {
                            button14.BackColor = System.Drawing.Color.Pink;
                        }
                        if (message == "j")
                        {
                            button14.BackColor = System.Drawing.Color.Blue;
                        }
                        if (message == "k")
                        {
                            button14.BackColor = System.Drawing.Color.SkyBlue;
                        }
                        if (message == "l")
                        {
                            button14.BackColor = System.Drawing.Color.DarkBlue;
                            
                        }
                    }
                    catch (TimeoutException)
                    {
                        MessageBox.Show("Read line error");
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void play_welcome() 
        {
            try
            {
                SoundPlayer MySoundPlayer = new SoundPlayer(Resources.Resource3.recording);
                //  MySoundPlayer.Play();
                // SystemSounds.Beep.Play();
                // MySoundPlayer.Load();
                MySoundPlayer.Load();
                MySoundPlayer.Play();

            }
            catch (Exception MyError)
            {
                MessageBox.Show("An error has occurred: " + MyError.Message);
            }
        }

        private void head_move() 
        {
           
            serialPort1.WriteLine("j");
            Thread.Sleep(5000);
            serialPort1.WriteLine("k");
            Thread.Sleep(5000);
            serialPort1.WriteLine("l");
            Thread.Sleep(1000);
            headThread.Abort();    
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string a = selectedPort[0].ToString();
                string b = comboBox1.Text;
                //MessageBox.Show("Select = "+b+" ; Available= "+a, "");

                if (selectedPort.Length == 0)
                {
                    MessageBox.Show("No ports available");
                }
                else if (a == b)
                {
                    serialPort1.PortName = comboBox1.SelectedItem.ToString();
                    button6.Enabled = true;
                    comboBox1.Enabled = false;
                }
                else
                {
                    MessageBox.Show(b + " is not availabale");
                }
            }
            catch (Exception d)
            {
                MessageBox.Show(d.Message);
            }
        }
/// <summary>
/// //////////////////////////////////////New
/// </summary>
/// <param name="sender"></param>
/// <param name="e"></param>
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                serialPort1.Close();
                if (!testReceive1)
                {
                    readThread.Abort();

                }

                if (!testReceive2)
                {
                    headThread.Abort();
                }
            }
            catch (Exception k)
            {
            }


       }        
    }
}

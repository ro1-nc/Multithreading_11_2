

//Start a long operation. If that operation lasts more than 5 seconds – Abort it.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;

namespace Multithreading_Dia_1
{
    public partial class Form1 : Form
    {
        

        public Form1()
        {
            InitializeComponent();
        }

        static bool Timeout(ThreadStart threadStart, TimeSpan timeout)
        {


            Thread workerThread = new Thread(threadStart);

            workerThread.Start();

            bool finished = workerThread.Join(timeout);
            if (!finished)
                workerThread.Abort();

            return finished;
        }
        static void LongOperation()
        {
            Thread.Sleep(15000);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            if (Timeout(LongOperation, TimeSpan.FromMilliseconds(5000)))
            {
                MessageBox.Show("Thread was finished.");
            }
            else
            {
                MessageBox.Show("Thread was aborted.");
            }
            
            this.Close();

        }


    }
}

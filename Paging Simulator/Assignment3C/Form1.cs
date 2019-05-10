using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace Assignment3C
{
    public partial class Form1 : Form
    {
        public int[] memoryBlocks = new int[4];
        int FIFO = 0;
        int indexNum = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void Memory_Block_Enter(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.RowCount = 160;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            int keptPage = 0;
            int processNum = 0;
            string pageOut;
            Random rand = new Random();
            Button[] array = { button1, button2, button3, button4 };

            for (int i=0; i<160; i++)
            {
                dataGridView1.Rows[i].Cells[0].Value = i;

                processNum = rand.Next(1, 161);
                
                dataGridView1.Rows[i].Cells[1].Value = processNum;

                if (processNum < 11)
                    keptPage = 0;
                else
                    keptPage = processNum / 10;

                dataGridView1.Rows[i].Cells[2].Value = keptPage;

                if(keptPage!= memoryBlocks[0] && keptPage != memoryBlocks[1] && keptPage != memoryBlocks[2] 
                    && keptPage != memoryBlocks[3])
                {
                    memoryBlocks[FIFO] = keptPage;

                    pageOut = array[FIFO].Text;
                    dataGridView1.Rows[i].Cells[3].Value = pageOut;

                    array[FIFO].Text = Convert.ToString(keptPage);
                    FIFO++;

                    if(FIFO==4)
                    {
                        FIFO = 0;
                    }
                }

                dataGridView1.Rows[i].Cells[4].Value = keptPage;
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Button[] array = { button1, button2, button3, button4 };

            for (int i=0; i<160; i++)
            {
                for(int y=0; y<5; y++)
                {
                    dataGridView1.Rows[i].Cells[y].Value = "";
                }
            }

            for(int i=0; i<4; i++)
            {
                array[i].Text = "";
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            int keptPage = 0;
            int processNum = 0;
            //int i = 0;
            string pageOut;
            Random rand = new Random();
            Button[] array = { button1, button2, button3, button4 };

            dataGridView1.Rows[indexNum].Cells[0].Value = indexNum;

            processNum = rand.Next(0, 161);
            dataGridView1.Rows[indexNum].Cells[1].Value = processNum;

            if (processNum < 11)
                keptPage = 0;
            else
                keptPage = processNum / 10;

            dataGridView1.Rows[indexNum].Cells[2].Value = keptPage;

            if (keptPage != memoryBlocks[0] && keptPage != memoryBlocks[1] && keptPage != memoryBlocks[2] && keptPage != memoryBlocks[3])
            {
                memoryBlocks[FIFO] = keptPage;

                pageOut = array[FIFO].Text;

                if (pageOut == "")
                {
                    pageOut = "N/A";
                    dataGridView1.Rows[indexNum].Cells[3].Value = pageOut;
                }
                else
                {
                    dataGridView1.Rows[indexNum].Cells[3].Value = pageOut;
                }

                array[FIFO].Text = Convert.ToString(keptPage);
                FIFO++;

                if (FIFO == 4)
                {
                    FIFO = 0;
                }
            }

            dataGridView1.Rows[indexNum].Cells[4].Value = keptPage;

            indexNum++;
        }

        public static void mainThread()
        {
            Thread.Sleep(10);
        }
    }
}

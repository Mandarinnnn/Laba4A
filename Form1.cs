using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Laba4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Graph graph = new Graph();
        int Number = 0;
        int Start = 1;
       

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            if (graph.IsClicked(e) == false)//если нажато на пустое место
            {
                Number = Number + 1;
                graph.AddV(new Vertex(e.X,e.Y,15,Number));
                Refresh();
            }
            else
            {
                if (graph.CheckedVertecis.Count==2)
                {
                    if(graph.V[graph.CheckedVertecis[0]] == graph.V[graph.CheckedVertecis[1]])
                    {
                        graph.CheckedVertecis.RemoveAt(1);
                        graph.CheckedVertecis.RemoveAt(0);
                        graph.MakeAllnotChecked();
                        
                    }
                    else
                    {
                        graph.AddE(graph.V[graph.CheckedVertecis[0]], graph.V[graph.CheckedVertecis[1]]);
                        graph.CheckedVertecis.RemoveAt(1);
                        graph.CheckedVertecis.RemoveAt(0);
                        graph.MakeAllnotChecked();
                    }
                    Refresh();
                }       
            }
            Refresh();
            
        }




        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = panel1.CreateGraphics();
            graph.Draw(panel1,g);
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            graph.CreateAdjacencyMatrix();
            graph.DFS(Start, panel1);
            graph.MakenotColored();
            Refresh();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            graph.RemoveV();
            Number = 0;
            graph.E.RemoveAll(a => a != null);
            Refresh();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Start = Convert.ToInt32(textBox1.Text);
        }
    }
}

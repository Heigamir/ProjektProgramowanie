﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjektProgramowanie
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Add(textBox1.Text);
            textBox1.Text = null;
            listBox2.Items.Add("Do kupienia");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            listBox2.Items.Clear();
        }

        private void remove_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
            {
                listBox2.Items.RemoveAt(listBox1.SelectedIndex);
                listBox1.Items.RemoveAt(listBox1.SelectedIndex);
            }
            else
            {
                if (listBox2.SelectedIndex != -1)
                {

                    listBox1.Items.RemoveAt(listBox2.SelectedIndex);
                    listBox2.Items.RemoveAt(listBox2.SelectedIndex);
                }
            }

        }

        private void change_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
            {
                listBox2.SelectedIndex = listBox1.SelectedIndex;
                if (listBox2.SelectedItem.Equals("Do kupienia"))
                {
                    listBox2.Items.Insert(listBox2.SelectedIndex, "Kupione");
                    listBox2.Items.RemoveAt(listBox2.SelectedIndex);
                }
                else
                {
                    listBox2.SelectedIndex = listBox1.SelectedIndex;
                    listBox2.Items.Insert(listBox2.SelectedIndex, "Do kupienia");
                    listBox2.Items.RemoveAt(listBox2.SelectedIndex);
                }
            }
            else
            {
                if (listBox2.SelectedIndex != -1)
                {
                    if (listBox2.SelectedItem.Equals("Do kupienia"))
                    {
                        listBox2.Items.Insert(listBox2.SelectedIndex, "Kupione");
                        listBox2.Items.RemoveAt(listBox2.SelectedIndex);
                    }
                    else
                    {
                        listBox2.SelectedIndex = listBox1.SelectedIndex;
                        listBox2.Items.Insert(listBox2.SelectedIndex, "Do kupienia");
                        listBox2.Items.RemoveAt(listBox2.SelectedIndex);
                    }
                }
            }
            
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1_Click(this, new EventArgs());
            }
        }
    }
}
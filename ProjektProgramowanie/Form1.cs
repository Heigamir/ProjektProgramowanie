using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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
        /// <summary>
        /// Dodaje obiekt do listy wraz z domyślnym stastusem do kupienia
        /// </summary>
        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Add(textBox1.Text);
            textBox1.Text = null;
            listBox2.Items.Add("Do kupienia");
        }
        /// <summary>
        /// Czyści obie listy
        /// </summary>
        private void button3_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            listBox2.Items.Clear();
        }
        /// <summary>
        /// Usuwanie elementów z obu listy
        /// Należy pamiętać żeby usunąć element z listy wskazującej jako ostani inaczej listy przestaną się pokrywać
        /// </summary>
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
        /// <summary>
        /// Zmianna statusu
        /// Trzeba najpierw dodac nowy status a potem usunać stary!
        /// </summary>
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
        /// <summary>
        /// Dodaje obsługe "ENTER" z kjlawiatury aby przesłać text z pola do listy
        /// </summary>
        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1_Click(this, new EventArgs());
            }
        }
        /// <summary>
        /// Obsługa odczytu i iteracji po pliku do programu
        /// </summary>
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                Console.WriteLine("Plik wczytany");
                listBox1.Items.Clear();
                listBox2.Items.Clear();
                string[] lines = File.ReadAllLines(dlg.FileName);
                for(int i=0; i< lines.Length;i+=2)
                {
                    listBox1.Items.Add(lines[i]);
                    listBox2.Items.Add(lines[i+1]);
                }
            }
            dlg.Dispose();
            
        }
        /// <summary>
        /// Obsługa zapisu i iteracji danych z programu do pliku
        /// </summary>
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                Console.WriteLine("Plik zapisany");
                StreamWriter writer = new StreamWriter(dlg.FileName);
                for (int i = 0; i < listBox1.Items.Count; i++)
                {
                    writer.WriteLine((string)listBox1.Items[i]);
                    writer.WriteLine((string)listBox2.Items[i]);
                }
                writer.Close();
            }
            dlg.Dispose();
            
        }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WF_Vigenere_Cracker
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int K = int.Parse(textBox4.Text);
            textBox1.Text = textBox1.Text.Replace(Environment.NewLine, "");
            textBox1.Text = textBox1.Text.Replace(" ", "");
            string tx = textBox1.Text;

            for (int i = 0; i < K; i++)
            {
                Console.WriteLine(string.Join(", ", Counter(tx.Skip(i).Where((c, index) => index % K == 0))));
            }

            string alp = "АБВГДЕЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ_";
            int N = alp.Length;

            string password = string.Join("", Enumerable.Range(0, K).Select(i =>
            {
                char mostCommonChar = Counter(tx.Skip(i).Where((c, index) => index % K == 0))
                    .OrderByDescending(pair => pair.Value)
                    .First().Key;

                int newIndex = (alp.IndexOf(mostCommonChar) + 1) % N;
                return alp[newIndex].ToString();
            }));

            textBox3.Text = password;

            int j = 0;
            string s = "";
            foreach (char c in tx)
            {
                int newIndex = (alp.IndexOf(c) - alp.IndexOf(password[j]) + N) % N;
                s += alp[newIndex];
                j = (j + 1) % K;
            }

            textBox2.Text = s;
        }
        static Dictionary<T, int> Counter<T>(IEnumerable<T> collection)
        {
            var counter = new Dictionary<T, int>();
            foreach (T item in collection)
            {
                if (counter.ContainsKey(item))
                    counter[item]++;
                else
                    counter[item] = 1;
            }
            return counter;
        }

        private void label1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Сделал Шаймиев Аскар");
        }

        private void label2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("☭Created by AresTotal from Russia☭");
        }
    }
}

using System;
using System.Windows.Forms;
using System.IO;

namespace WindowsFormsApplication1{
    public partial class Form1 : Form{
        public Form1(){
            InitializeComponent();
        }
        public string name = "";
        public bool fin = false;
        private void button1_Click(object sender, EventArgs e){
            Stream myStream = null;
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            openFileDialog1.InitialDirectory = "c:\\";
            openFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK){
                try{
                    if ((myStream = openFileDialog1.OpenFile()) != null){
                        progressBar1.Value = 0;
                        progressBar1.Visible = true;
                        using (myStream){
                            string key = textBox1.Text;
                            long prog = Convert.ToInt64(myStream.Length / 100);
                            if (checkBox1.Checked == true)
                            {
                                int[] mas = new int[myStream.Length];
                                name = openFileDialog1.FileName;
                                if (prog == 0)
                                {
                                    prog = 1;
                                }
                                for (long i = 0; i < myStream.Length; i++)
                                {
                                    myStream.Seek(i, SeekOrigin.Begin);
                                    char ch = Convert.ToChar(myStream.ReadByte());
                                    mas[i] = Convert.ToInt32(ch);
                                    if (i % (2 * prog) == 0 & progressBar1.Value != 75)
                                    {
                                        progressBar1.Value++;
                                    }
                                }
                                int left, right, temp;
                                for (long q = 0; q < myStream.Length; q = q + 2)
                                {
                                    if (q + 1 != myStream.Length)
                                    {
                                        left = mas[q];
                                        right = mas[q + 1];
                                        temp = 0;
                                        for (int i = 0; i < key.Length; i++)
                                        {
                                            char ch = key[i];
                                            byte g = Convert.ToByte(ch);
                                            temp = right ^ left ^ Convert.ToByte(ch);
                                            right = left;
                                            left = temp;
                                        }
                                        mas[q] = left;
                                        mas[q + 1] = right;
                                    }
                                    if (q % (3 * prog) == 0 & progressBar1.Value != 90)
                                    {
                                        progressBar1.Value++;
                                    }
                                }
                                myStream.Close();
                                saveFileDialog1.FileName = name;
                                FileStream file = new FileStream(name, FileMode.Open);
                                for (long i = 0; i < mas.Length; i++)
                                {
                                    char ch = Convert.ToChar(mas[i]);
                                    file.WriteByte((byte)ch);
                                    if (i % (4 * prog) == 0 & progressBar1.Value != 99)
                                    {
                                        progressBar1.Value++;
                                    }
                                }
                                file.Close();
                                fin = true;
                                progressBar1.Value = 0;
                                progressBar1.Visible = false;
                                
                            }
                            if (checkBox2.Checked == true)
                            {
                                Stream my1Stream = openFileDialog1.OpenFile();
                                progressBar1.Value = 0;
                                progressBar1.Visible = true;
                                name = openFileDialog1.FileName;
                                int[] mas = new int[my1Stream.Length];
                                if (prog == 0)
                                {
                                    prog = 1;
                                }
                                for (long i = 0; i < my1Stream.Length; i++)
                                {
                                    my1Stream.Seek(i, SeekOrigin.Begin);
                                    char ch = (char)my1Stream.ReadByte();
                                    mas[i] = Convert.ToInt32(ch);
                                    if (i % (2 * prog) == 0 & progressBar1.Value < 50)
                                    {
                                        progressBar1.Value++;
                                    }
                                }

                                for (long i = 0; i < mas.Length; i++)
                                {
                                    for (int u = key.Length - 1; u > -1; u--)
                                    {
                                        char ch = Convert.ToChar(key[u]);
                                        mas[i] = Convert.ToInt32(mas[i] ^ (byte)ch);
                                    }
                                    if (i % (3 * prog) == 0 & progressBar1.Value < 75)
                                    {
                                        progressBar1.Value++;
                                    }
                                }
                                my1Stream.Close();
                                FileStream file = new FileStream(name, FileMode.Open);
                                for (long i = 0; i < mas.Length; i++)
                                {
                                    char ch = Convert.ToChar(mas[i]);
                                    file.WriteByte((byte)ch);
                                    if (i % (3 * prog) == 0 & progressBar1.Value < 99)
                                    {
                                        progressBar1.Value++;
                                    }
                                }
                                file.Close();
                                progressBar1.Visible = false;
                                progressBar1.Value = 0;
                                fin = true;
                            }
                            if (checkBox3.Checked == true)
                            {
                                Stream my2Stream = openFileDialog1.OpenFile();
                                progressBar1.Value = 0;
                                progressBar1.Visible = true;
                                name = openFileDialog1.FileName;
                                int[] mas = new int[my2Stream.Length];
                                if (prog == 0)
                                {
                                    prog = 1;
                                }
                                for (long i = 0; i < my2Stream.Length; i++)
                                {
                                    my2Stream.Seek(i, SeekOrigin.Begin);
                                    char ch = (char)my2Stream.ReadByte();
                                    mas[i] = Convert.ToInt32(ch);
                                    if (i % (2 * prog) == 0 & progressBar1.Value < 50)
                                    {
                                        progressBar1.Value++;
                                    }
                                }
                                for (long i = 0; i < mas.Length; i = i + 2)
                                {
                                    if (i + 1 != mas.Length)
                                    {
                                        for (int u = key.Length - 1; u > -1; u--)
                                        {
                                            char ch = Convert.ToChar(key[u]);
                                            mas[i] = Convert.ToInt32(mas[i] ^ (byte)ch);
                                            mas[i + 1] = Convert.ToInt32(mas[i + 1] ^ (byte)Math.Pow(2, u));
                                        }
                                        if (i % (3 * prog) == 0 & progressBar1.Value < 75)
                                        {
                                            progressBar1.Value++;
                                        }
                                    }
                                } 
                                my2Stream.Close();
                                FileStream file = new FileStream(name, FileMode.Open);
                                for (long i = 0; i < mas.Length; i++)
                                {
                                    char ch = Convert.ToChar(mas[i]);
                                    file.WriteByte((byte)ch);
                                    if (i % (3 * prog) == 0 & progressBar1.Value < 99)
                                    {
                                        progressBar1.Value++;
                                    }
                                }
                                file.Close();
                                progressBar1.Visible = false;
                                progressBar1.Value = 0;
                                fin = true;
                            }
                        }
                    }
                }
                catch (Exception ex){
                    MessageBox.Show("Помилка: Не вдається прочитати файл з диска. Детальніший опис помилки: " + ex.Message);
                }
            }
            if (progressBar1.Visible == false & fin == true){
                MessageBox.Show("Файл успішно зашифрований", "Повідомлення", MessageBoxButtons.OK);
            }
            fin = false;
            progressBar1.Visible = false;
        }
        private void button2_Click(object sender, EventArgs e){
            Stream myStream = null;
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            openFileDialog1.InitialDirectory = "c:\\";
            openFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;
            if (openFileDialog1.ShowDialog() == DialogResult.OK){
                try
                {
                    if ((myStream = openFileDialog1.OpenFile()) != null)
                    {
                        using (myStream)
                        {
                            string key = textBox2.Text;
                            long prog = Convert.ToInt64(myStream.Length / 100);
                            if (checkBox3.Checked == true)
                            {
                                progressBar1.Value = 0;
                                progressBar1.Visible = true;
                                name = openFileDialog1.FileName;
                                int[] mas = new int[myStream.Length];
                                if (prog == 0)
                                {
                                    prog = 1;
                                }
                                for (long i = 0; i < myStream.Length; i++)
                                {
                                    myStream.Seek(i, SeekOrigin.Begin);
                                    char ch = (char)myStream.ReadByte();
                                    mas[i] = Convert.ToInt32(ch);
                                    if (i % (2 * prog) == 0 & progressBar1.Value < 50)
                                    {
                                        progressBar1.Value++;
                                    }
                                }
                                for (long i = 0; i < mas.Length; i = i + 2)
                                {
                                    if (i + 1 != myStream.Length)
                                    {
                                        for (int u = 0; u < key.Length; u++)
                                        {
                                            char ch = Convert.ToChar(key[u]);
                                            mas[i] = Convert.ToInt32(mas[i] ^ (byte)ch);
                                            mas[i + 1] = Convert.ToInt32(mas[i + 1] ^ (byte)Math.Pow(2, u));
                                        }
                                        if (i % (3 * prog) == 0 & progressBar1.Value < 75)
                                            progressBar1.Value++;
                                    }
                                }

                                myStream.Close();
                                FileStream file = new FileStream(name, FileMode.Open);
                                for (long i = 0; i < mas.Length; i++)
                                {
                                    char ch = Convert.ToChar(mas[i]);
                                    file.WriteByte((byte)ch);
                                    if (i % (3 * prog) == 0 & progressBar1.Value < 99)
                                        progressBar1.Value++;
                                }
                                file.Close();
                                progressBar1.Visible = false;
                                progressBar1.Value = 0;
                                fin = true;
                            }
                            myStream.Close();
                            if (checkBox2.Checked == true)
                            {
                                Stream my1Stream = openFileDialog1.OpenFile();
                                progressBar1.Visible = true;
                                progressBar1.Value = 0;
                                int[] mas = new int[my1Stream.Length];
                                name = openFileDialog1.FileName;
                                if (prog == 0)
                                    prog = 1;
                                for (long i = 0; i < my1Stream.Length; i++)
                                {
                                    my1Stream.Seek(i, SeekOrigin.Begin);
                                    char ch = (char)my1Stream.ReadByte();
                                    mas[i] = Convert.ToInt32(ch);
                                    if (i % (2 * prog) == 0 & progressBar1.Value != 50)
                                        progressBar1.Value++;
                                }
                                for (long i = 0; i < mas.Length; i++)
                                {
                                    for (int u = 0; u < key.Length; u++)
                                    {
                                        char ch = Convert.ToChar(key[u]);
                                        mas[i] = Convert.ToInt32(mas[i] ^ (byte)ch);
                                    }
                                    if (i % (3 * prog) == 0 & progressBar1.Value != 75)
                                        progressBar1.Value++;
                                }
                                my1Stream.Close();
                                FileStream file = new FileStream(name, FileMode.Open);
                                for (long i = 0; i < mas.Length; i++)
                                {
                                    char ch = Convert.ToChar(mas[i]);
                                    file.WriteByte((byte)ch);
                                    if (i % (3 * prog) == 0 & progressBar1.Value != 100)
                                    {
                                        progressBar1.Value++;
                                    }
                                }
                                file.Close();
                                fin = true;
                                progressBar1.Visible = false;
                            }
                            if (checkBox1.Checked == true)
                            {
                                Stream my2Stream = openFileDialog1.OpenFile();
                                progressBar1.Value = 0;
                                progressBar1.Visible = true;
                                int[] mas = new int[my2Stream.Length];
                                name = openFileDialog1.FileName;
                                if (prog == 0)
                                {
                                    prog = 1;
                                }
                                for (long i = 0; i < my2Stream.Length; i++)
                                {
                                    my2Stream.Seek(i, SeekOrigin.Begin);
                                    char ch = Convert.ToChar(my2Stream.ReadByte());
                                    mas[i] = Convert.ToInt32(ch);
                                    if (i % (2 * prog) == 0 & progressBar1.Value < 50)
                                        progressBar1.Value++;
                                }
                                int left, right, temp;
                                for (long q = 0; q < my2Stream.Length; q = q + 2){
                                    if (q + 1 != my2Stream.Length){
                                        left = mas[q];
                                        right = mas[q + 1];
                                        temp = 0;
                                        for (int i = key.Length - 1; i > -1; i--){
                                            char ch = key[i];
                                            temp = right ^ left ^ Convert.ToByte(ch);
                                            left = right;
                                            right = temp;
                                        }
                                        mas[q] = left;
                                        mas[q + 1] = right;
                                    }
                                    if (q % (3 * prog) == 0 & progressBar1.Value != 75)
                                        progressBar1.Value++;
                                }
                                my2Stream.Close();
                                saveFileDialog1.FileName = name;
                                FileStream file = new FileStream(name, FileMode.Open);
                                for (long i = 0; i < mas.Length; i++){
                                    char ch = Convert.ToChar(mas[i]);
                                    file.WriteByte((byte)ch);
                                    if (i % (3 * prog) == 0 & progressBar1.Value != 99)                                    
                                        progressBar1.Value++;
                                }
                                file.Close();
                                progressBar1.Value = 0;
                                fin = true;
                            }
                        }
                    }
                }
                catch (Exception ex){
                    MessageBox.Show("Помилка: Не вдається прочитати файл з диска. Детальніший опис помилки: " + ex.Message);
                }
            }
            if (progressBar1.Visible == false & fin == true)
                MessageBox.Show("Файл успішно розшифрований", "Повідомлення", MessageBoxButtons.OK);
            progressBar1.Visible = false;
            progressBar1.Value = 0;
            fin = false;
            
        }
        
        private void допомогаToolStripMenuItem1_Click(object sender, EventArgs e)
        {
        
        }

        private void проПрограмуMMSHToolStripMenuItem1_Click(object sender, EventArgs e)
        {
        }
    }
}

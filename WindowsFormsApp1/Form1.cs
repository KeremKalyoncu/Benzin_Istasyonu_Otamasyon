using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void progressBar1_Click(object sender, EventArgs e)
        {

        }
        private void label15_Click(object sender, EventArgs e)
        {

        }
        private void label12_Click(object sender, EventArgs e)
        {

        }
        private void label13_Click(object sender, EventArgs e)
        {

        }
        private void label11_Click(object sender, EventArgs e)
        {

        }
        private void label14_Click(object sender, EventArgs e)
        {

        }
        
        private void label28_Click(object sender, EventArgs e)
        {

        }
        private void tabPage3_Click(object sender, EventArgs e)
        {

        }
private void label29_Click(object sender, EventArgs e)
        {

        }


        //kod başlangıc
       
        double d_benzin95 = 0, d_benzin97 = 0, d_dizel = 0, d_eurodizel = 0, d_lpg = 0;  // depodaki akaryakıt
        double e_benzin95 = 0, e_benzin97 = 0, e_dizel = 0, e_eurodizel = 0, e_lpg = 0;// ekleme akaryakıt
        double f_benzin95 = 0, f_benzin97 = 0, f_dizel = 0, f_eurodizel = 0, f_lpg = 0;// fiyat 
        double s_benzin95 = 0, s_benzin97 = 0, s_dizel = 0, s_eurodizel = 0, s_lpg = 0;// satış

        string[] depoBilgileri;
        string[] fiyatBilgileri;
        private void button3_Click(object sender, EventArgs e)
        {
            s_benzin95 = double.Parse(numericUpDown1.Value.ToString());
            s_benzin97 = double.Parse(numericUpDown2.Value.ToString());
            s_dizel = double.Parse(numericUpDown3.Value.ToString());
            s_eurodizel = double.Parse(numericUpDown4.Value.ToString());
            s_lpg = double.Parse(numericUpDown5.Value.ToString());

            if(numericUpDown1.Enabled==true)
            {
                d_benzin95=d_benzin95-s_benzin95;
                label29.Text =(s_benzin95 * f_benzin95).ToString("0.##");
            }
            else if (numericUpDown2.Enabled == true)
            {
                d_benzin97 = d_benzin97 - s_benzin97;
                label29.Text = (s_benzin97 * f_benzin97).ToString("0.##");
            }
            else if (numericUpDown3.Enabled == true)
            {
                d_dizel = d_dizel - s_dizel;
                label29.Text = (s_dizel * f_dizel).ToString("0.##");
            }
            else if (numericUpDown4.Enabled == true)
            {
                d_eurodizel = d_eurodizel - s_eurodizel;
                label29.Text = (s_eurodizel * f_eurodizel).ToString("0.##");
            }
            else if (numericUpDown5.Enabled == true)
            {
                d_lpg = d_lpg - s_lpg;
                label29.Text = (s_lpg * f_lpg).ToString("0.##");
            }

            depoBilgileri[0]= Convert.ToString(d_benzin95);
            depoBilgileri[1] = Convert.ToString(d_benzin97);
            depoBilgileri[2] = Convert.ToString(d_dizel);
            depoBilgileri[3] = Convert.ToString(d_eurodizel);
            depoBilgileri[4] = Convert.ToString(d_lpg);

            System.IO.File.WriteAllLines(Application.StartupPath+"\\DEPO.txt",depoBilgileri);
            Txt_Depo_Oku();
            Txt_Depo_Yaz();
            progressBar_guncelle();
            numericupdown_value();

            numericUpDown1.Value = 0;
            numericUpDown2.Value = 0;
            numericUpDown3.Value = 0;
            numericUpDown4.Value = 0;
            numericUpDown5.Value = 0;

        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox1.Text=="BENZİN 95 OKTAN")
            {
                numericUpDown1.Enabled = true;
                numericUpDown2.Enabled = false;
                numericUpDown3.Enabled = false;
                numericUpDown4.Enabled = false;
                numericUpDown5.Enabled = false;
            }
            else if (comboBox1.Text == "BENZİN 97 OKTAN")
            {
                numericUpDown1.Enabled = false;
                numericUpDown2.Enabled = true;
                numericUpDown3.Enabled = false;
                numericUpDown4.Enabled = false;
                numericUpDown5.Enabled = false;
            }
            else if (comboBox1.Text == "DİZEL")
            {
                numericUpDown1.Enabled = false;
                numericUpDown2.Enabled = false;
                numericUpDown3.Enabled = true;
                numericUpDown4.Enabled = false;
                numericUpDown5.Enabled = false;
            }
            else if (comboBox1.Text == "EURO DİZEL")
            {
                numericUpDown1.Enabled =false;
                numericUpDown2.Enabled = false;
                numericUpDown3.Enabled = false;
                numericUpDown4.Enabled = true;
                numericUpDown5.Enabled = false;
            }
            else if (comboBox1.Text == "LPG")
            {
                numericUpDown1.Enabled = false;
                numericUpDown2.Enabled = false;
                numericUpDown3.Enabled = false;
                numericUpDown4.Enabled = false;
                numericUpDown5.Enabled = true;
            }
            numericUpDown1.Value = 0;
            numericUpDown2.Value = 0;
            numericUpDown3.Value = 0;
            numericUpDown4.Value = 0;
            numericUpDown5.Value = 0;
            label29.Text = "Secim Bekleniyor...";
        }
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                f_benzin95 = f_benzin95 + (f_benzin95 * Convert.ToDouble
                    (textBox7.Text) / 100);
                fiyatBilgileri[0]= Convert.ToString(f_benzin95);
            }
            catch (Exception)
            {
                textBox7.Text = "Hata";
               
            }
            try
            {
                f_benzin97 = f_benzin97 + (f_benzin97 * Convert.ToDouble
                    (textBox10.Text) / 100);
                fiyatBilgileri[1] = Convert.ToString(f_benzin97);
            }
            catch (Exception)
            {
                textBox10.Text = "Hata";
               
            }
            try
            {
                f_dizel = f_dizel + (f_dizel * Convert.ToDouble
                    (textBox3.Text) / 100);
                fiyatBilgileri[2] = Convert.ToString(f_dizel);
            }
            catch (Exception)
            {
                textBox3.Text = "Hata";
                
            }
            try
            {
                f_eurodizel= f_eurodizel + (f_eurodizel * Convert.ToDouble
                    (textBox9.Text) / 100);
                fiyatBilgileri[3] = Convert.ToString(f_eurodizel);
            }
            catch (Exception)
            {
                textBox9.Text = "Hata";
                
            }
            try
            {
                f_lpg = f_lpg + (f_lpg * Convert.ToDouble
                    (textBox8.Text) / 100);
                fiyatBilgileri[4] = Convert.ToString(f_lpg);
            }
            catch (Exception)
            {
                textBox8.Text = "Hata";
                
            }
            System.IO.File.WriteAllLines(Application.StartupPath + "\\Fiyat.txt", fiyatBilgileri);
            Txt_Fiyat_Oku();
            Txt_Fiyat_Yaz();
            progressBar_guncelle();
            numericupdown_value();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                e_benzin95 = Convert.ToDouble(textBox1.Text);
                if(1000<d_benzin95+e_benzin95 || e_benzin95 <=0)
                {
                    textBox1.Text = "";
                }
                else
                {
                    depoBilgileri[0] = Convert.ToString(d_benzin95 + e_benzin95);
                }
            }
            catch (Exception)
            {

                textBox1.Text = "Hata";
            }
            try
            {
                e_benzin97 = Convert.ToDouble(textBox2.Text);
                if (1000 < d_benzin97 + e_benzin97 || e_benzin97 <= 0)
                {
                    textBox2.Text = "";
                }
                else
                {
                    depoBilgileri[1] = Convert.ToString(d_benzin97 + e_benzin97);
                }
            }
            catch (Exception)
            {

                textBox2.Text = "Hata";
            }
            try
            {
                e_dizel = Convert.ToDouble(textBox4.Text);
                if (1000 < d_dizel + e_dizel || e_dizel <= 0)
                {
                    textBox4.Text = "";
                }
                else
                {
                    depoBilgileri[2] = Convert.ToString(d_dizel + e_dizel);
                }
            }
            catch (Exception)
            {

                textBox4.Text = "Hata";
            }
            try
            {
                e_eurodizel = Convert.ToDouble(textBox5.Text);
                if (1000 < d_eurodizel + e_eurodizel || e_eurodizel <= 0)
                {
                    textBox5.Text = "";
                }
                else
                {
                    depoBilgileri[3] = Convert.ToString(d_eurodizel + e_eurodizel);
                }
            }
            catch (Exception)
            {

                textBox5.Text = "Hata";
            }
            try
            {
                e_lpg = Convert.ToDouble(textBox6.Text);
                if (1000 < d_lpg + e_lpg || e_lpg <= 0)
                {
                    textBox6.Text = "";
                }
                else
                {
                    depoBilgileri[4] = Convert.ToString(d_lpg + e_lpg);
                }
            }
            catch (Exception)
            {

                textBox6.Text = "Hata";
            }
            System.IO.File.WriteAllLines(Application.StartupPath + "\\DEPO.txt", depoBilgileri);
            Txt_Depo_Oku();
            Txt_Depo_Yaz();
            progressBar_guncelle();
            numericupdown_value();
        }
        private void Txt_Depo_Oku()
        {
            depoBilgileri = System.IO.File.ReadAllLines(Application.StartupPath + "\\DEPO.TXT");
            d_benzin95 = Convert.ToDouble(depoBilgileri[0]);
            d_benzin97 = Convert.ToDouble(depoBilgileri[1]);
            d_dizel = Convert.ToDouble(depoBilgileri[2]);
            d_eurodizel = Convert.ToDouble(depoBilgileri[3]);
            d_lpg = Convert.ToDouble(depoBilgileri[4]);
        }
        private void Txt_Depo_Yaz()
        {
            label17.Text = d_benzin95.ToString("N");
            label18.Text = d_benzin97.ToString("N");
            label19.Text = d_dizel.ToString("N");
            label20.Text = d_eurodizel.ToString("N");
            label16.Text = d_lpg.ToString("N");

        }
        private void Txt_Fiyat_Oku()
        {
            fiyatBilgileri = System.IO.File.ReadAllLines(Application.StartupPath + "\\Fiyat.txt");
            f_benzin95 = Convert.ToDouble(fiyatBilgileri[0]);
            f_benzin97 = Convert.ToDouble(fiyatBilgileri[1]);
            f_dizel = Convert.ToDouble(fiyatBilgileri[2]);
            f_eurodizel = Convert.ToDouble(fiyatBilgileri[3]);
            f_lpg = Convert.ToDouble(fiyatBilgileri[4]);
        }
        private void Txt_Fiyat_Yaz()
        {
            label15.Text = f_benzin95.ToString("N");
            label14.Text = f_benzin97.ToString("N");
            label13.Text = f_dizel.ToString("N");
            label12.Text = f_eurodizel.ToString("N");
            label11.Text = f_lpg.ToString("N");
        }
        private void progressBar_guncelle()
        {
            progressBar1.Value = Convert.ToInt16(d_benzin95);
            progressBar2.Value = Convert.ToInt16(d_benzin97);
            progressBar3.Value = Convert.ToInt16(d_dizel);
            progressBar4.Value = Convert.ToInt16(d_eurodizel);
            progressBar5.Value = Convert.ToInt16(d_lpg);
        }
        private void numericupdown_value()
        {
            numericUpDown1.Maximum = decimal.Parse(d_benzin95.ToString());
            numericUpDown2.Maximum = decimal.Parse(d_benzin97.ToString());
            numericUpDown3.Maximum = decimal.Parse(d_dizel.ToString());
            numericUpDown4.Maximum = decimal.Parse(d_eurodizel.ToString());
            numericUpDown5.Maximum = decimal.Parse(d_lpg.ToString());
        }
        private void Form1_Load_1(object sender, EventArgs e)
        {
            this.Text = "AKARYAKIT İSTASYONU - KALYONCU";
            Txt_Depo_Oku();
            Txt_Depo_Yaz();
            Txt_Fiyat_Oku();
            Txt_Fiyat_Yaz();
            progressBar_guncelle();
            numericupdown_value();



            string[] yakit_turleri = { "BENZİN 95 OKTAN", "BENZİN 97 OKTAN", "DİZEL", "EURO DİZEL", "LPG" };
            comboBox1.Items.AddRange(yakit_turleri);

            numericUpDown1.Enabled = false;
            numericUpDown2.Enabled = false;
            numericUpDown3.Enabled = false;
            numericUpDown4.Enabled = false;
            numericUpDown5.Enabled = false;

            numericUpDown1.DecimalPlaces = 2;
            numericUpDown2.DecimalPlaces = 2;
            numericUpDown3.DecimalPlaces = 2;
            numericUpDown4.DecimalPlaces = 2;
            numericUpDown5.DecimalPlaces = 2;

            numericUpDown1.Increment = 0.1M;
            numericUpDown2.Increment = 0.1M;
            numericUpDown3.Increment = 0.1M;
            numericUpDown4.Increment = 0.1M;
            numericUpDown5.Increment = 0.1M;

            numericUpDown1.ReadOnly = true;
            numericUpDown2.ReadOnly = true;
            numericUpDown3.ReadOnly = true;
            numericUpDown4.ReadOnly = true;
            numericUpDown5.ReadOnly = true;
        }



    }
}

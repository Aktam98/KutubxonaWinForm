using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Kutubxona
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=Kutubxona;Integrated Security=True");

        private void Form1_Load(object sender, EventArgs e)
        {
            addxizmat.Size = new Size(0, 0);
            addkitob.Size = new Size(0, 0);
            addkitobxon.Size = new Size(0, 0);
            panel2.Size = new Size(0, 0);
            panel3.Size = new Size(0, 0);
            menu.Table = "xizmat";
            menutable();
            menu.up = 0;
        }
         
        void menutable()
        {
            con.Open();
            string query = "select* from "+menu.Table;
            SqlDataAdapter dataAdapter = new SqlDataAdapter(query, con);

            DataSet ds = new DataSet();
            dataAdapter.Fill(ds, menu.Table);
            con.Close();
            dataGridView2.DataSource = ds;
            dataGridView2.DataMember =menu.Table;
        }
        

        private void button1_Click(object sender, EventArgs e)
        {
            menu.Table = "xizmat";
            menutable();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            menu.Table = "Kitob";
            menutable();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            menu.Table = "Kitobxon";
            menutable();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            menu.Table = "Xodim";
            menutable();
            
                
        }

        private void button5_Click(object sender, EventArgs e)
        {
           
            if (menu.Table == "xizmat")
            {   menu.up = 0;
                con.Open();
                string query = "Select* From Kitob";
                SqlCommand command = new SqlCommand(query, con);
                SqlDataReader sqlread = command.ExecuteReader();
                while (sqlread.Read())
                {
                    comboBox1.Items.Add(sqlread["ID"]);
                }
                sqlread.Close();
                con.Close();

                con.Open();
                string query2 = "Select* From Kitobxon";
                SqlCommand command2 = new SqlCommand(query2, con);
                SqlDataReader sqlread2 = command2.ExecuteReader();
                while (sqlread2.Read())
                {
                    comboBox2.Items.Add(sqlread2["ID"]);
                }
                sqlread2.Close();
                con.Close();

                con.Open();
                string query3 = "Select* From Xodim";
                SqlCommand command3 = new SqlCommand(query3, con);
                SqlDataReader sqlread3 = command3.ExecuteReader();
                while (sqlread3.Read())
                {
                    comboBox3.Items.Add(sqlread3["ID"]);
                }
                sqlread3.Close();
                con.Close();
                panel2.Size = new Size(0, 0);
                addkitob.Size = new Size(0, 0);
                addxizmat.Size = new Size(303, 385);
                addkitobxon.Size = new Size(0, 0);
            }
            if (menu.Table == "Kitob")
            {
                menu.up = 0;
                panel2.Size = new Size(0, 0);
                addxizmat.Size = new Size(0, 0);
                addkitob.Size = new Size(299, 339);
                addkitobxon.Size = new Size(0, 0);
            }
            if (menu.Table == "Kitobxon")
            {
                menu.up = 0;
                panel2.Size = new Size(0, 0);
                addxizmat.Size = new Size(0, 0);
                addkitob.Size = new Size(0,0);
                addkitobxon.Size = new Size(292,338);
            }
            if(menu.Table == "Xodim")
            {
                menu.up = 0;
                panel2.Size = new Size(257, 355);
                addxizmat.Size = new Size(0, 0);
                addkitob.Size = new Size(0, 0);
                addkitobxon.Size = new Size(0,0);
            }

            
        }

        private void button9_Click(object sender, EventArgs e)
        {
            string olish_sanasi = comboBox4.Text + "." + comboBox5.Text + "." + comboBox6.Text;
            string qaytarish_sanasi = comboBox9.Text + "." + comboBox8.Text + "." + comboBox7.Text;

            if (menu.up == 0)
            {
                con.Open();
                string insquery = "Insert into xizmat(KitobID,KitobxonID,XodimID,olish_sanasi,qaytarish_sanasi) values('" + comboBox1.Text + "','" + comboBox2.Text + "','" + comboBox3.Text + "','" + olish_sanasi + "','" + qaytarish_sanasi + "')";
                SqlDataAdapter dataAdapter = new SqlDataAdapter(insquery, con);
                dataAdapter.SelectCommand.ExecuteNonQuery();
                con.Close();
            }
            if(menu.up != 0)
            {
                string id = dataGridView2.SelectedRows[0].Cells[0].Value.ToString();
                
                string insquery = "update xizmat set KitobID='" + comboBox1.Text + "' ,KitobxonID='" + comboBox2.Text + "' ,XodimID='" + comboBox3.Text + " ,olish_sanasi='" + olish_sanasi + " ,qaytarish_sanasi='" + qaytarish_sanasi + "'where ID="+id;
                SqlDataAdapter dataAdapter = new SqlDataAdapter(insquery, con);
                dataAdapter.SelectCommand.ExecuteNonQuery();
                con.Close();
                menu.up = 0;
            }
            MessageBox.Show("Malumot saqlandi");
            addxizmat.Size = new Size(0, 0);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            addxizmat.Size = new Size(0, 0);
            menu.up = 0;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            
            if (menu.Table == "xizmat")
            {
                menu.up = 1;
                addxizmat.Size = new Size(303, 385);
            }
            if (menu.Table =="Kitob")
            {
                menu.up = 1;
                addkitob.Size = new Size(299, 339);
                textBox2.Text = dataGridView2.SelectedRows[0].Cells[1].Value.ToString();
                textBox3.Text = dataGridView2.SelectedRows[0].Cells[2].Value.ToString();

            }
            if (menu.Table == "Kitobxon")
            {
                menu.up = 1;
                addkitobxon.Size = new Size(292,338);
                textBox4.Text = dataGridView2.SelectedRows[0].Cells[1].Value.ToString();
                textBox5.Text = dataGridView2.SelectedRows[0].Cells[2].Value.ToString();
                textBox6.Text = dataGridView2.SelectedRows[0].Cells[3].Value.ToString();
                textBox7.Text = dataGridView2.SelectedRows[0].Cells[4].Value.ToString();

            }
            if (menu.Table == "Xodim")
            {
                menu.up = 1;
                panel2.Size = new Size(257, 355);
                textBox8.Text = dataGridView2.SelectedRows[0].Cells[1].Value.ToString();
                textBox9.Text = dataGridView2.SelectedRows[0].Cells[2].Value.ToString();
                textBox10.Text = dataGridView2.SelectedRows[0].Cells[3].Value.ToString();

            }

        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (menu.up == 0)
            {
                con.Open();
                string insquery = "Insert into Kitob(Nomi,Muallifi) values('" + textBox2.Text + "','" + textBox3.Text + "')";
                SqlDataAdapter dataAdapter = new SqlDataAdapter(insquery, con);
                dataAdapter.SelectCommand.ExecuteNonQuery();
                con.Close();
            }
            if (menu.up != 0)
            {
                string id = dataGridView2.SelectedRows[0].Cells[0].Value.ToString();
                con.Open();
              
                string insquery = "update Kitob set Nomi='" + textBox2.Text + "',Muallifi='" + textBox3.Text + "' where ID=" + id;
                SqlDataAdapter dataAdapter = new SqlDataAdapter(insquery, con);
                dataAdapter.SelectCommand.ExecuteNonQuery();
                con.Close();
                menu.up = 0;
            }
            MessageBox.Show("Malumot saqlandi");
            addkitob.Size = new Size(0, 0);

        }

        private void button11_Click(object sender, EventArgs e)
        {
            addkitob.Size = new Size(0, 0);
            menu.up = 0;
        }

        private void button13_Click(object sender, EventArgs e)
        {
            if (menu.up == 0)
            {
                con.Open();
                string insquery = "Insert into Kitobxon(Ism,Familiya,Telefon,PasportID) values('" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "','" + textBox7.Text + "')";
                SqlDataAdapter dataAdapter = new SqlDataAdapter(insquery, con);
                dataAdapter.SelectCommand.ExecuteNonQuery();
                con.Close();
            }
            if (menu.up != 0)
            {
                con.Open();
                
                string insquery = "update Kitobxon set Ism='"+ textBox4.Text + "' ,Familiya='" + textBox5.Text + "' ,Telefon='" + textBox6.Text + "' ,PasportID='" + textBox7.Text + "' where ID=" + dataGridView2.SelectedRows[0].Cells[0].Value.ToString();
                SqlDataAdapter dataAdapter = new SqlDataAdapter(insquery, con);
                dataAdapter.SelectCommand.ExecuteNonQuery();
                con.Close();
                menu.up = 0;
            }
            MessageBox.Show("Malumot saqlandi");
            addkitobxon.Size = new Size(0, 0);
        }

        private void button14_Click(object sender, EventArgs e)
        {
            addkitobxon.Size = new Size(0, 0);
            menu.up = 0;
        }

        private void button16_Click(object sender, EventArgs e)
        {
            if (menu.up == 0)
            {
                con.Open();
                string insquery = "Insert into Xodim(Ism,Familiya,Telefon) values('" + textBox8.Text + "','" + textBox9.Text + "','" + textBox10.Text + "')";
                SqlDataAdapter dataAdapter = new SqlDataAdapter(insquery, con);
                dataAdapter.SelectCommand.ExecuteNonQuery();
                con.Close();
            }
            if (menu.up != 0)
            {
                con.Open();
                
                string insquery = "update Xodim set Ism='" + textBox8.Text + "' ,Familiya='" + textBox9.Text + "' ,Telefon='" + textBox10.Text + "' where ID=" + dataGridView2.SelectedRows[0].Cells[0].Value.ToString();
                SqlDataAdapter dataAdapter = new SqlDataAdapter(insquery, con);
                dataAdapter.SelectCommand.ExecuteNonQuery();
                con.Close();
                menu.up = 0;
            }
            MessageBox.Show("Malumot saqlandi");
            panel2.Size = new Size(0, 0);
        }

        private void button15_Click(object sender, EventArgs e)
        {
            panel2.Size = new Size(0, 0);
            menu.up = 0;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            panel3.Size = new Size(263, 119);
        }

        private void button18_Click(object sender, EventArgs e)
        {
            panel3.Size = new Size(0, 0);
        }

        private void button17_Click(object sender, EventArgs e)
        {
           string id= dataGridView2.SelectedRows[0].Cells[0].Value.ToString();
            con.Open();
            string insquery = "delete from "+menu.Table+" where ID="+id;
            SqlDataAdapter dataAdapter = new SqlDataAdapter(insquery, con);
            dataAdapter.SelectCommand.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Malumot o'chirildi");
            panel3.Size = new Size(0, 0);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
}

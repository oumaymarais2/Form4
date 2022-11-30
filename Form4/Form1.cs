using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Form4
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			SqlConnection con = new SqlConnection("Data Source=DESKTOP-64KR7SG\\SQLEXPRESS;Initial Catalog=livre;Integrated Security=True");
			con.Open();
			SqlCommand cmd = new SqlCommand("insert into book values('" + int.Parse(textBox1.Text) + "', '" + textBox2.Text + "', '" + int.Parse(textBox3.Text) + "')", con);
			/*cmd.Parameters.AddWithValue("@ID", int.Parse(textBox1.Text));
			cmd.Parameters.AddWithValue("@Name", textBox2.Text);
			cmd.Parameters.AddWithValue("@Price", int.Parse(textBox3.Text));*/
			 MessageBox.Show(cmd.CommandText);
			try { 
				cmd.ExecuteNonQuery();
				MessageBox.Show("seccesfully insert");
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
			con.Close();
			



		}

		private void button2_Click(object sender, EventArgs e)
		{
			SqlConnection con = new SqlConnection("Data Source=DESKTOP-64KR7SG\\SQLEXPRESS;Initial Catalog=livre;Integrated Security=True");
			con.Open();
			SqlCommand cmd = new SqlCommand("update book set Name='" + textBox2.Text + "',Prise= '" + int.Parse(textBox3.Text) + "' where ID='" + int.Parse(textBox1.Text) + "'", con);
			
			try { 
				cmd.ExecuteNonQuery();
				MessageBox.Show("seccesfully update");
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
			con.Close();
		}

		private void button3_Click(object sender, EventArgs e)
		{
			SqlConnection con = new SqlConnection("Data Source=DESKTOP-64KR7SG\\SQLEXPRESS;Initial Catalog=livre;Integrated Security=True");
			con.Open();
			SqlCommand cmd = new SqlCommand("Delete from book  where ID='" + int.Parse(textBox1.Text) + "'", con);
			
			try
			{
				cmd.ExecuteNonQuery();
				MessageBox.Show("seccesfully delete");
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
			con.Close();
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			// TODO: This line of code loads data into the 'livreDataSet.book' table. You can move, or remove it, as needed.
			this.bookTableAdapter.Fill(this.livreDataSet.book);
			// TODO: This line of code loads data into the 'booksDataSet.Library' table. You can move, or remove it, as needed.
			this.libraryTableAdapter.Fill(this.booksDataSet.Library);

		}
	}
}

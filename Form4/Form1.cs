using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
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
			SqlConnection con = new SqlConnection("Data Source=DESKTOP-64KR7SG\\SQLEXPRESS;Initial Catalog=Books;Integrated Security=True");
			con.Open();
			SqlCommand cmd = new SqlCommand("insert into Library values(@ID,@Name,@Price)", con);
			cmd.Parameters.AddWithValue("@ID",int.Parse(textBox1.Text));
			cmd.Parameters.AddWithValue("@Name", textBox2.Text);
			cmd.Parameters.AddWithValue("@Price", int.Parse(textBox3.Text));
			
			con.Close();
			MessageBox.Show("seccesfully insert");



		}

		private void button2_Click(object sender, EventArgs e)
		{
			SqlConnection con = new SqlConnection("Data Source=DESKTOP-64KR7SG\\SQLEXPRESS;Initial Catalog=Books;Integrated Security=True");
			con.Open();
			SqlCommand cmd = new SqlCommand("Update Library set Name=@Name,Price=@Price where ID=@ID",con);
			cmd.Parameters.AddWithValue("@ID", int.Parse(textBox1.Text));
			cmd.Parameters.AddWithValue("@Name", textBox2.Text);
			cmd.Parameters.AddWithValue("@Price", int.Parse(textBox3.Text));
			cmd.ExecuteNonQuery();
			con.Close();
			MessageBox.Show("seccesfully updated");
		}

		private void button3_Click(object sender, EventArgs e)
		{
			SqlConnection con = new SqlConnection("Data Source=DESKTOP-64KR7SG\\SQLEXPRESS;Initial Catalog=Books;Integrated Security=True");
			con.Open();
			SqlCommand cmd = new SqlCommand("Delete from Library  where ID=@ID", con);
			cmd.Parameters.AddWithValue("@ID", int.Parse(textBox1.Text));
			con.Close();
			MessageBox.Show("seccesfully Deleted");
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			// TODO: This line of code loads data into the 'booksDataSet.Library' table. You can move, or remove it, as needed.
			this.libraryTableAdapter.Fill(this.booksDataSet.Library);

		}
	}
}

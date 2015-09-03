using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace wedfromass2
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        private string constr = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\trungnguyen\\Desktop\\MVCMyClass\\WebApplication4\\WebApplication4\\App_Data\\ManageStore.mdf;Integrated Security=True";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {

                this.BindCategory();
            }

        }
        private void BindGrid()
        {

            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("Product_CRUD"))
                {
                    int id = Int32.Parse(dropdown.SelectedValue);

                    cmd.Parameters.AddWithValue("@Action", "SELECT");
                    cmd.Parameters.AddWithValue("@CategoryID", id);
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            GridView1.DataSource = dt;
                            GridView1.DataBind();
                        }
                    }
                }
            }
        }


        protected void Insert(object sender, EventArgs e)
        {
           
                string Title = txtaddTitle.Text;
                int CategoryID = Int32.Parse(dropdowadd.SelectedValue);
                string ShortDescription = txtaddShortDescription.Text;
                string LongDescription = TxtaddLongDescription.Text;
                string Price = TxtappPrice.Text;
                string Quantity = TxtappQuantity.Text;
                string ImageUrl = TxtappImageUrl.Text;
                double n;
                bool isPriceNumber = double.TryParse(Price, out n);
                bool isQuantityNumber = double.TryParse(Quantity, out n);
                if (Title == null || Price == null || Quantity == null || ImageUrl == null || CategoryID == 0 || ShortDescription == null || LongDescription == null || isPriceNumber == false || isQuantityNumber == false) 
                { validation.Text = "Please check input"; }
                else
                {
                    using (SqlConnection con = new SqlConnection(constr))
                    {
                        using (SqlCommand cmd = new SqlCommand("Product_CRUD"))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@Action", "INSERT");
                            cmd.Parameters.AddWithValue("@Title", Title);
                            cmd.Parameters.AddWithValue("@CategoryID", CategoryID);
                            cmd.Parameters.AddWithValue("@ShortDescription", ShortDescription);
                            cmd.Parameters.AddWithValue("@LongDescription", LongDescription);
                            cmd.Parameters.AddWithValue("@Price", Price);
                            cmd.Parameters.AddWithValue("@Quantity", Quantity);
                            cmd.Parameters.AddWithValue("@ImageUrl", ImageUrl);
                            cmd.Connection = con;
                            con.Open();
                            cmd.ExecuteNonQuery();
                            con.Close();
                        }
                    }
                    this.BindGrid();
                    validation.Text = "Add Successfull";
                    TxtaddLongDescription.Text = "";
                    txtaddShortDescription.Text = "";
                    txtaddTitle.Text = "";
                    TxtappImageUrl.Text = "";
                    TxtappPrice.Text = "";
                    TxtappQuantity.Text = "";
                }
            }


        protected void OnRowEditing(object sender, System.Web.UI.WebControls.GridViewEditEventArgs e)
        {

            GridView1.EditIndex = e.NewEditIndex;
            this.BindGrid();
        }


        protected void OnRowUpdating(object sender, System.Web.UI.WebControls.GridViewUpdateEventArgs e)
        {
            GridViewRow row = GridView1.Rows[e.RowIndex];
            int ProductID = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values[0]);

            string Title = (row.FindControl("txtTitle") as TextBox).Text;
            string ShortDescription = (row.FindControl("txtShortDescription") as TextBox).Text;
            string LongDescription = (row.FindControl("txtLongDescription") as TextBox).Text;
            string ImageUrl = (row.FindControl("txtImageUrl") as TextBox).Text;
            string Price = (row.FindControl("txtPrice") as TextBox).Text;
            string Quantity = (row.FindControl("txtQuantity") as TextBox).Text;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("Product_CRUD"))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Action", "UPDATE");
                    cmd.Parameters.AddWithValue("@ProductID", ProductID);
                    cmd.Parameters.AddWithValue("@Title", Title);
                    cmd.Parameters.AddWithValue("@ShortDescription", ShortDescription);
                    cmd.Parameters.AddWithValue("@LongDescription", LongDescription);
                    cmd.Parameters.AddWithValue("@Price", Price);
                    cmd.Parameters.AddWithValue("@Quantity", Quantity);
                    cmd.Parameters.AddWithValue("@ImageUrl", ImageUrl);
                    cmd.Connection = con;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            GridView1.EditIndex = -1;
            this.BindGrid();
        }


        protected void OnRowCancelingEdit(object sender, EventArgs e)
        {
            GridView1.EditIndex = -1;
            this.BindGrid();
        }



        protected void OnRowDeleting(object sender, System.Web.UI.WebControls.GridViewDeleteEventArgs e)
        {
            int ProductID = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values[0]);

            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("Product_CRUD"))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Action", "DELETE");
                    cmd.Parameters.AddWithValue("@ProductID", ProductID);
                    cmd.Connection = con;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            this.BindGrid();
        }



        protected void OnRowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowIndex != GridView1.EditIndex)
            {
                //   (e.Row.Cells[2].Controls[2] as LinkButton).Attributes["onclick"] = "return confirm('Do you want to delete this row?');";
            }
        }


        protected void BindCategory()
        {
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            SqlCommand cmd = new SqlCommand("EXEC DisplayCategory", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dropdown.DataSource = ds;
            dropdown.DataTextField = "Title";
            dropdown.DataValueField = "CategoryID";
            dropdown.DataBind();
            dropdown.Items.Insert(0, new ListItem("--Select--", "0"));
            dropdown2.DataSource = ds;
            dropdown2.DataTextField = "Title";
            dropdown2.DataValueField = "CategoryID";
            dropdown2.DataBind();
            dropdown2.Items.Insert(0, new ListItem("--Select--", "0"));
            dropdown.Items.Insert(0, new ListItem("--Select--", "0"));
            dropdowadd.DataSource = ds;
            dropdowadd.DataTextField = "Title";
            dropdowadd.DataValueField = "CategoryID";
            dropdowadd.DataBind();
            dropdowadd.Items.Insert(0, new ListItem("--Select--", "0"));
            con.Close();
        }

        protected void submit_Click(object sender, EventArgs e)
        {
            BindGrid();
        }

        protected void ButtonDelete_Click(object sender, EventArgs e)
        {
            
                int id = Int32.Parse(dropdown2.SelectedValue);
                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand("DELETECAT"))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        // cmd.Parameters.AddWithValue("@Action", "DELETECATEGORY");
                        cmd.Parameters.AddWithValue("@CategoryID", id);
                        cmd.Connection = con;
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }
                BindGrid();
                BindCategory();
            
        }
    }
}
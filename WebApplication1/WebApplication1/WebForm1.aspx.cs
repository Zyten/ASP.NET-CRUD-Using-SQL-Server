using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;

namespace WebApplication1
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGridview();
            }
        }
        protected void BindGridview()
        {
            DataSet ds = new DataSet();
            using (SqlConnection con = new SqlConnection("Data Source=ZYTEN-PC\\SQLEXPRESS;Integrated Security=true;Initial Catalog=book_details"))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("crudoperations", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@status", "SELECT");
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                con.Close();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    gvDetails.DataSource = ds;
                    gvDetails.DataBind();
                }
                else
                {
                    ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());
                    gvDetails.DataSource = ds;
                    gvDetails.DataBind();
                    int columncount = gvDetails.Rows[0].Cells.Count;
                    gvDetails.Rows[0].Cells.Clear();
                    gvDetails.Rows[0].Cells.Add(new TableCell());
                    gvDetails.Rows[0].Cells[0].ColumnSpan = columncount;
                    gvDetails.Rows[0].Cells[0].Text = "No Records Found";
                }
            }
        }

        protected void gvDetails_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("AddNew"))
            {
                TextBox txtbname = (TextBox)gvDetails.FooterRow.FindControl("txtbname");
                TextBox txtbauthor = (TextBox)gvDetails.FooterRow.FindControl("txtbauthor");
                TextBox txtbISBN = (TextBox)gvDetails.FooterRow.FindControl("txtbISBN");
                crudoperations("INSERT", txtbname.Text, txtbauthor.Text, txtbISBN.Text, 0);
            }
        }

        protected void gvDetails_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvDetails.EditIndex = e.NewEditIndex;
            BindGridview();
        }

        protected void gvDetails_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvDetails.EditIndex = -1;
            BindGridview();
        }

        protected void gvDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvDetails.PageIndex = e.NewPageIndex;
            BindGridview();
        }

        protected void gvDetails_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int book_id = Convert.ToInt32(gvDetails.DataKeys[e.RowIndex].Values["book_id"].ToString());
            TextBox txtbookname = (TextBox)gvDetails.Rows[e.RowIndex].FindControl("txtBookName");
            TextBox txtbookauthor = (TextBox)gvDetails.Rows[e.RowIndex].FindControl("txtBookAuthor");
            TextBox txtbISBN = (TextBox)gvDetails.FooterRow.FindControl("txtbISBN");
            crudoperations("UPDATE", txtbookname.Text, txtbookauthor.Text, txtbISBN.Text, book_id);
        }

        protected void gvDetails_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int book_id = Convert.ToInt32(gvDetails.DataKeys[e.RowIndex].Values["book_id"].ToString());
            string book_name = gvDetails.DataKeys[e.RowIndex].Values["book_name"].ToString();
            crudoperations("DELETE", book_name, "", "", book_id);
        }

        protected void crudoperations(string status, string book_name, string book_author, string book_ISBN, int book_id)
        {
            using (SqlConnection con = new SqlConnection("Data Source=ZYTEN-PC\\SQLEXPRESS;Integrated Security=true;Initial Catalog=book_details"))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("crudoperations", con);
                cmd.CommandType = CommandType.StoredProcedure;
                if (status == "INSERT")
                {
                    cmd.Parameters.AddWithValue("@status", status);
                    cmd.Parameters.AddWithValue("@book_name", book_name);
                    cmd.Parameters.AddWithValue("@book_author", book_author);
                    cmd.Parameters.AddWithValue("@book_ISBN", book_ISBN);
                }
                else if (status == "UPDATE")
                {
                    cmd.Parameters.AddWithValue("@status", status);
                    cmd.Parameters.AddWithValue("@book_name", book_name);
                    cmd.Parameters.AddWithValue("@book_author", book_author);
                    cmd.Parameters.AddWithValue("@book_ISBN", book_ISBN);
                    cmd.Parameters.AddWithValue("@book_id", book_id);
                }
                else if (status == "DELETE")
                {
                    cmd.Parameters.AddWithValue("@status", status);
                    cmd.Parameters.AddWithValue("@book_id", book_id);
                }
                cmd.ExecuteNonQuery();
                lblresult.ForeColor = Color.Green;
                string append = "";
                if (status.ToLower() == "update" || status.ToLower() == "delete")
                    append = "d.";
                else
                    append = "ed.";
                lblresult.Text = "<strong>Success!</strong> " + " Book " + book_name + " " + status.ToLower() + append;
                success_alert.Visible = true;
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "HideLabel();", true);
                gvDetails.EditIndex = -1;
                BindGridview();
            }
        }
    }
}
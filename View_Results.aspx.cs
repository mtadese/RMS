﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using MySql.Data.MySqlClient;

namespace RMS
{
    public partial class View_Results : System.Web.UI.Page
    {
        string connectionString;
        MySqlDataReader dr;
        MySqlConnection con;
        MySqlCommand cmd;
        MySqlDataAdapter adap;
        DataSet ds1;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["SqlConnection"].ConnectionString);

                //connectionString = "Server=localhost;Database=noun_result_sys;Uid=root;Pwd=password;";
                //con = new MySqlConnection(connectionString);
                con.Open();

            }
            catch (Exception err)
            {
                lblError.Visible = true;
                lblError.Text = "Error: " + err.Message;
            }
            con.Close();
        }

        protected void btnSearchStud_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtStudID.Text != "")
                {
                    MySqlCommand cmd = con.CreateCommand();
                    cmd.CommandText = "SELECT * FROM students where student_id like " + "'" + txtStudID.Text + "%'";

                    adap = new MySqlDataAdapter(cmd);
                    ds1 = new DataSet();
                    adap.Fill(ds1, "rms");

                    grdStudent.DataSource = ds1.Tables[0];
                    grdStudent.DataBind();

                    PanelStudGrid.Visible = true;

                }
                else
                {
                    MySqlCommand cmd = con.CreateCommand();
                    cmd.CommandText = "SELECT * FROM students";

                    adap = new MySqlDataAdapter(cmd);
                    ds1 = new DataSet();
                    adap.Fill(ds1, "rms");

                    grdStudent.DataSource = ds1.Tables[0];
                    grdStudent.DataBind();

                    PanelStudGrid.Visible = true;
                }
            }
            catch (Exception err)
            {

                lblError.Visible = true;
                lblError.Text = "Error: " + err.Message;
            }
        }

        protected void lnkCancel_Click(object sender, EventArgs e)
        {
            PanelStudGrid.Visible = false;
        }

        protected void grdStudent_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                //lstAppointDays.Items.Clear();
                //drpCourse1.Items.Clear();

                string id = grdStudent.SelectedRow.Cells[0].Text;
                txtStudID.Text = id;

                string a = txtStudID.Text;

                MySqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "Select * from students where student_id = '" + a + "' ";

                adap = new MySqlDataAdapter(cmd);
                ds1 = new DataSet();
                adap.Fill(ds1, "students");

                //DataTable dt = ds1.Tables[0];

                ///for (int i = 9; i <= 15; i++)
                //{
                //    foreach (DataRow dr1 in dt.Rows) { lstAppointDays.Items.Add(dr1[i].ToString()); drpAppointDays.Items.Add(dr1[i].ToString()); }
                //}

                dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    txtStudID.Text = Convert.ToString(dr[1]);
                    txtStudentName.Text = Convert.ToString(dr[2] + ", " + dr[3]);
                    txtStudentProgram.Text = Convert.ToString(dr[12]);
                    txtStudentLevel.Text = Convert.ToString(dr[13]);
                    txtSession.Text = Convert.ToString(dr[14]);

                    PanelStudGrid.Visible = false;
                    Panel4.Visible = true;

                    dr.Close();
                }
            }
            catch (Exception err)
            {
                lblError.Visible = true;
                lblError.Text = "Error: " + err.Message;
            }
            con.Close();
            Load_Courses();
        }

        protected void Load_Courses()
        {
            try
            {
                con.Open();

                MySqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "Select * from results where student_id = '" + txtStudID.Text + "' ";

                cmd = new MySqlCommand(cmd.CommandText, con);
                MySqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    lblCse1.Text = dr["course_id1"].ToString();
                    lblCse2.Text = dr["course_id2"].ToString();
                    lblCse3.Text = dr["course_id3"].ToString();
                    lblCse4.Text = dr["course_id4"].ToString();
                    lblCse5.Text = dr["course_id5"].ToString();
                    lblCse6.Text = dr["course_id6"].ToString();
                    lblCse7.Text = dr["course_id7"].ToString();
                    lblCse8.Text = dr["course_id8"].ToString();
                    lblCse9.Text = dr["course_id9"].ToString();
                    lblCse10.Text = dr["course_id10"].ToString();

                    txtScore1.Text = dr["score1"].ToString();
                    txtScore2.Text = dr["score2"].ToString();
                    txtScore3.Text = dr["score3"].ToString();
                    txtScore4.Text = dr["score4"].ToString();
                    txtScore5.Text = dr["score5"].ToString();
                    txtScore6.Text = dr["score6"].ToString();
                    txtScore7.Text = dr["score7"].ToString();
                    txtScore8.Text = dr["score8"].ToString();
                    txtScore9.Text = dr["score9"].ToString();
                    txtScore10.Text = dr["score10"].ToString();

                    DropDownListGrade1.Text = dr["grade1"].ToString();
                    DropDownListGrade2.Text = dr["grade2"].ToString();
                    DropDownListGrade3.Text = dr["grade3"].ToString();
                    DropDownListGrade4.Text = dr["grade4"].ToString();
                    DropDownListGrade5.Text = dr["grade5"].ToString();
                    DropDownListGrade6.Text = dr["grade6"].ToString();
                    DropDownListGrade7.Text = dr["grade7"].ToString();
                    DropDownListGrade8.Text = dr["grade8"].ToString();
                    DropDownListGrade9.Text = dr["grade9"].ToString();
                    DropDownListGrade10.Text = dr["grade10"].ToString();

                    Label1.Text = txtStudID.Text + "'s Result";
                    dr.Close();

                }

            }
            catch (Exception err)
            {
                lblError.Visible = true;
                lblError.Text = "Error: " + err.Message;
            }
            con.Close();
        }

        protected void btnCanc_Click(object sender, EventArgs e)
        {
            Panel4.Visible = false;
            PanelStudGrid.Visible = true;
        }



    }
}
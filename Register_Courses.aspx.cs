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
    public partial class Register_Courses : System.Web.UI.Page
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
                if (txtStudID.Text != "" )
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
            txt_courses();
        }

        protected void Load_Courses()
        {
        try
        {
            con.Open();
            //lstAppointDays.Items.Clear();
            drpCourse1.Items.Clear();
            drpCourse2.Items.Clear();

            //string id = grdStudent.SelectedRow.Cells[0].Text;
            //txtStudID.Text = id;

            //string a = txtStudID.Text;

            MySqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "Select * from courses where course_level = '" + txtStudentLevel.Text + "' ";

            
            drpCourse1.DataSource = cmd.ExecuteReader();
            drpCourse1.DataTextField = "course_id";
            drpCourse1.DataValueField = "course_id";
            drpCourse1.DataBind();

            con.Close();
            con.Open();
            drpCourse2.DataSource = cmd.ExecuteReader();
            drpCourse2.DataTextField = "course_id";
            drpCourse2.DataValueField = "course_id";
            drpCourse2.DataBind();

            con.Close();
            con.Open();
            drpCourse3.DataSource = cmd.ExecuteReader();
            drpCourse3.DataTextField = "course_id";
            drpCourse3.DataValueField = "course_id";
            drpCourse3.DataBind();

            con.Close();
            con.Open();
            drpCourse4.DataSource = cmd.ExecuteReader();
            drpCourse4.DataTextField = "course_id";
            drpCourse4.DataValueField = "course_id";
            drpCourse4.DataBind();

            con.Close();
            con.Open();
            drpCourse5.DataSource = cmd.ExecuteReader();
            drpCourse5.DataTextField = "course_id";
            drpCourse5.DataValueField = "course_id";
            drpCourse5.DataBind();

            con.Close();
            con.Open();
            drpCourse6.DataSource = cmd.ExecuteReader();
            drpCourse6.DataTextField = "course_id";
            drpCourse6.DataValueField = "course_id";
            drpCourse6.DataBind();

            con.Close();
            con.Open();
            drpCourse7.DataSource = cmd.ExecuteReader();
            drpCourse7.DataTextField = "course_id";
            drpCourse7.DataValueField = "course_id";
            drpCourse7.DataBind();

            con.Close();
            con.Open();
            drpCourse8.DataSource = cmd.ExecuteReader();
            drpCourse8.DataTextField = "course_id";
            drpCourse8.DataValueField = "course_id";
            drpCourse8.DataBind();

            con.Close();
            con.Open();
            drpCourse9.DataSource = cmd.ExecuteReader();
            drpCourse9.DataTextField = "course_id";
            drpCourse9.DataValueField = "course_id";
            drpCourse9.DataBind();

            con.Close();
            con.Open();
            drpCourse10.DataSource = cmd.ExecuteReader();
            drpCourse10.DataTextField = "course_id";
            drpCourse10.DataValueField = "course_id";
            drpCourse10.DataBind();

            
            
            

            //adap = new MySqlDataAdapter(cmd);
            //ds1 = new DataSet();
            //adap.Fill(ds1, "courses");            

            //DataTable dt = ds1.Tables[0];

            //for (int i = 4; i <= 13; i++)
            //{
            //    foreach (DataRow dr1 in dt.Rows) { lstAppointDays.Items.Add(dr1[i].ToString()); drpCourse1.Items.Add(dr1[i].ToString()); }
            //}
            //dr = cmd.ExecuteReader();                        
        }
        catch (Exception err)
        {
            lblError.Visible = true;
            lblError.Text = "Error: " + err.Message;
        }
        con.Close();
    }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                txtDateCreated.Text = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");

                if (txtStudID.Text == "") { Label1.Visible = false; lblError.Visible = true; lblError.Text = "Mandatory Field is empty: Student ID"; }
                else if (txtStudentProgram.Text == "") { Label1.Visible = false; lblError.Visible = true; lblError.Text = "Mandatory Field is empty: Student Program"; }
                else if (txtStudentLevel.Text == "") { Label1.Visible = false; lblError.Visible = true; lblError.Text = "Mandatory Field is empty: Student Level"; }
                else if (txtSession.Text == "") { Label1.Visible = false; lblError.Visible = true; lblError.Text = "Mandatory Field is empty: Session"; }
                           
                else
                {
                    txt_courses();

                    cmd = con.CreateCommand();
                    cmd.CommandText = "INSERT INTO registered_courses(stud_id, program, level, session, course_id1, course_id2, course_id3, course_id4, course_id5, course_id6, course_id7, course_id8, course_id9, course_id10, date_created)VALUES(@stud_id, @program, @level, @session, @course_id1, @course_id2, @course_id3, @course_id4, @course_id5, @course_id6, @course_id7, @course_id8, @course_id9, @course_id10, @date_created)";
                    cmd.Parameters.AddWithValue("@stud_id", txtStudID.Text);
                    cmd.Parameters.AddWithValue("@program", txtStudentProgram.Text);
                    cmd.Parameters.AddWithValue("@level", txtStudentLevel.Text);
                    cmd.Parameters.AddWithValue("@session", txtSession.Text);
                    cmd.Parameters.AddWithValue("@course_id1", txtbox1.Text);
                    cmd.Parameters.AddWithValue("@course_id2", txtbox2.Text);
                    cmd.Parameters.AddWithValue("@course_id3", txtbox3.Text);
                    cmd.Parameters.AddWithValue("@course_id4", txtbox4.Text);
                    cmd.Parameters.AddWithValue("@course_id5", txtbox5.Text);
                    cmd.Parameters.AddWithValue("@course_id6", txtbox6.Text);
                    cmd.Parameters.AddWithValue("@course_id7", txtbox7.Text);
                    cmd.Parameters.AddWithValue("@course_id8", txtbox8.Text);
                    cmd.Parameters.AddWithValue("@course_id9", txtbox9.Text);
                    cmd.Parameters.AddWithValue("@course_id10", txtbox10.Text);
                    cmd.Parameters.AddWithValue("@date_created", txtDateCreated.Text);
                   
                    cmd.ExecuteNonQuery();

                    Label1.Text = "New User Registered";

                    txtStudID.Text = "";
                    txtStudentProgram.Text = "";
                    txtStudentLevel.Text = "";
                    txtSession.Text = "";
                    
                    txtDateCreated.Text = "";

                    lblError.Visible = false;
                    Label1.Text = txtStudentName.Text + "'s Courses Registered Successfully";
                }

            }
            catch (Exception err)
            {
                //Label1.Text = ("Error:{0}", err.Message);
                lblError.Visible = true;
                lblError.Text = "Error: " + err.Message;
            }
            con.Close();
        }

        protected void btnCanc_Click(object sender, EventArgs e)
        {
            txtStudID.Text = "";
            txtStudentProgram.Text = "";
            txtStudentLevel.Text = "";
            txtSession.Text = "";
            
            txtDateCreated.Text = "";
        }

     

        protected void txt_courses()
        {
            txtbox1.Text = drpCourse1.SelectedItem.Text.ToString();
            txtbox2.Text = drpCourse2.SelectedItem.Text.ToString();
            txtbox3.Text = drpCourse3.SelectedItem.Text.ToString();
            txtbox4.Text = drpCourse4.SelectedItem.Text.ToString();
            txtbox5.Text = drpCourse5.SelectedItem.Text.ToString();
            txtbox6.Text = drpCourse6.SelectedItem.Text.ToString();
            txtbox7.Text = drpCourse7.SelectedItem.Text.ToString();
            txtbox8.Text = drpCourse8.SelectedItem.Text.ToString();
            txtbox9.Text = drpCourse9.SelectedItem.Text.ToString();
            txtbox10.Text = drpCourse10.SelectedItem.Text.ToString();
         
        }
       
      
    }
}
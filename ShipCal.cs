using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ShipCal
{
    public partial class ShipCal : Form
    {
        public ShipCal()
        {
            InitializeComponent();
        }

        private void bt_cal_Click(object sender, EventArgs e)
        {
            
            //Is Number
            bool boolIsNum;
            string stringIsNum;
            double doubleIsNum;

            //aramex varbiles
            int intWight;
            double doubleWight;
            string stringWight;
            

            //worldship1 varablies
            double doubleSizeLength;
            double doubleSizeWidth;
            double doubleSizeHeight;
            double doubleDimWeight = 0;
            int intDimWeight = 0;
            //string stringDimWeight;


            double doubleWS1Weight;
            int intWS1WeightEc;
            int intWS1WeightEx;
            string stringWS1Ex;
            string stringWS1Ec;


            

            //to chick if the weight is number
            stringIsNum = tb1.Text;
            boolIsNum = double.TryParse(stringIsNum, out doubleIsNum);




            //|######################################################################|
            //|####################  Aramex  Caluclation ############################|
            //|######################################################################|

            if (rb_lbs.Checked)
            {
                //if weight box empty do nothing
                if (tb1.Text == "") { }

             
                else if (!boolIsNum){MessageBox.Show("Plece Enter number");}

                else
                {

                    doubleWight = Convert.ToDouble(tb1.Text); //convert to double
                    doubleWight = doubleWight + 0.4;  //to make the int alwes rounded up
                    doubleWight = Math.Round(doubleWight, MidpointRounding.AwayFromZero); //if it is in half way it wall round up
                    intWight = Convert.ToInt32(doubleWight); //convert to int
                    intWight = ((intWight) * 35) + 30; //calclute the cost
                    stringWight = Convert.ToString(intWight); //convert back to string


                    tb2.Text = stringWight;

                }
            }//end if lbs

            else if (rb_kg.Checked)
            {
                //if weight box empty do nothing
                if (tb1.Text == "") { }


                
                if (!boolIsNum) { MessageBox.Show("Plece Enter number"); }

                else
                {

                    doubleWight = Convert.ToDouble(tb1.Text); //convert to double
                    doubleWight = doubleWight + 0.49; //to make the int alwes rounded up
                    doubleWight = Math.Round(doubleWight, MidpointRounding.AwayFromZero); //if it is in half way it wall round up
                    intWight = Convert.ToInt32(doubleWight); //convert to int
                    intWight = ((intWight) * 70) + 30; //calclute the cost
                    stringWight = Convert.ToString(intWight); //convert back to string

                   tb2.Text = stringWight;

                }
            }//end if kg 

            


            //|######################################################################|
            //|####################  calclute Dim weight ############################|
            //|######################################################################|
            if (cb_dw.Checked) { intDimWeight = 0; }        
                
                //if Dim weight are empty
            else if (tb_dw_l.Text == null || tb_dw_l.Text == "" || tb_dw_w.Text == null || tb_dw_w.Text == "" || tb_dw_h.Text == null || tb_dw_h.Text == "")
            {
                MessageBox.Show("Please Enter valid value in Dimensional Weight, or check the ignore box.",
                "Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Exclamation,
                MessageBoxDefaultButton.Button1);
            }

            else {

                //convert all Dim Weight to double
                doubleSizeLength = Convert.ToDouble(tb_dw_l.Text);
                doubleSizeWidth = Convert.ToDouble(tb_dw_w.Text);
                doubleSizeHeight = Convert.ToDouble(tb_dw_h.Text);
            
                //to calclute DW in double

                if (rb_insh.Checked)
                {
                    doubleDimWeight = (doubleSizeLength * doubleSizeWidth * doubleSizeHeight) / 166;
                }

                else if (rb_cm.Checked) 
                {
                    doubleDimWeight = (doubleSizeLength * doubleSizeWidth * doubleSizeHeight) / 166;
                }

                //to make the int alwes rounded up
                doubleDimWeight = doubleDimWeight + 0.49;

                //if it is in half way it wall round up
                doubleDimWeight = Math.Round(doubleDimWeight, MidpointRounding.AwayFromZero);

                //convert to int
                intDimWeight = Convert.ToInt32(doubleDimWeight);
                                         
            }


            //|######################################################################|
            //|##################  World Ship1  Caluclation #########################|
            //|######################################################################|


            doubleWS1Weight = Convert.ToDouble(tb1.Text); //convert  Weight to double
            doubleWS1Weight = doubleWS1Weight + 0.4; //to make the int alwes rounded up
            doubleWS1Weight = Math.Round(doubleWS1Weight, MidpointRounding.AwayFromZero);  //if it is in half way it wall round up

            //convert to int
            intWS1WeightEx = Convert.ToInt32(doubleWS1Weight);
            intWS1WeightEc = Convert.ToInt32(doubleWS1Weight);

             //convert back to string
            stringWS1Ex = Convert.ToString(intWS1WeightEx);
            stringWS1Ec = Convert.ToString(intDimWeight);

            tb_WS1_Ex.Text = stringWS1Ex;
            tb_WS1_Ec.Text = stringWS1Ec;
            

        }//end cal cliced





        //lable change for wight type  to  "kg"
        private void rb_kg_CheckedChanged(object sender, EventArgs e)
        {
            lb_type.Text = "kg";
        }


        //lable change for wight type  to  "lbs"
        private void rb_lbs_CheckedChanged(object sender, EventArgs e)
        {
            lb_type.Text = "lbs";
        }


        //lable change for size type  to  "cm"
        private void rb_cm_CheckedChanged(object sender, EventArgs e)
        {

            lb_dw_l.Text = "cm";
            lb_dw_w.Text = "cm";
            lb_dw_h.Text = "cm";

        }

        //lable change for size type  to  "inch"
        private void rb_insh_CheckedChanged(object sender, EventArgs e)
        {

            lb_dw_l.Text = "inch";
            lb_dw_w.Text = "inch";
            lb_dw_h.Text = "inch";

        }






        //menu --> new  reset all tool
        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rb_lbs.Checked = true;
            lb_type.Text = "lbs";

            tb1.Text = "";
            tb2.Text = "";
        }


        //about form
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About box1 = new About();
            box1.ShowDialog();
        }


        //help form
        private void howToUseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            help box2 = new help();
            box2.ShowDialog();
        }



        //to detect enter
        private void tb1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.bt_cal_Click(this,e);
            }

        }


        //to perform exite from the menu
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

      


        // to desiable the dimantal wight entry
        private void cb_dw_CheckedChanged(object sender, EventArgs e)
        {
            gb_dw.Enabled = !gb_dw.Enabled;
            gb_st.Enabled = !gb_st.Enabled;
        }

      

      

       

       
        

       
    }
}

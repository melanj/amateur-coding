using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Resources;

namespace StockControl
{
    class validation
    {
        // get/set error message
        private static string errmsg="";

        public static Boolean validate(Control[] sender){           
        int j =0;
        errmsg="";
        foreach( Control i in sender ) { // check all controls in control array
            List<String> validateType = GetValidateType(i); // type validation type
            switch (validateType[0])
            {
                    case "phone":
                        if(isphone(i.Text,false)){
                             i.BackColor = Color.White;
                        }
                        else{
                        i.BackColor = Color.LightPink;
                        errmsg += validateType[1];
                                 j++; 
                        }
                        break;

                    case "email":
                        if(isemail(i.Text,false)){
                             i.BackColor = Color.White;
                        }
                        else{
                        i.BackColor = Color.LightPink;
                        errmsg += validateType[1];
                                 j++;
                        }
                        break;

                    case "number":
                        if (isInt(i.Text))
                        {
                            i.BackColor = Color.White;
                        }
                        else
                        {
                            i.BackColor = Color.LightPink;
                            errmsg += validateType[1];
                            j++;
                        }
                        break;
                    case "money":
                        if (ismoney(i.Text))
                        {
                            i.BackColor = Color.White;
                        }
                        else
                        {
                            i.BackColor = Color.LightPink;
                            errmsg += validateType[1];
                            j++;
                        }
                        break;
                    case "text":
                    default:
                        if (i.Text == ""){
                                 i.BackColor = Color.LightPink;
                                 errmsg += validateType[1];
                                 j++;
                             }
                          else{
                                i.BackColor = Color.White;
                             }
                    break;
                }
            }
            return (j==0); // true if not validation error
        }
        // get validation error message
        public static string getMessage(){
            return "Attention : " + errmsg;
        }

        //check is phone number
        public static bool isphone(string text, bool req){
             return (text.Length!=0)? new Regex(@"^0\d{9}$").IsMatch(text,0):(req==false);
        }

        //check is E-mail address
        public static bool isemail(string text, bool req){
             return (text.Length!=0)? new Regex(@"^\w*(?<=\w)\.?\w+@(?=[\w\.]+\W)\w+(\.\w{2,4})+$").IsMatch(text,0):(req==false);
        }

        //check is number
        public static bool isInt(string text)
        {
            return new Regex(@"^\d+$").IsMatch(text, 0);
        }

        //check is phone local money
        public static bool ismoney(string text)
        {
            return new Regex(@"^\d+|\d+.\d{2}$").IsMatch(text, 0);
        }

        // get validate type by reading control's tag
        private static List<String> GetValidateType(Control ctrl)
        {
            List<String> ctrlData = new List<String>();
            string[] data; 
            try
            {
                   data = ctrl.Tag.ToString().Split(',');
                   ctrlData.Add(data[0]);
                   ctrlData.Add("\n" + data[1]);
            }
            catch (Exception) // if tag is empty
            {
                ctrlData.Add("");
                ctrlData.Add("");
            
            }
            return ctrlData;
        }
    }


    }

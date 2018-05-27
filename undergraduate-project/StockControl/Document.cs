using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Text;
using StockControl.Model;

namespace StockControl
{
    public class Document
    {

        //Print Goods Received Note (GRN)
        public static void GRN(Order order, List<ReceivedItem> items, PrintPageEventArgs e)
        {
            int curpos = 170;
            e.Graphics.DrawImage(global::StockControl.Properties.Resources.GRN, -15, 0); // add GRN image 
            Draw2Coltext("Date", string.Format("{0:MMM dd, yyyy}", DateTime.Now),  ref curpos,e);
            Draw2Coltext("Order No", string.Format("ORD{0:0000}", order.OrderNo), ref curpos, e);
            Draw2Coltext("GRN No", string.Format("GRN{0:0000}", order.OrderNo), ref curpos, e);
            Draw2Coltext("Order Date", string.Format("{0:MMM dd, yyyy}", order.OrderDate), ref curpos, e);
            Draw2Coltext("Supplier", string.Format("{0}", order.Supplier.Name), ref curpos, e);
            Draw5Coltext("Item", "Description", "Ordered", "Delivered", "Remarks", ref curpos, e);
            foreach (ReceivedItem a in items) {
                Draw5Coltext(string.Format("ITM{0:0000}", a.OrderItem.Item.ItemCode), a.OrderItem.Item.Description, a.OrderItem.Quantity.ToString(), a.Quantity.ToString(), "", ref curpos, e);
            }
            curpos += 30;
            e.Graphics.DrawString("Prepared by " + Authentication.GetUser().FullName, new Font("Arial", 12), Brushes.Black, 22, curpos+3);
            curpos += 25;
            e.Graphics.DrawString("Checked by", new Font("Arial", 12), Brushes.Black, 22, curpos + 3);
            curpos += 50;
            e.Graphics.DrawString("\t\t\t\t\t\t\t\t.....................................", new Font("Arial", 12), Brushes.Black, 22, curpos + 3);
            e.Graphics.DrawString("\t\t\t\t\t\t\t\tAuthorized Signature", new Font("Arial", 12), Brushes.Black, 22, curpos + 33);
        }

        //print invoice
        public static void Invoice(Invoice invoice, List<SoldItem> items, PrintPageEventArgs e)
        {
            int curpos = 170;
            e.Graphics.DrawImage(global::StockControl.Properties.Resources.invoice, -15, 0); // add Invoice image 
            Draw2Coltext("Date", string.Format("{0:MMM dd, yyyy}", invoice.InvoiceDate), ref curpos, e);
            Draw2Coltext("Invoice No", string.Format("INV{0:0000}", invoice.InvoiceNo), ref curpos, e);
            Draw2Coltext("Customer", string.Format("{0}", invoice.Customer.Name), ref curpos, e);
            Draw2Coltext("Payment Term", ((invoice.IsCredit) ? "Credit" : "Cash"), ref curpos, e);
            Draw5Coltext("Item", "Description", "Quantity", "Unit Price", "Amount", ref curpos, e);
            foreach (SoldItem a in items)
            {
                Draw5Coltext(string.Format("ITM{0:0000}", a.Item.ItemCode), a.Item.Description, a.Quantity.ToString(), string.Format("{0:f}", a.UnitPrice), string.Format("{0:f}", a.UnitPrice * a.Quantity), ref curpos, e);
            }
            Draw2Coltext("Total", string.Format("Rs. {0:f}", invoice.Total), ref curpos, e);
            curpos += 50;
            e.Graphics.DrawString(".....................................\t\t\t\t\t\t.....................................", new Font("Arial", 12), Brushes.Black, 22, curpos + 3);
            e.Graphics.DrawString("Customer  Signature\t\t\t\t\t\tAuthorized Signature", new Font("Arial", 12), Brushes.Black, 22, curpos + 33);
        }

        //print order
        public static void Order(Order order, List<OrderItem> items, PrintPageEventArgs e)
        {
            int curpos = 170;
            e.Graphics.DrawImage(global::StockControl.Properties.Resources.Porder, -15, 0); // add Order image 
            Draw2Coltext("Date", string.Format("{0:MMM dd, yyyy}", order.OrderDate), ref curpos, e);
            Draw2Coltext("Order No", string.Format("ORD{0:0000}", order.OrderNo), ref curpos, e);
            Draw2Coltext("Supplier", string.Format("{0}", order.Supplier.Name), ref curpos, e);
            Draw5Coltext("Code*", "Item Description", "Quantity", "Unit Price(Rs.)", "Amount(Rs.)", ref curpos, e);
            foreach (OrderItem a in items)
            {
               Draw5Coltext(string.Format("ITM{0:0000}", a.Item.ItemCode), a.Item.Description, a.Quantity.ToString(), a.UnitCost.ToString() ,String.Format("{0:f}",(a.UnitCost * a.Quantity)), ref curpos, e);
            }
            Draw2Coltext("Total", string.Format("Rs. {0:f}", order.Total), ref curpos, e);
            curpos += 25;
            e.Graphics.DrawString("Prepared by  " + Authentication.GetUser().FullName, new Font("Arial", 12), Brushes.Black, 22, curpos + 3);
            curpos += 30;
            e.Graphics.DrawString("Checked by  ", new Font("Arial", 12), Brushes.Black, 22, curpos + 3);
            curpos += 50;
            e.Graphics.DrawString("\t\t\t\t\t\t\t\t.....................................", new Font("Arial", 12), Brushes.Black, 22, curpos + 3);
            e.Graphics.DrawString("\t\t\t\t\t\t\t\tAuthorized Signature", new Font("Arial", 12), Brushes.Black, 22, curpos + 33);
        }

        //print Receipt for payments 
        public static void Receipt(Payment payment, List<Payment> payments, PrintPageEventArgs e)
        {
            int curpos = 240;
            e.Graphics.DrawImage(global::StockControl.Properties.Resources.logo4, -15, 0); // add receipt image 
            e.Graphics.DrawString("Payment Receiving Note", new Font("Arial", 18), Brushes.Black, ((e.MarginBounds.Width / 2) - (e.Graphics.MeasureString("Payment Receiving Note", new Font("Arial", 18)).Width / 2)) + 20, 170);
            Draw2Coltext("Date", string.Format("{0:MMM dd, yyyy}", payment.PaidDate), ref curpos, e);
            Draw2Coltext("Payment Ref#", string.Format("{0:0000}", payment.Ref), ref curpos, e);
            Draw2Coltext("Customer",payment.Invoice.Customer.Name, ref curpos, e);
            Draw2Coltext("Invoice No", string.Format("INV{0:0000}", payment.Invoice.InvoiceNo), ref curpos, e);
            Draw2Coltext("Invoice Date", string.Format("{0:MMM dd, yyyy}", payment.Invoice.InvoiceDate), ref curpos, e);
            Draw2Coltext("Amount (Rs.)", string.Format("{0:f}", payment.Amount), ref curpos, e);
            Draw2Coltext("Balance (Rs.)", string.Format("{0:f}", payment.Balance), ref curpos, e);
            if (payments.Count > 0)
            {
                e.Graphics.DrawString(string.Format("Past payments details for INV{0:0000}", payment.Invoice.InvoiceNo), new Font("Arial", 12), Brushes.Black, 22, curpos += 25);
                curpos += 35;
                Draw3Coltext("#Ref", "Date", "Amount", ref curpos, e);
                foreach (Payment a in payments)
                {
                    Draw3Coltext(string.Format("{0:0000}", a.Ref), string.Format("{0:MMM dd, yyyy}", a.PaidDate), string.Format("{0:f}", a.Amount), ref curpos, e);
                }
            }
            curpos += 50;
            e.Graphics.DrawString("\t\t\t\t\t\t\t\t.....................................", new Font("Arial", 12), Brushes.Black, 22, curpos + 3);
            e.Graphics.DrawString("\t\t\t\t\t\t\t\tAuthorized Signature", new Font("Arial", 12), Brushes.Black, 22, curpos + 33);
        }

        // draw 2 Column row for printing 
        public static int Draw2Coltext(string str1, string str2, ref int top, PrintPageEventArgs e)
        {
            int td = e.MarginBounds.Width;
            e.Graphics.FillRectangle(new SolidBrush(Color.LightGray), new Rectangle(20, top, td / 3, 25));
            e.Graphics.DrawRectangle(Pens.Black, new Rectangle(20, top, td / 3, 25));
            e.Graphics.DrawString(str1, new Font("Arial", 12), Brushes.Black, 22, (top + 3));
            e.Graphics.DrawRectangle(Pens.Black, new Rectangle(td / 3 + 20, top, 2 * td / 3, 25));
            e.Graphics.DrawString(str2, new Font("Arial", 12), Brushes.Black, (td / 3 + 22), (top + 3));
            top = top + 25;
            return top;
        }

        // draw 5 Column row for printing 
        public static int Draw5Coltext(string str1, string str2, string str3, string str4, string str5, ref int top, PrintPageEventArgs e)
        {
            int td = e.MarginBounds.Width;
            e.Graphics.DrawRectangle(Pens.Black, new Rectangle(20, top, td / 10, 25));
            e.Graphics.DrawString(str1, new Font("Arial", 12), Brushes.Black, 22, (top + 3));
            e.Graphics.DrawRectangle(Pens.Black, new Rectangle(td / 10 + 20, top, td / 2, 25));
            e.Graphics.DrawString(str2, new Font("Arial", 12), Brushes.Black, (td / 10 + 2 + 20), (top + 3));
            e.Graphics.DrawRectangle(Pens.Black, new Rectangle((6 * td / 10) + 20, top, td / 10, 25));
            e.Graphics.DrawString(str3, new Font("Arial", 12), Brushes.Black, ((7 * td / 10) - 3) + 20, (top + 3), new StringFormat(StringFormatFlags.DirectionRightToLeft));
            e.Graphics.DrawRectangle(Pens.Black, new Rectangle(7 * td / 10 + 20, top, 3 * td / 20, 25));
            e.Graphics.DrawString(str4, new Font("Arial", 12), Brushes.Black, ((17 * td / 20) - 2) + 20, (top + 3), new StringFormat(StringFormatFlags.DirectionRightToLeft));
            e.Graphics.DrawRectangle(Pens.Black, new Rectangle(17 * td / 20 + 20, top, 3 * td / 20, 25));
            e.Graphics.DrawString(str5, new Font("Arial", 12), Brushes.Black, (td - 2) + 20, (top + 3), new StringFormat(StringFormatFlags.DirectionRightToLeft));
            top = top + 25;
            return top;
        }

        // draw 3 Column row for printing 
        public static int Draw3Coltext(string str1, string str2, string str3, ref int top, PrintPageEventArgs e)
        {
            int td = e.MarginBounds.Width;
            e.Graphics.DrawRectangle(Pens.Black, new Rectangle(20, top, td / 10, 25));
            e.Graphics.DrawString(str1, new Font("Arial", 12), Brushes.Black, 22, (top + 3));
            e.Graphics.DrawRectangle(Pens.Black, new Rectangle(td / 10 + 20, top, td / 5, 25));
            e.Graphics.DrawString(str2, new Font("Arial", 12), Brushes.Black, (td / 10 + 2 + 20), (top + 3));
            e.Graphics.DrawRectangle(Pens.Black, new Rectangle((3 * td / 10) + 20, top, td / 5, 25));
            e.Graphics.DrawString(str3, new Font("Arial", 12), Brushes.Black, ((td / 2) - 3) + 20, (top + 3), new StringFormat(StringFormatFlags.DirectionRightToLeft));
            top = top + 25;
            return top;
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project_Librari_Management.DAL.DAO
{
   public class Invest
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        private double book;

        public double Book
        {
            get { return book; }
            set { book = value; }
        }
        private double paper;

        public double Paper
        {
            get { return paper; }
            set { paper = value; }
        }
        private double ink;

        public double Ink
        {
            get { return ink; }
            set { ink = value; }
        }
        private double equipment;

        public double Equipment
        {
            get { return equipment; }
            set { equipment = value; }
        }
        private double others;

        public double Others
        {
            get { return others; }
            set { others = value; }
        }
        private string date;

        public string Date
        {
            get { return date; }
            set { date = value; }
        }

    }
}

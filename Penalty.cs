using System;
using System.Collections.Generic;
using System.Text;
using Common.Entities;


namespace C_Sharp_PoLiS
{
   public class Penalty : Entities
    {
        public string ? NamePenalty { set; get; }
        public string ? СategoryPenalty { set; get; }
        public string ? DataPenalty { set; get; }
        public string? WhoIssued { set; get; } // Ким виданий 
        public string? WhoMIssued { set; get; }
        public decimal ? PrisePenalty { set; get; }
        //public Policeman policeman;

        //public Сitizen сitizen;

        public Penalty()
        {
            NamePenalty = null;
            СategoryPenalty = null;
            DataPenalty = null;
            WhoIssued = null;
            WhoMIssued = null;
            PrisePenalty = null;
            
        }

        public override string ToString()
        {
            return string.Format($"\t |{Inum}| Назва штрафу: {NamePenalty}|  Категорія: {СategoryPenalty}|  Дата видачі: {DataPenalty}| " +
             $"Ким виданий:  {WhoIssued}|  Кому виданий: {WhoMIssued}|  \n |Розмір штрафу (грн): {PrisePenalty}|.\n");


        }

        public Penalty(string? NamePenalty, string? СategoryPenalty, string? DataPenalty, string? WhoIssued, string? WhoMIssued, decimal? PrisePenalty)
        {
            this.NamePenalty = NamePenalty;
            this.СategoryPenalty = СategoryPenalty;
            this.DataPenalty = DataPenalty;
            this.WhoIssued = WhoIssued;
            this.WhoMIssued = WhoMIssued;
            this.PrisePenalty = PrisePenalty;
        }


    }
}

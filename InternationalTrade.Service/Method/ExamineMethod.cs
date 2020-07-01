using InternationalTrade.Repository.Entities;
using InternationalTrade.Repository.Enums;
using InternationalTrade.Service.Interface;
using InternationalTrade.Service.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternationalTrade.Service.Method
{
    public class ExamineMethod : BaseRepository, IExamine
    {
        public ExamineViewPage Index(string searchString, string Year, int? page)
        {
            ExamineViewPage xx = new ExamineViewPage();
            var Examine = db.Examine.ToList();
            int pageNumber;
            int pageSizeNum;
            int ItemNum;
            int pageNum;
            if (!String.IsNullOrEmpty(searchString))
            {
                Examine = Examine.Where(s => s.CompanyName.Contains(searchString)).ToList();
            }
            if (!String.IsNullOrEmpty(Year))
            {
                Examine = Examine.Where(s => s.ExamineTime.Value.Year == Convert.ToInt32(Year)).ToList();
            }

            pageSizeNum = 5;//每页显示多少条
            ItemNum = Examine.Count();//数据总数
            pageNum = (ItemNum % pageSizeNum) == 0 ? (ItemNum / pageSizeNum) : (ItemNum / pageSizeNum) + 1;//总页数
            if (page == 4)
            {
                pageNumber = pageNum;
            }
            else
            {
                pageNumber = page ?? 1;
            }
            Examine = Examine.OrderBy(x => x.ExamineID).Skip((pageNumber - 1) * pageSizeNum).Take(pageSizeNum).ToList();
            xx.aa = Examine;
            xx.pageNumber = pageNumber;
            xx.pageNumx = pageNum;
            xx.ItemNum = ItemNum.ToString();
            xx.searchstring = searchString;
            xx.Year = Year;
            return xx;
        }

        public ExamineViewPage ExamineDetail(string id)
        {
            Examine ExamineInfo = new Examine();
            ExamineViewPage xx = new ExamineViewPage();

            ExamineInfo = db.Examine.Find(id);

            xx.ExamineID = ExamineInfo.ExamineID;
            xx.CompanyName = ExamineInfo.CompanyName;
            xx.ExamineName = ExamineInfo.ExamineName;
            xx.PayCard = ExamineInfo.PayCard;
            xx.BusinessCard = ExamineInfo.BusinessCard;
            xx.ExamineState = ExamineInfo.ExamineState;
            xx.ExamineTime = ExamineInfo.ExamineTime;
            return xx;
        }

        public void Add(ExamineViewPage ExamineAdd, string id)
        {
            Examine ExamineInfo = new Examine();

            var UserInfo = (from b1 in db.UsersInfo
                            where b1.UserID == id
                            select b1.CompanyName).FirstOrDefault();//寻找当前id的数据

            ExamineInfo.ExamineID = DateTime.Now.ToString("yyyyMMddHHmmss");
            ExamineInfo.ExamineName = ExamineAdd.ExamineName;
            ExamineInfo.CompanyName = UserInfo.FirstOrDefault().ToString();
            ExamineInfo.ExamineState = ExamineState1.ExamineAccept;
            ExamineInfo.ExamineTime = DateTime.Now;
            db.Examine.Add(ExamineInfo);
            db.SaveChanges();
        }

        public void Pass(Array arr)
        {
            for (var i = 0; i < arr.Length; i++)
            {
                var ExamineID = arr.GetValue(i);
                Examine Examine1 = db.Examine.Find(ExamineID);
                if (Examine1.ExamineState == ExamineState1.ExamineAccept)
                {
                    Examine1.ExamineState = ExamineState1.ExaminePass;
                    db.SaveChanges();
                }
            }
        }

        public void NoPass(Array arr)
        {
            for (var i = 0; i < arr.Length; i++)
            {
                var ExamineID = arr.GetValue(i);
                Examine Examine1 = db.Examine.Find(ExamineID);
                if (Examine1.ExamineState == ExamineState1.ExamineAccept)
                {
                    Examine1.ExamineState = ExamineState1.ExamineNoPass;
                    db.SaveChanges();
                }
            }
        }

        public void Pass1(string id)
        {
            Examine Examine1 = db.Examine.Find(id);
            if (Examine1.ExamineState == ExamineState1.ExamineAccept)
            {
                Examine1.ExamineState = ExamineState1.ExaminePass;
                db.SaveChanges();
            }
        }

        public void NoPass1(string id)
        {
            Examine Examine1 = db.Examine.Find(id);
            if (Examine1.ExamineState == ExamineState1.ExamineAccept)
            {
                Examine1.ExamineState = ExamineState1.ExamineNoPass;
                db.SaveChanges();
            }
        }


    }
}

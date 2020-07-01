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
    public class VisaManageMethod:BaseRepository,IVisaManage
    {
        public VisaManageViewPage Index(string searchString, VisaState1 State, int? page)
        {
            VisaManageViewPage xx = new VisaManageViewPage();
            var VisaManage = db.Visa.ToList();
            int pageNumber;
            int pageSizeNum;
            int ItemNum;
            int pageNum;
            if (State == VisaState1.All)
            {
                VisaManage = VisaManage.Where(s => s.VisaName.Contains(searchString)).ToList();
            }
            else
            {
                if (!String.IsNullOrEmpty(searchString))
                {
                    VisaManage = VisaManage.Where(s => s.VisaName.Contains(searchString)).ToList();
                }
                VisaManage = VisaManage.Where(s => s.VisaState == State).ToList();
            }


            pageSizeNum = 5;//每页显示多少条
            ItemNum = VisaManage.Count();//数据总数
            pageNum = (ItemNum % pageSizeNum) == 0 ? (ItemNum / pageSizeNum) : (ItemNum / pageSizeNum) + 1;//总页数
            if (page == 4)
            {
                pageNumber = pageNum;
            }
            else
            {
                pageNumber = page ?? 1;
            }
            VisaManage = VisaManage.OrderBy(x => x.VisaID).Skip((pageNumber - 1) * pageSizeNum).Take(pageSizeNum).ToList();
            xx.aa = VisaManage;
            xx.pageNumber = pageNumber;
            xx.pageNumx = pageNum;
            xx.ItemNum = ItemNum.ToString();
            xx.searchstring = searchString;
            xx.State = State;
            return xx;
        }

        public VisaManageViewPage VisaDetail(string id)
        {
            Visa VisaInfo = db.Visa.Find(id);//寻找当前id的数据
            VisaManageViewPage VisaDetail = new VisaManageViewPage();
            VisaDetail.CompanyName = VisaInfo.CompanyName;
            VisaDetail.VisaName = VisaInfo.VisaName;
            VisaDetail.VisaState = VisaInfo.VisaState;
            VisaDetail.VisaTime = VisaInfo.VisaTime;
            return VisaDetail;
        }


        public String CheckPass(string id)
        {
            var VisaInfo = db.Visa.Where(a => a.VisaID == id).ToList();
            Visa VisaInfo1 = db.Visa.Find(id);//寻找当前id的数据
            VisaInfo1.VisaState = VisaState1.Reviewed;
            db.SaveChanges();
            return "已审核";
        }

        //public String Finish(string id)
        //{
        //    var Embassy = db.Embassy.Where(a => a.EmbassyID == id).ToList();
        //    Embassy EmbassyInfo = db.Embassy.Find(id);//寻找当前id的数据
        //    EmbassyInfo.EmbassyType = "使馆认证完成";
        //    db.SaveChanges();
        //    return "使馆认证完成";
        //}
    }
}

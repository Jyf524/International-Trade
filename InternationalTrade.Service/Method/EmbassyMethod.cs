using InternationalTrade.Repository.Entities;
using InternationalTrade.Repository.Enums;
using InternationalTrade.Service.Interface;
using InternationalTrade.Service.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace InternationalTrade.Service.Method
{
    public class EmbassyMethod:BaseRepository,IEmbassy
    {

        public EmbassyViewPage Index(string searchString, EmbassyState1 State, int? page)
        {
            EmbassyViewPage xx = new EmbassyViewPage();
            var Embassy = db.Embassy.ToList();
            int pageNumber;
            int pageSizeNum;
            int ItemNum;
            int pageNum;

            if (State == EmbassyState1.All)
            {
                Embassy = Embassy.Where(s => s.CompanyName.Contains(searchString)).ToList();
            }
            else
            {
                if (!String.IsNullOrEmpty(searchString))
                {
                    Embassy = Embassy.Where(s => s.CompanyName.Contains(searchString)).ToList();
                }
                Embassy = Embassy.Where(s => s.EmbassyType == State).ToList();
            }

            pageSizeNum = 5;//每页显示多少条
            ItemNum = Embassy.Count();//数据总数
            pageNum = (ItemNum % pageSizeNum) == 0 ? (ItemNum / pageSizeNum) : (ItemNum / pageSizeNum) + 1;//总页数
            if (page == 4)
            {
                pageNumber = pageNum;
            }
            else
            {
                pageNumber = page ?? 1;
            }
            Embassy = Embassy.OrderBy(x => x.EmbassyID).Skip((pageNumber - 1) * pageSizeNum).Take(pageSizeNum).ToList();
            xx.aa = Embassy;
            xx.pageNumber = pageNumber;
            xx.pageNumx = pageNum;
            xx.ItemNum = ItemNum.ToString();
            xx.searchstring = searchString;
            xx.State = State;
            return xx;
        }

        public String Delivery(string id)
        {
            var Embassy = db.Embassy.Where(a => a.EmbassyID == id).ToList();
            Embassy EmbassyInfo = db.Embassy.Find(id);//寻找当前id的数据
            EmbassyInfo.EmbassyType = EmbassyState1.DeliveryOffice;
            db.SaveChanges();
            return "送外办完成";
        }

        public String Finish(string id)
        {
            var Embassy = db.Embassy.Where(a => a.EmbassyID == id).ToList();
            Embassy EmbassyInfo = db.Embassy.Find(id);//寻找当前id的数据
            EmbassyInfo.EmbassyType = EmbassyState1.EmbassyFinish;
            db.SaveChanges();
            return "使馆认证完成";
        }

        public void Add(EmbassyViewPage EmbassyAdd)
        {
            Embassy EmbassyInfo = new Embassy();
            EmbassyInfo.EmbassyID = DateTime.Now.ToString("yyyyMMddHHmmss");
            EmbassyInfo.CompanyName = EmbassyAdd.CompanyName;
            EmbassyInfo.EmbassyType = EmbassyState1.EmbassyAccept;
            EmbassyInfo.EmbassyTime = DateTime.Now;
            db.Embassy.Add(EmbassyInfo);
            db.SaveChanges();
        }

        public String CheckEmbassyInfo(EmbassyViewPage CheckEmbassyInfo)
        {
            var Embassy = db.Embassy.ToList();

            if (String.IsNullOrEmpty(CheckEmbassyInfo.CompanyName))
            {
                return "企业名称不为空";
            }
            string name = "^[a-zA-Z0-9\u4e00-\u9fa5]{1,}$";//字母数字汉字
            Regex rxname = new Regex(name);
            if (!rxname.IsMatch(CheckEmbassyInfo.CompanyName))
            {
                return "请输入正确格式";
            }

            Embassy = Embassy.Where(s => s.CompanyName.Contains(CheckEmbassyInfo.CompanyName)).ToList();

            if(Embassy.Count>0)
            {
                return "该企业已认证";
            }
            
            return "添加成功！";
        }

        public UserManagerViewPage ListDown()
        {
            UserManagerViewPage xx = new UserManagerViewPage();

            var UsersInfos = db.UsersInfo.Where(c => c.UserRole == UsersRole.CompanyUser).ToList();

            xx.aa = UsersInfos;

            return xx;

        }
    }
}

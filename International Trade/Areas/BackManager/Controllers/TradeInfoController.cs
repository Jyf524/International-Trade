using International_Trade.Filters;
using InternationalTrade.Service.Interface;
using InternationalTrade.Service.Method;
using InternationalTrade.Service.Model;
using NPOI.HSSF.UserModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace International_Trade.Areas.BackManager.Controllers
{
    [RoleAuthorization(Message = 3)]
    public class TradeInfoController : Controller
    {
        //
        // GET: /BackManager/TradeInfo/

        public ActionResult TradeInfoIndex()
        {
            return View();
        }

        public ActionResult TradeInfoIndex1(string searchString, string Date, string Place, int? page)
        {
            ITradeInfo IU = new TradeInfoMethod();
            return Json(IU.Index(searchString, Date,Place, page), JsonRequestBehavior.AllowGet);
        }

        public ActionResult Delete(string id = null)
        {
            ITradeInfo IU = new TradeInfoMethod();
            string message = IU.Delete(id);
            if (message != "删除成功！")
            {
                return Json(message);
            }
            return Json("删除成功！");
        }

        public ActionResult TradeInfoAdd()
        {
            return View();
        }

        public ActionResult TradeInfoAdd1(TradeInfoViewPage TradeInfoAdd)
        {
            ITradeInfo IU = new TradeInfoMethod();
            string message = IU.CheckTradeInfo(TradeInfoAdd);
            if (message != "添加成功！")
            {
                return Json(message);
            }

            string fileSave = Server.MapPath("~/upload/");

            try
            {
                HttpFileCollectionBase file = Request.Files;
                if (file.Count != 0)
                {
                    for (int i = 0; i < file.Count; i++)
                    {
                        if (file.AllKeys[i] == "TradeImg")
                        {
                            HttpPostedFileBase file1 = file[i];
                            string extName = Path.GetExtension(file1.FileName);
                            string newName = Guid.NewGuid().ToString() + extName;
                            file1.SaveAs(Path.Combine(fileSave, newName));
                            TradeInfoAdd.TradeImg = "../upload/" + newName;
                        }
                    }
                }
            }
            catch
            {
                return Json("文件过大", JsonRequestBehavior.AllowGet);
            }

            IU.Add(TradeInfoAdd);
            return Json("添加成功");
        }

        public ActionResult TradeInfoDetail(string id = null)
        {
            return View();
        }

        public ActionResult TradeInfoDetail1(string id = null)
        {
            ITradeInfo IU = new TradeInfoMethod();
            return Json(IU.TradeInfoDetail(id));
        }

        public ActionResult TradeInfoDetailSave(TradeInfoViewPage TradeInfoSave, string idd)
        {
            ITradeInfo IT = new TradeInfoMethod();
            string message = IT.CheckTradeInfoSave(TradeInfoSave);
            string fileSave = Server.MapPath("~/upload/");
            if (message != "修改成功！")
            {
                return Json(message);
            }
            try
            {
                HttpFileCollectionBase file = Request.Files;
                if (file.Count != 0)
                {
                    for (int i = 0; i < file.Count; i++)
                    {
                        if (file.AllKeys[i] == "TradeImg")
                        {
                            HttpPostedFileBase file1 = file[i];
                            string extName = Path.GetExtension(file1.FileName);
                            string newName = Guid.NewGuid().ToString() + extName;
                            file1.SaveAs(Path.Combine(fileSave, newName));
                            TradeInfoSave.TradeImg = "../upload/" + newName;
                        }
                    }
                }
            }
            catch
            {
                return Json("文件过大", JsonRequestBehavior.AllowGet);
            }
            IT.Save(TradeInfoSave, idd);
            return Json("修改成功！");
        }

        public ActionResult LeaveMessage()
        {
            return View();
        }

        public ActionResult LeaveMessage1(string id)
        {
            ITradeInfo IT = new TradeInfoMethod();
            return Json(IT.TradeInfoMessage(id), JsonRequestBehavior.AllowGet);
        }

        //导出
        public ActionResult daochu()
        {
            ITradeInfo IT = new TradeInfoMethod();
            //将查询出来的数据转化为对象列表的格式
            var dao = IT.daochu().aa;
            //创建工作簿
            HSSFWorkbook excelBook = new HSSFWorkbook();
            //为工作簿创建工作表并命名
            NPOI.SS.UserModel.ISheet sheet1 = excelBook.CreateSheet("商展信息");
            //创建表头
            NPOI.SS.UserModel.IRow row1 = sheet1.CreateRow(0);//先创建一行用来放表头
            //创建7列并赋值
            row1.CreateCell(0).SetCellValue("企业名称");//第0行，第0列
            row1.CreateCell(1).SetCellValue("商展地址");//第0行，第1列

            //创建数据行
            for (int i = 0; i < dao.Count(); i++)
            {
                //创建行
                NPOI.SS.UserModel.IRow rowTemp = sheet1.CreateRow(i + 1);//因为第一行已经被表头占用了，所以要+1
                rowTemp.CreateCell(0).SetCellValue(dao[i].CompanyName);
                rowTemp.CreateCell(1).SetCellValue(dao[i].TradeAddress);
            }
            //命名文件名
            var fileName = "商展信息" + DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss-ffff") + ".xls";
            //将Excel表格转化为流，输出
            //创建文件流
            MemoryStream bookStream = new MemoryStream();
            //文件写入流（向流中写入字节序列）
            excelBook.Write(bookStream);
            //输出之前调用Seek（偏移量，游标位置) 把0位置指定为开始位置
            bookStream.Seek(0, SeekOrigin.Begin);
            return File(bookStream, "applicationnd.ms-excel", fileName);
        }

    }
}

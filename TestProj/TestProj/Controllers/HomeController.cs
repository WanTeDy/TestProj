using System;
using System.Collections.Generic;
using System.Linq;
using TestProj.Models;
using System.Web.Mvc;
using PagedList;

namespace TestProj.Controllers
{
    public class HomeController : Controller
    {
        private static List<DataModel> data;
        private static List<AnotherDataModel> anotherData;
        private static Int32 pageSize = 20;

        private static List<DataModel> GetData()
        {
            if (data == null)
            {
                data = new List<DataModel>();
                for (int i = 0; i < 200; i++)
                {
                    var tempData = new DataModel
                    {
                        Id = i + 1,
                        DateAndTime = DateTime.Now,
                        OrderId = Faker.RandomNumber.Next(),
                        DomenUrl = "www." + Faker.Internet.DomainName(),
                        CustomerName = Faker.Name.First(),
                        TotalCost = Faker.RandomNumber.Next(),
                        Status = Faker.Lorem.Words(1).FirstOrDefault(),
                        Method = Faker.Lorem.Words(1).FirstOrDefault(),
                    };
                    data.Add(tempData);
                }
            }
            return data;
        }

        private static List<AnotherDataModel> GetAnotherData()
        {
            if (anotherData == null)
            {
                anotherData = new List<AnotherDataModel>();
                for (int i = 0; i < 200; i++)
                {
                    var tempData = new AnotherDataModel
                    {
                        Id = i + 1,
                        DateAndTime = DateTime.Now,
                        OrderId = Faker.RandomNumber.Next(),
                        DomenUrl = "www." + Faker.Internet.DomainName(),
                        CustomerName = Faker.Name.First(),
                        TotalCost = Faker.RandomNumber.Next(),
                        Status = Faker.Lorem.Words(1).FirstOrDefault(),
                        Method = Faker.Lorem.Words(1).FirstOrDefault(),
                        CompanyName = Faker.Company.Name(),
                    };
                    anotherData.Add(tempData);
                }
            }
            return anotherData;
        }

        private static Int32 GetMaxPageNumber<T>(IEnumerable<T> list)
        {
            double res = list.Count() / (double)pageSize;
            return (Int32)Math.Ceiling(res);
        }

        private static Int32 GetPageNumber(int currentPage, int maxPage)
        {
            if (maxPage == 0)
                return 1;
            else if (currentPage > maxPage)
                return maxPage;
            else
                return currentPage;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List(int? id)
        {
            int pageNumber = id ?? 1;
            int maxPage = GetMaxPageNumber(GetData());
            pageNumber = GetPageNumber(pageNumber, maxPage);
            if (Request.IsAjaxRequest())
                return PartialView("_table", GetData().ToPagedList<DataModel>(pageNumber, pageSize));
            return View(GetData().ToPagedList<DataModel>(pageNumber, pageSize));
        }

        [HttpPost]
        public ActionResult DeleteList(DeleteModel dataForDelete)
        {
            if (dataForDelete != null && dataForDelete.Values.Length > 0)
            {
                foreach (var elem in dataForDelete.Values)
                    data.RemoveAll(x => x.Id == elem);
            }
            int maxPage = GetMaxPageNumber(GetData());
            int pageNumber = GetPageNumber(dataForDelete.PageNumber, maxPage);
            return PartialView("_table", GetData().ToPagedList<DataModel>(pageNumber, pageSize));
        }

        public ActionResult AnotherList(int? id)
        {
            int pageNumber = id ?? 1;
            int maxPage = GetMaxPageNumber(GetData());
            pageNumber = GetPageNumber(pageNumber, maxPage);
            if (Request.IsAjaxRequest())
                return PartialView("_anotherTable", GetAnotherData().ToPagedList<AnotherDataModel>(pageNumber, pageSize));
            return View(GetAnotherData().ToPagedList<AnotherDataModel>(pageNumber, pageSize));
        }

        [HttpPost]
        public ActionResult DeleteAnotherList(DeleteModel dataForDelete)
        {
            if (dataForDelete != null && dataForDelete.Values.Length > 0)
            {
                foreach (var elem in dataForDelete.Values)
                    anotherData.RemoveAll(x => x.Id == elem);
            }
            int maxPage = GetMaxPageNumber(GetAnotherData());
            int pageNumber = GetPageNumber(dataForDelete.PageNumber, maxPage);
            return PartialView("_anotherTable", GetAnotherData().ToPagedList<AnotherDataModel>(pageNumber, pageSize));
        }
    }

    public class DeleteModel
    {
        public Int32[] Values { get; set; }
        public Int32 PageNumber { get; set; }
    }
}
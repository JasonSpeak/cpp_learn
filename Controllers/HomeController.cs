using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using dotnetcoretest1.Models;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Data;


namespace dotnetcoretest1.Controllers
{
    public class HomeController : Controller
    {
        
        #region getConn()----获取MySql数据库连接
        //Return:
        //  MySqlConnection mysqlcon
        public MySqlConnection getConn()
        {
            MySqlConnection mysqlconn = new MySqlConnection("Server=localhost;Username=root;Password=19970701zj;Database=hotelbooksys;SslMode=None");
            return mysqlconn;
        }
        #endregion


        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";
            // MySqlConnection mysqlconn = getConn();
            // string selectstring = "insert into  user(userName,userPw,userEmail,creatTime) values('admin','123456','1208694121@qq.com',Now())";
            // mysqlconn.Open();
            // MySqlCommand cmd = mysqlconn.CreateCommand();
            // cmd.CommandText=selectstring;
            // var result = cmd.ExecuteNonQuery();
            // ViewBag.result = result;
            // mysqlconn.Close();
            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";
            return View();
        }

        public IActionResult SignIn()
        {
            ViewBag.message="使用您的账号登入jobskyHotal";
            return View();
        }

        

        public IActionResult SignUp()
        {
            ViewBag.message="填入您的信息注册一个jobskyHotal账号";
            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

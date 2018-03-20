using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using dotnetcoretest1.Models;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Web;
using System.Text;


namespace dotnetcoretest1.Controllers
{
    public class HomeController : Controller
    {
        
        #region 字符串处理为utf8格式
        public string get_uft8(string unicodeString)
        {
            UTF8Encoding utf8 = new UTF8Encoding();
            Byte[] encodedBytes = utf8.GetBytes(unicodeString);
            String decodedString = utf8.GetString(encodedBytes);
            return decodedString;
        }

        #endregion

        #region 数据库操作---getConn();runCommend(string str);getdataTable(string str)
        
        
        //getConn()----获取MySql数据库连接
        //Return:
        //  MySqlConnection mysqlcon
        public MySqlConnection getConn()
        {
            MySqlConnection mysqlconn = new MySqlConnection("Server=localhost;Username=root;Password=19970701zj;Charset=utf8;Database=hotelbooksys;SslMode=None");
            return mysqlconn;
        }
        
        // runCommend(String str)----运行sql命令(insert;update;delete)
        //Return:
        //  int rowNumber
        public int runCommend(string str)
        {
            MySqlConnection conn = getConn();
            MySqlCommand cmd = conn.CreateCommand();
            conn.Open();
            cmd.CommandText = str;
            int rowNumber = cmd.ExecuteNonQuery();
            conn.Close();
            return rowNumber;
            
        }


        //getdataTable(string str)----运行sql命令获取DataTable
        //Return:
        //  DataTable dt
        public DataTable getdataTable(string str)
        {
            MySqlConnection conn = getConn();
            conn.Open();
            MySqlDataAdapter mda = new MySqlDataAdapter(str,conn);
            DataSet mds = new DataSet();
            mda.Fill(mds);
            conn.Close();
            DataTable dt = mds.Tables[0];
            return dt;
        }  
        #endregion


        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";
            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";
            return View();
        }


        #region 登陆模块
        public IActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SignIn(SignInModel model)
        {
            //验证模型是否正确
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            string str = "select userPw from user where userName='" + model.userName + "';";
            DataTable dt = getdataTable(str);
            object obj = dt.Rows[0][0];
            string pw = obj.ToString();
            if(pw==model.userPw)
            {
                
                return Redirect("/");
            }
            else
            {
                return View();
            }
        }

        #endregion

        #region 注册模块
        public IActionResult SignUp()
        {
            ViewBag.message="填入您的信息注册一个jobskyHotal账号";
            
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SignUp(SignUpModel model)
        {
            //验证模型是否正确
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            //注册插入数据库
            string str = "insert into user(userName,userPw,userEmail,userSex,creatTime) values('" + model.userName + "','"+model.userPw+"','"+model.userEmail+"','"+model.userSex+"','"+DateTime.Now.ToString()+"')";
            string utf8str = get_uft8(str);
            try
            {
                runCommend(utf8str);
                return RedirectToAction("signupSucc");
            }
            catch(Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e);
                return RedirectToAction("signupError");
                
            }

            
        }


        public IActionResult signupSucc()
        {
            ViewBag.message="注册成功!";
            // string str="select * from user";
            // DataTable dt = getdataTable(str);
            // ViewBag.dt = dt;
            return View();
        }
        public IActionResult signupError()
        {
            ViewBag.message="注册失败!";
            return View();
        }

        #endregion

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

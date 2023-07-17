using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace WebApplication1.Models
{
    public class LoginViewModel
    {
        [Required]
        [Display(Name = "UseId")]
        public string UseId { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }
    }
    public class AccountModel
    {
        public string PLANT { get; set; }
        public string USERID { get; set; }
        public string USERNAME { get; set; }
        public string PASSWORD { get; set; }
        public string BUSINESSFUNCTION { get; set; }
        public bool ISWINDOW { get; set; }
        public string WINDOWSID { get; set; }
        public string DOMAINNAME { get; set; }
        public bool CHKPASS { get; set; }
        public double EXPIREDAY { get; set; }
    }

    public class MenuListModel
    {
        public string GROUP { get; set; }
        public string SEQUENCE { get; set; }
        public string CODE { get; set; }
        public string LEVEL { get; set; }
        public string NAME { get; set; }
        public string NODE { get; set; }
        public string PARENT { get; set; }
        public string CONTROLLER { get; set; }
        public string VIEW { get; set; }
        public string PARAMERTER { get; set; }
        public string ICON { get; set; }
        public string CREATEDBY { get; set; }
        public string CREATEDTIME { get; set; }
        public string UPDATEDBY { get; set; }
        public string UPDATEDTIME { get; set; }

        public bool ISENABLE { get; set; }
    }
    public class MASTERUSER
    {
        public string PLANTCODE { get; set; }
        public string USERID { get; set; }
        public string USERNAME { get; set; }
        public string DEPARTMENT { get; set; }
        public string EMAIL { get; set; }
        public string PASSWORD { get; set; }
        public string PHONE { get; set; }
        public string BUSINESSFUNCTION { get; set; }
        public string CREATEUSER { get; set; }
        public string CREATEDATE { get; set; }
        public string CHANGEUSER { get; set; }
        public string CHANGEDATE { get; set; }
    }

    public class MASTERDEPARTMENT
    {
        public string ID { get; set; }
        public string NAME { get; set; }
        public string CREATEUSER { get; set; }
        public string CREATEDATE { get; set; }
        public string CHANGEUSER { get; set; }
        public string CHANGEDATE { get; set; }
    }
    public class MASTERGROUP
    {
        public string ID { get; set; }
        public string NAME { get; set; }
        public string CREATEUSER { get; set; }
        public string CREATEDATE { get; set; }
        public string CHANGEUSER { get; set; }
        public string CHANGEDATE { get; set; }
    }
    public class MASTERPLANT
    {
        public string ID { get; set; }
        public string NAME { get; set; }
        public string CREATEUSER { get; set; }
        public string CREATEDATE { get; set; }
        public string CHANGEUSER { get; set; }
        public string CHANGEDATE { get; set; }
    }
}
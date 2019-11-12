using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace shanuMVCUserRoles.Controllers
{
    public class MenuAPIController : ApiController
    {
		AttendanceDBEntitiesNew objapi = new AttendanceDBEntitiesNew();



		// to Search Student Details and display the result
		[HttpGet]
		public IEnumerable<USP_Menu_Select_Result> getMenuCRUDSelect(string menuID, string menuName)
		{
			if (menuID == null)
				menuID = "";
			if (menuName == null)
				menuName = "";		
			return objapi.USP_Menu_Select(menuID, menuName).AsEnumerable();
		}

		// To Insert new Student Details
		[HttpGet]
		public IEnumerable<USP_UserRoles_Select_Result> getUserRoleDetails(string UserRole)
		{
			if (UserRole == null)
				UserRole = "";
			return objapi.USP_UserRoles_Select(UserRole).AsEnumerable();
		}


		// To Insert new Student Details
		[HttpGet]
		public IEnumerable<USP_MenubyUserRole_Select_Result> getMenubyUserRole(string UserRole)
		{
			if (UserRole == null)
				UserRole = "";
			return objapi.USP_MenubyUserRole_Select(UserRole).AsEnumerable();
		}



		// To Insert new Student Details
		[HttpGet]
		public IEnumerable<string> insertMenu(string menuID, string menuName, string parentMenuID, string UserRole, string menuFileName, string MenuURL, string UseYN)
		{
			return objapi.USP_Menu_Insert(menuID, menuName, parentMenuID, UserRole, menuFileName, MenuURL, UseYN).AsEnumerable();
		}

		//to Update Student Details
		[HttpGet]
		public IEnumerable<string> updateMenu(int MenuIdentity, string menuID, string menuName, string parentMenuID, string UserRole, string menuFileName, string MenuURL, string UseYN)
		{
			return objapi.USP_Menu_Update(MenuIdentity, menuID, menuName, parentMenuID, UserRole, menuFileName, MenuURL, UseYN).AsEnumerable();
		}


		//to Update Student Details
		[HttpGet]
		public string deleteMenu(int MenuIdentity)
		{
			objapi.USP_Menu_Delete(MenuIdentity);
			objapi.SaveChanges();
			return "deleted";
		}
	}
}
